/*
# -------------------------------------------------------------------------------
# Author:      Cody Martin <cody.martin@blacklanternsecurity.com>
#
# Created:     10-15-2020
# Copyright:   (c) BLS OPS LLC. 2020
# Licence:     GPL
# -------------------------------------------------------------------------------
*/

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Enter_The_Matrix.Models;
using System.Collections.Generic;
using Enter_The_Matrix.Services;
using Enter_The_Matrix.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Security.Claims;
using Enter_The_Matrix.FactorModels;
using ClosedXML.Excel;
using System.IO;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using System.Drawing;

namespace Enter_The_Matrix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AssessmentsService _assessmentsService;
        private readonly ScenariosService _scenariosService;
        private readonly StepsService _stepsService;
        private readonly SteplatesService _steplatesService;

        public HomeController(
            ILogger<HomeController> logger,
            AssessmentsService assessmentsService,
            ScenariosService scenariosService,
            StepsService stepsService,
            SteplatesService steplatesService)
        {
            _logger = logger;
            _assessmentsService = assessmentsService;
            _scenariosService = scenariosService;
            _stepsService = stepsService;
            _steplatesService = steplatesService;
        }

        #region Index

        public IActionResult Index()
        {
            return RedirectToAction("Login", "Security");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Main()
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }
            return View();
        }

        #endregion

        #region Assessments

        [HttpGet]
        public IActionResult Assessments()
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            List<Assessments> assessmentList = _assessmentsService.GetAllAsync().Result.ToList();
            assessmentList.Reverse();

            return View(assessmentList);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAssessment(string assessmentId)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            // Grab the assessent
            Assessments assessment = _assessmentsService.GetByIdAsync(assessmentId).Result;

            // Clean out scenarios and events
            foreach (var scenarioId in assessment.Scenarios)
            {
                // Grab the scenario
                Models.Scenarios scenario = _scenariosService.GetByIdAsync(scenarioId).Result;
                foreach (var eventId in scenario.Steps)
                {
                    // Clean out events
                    await _stepsService.DeleteAsync(eventId);
                }

                // All events cleaned, remove scenario
                await _scenariosService.DeleteAsync(scenarioId);
            }

            // All scenarios cleaned, remove assessent
            await _assessmentsService.DeleteAsync(assessmentId);

            return RedirectToAction("Assessments", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssessment(string name)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            var identity = User.Identity as ClaimsIdentity;
            string user = "";
            if (identity != null)
            {
                try
                {
                    user = identity.FindFirst("DisplayName").Value;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                }
            }

            Assessments assessment = new Assessments
            {
                Name = name,
                Date = DateTime.Now,
                CreatedBy = user,
                Scenarios = new string[] { }
            };

            Assessments newAssessment = await _assessmentsService.CreateAsync(assessment);

            return RedirectToAction("Scenarios", "Home", new { assessmentId = newAssessment.Id });
        }

        [HttpPost]
        public async Task<IActionResult> EditAssessment(string assessmentId, string name)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            Assessments assessment = _assessmentsService.GetByIdAsync(assessmentId).Result;

            assessment.Name = name;

            await _assessmentsService.UpdateAsync(assessmentId, assessment);

            return RedirectToAction("Scenarios", "Home", new { assessmentId = assessmentId });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAssessment(string assessmentId, string[] scenarioIds)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            Assessments assessment = await _assessmentsService.GetByIdAsync(assessmentId);

            assessment.Scenarios = scenarioIds;

            await _assessmentsService.UpdateAsync(assessmentId, assessment);

            return RedirectToAction("Scenarios", "Home", new { assessmentId = assessmentId });
        }

        #endregion

        #region Scenarios

        [HttpGet]
        public IActionResult Scenarios(string assessmentId)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }
            Assessments assessments = _assessmentsService.GetByIdAsync(assessmentId).Result;
            List<Models.Scenarios> scenarioList = new List<Models.Scenarios>();

            foreach (var scenarioId in assessments.Scenarios)
            {
                scenarioList.Add(_scenariosService.GetByIdAsync(scenarioId).Result);
            }

            AssessmentScenarios assessmentModel = new AssessmentScenarios();
            assessmentModel.scenarioList = scenarioList;
            assessmentModel.assessment = assessments;

            return View(assessmentModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteScenario(string scenarioId, string assessmentId)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            // Remove the steps belonging to the scenario
            Models.Scenarios scenario = _scenariosService.GetByIdAsync(scenarioId).Result;
            foreach (var step in scenario.Steps)
            {
                await _stepsService.DeleteAsync(step);
            }

            // Remove the scenario
            await _scenariosService.DeleteAsync(scenarioId);

            // Remove the scenario ID from the assessment owning it
            Assessments assessment = _assessmentsService.GetByIdAsync(assessmentId).Result;
            List<string> scenarios = assessment.Scenarios.ToList();
            scenarios.Remove(scenarioId);
            assessment.Scenarios = scenarios.ToArray();
            await _assessmentsService.UpdateAsync(assessmentId, assessment);

            // Return to scenario listing for the assessment
            return RedirectToAction("Scenarios", "Home", new { assessmentId = assessmentId });
        }

        [HttpPost]
        public async Task<IActionResult> CreateScenario(string assessmentId, string name)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            var identity = User.Identity as ClaimsIdentity;
            string user = "";
            if (identity != null)
            {
                try
                {
                    user = identity.FindFirst("DisplayName").Value;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                }
            }

            Models.Scenarios scenario = new Models.Scenarios
            {
                Name = name,
                CreatedBy = user,
                Date = DateTime.Now,
                Steps = new string[] { }
            };

            // Create the scenario
            Models.Scenarios newScenario = await _scenariosService.CreateAsync(scenario);

            // Add the scenario to this assessments list of scenarios
            Assessments assessment = await _assessmentsService.GetByIdAsync(assessmentId);
            List<string> scenarioIds = assessment.Scenarios.ToList();
            scenarioIds.Add(newScenario.Id);
            assessment.Scenarios = scenarioIds.ToArray();
            await _assessmentsService.UpdateAsync(assessmentId, assessment);

            return RedirectToAction("Events", "Home", new { scenarioId = newScenario.Id, assessmentId = assessmentId });
        }

        [HttpPost]
        public async Task<IActionResult> EditScenario(string scenarioId, string assessmentId, string name)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            Models.Scenarios scenario = await _scenariosService.GetByIdAsync(scenarioId);

            scenario.Name = name;

            await _scenariosService.UpdateAsync(scenarioId, scenario);

            return RedirectToAction("Events", "Home", new { scenarioId = scenarioId, assessmentId = assessmentId });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateScenario(string scenarioId, string assessmentId, string[] stepIds)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            Models.Scenarios scenario = await _scenariosService.GetByIdAsync(scenarioId);

            scenario.Steps = stepIds;

            await _scenariosService.UpdateAsync(scenarioId, scenario);

            return RedirectToAction("Events", "Home", new { scenarioId = scenarioId, assessmentId = assessmentId });
        }
        #endregion

        #region Events

        [HttpGet]
        public IActionResult Events(string scenarioId, string assessmentId)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }
            Models.Scenarios scenarios = _scenariosService.GetByIdAsync(scenarioId).Result;
            List<Steps> stepList = new List<Steps>();

            foreach (var stepId in scenarios.Steps)
            {
                stepList.Add(_stepsService.GetByIdAsync(stepId).Result);
            }

            Assessments assessment = _assessmentsService.GetByIdAsync(assessmentId).Result;

            ScenarioSteps scenarioModel = new ScenarioSteps();
            scenarioModel.stepList = stepList;
            scenarioModel.scenario = scenarios;
            scenarioModel.assessment = assessment;

            ViewBag.steplates = _steplatesService.GetAllAsync().Result;

            return View(scenarioModel);
        }

        [HttpGet]
        public IActionResult EditEvent(string stepId, string scenarioId, string assessmentId)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }
            ScenarioSteps scenarioModel = new ScenarioSteps();
            scenarioModel.scenario = _scenariosService.GetByIdAsync(scenarioId).Result;

            Steps step = _stepsService.GetByIdAsync(stepId).Result;
            scenarioModel.stepList = new List<Steps>();
            scenarioModel.stepList.Add(step);

            Assessments assessment = _assessmentsService.GetByIdAsync(assessmentId).Result;
            scenarioModel.assessment = assessment;

            ViewBag.sources = new ThreatSources();
            ViewBag.relevances = new Relevance();
            ViewBag.risks = new Risk();
            ViewBag.capabilities = new Capability();
            ViewBag.intents = new Intent();
            ViewBag.targetings = new Targeting();
            ViewBag.initiations = new Initiation();
            ViewBag.adverses = new Adverse();
            ViewBag.impacts = new Impact();
            ViewBag.vulnerabilities = new Vulnerability();
            ViewBag.pervasivenesses = new Pervasiveness();
            ViewBag.severities = new Severity();
            ViewBag.conditions = new Conditions();
            ViewBag.techniques = new Techniques(step.MitreId);

            List<Steps> prev_steps = new List<Steps>();
            foreach (string id in scenarioModel.scenario.Steps)
            {
                if (id != step.Id)
                {
                    prev_steps.Add(_stepsService.GetByIdAsync(id).Result);
                }
            }
            ViewBag.previous_steps = prev_steps;
            EntityTypes types = new EntityTypes();
            ViewBag.entities = types.getTypes();

            return View(scenarioModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(
            string ev,
            string source,
            int capability,
            int intent,
            int targeting,
            string relevance,
            int initiation,
            int severity,
            int pervasiveness,
            int adverse,
            string likelihood,
            int impact,
            string risk,
            string stepId,
            string scenarioId,
            string assessmentId,
            string addedBy,
            DateTime dateCreated,
            string vulnerability = "",
            string mitigation = "",
            string condition = "",
            string entity_type = "",
            string entity_description = "",
            string[] entity_preceded_by = null,
            string mitreId = "")
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }
            if (!ModelState.IsValid) { return BadRequest(); }

            if(entity_description == "" || entity_description == null) { entity_description = " "; }
            Node node = new Node(entity_preceded_by, entity_type, entity_description, risk, stepId);


            Steps step = new Steps()
            {
                Id = stepId,
                Event = ev,
                ThreatSource = source,
                Capability = capability,
                Intent = intent,
                Targeting = targeting,
                Relevance = relevance,
                Initiation = initiation,
                Vulnerability = vulnerability,
                Mitigation = mitigation,
                Severity = severity,
                Condition = condition,
                Pervasiveness = pervasiveness,
                Adverse = adverse,
                Likelihood = likelihood,
                Impact = impact,
                Risk = risk,
                AddedBy = addedBy,
                Date = dateCreated,
                GraphNode = node,
                MitreId = mitreId
            };

            await _stepsService.UpdateAsync(step.Id, step);
            return RedirectToAction("Events", "Home", new { scenarioId = scenarioId, assessmentId = assessmentId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEvent(string stepId, string scenarioId, string assessmentId)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            await _stepsService.DeleteAsync(stepId);

            Models.Scenarios scenario = await _scenariosService.GetByIdAsync(scenarioId);

            List<string> steps = scenario.Steps.ToList();

            steps.Remove(stepId);

            scenario.Steps = steps.ToArray();

            await _scenariosService.UpdateAsync(scenario.Id, scenario);

            return RedirectToAction("Events", "Home", new { scenarioId = scenarioId, assessmentId = assessmentId });
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(string scenarioId, string assessmentId)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            // Create the new empty step
            Steps step = new Steps
            {
                Event = "",
                ThreatSource = "",
                Capability = 0,
                Intent = 0,
                Targeting = 0,
                Relevance = "",
                Initiation = 0,
                Vulnerability = "",
                Severity = 0,
                Condition = "",
                Pervasiveness = 0,
                Mitigation = "",
                Adverse = 0,
                Likelihood = "Very Low",
                Impact = 0,
                Risk = "Very Low",
                Date = DateTime.Now,
                AddedBy = User.FindFirst("DisplayName").Value,
                MitreId = ""
            };

            // Add to the DB
            Steps newStep = await _stepsService.CreateAsync(step);

            // Link the new step to the current scenario
            Models.Scenarios scenario = await _scenariosService.GetByIdAsync(scenarioId);
            List<string> stepIds = scenario.Steps.ToList();
            stepIds.Add(newStep.Id);
            scenario.Steps = stepIds.ToArray();
            await _scenariosService.UpdateAsync(scenario.Id, scenario);

            // Return to step editting
            return RedirectToAction("EditEvent", "Home", new { stepId = newStep.Id, scenarioId = scenario.Id, assessmentId = assessmentId });
        }

        public async Task<IActionResult> ImportEvent(string steplateId, string assessmentId, string scenarioId)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            Steplates steplate = await _steplatesService.GetByIdAsync(steplateId);

            Steps step = new Steps();
            step.AddedBy = User.FindFirst("DisplayName").Value;
            step.Date = DateTime.Now;
            step.Adverse = steplate.Adverse;
            step.Capability = steplate.Capability;
            step.Condition = steplate.Condition;
            step.Event = steplate.Event;
            step.Impact = steplate.Impact;
            step.Initiation = steplate.Initiation;
            step.Intent = steplate.Intent;
            step.Likelihood = steplate.Likelihood;
            step.Mitigation = steplate.Mitigation;
            step.Pervasiveness = steplate.Pervasiveness;
            step.Relevance = steplate.Relevance;
            step.Risk = steplate.Risk;
            step.Severity = steplate.Severity;
            step.Targeting = steplate.Targeting;
            step.ThreatSource = steplate.ThreatSource;
            step.Vulnerability = steplate.Vulnerability;
            step.MitreId = steplate.MitreId;

            // Create the step
            Steps importedStep = await _stepsService.CreateAsync(step);

            // Add to our scenario
            Scenarios scenario = await _scenariosService.GetByIdAsync(scenarioId);
            List<string> stepIds = scenario.Steps.ToList();
            stepIds.Add(importedStep.Id);
            scenario.Steps = stepIds.ToArray();
            await _scenariosService.UpdateAsync(scenario.Id, scenario);

            return RedirectToAction("EditEvent", "Home", new { stepId = importedStep.Id, scenarioId = scenarioId, assessmentId = assessmentId });
        }

        [HttpPost]
        public async Task<IActionResult> TemplateEvent(string stepId)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            Steps step = new Steps();
            step = await _stepsService.GetByIdAsync(stepId);

            Steplates steplate = new Steplates();
            steplate.AddedBy = User.FindFirst("DisplayName").Value;
            steplate.Adverse = step.Adverse;
            steplate.Capability = step.Capability;
            steplate.Date = DateTime.Now;
            steplate.Event = step.Event;
            steplate.Impact = step.Impact;
            steplate.Initiation = step.Initiation;
            steplate.Intent = step.Intent;
            steplate.Likelihood = step.Likelihood;
            steplate.MitreId = step.MitreId;
            steplate.Risk = step.Risk;
            steplate.Targeting = step.Targeting;
            steplate.ThreatSource = step.ThreatSource;

            Node node = new Node(null, step.GraphNode.EntityType, step.GraphNode.EntityDescription, "", "");

            steplate.GraphNode = node;

            steplate.Vulnerability = "";
            steplate.Pervasiveness = 0;
            steplate.Severity = 0;
            steplate.Mitigation = "";
            steplate.Relevance = "";
            steplate.Condition = "";

            Steplates retSteplate = await _steplatesService.CreateAsync(steplate);

            return RedirectToAction("EditSteplate", "Home", new { steplateId = retSteplate.Id });

        }
        
        #endregion

        #region Steplates

        [HttpGet]
        public async Task<IActionResult> Steplates()
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            List<Steplates> steplateList = await _steplatesService.GetAllAsync();

            return View(steplateList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSteplate()
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            Steplates steplate = new Steplates {
                Event = "",
                ThreatSource = "",
                Capability = 0,
                Intent = 0,
                Targeting = 0,
                Relevance = "",
                Initiation = 0,
                Vulnerability = "",
                Severity = 0,
                Condition = "",
                Pervasiveness = 0,
                Mitigation = "",
                Adverse = 0,
                Likelihood = "Very Low",
                Impact = 0,
                Risk = "Very Low",
                Date = DateTime.Now,
                AddedBy = User.FindFirst("DisplayName").Value,
                MitreId = ""
            };

            Steplates retSteplate = await _steplatesService.CreateAsync(steplate);

            return RedirectToAction("EditSteplate", "Home", new { steplateId = retSteplate.Id });
        }

        [HttpGet]
        public async Task<IActionResult> EditSteplate(string steplateId)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            Steplates steplate = await _steplatesService.GetByIdAsync(steplateId);

            ViewBag.sources = new ThreatSources();
            ViewBag.relevances = new Relevance();
            ViewBag.risks = new Risk();
            ViewBag.capabilities = new Capability();
            ViewBag.intents = new Intent();
            ViewBag.targetings = new Targeting();
            ViewBag.initiations = new Initiation();
            ViewBag.adverses = new Adverse();
            ViewBag.impacts = new Impact();
            ViewBag.vulnerabilities = new Vulnerability();
            ViewBag.pervasivenesses = new Pervasiveness();
            ViewBag.severities = new Severity();
            ViewBag.conditions = new Conditions();
            ViewBag.techniques = new Techniques(steplate.MitreId);

            return View(steplate);
        }

        [HttpPost]
        public async Task<IActionResult> EditSteplate(
            string ev,
            string source,
            int capability,
            int intent,
            int targeting,
            string relevance,
            int initiation,
            int severity,
            int pervasiveness,
            int adverse,
            string likelihood,
            int impact,
            string risk,
            string steplateId,
            string addedBy,
            DateTime dateCreated,
            string vulnerability = "",
            string mitigation = "",
            string condition = "",
            string mitreId = ""
        )
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            Steplates steplate = new Steplates
            {
                Event = ev,
                ThreatSource = source,
                Capability = capability,
                Intent = intent,
                Targeting = targeting,
                Relevance = relevance,
                Initiation = initiation,
                Severity = severity,
                Pervasiveness = pervasiveness,
                Adverse = adverse,
                Likelihood = likelihood,
                Impact = impact,
                Risk = risk,
                Id = steplateId,
                AddedBy = addedBy,
                Date = dateCreated,
                Vulnerability = vulnerability,
                Mitigation = mitigation,
                Condition = condition,
                MitreId = mitreId
            };

            await _steplatesService.UpdateAsync(steplateId, steplate);

            return RedirectToAction("Steplates", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSteplate(string steplateId)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            await _steplatesService.DeleteAsync(steplateId);

            return RedirectToAction("Steplates", "Home");
        }

        #endregion

        #region Export
        public async Task<IActionResult> ExportExcel(string filename, string assessmentId)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            Assessments assessment = await _assessmentsService.GetByIdAsync(assessmentId);
            Relevance rel = new Relevance();

            using (var workbook = new XLWorkbook())
            {
                var id = 0;
                var worksheet = workbook.Worksheets.Add("Threat Matrix");

                worksheet.Range("A1:Q2").Style.Alignment.WrapText = true;

                worksheet.Row(1).Height = 65;
                worksheet.Row(2).Height = 100;

                worksheet.Column(1).Width = 8;
                worksheet.Column(2).Width = 16;
                worksheet.Column(3).Width = 4;
                worksheet.Column(4).Width = 20;
                worksheet.Column(5).Width = 15;
                worksheet.Column(6).Width = 4;
                worksheet.Column(7).Width = 4;
                worksheet.Column(8).Width = 4;
                worksheet.Column(9).Width = 8;
                worksheet.Column(10).Width = 5;
                worksheet.Column(11).Width = 15;
                worksheet.Column(12).Width = 15;
                worksheet.Column(13).Width = 4;
                worksheet.Column(14).Width = 25;
                worksheet.Column(15).Width = 5;
                worksheet.Column(16).Width = 12;
                worksheet.Column(17).Width = 4;
                worksheet.Column(18).Width = 12;

                worksheet.Range("A1:D2").Merge();

                worksheet.Cell("E1").Value = "Threat Sources";
                worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Range("E1:E2").Merge();

                worksheet.Cell("F1").Value = "Threat Source Characteristics";
                worksheet.Cell("F1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Range("F1:H1").Merge();

                worksheet.Cell("F2").Value = "Capability (0-10)";
                worksheet.Cell("F2").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                worksheet.Cell("F2").Style.Alignment.SetTextRotation(90);

                worksheet.Cell("G2").Value = "Intent (0-10)";
                worksheet.Cell("G2").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                worksheet.Cell("G2").Style.Alignment.SetTextRotation(90);

                worksheet.Cell("H2").Value = "Targeting (0-10)";
                worksheet.Cell("H2").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                worksheet.Cell("H2").Style.Alignment.SetTextRotation(90);

                worksheet.Cell("I1").Value = "Relevance (Confirmed (C), Expected (E), Anticipated (A), Predicted (Pr), Possible (Po))";
                worksheet.Cell("I1").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                worksheet.Cell("I1").Style.Alignment.SetTextRotation(90);
                worksheet.Range("I1:I2").Merge();

                worksheet.Cell("J1").Value = "Likelihood of Attack Initiation (0-10)";
                worksheet.Cell("J1").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                worksheet.Cell("J1").Style.Alignment.SetTextRotation(90);
                worksheet.Range("J1:J2").Merge();

                worksheet.Cell("K1").Value = "Vulnerabilities";
                worksheet.Cell("K1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Range("K1:K2").Merge();

                worksheet.Cell("L1").Value = "Predisposing Conditions";
                worksheet.Cell("L1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Range("L1:L2").Merge();

                worksheet.Cell("M1").Value = "Severity and Pervasiveness (0-10)";
                worksheet.Cell("M1").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                worksheet.Cell("M1").Style.Alignment.SetTextRotation(90);
                worksheet.Range("M1:M2").Merge();

                worksheet.Cell("N1").Value = "Mitigation";
                worksheet.Cell("N1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Range("N1:N2").Merge();

                worksheet.Cell("O1").Value = "Likelihood Attack Results in Adverse Impact (0-10)";
                worksheet.Cell("O1").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                worksheet.Cell("O1").Style.Alignment.SetTextRotation(90);
                worksheet.Range("O1:O2").Merge();

                worksheet.Cell("P1").Value = "Overall Likelihood (Very Low, Low, Moderate, High, Very High)";
                worksheet.Cell("P1").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                worksheet.Cell("P1").Style.Alignment.SetTextRotation(90);
                worksheet.Range("P1:P2").Merge();

                worksheet.Cell("Q1").Value = "Level of Impact (0-10)";
                worksheet.Cell("Q1").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                worksheet.Cell("Q1").Style.Alignment.SetTextRotation(90);
                worksheet.Range("Q1:Q2").Merge();

                worksheet.Cell("R1").Value = "Risk \n \n (Very Low, Low, Moderate, High, Very High)";
                worksheet.Cell("R1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Range("R1:R2").Merge();

                worksheet.Cell("A3").Value = "ADVERSARIAL";
                worksheet.Cell("A3").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Range("A3:R3").Merge();
                worksheet.Range("A3:R3").Style.Fill.BackgroundColor = XLColor.LightGray;
                worksheet.Range("A3:R3").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

                worksheet.Range("A4:E4").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                worksheet.Range("F4:R4").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                worksheet.Range("F4:R4").Style.Fill.BackgroundColor = XLColor.LightGray;

                worksheet.Cell("A4").Value = "ID";
                worksheet.Cell("A4").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                worksheet.Cell("B4").Value = "MITRE ATT&CK ID";
                worksheet.Cell("B4").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                worksheet.Cell("C4").Value = "Threat Scenario and Events";
                worksheet.Cell("C4").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Range("C4:D4").Merge();

                worksheet.Range("A1:R4").Style.Font.Bold = true;

                worksheet.SheetView.FreezeRows(4);

                int row = 4;

                foreach (var scenarioId in assessment.Scenarios)
                {
                    row++;
                    id++;
                    var subId = 0;
                    Enter_The_Matrix.Models.Scenarios scenario = await _scenariosService.GetByIdAsync(scenarioId);
                    worksheet.Cell(row, 1).Value = id;
                    worksheet.Cell(row, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    
                    worksheet.Cell(row, 3).Value = "Scenario - " + scenario.Name;
                    worksheet.Cell(row, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell(row, 3).Style.Alignment.WrapText = true;
                    worksheet.Range(row, 3, row, 4).Merge();

                    worksheet.Range(row, 5, row, 18).Style.Fill.BackgroundColor = XLColor.LightGray;
                    worksheet.Range(row, 5, row, 18).Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

                    worksheet.Row(row).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    foreach (var eventId in scenario.Steps)
                    {
                        row++;
                        subId++;

                        Steps step = await _stepsService.GetByIdAsync(eventId);

                        double severityAndPervasiveness = 0;
                        if (step.Severity == 0) { severityAndPervasiveness = step.Pervasiveness; }
                        else if (step.Pervasiveness == 0) { severityAndPervasiveness = step.Severity; }
                        else { severityAndPervasiveness = (step.Pervasiveness + step.Severity) / 2; }

                        int sevper = (int)Math.Floor(severityAndPervasiveness);

                        worksheet.Cell(row, 1).Value = id.ToString() + "." + subId.ToString();

                        if (subId.ToString().ElementAt(subId.ToString().Length - 1) == '0')
                        {
                            worksheet.Cell(row, 1).Style.NumberFormat.Format = "0.00";
                        }

                        if (step.MitreId != null && step.MitreId != "")
                        {
                            worksheet.Cell(row, 2).Value = step.MitreId.Replace('/', '.');
                            worksheet.Cell(row, 2).Hyperlink = new XLHyperlink(@"https://attack.mitre.org/techniques/" + step.MitreId + @"/");
                            worksheet.Cell(row, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        }
                        else
                        {
                            worksheet.Cell(row, 2).Value = "N/A";
                            worksheet.Cell(row, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        }

                        worksheet.Cell(row, 4).Value = step.Event;
                        worksheet.Cell(row, 4).Style.Alignment.WrapText = true;

                        worksheet.Cell(row, 5).Value = step.ThreatSource;
                        worksheet.Cell(row, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(row, 6).Value = step.Capability;
                        worksheet.Cell(row, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(row, 7).Value = step.Intent;
                        worksheet.Cell(row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(row, 8).Value = step.Targeting;
                        worksheet.Cell(row, 8).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(row, 9).Value = rel.getAbbreviation(step.Relevance);
                        worksheet.Cell(row, 9).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(row, 10).Value = step.Initiation;
                        worksheet.Cell(row, 10).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        if (step.Vulnerability == null || step.Vulnerability.ToString() == "")
                        {
                            worksheet.Cell(row, 11).Value = "N/A";
                        }
                        else
                        {
                            worksheet.Cell(row, 11).Value = step.Vulnerability;
                        }
                        worksheet.Cell(row, 11).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        worksheet.Cell(row, 11).Style.Alignment.WrapText = true;

                        if (step.Condition == null || step.Condition.ToString() == "")
                        {
                            worksheet.Cell(row, 12).Value = "N/A";
                        }
                        else
                        {
                            worksheet.Cell(row, 12).Value = step.Condition;
                        }
                        worksheet.Cell(row, 12).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        worksheet.Cell(row, 12).Style.Alignment.WrapText = true;

                        if (sevper == 0) { worksheet.Cell(row, 13).Value = "N/A"; }
                        else { worksheet.Cell(row, 13).Value = sevper; }
                        worksheet.Cell(row, 13).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        if (step.Mitigation == null || step.Mitigation.ToString() == "")
                        {
                            worksheet.Cell(row, 14).Value = "None";
                        }
                        else
                        {
                            worksheet.Cell(row, 14).Value = step.Mitigation;
                        }
                        worksheet.Cell(row, 14).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        worksheet.Cell(row, 14).Style.Alignment.WrapText = true;

                        worksheet.Cell(row, 15).Value = step.Adverse;
                        worksheet.Cell(row, 15).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(row, 16).Value = step.Likelihood;
                        worksheet.Cell(row, 16).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        worksheet.Cell(row, 16).Style.Alignment.WrapText = true;

                        worksheet.Cell(row, 17).Value = step.Impact;
                        worksheet.Cell(row, 17).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(row, 18).Value = step.Risk;
                        worksheet.Cell(row, 18).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        worksheet.Cell(row, 18).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        XLColor bgRisk = XLColor.White;
                        if (step.Risk == "Very Low") { bgRisk = XLColor.Aqua; }
                        else if (step.Risk == "Low") { bgRisk = XLColor.Green; }
                        else if (step.Risk == "Moderate") { bgRisk = XLColor.Yellow; }
                        else if (step.Risk == "High") { bgRisk = XLColor.Orange; }
                        else if (step.Risk == "Very High") { bgRisk = XLColor.Red; }
                        worksheet.Cell(row, 18).Style.Fill.BackgroundColor = bgRisk;


                        worksheet.Row(row).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        filename + ".xlsx");
                }
            }
        }
        #endregion

        #region Diagram

        public async Task<IActionResult> Diagram(string scenarioId)
        {
            if (!User.Identity.IsAuthenticated) { return Unauthorized(); }

            List<string> document = new List<string>();

            Scenarios scenario = await _scenariosService.GetByIdAsync(scenarioId);
            List<Steps> stepList = new List<Steps>();
            foreach (string stepId in scenario.Steps)
            {
                stepList.Add(await _stepsService.GetByIdAsync(stepId));
            }

            List<Node> nodeList = new List<Node>();

            // Fixing root node issue
            var first = stepList.First();
            if (
                first.ThreatSource == "Outsider" || 
                first.ThreatSource == "Insider" || 
                first.ThreatSource == "Trusted Insider" || 
                first.ThreatSource == "Privileged Insider"
                )
            {
                nodeList.Add(new Node(null, "malicious-actor", first.ThreatSource, "", "root"));
            }
            else if (
                first.ThreatSource == "Partner Organization" ||
                first.ThreatSource == "Competitor Organization" ||
                first.ThreatSource == "Supplier Organization" ||
                first.ThreatSource == "Customer Organization"
                )
            {
                nodeList.Add(new Node(null, "group", first.ThreatSource, "", "root"));
            }
            else if (
                first.ThreatSource == "Ad Hoc Group" ||
                first.ThreatSource == "Established Group"
                )
            {
                nodeList.Add(new Node(null, "organization", first.ThreatSource, "", "root"));
            }
            else if (
                first.ThreatSource == "Nation State"
                )
            {
                nodeList.Add(new Node(null, "guard-personnel", first.ThreatSource, "", "root"));
            }
            else
            {
                nodeList.Add(new Node(null, "unknown-suspect", first.ThreatSource, "", "root"));
            }

            foreach (var step in stepList)
            {
                for (int i = 0; i < step.GraphNode.ParentId.Length; i++)
                {
                    if (step.GraphNode == null || step.GraphNode.Id == null || step.GraphNode.EntityDescription == null || step.GraphNode.EntityType == null)
                    {
                        break;
                    }
                    else if (step.GraphNode.ParentId[i] == null || step.GraphNode.ParentId[i] == "")
                    {
                        step.GraphNode.ParentId[i] = "root";
                    }
                    else
                    {
                        continue;
                    }
                }

                // Once we've made sure all root replacements have been made, add the node to the list
                nodeList.Add(step.GraphNode);

            }

            // Workaround for graphiz IDs
            int nodeId = 0;
            List<int> sameRanks = new List<int>();
            Dictionary<string, string> graphizIdTable = new Dictionary<string, string>();
            foreach (var node in nodeList)
            {
                if ( nodeId % 3 == 0)
                {
                    sameRanks.Add(nodeId);
                }
                graphizIdTable.Add(node.Id, nodeId++.ToString());
            }
            // setup the document
            document.Add("digraph Scenario {");
            document.Add("");
            document.Add("\tcompound=\"true\";");
            document.Add("\tranksep=1.25;");
            document.Add("\trankdir=\"LR\";");
            document.Add("\tnode[shape=\"plaintext\", fontsize=12, label=\"\"];");
            document.Add("\tbgcolor=\"transparent\";");
            document.Add("\tedge[arrowsize=1, color=\"black\"];");
            document.Add("\tgraph[penwidth=0, labelloc=\"b\"];");
            document.Add("\tnewrank=\"true\";");


            // create the nodes
            foreach (var node in nodeList)
            {
                List<string> wrappingDescription = node.EntityDescription.Split(' ').ToList();
                string wrappedDescription = "";
                int breaker = 4;
                int index = 0;
                foreach (string word in wrappingDescription)
                {
                    wrappedDescription += word + " ";
                    index++;
                    if (index % breaker == 0)
                    {
                        wrappedDescription += @"\n";
                    }
                }
                string idString = graphizIdTable.GetValueOrDefault(node.Id);
                document.Add("\tsubgraph cluster_" + idString + " {");
                document.Add("\t\tlabel=\"" + wrappedDescription + "\";");
                document.Add("\t\t" + idString + " [shape=\"none\",fixedsize=true,height=\"1\",width=\"1\",label=\"\",image=\"/var/matrix/app/enter_the_matrix/wwwroot/icons/" + node.EntityType + ".png\"]");
                document.Add("\t}");
            }

            string sameRank = "{rank=\"same\"; ";
            foreach (int element in sameRanks)
            {
                sameRank += element.ToString() + "; ";
            }
            sameRank += "};";
            document.Add(sameRank);

            // create the Links
            int stepCount = 1;
            foreach (var node in nodeList)
            {
                if (node.ParentId != null)
                {
                    int stepCount2 = stepCount++;
                    foreach (var parent in node.ParentId)
                    {
                        string idString = graphizIdTable.GetValueOrDefault(node.Id);
                        string parentIdString = graphizIdTable.GetValueOrDefault(parent);
                        document.Add("\t" + parentIdString + " -> " + idString + " [label=\"" + stepCount2 + ".\",fontsize=8,color=\"" + node.GetRiskColor() + "\"]");
                    }
                }
            }

            // Label Things
            document.Add("\tlabelloc=\"t\";");
            document.Add("\tfontsize=\"28\";");
            document.Add("\tlabel=\"" + scenario.Name + "\";");
            document.Add("}");

            // write the text to a DOT file
            using (StreamWriter outputFile = new StreamWriter(Path.Combine("wwwroot/graphs/", "graph.dot")))
            {
                foreach (string line in document)
                {
                    outputFile.WriteLine(line);
                }
            }

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = "-c \"dot -Tpng -owwwroot/graphs/Graph.png wwwroot/graphs/graph.dot\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (string.IsNullOrEmpty(error)) { Console.WriteLine(output); }
            else { Console.WriteLine(error); }


            return View(stepList);
        }

        #endregion
    }
}
