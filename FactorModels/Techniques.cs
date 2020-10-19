/*
# -------------------------------------------------------------------------------
# Author:      Cody Martin <cody.martin@blacklanternsecurity.com>
#
# Created:     10-15-2020
# Copyright:   (c) BLS OPS LLC. 2020
# Licence:     GPL
# -------------------------------------------------------------------------------
*/

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enter_The_Matrix.FactorModels
{
    public class Techniques
    {
        public List<string> htmlContent { get; set; }
        private Dictionary<string, string> techniques { get; set; }
        public Techniques(string selected)
        {
            //start off our htmlContent
            htmlContent = new List<string>();
            htmlContent.Add("<div id='accordion'>");

            // Populate our techniques list

            // tactics/pre -- count 15 at time of writing
            #region tactics/pre

            //htmlContent.Add("<optgroup label='PRE-ATT&CK'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark' id='heading-pre'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-pre'>MITRE ATT&CK PRE</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-pre' class='collapse' aria-labelledby='heading-pre' data-parent='#accordion'>");

            // tactics/pre/TA0012 -- count 13 at time of writing
            #region tactic TA0012
            techniques = new Dictionary<string, string>();
            techniques.Add("T1236", "Assess current holdings, needs, and wants");
            techniques.Add("T1229", "Assess KITs/KIQs benefits");
            techniques.Add("T1224", "Assess leadership areas of interest");
            techniques.Add("T1228", "Assign KITs/KIQs into categories");
            techniques.Add("T1226", "Conduct cost/benefit analysis");
            techniques.Add("T1232", "Create implementation plan");
            techniques.Add("T1231", "Create strategic plan");
            techniques.Add("T1230", "Derive intelligence requirements");
            techniques.Add("T1227", "Develop KITs/KIQs");
            techniques.Add("T1234", "Generate analyst intelligence requirements");
            techniques.Add("T1233", "Identify analyst level gaps");
            techniques.Add("T1225", "Identify gap areas");
            techniques.Add("T1235", "Receive operator KITs/KIQs tasking");

            // Add the TA0012->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0012'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0012'>TA0012 - Priority Definition Planning</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0012' class='collapse' aria-labelledby='heading-TA0012' data-parent='#collapse-pre'>");
            
            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            
            #endregion

            // tactics/pre/TA0013 -- count 4 at time of writing
            #region tactic TA0013
            techniques = new Dictionary<string, string>();
            techniques.Add("T1238", "Assign KITs, KIQs, and/or intelligence requirements");
            techniques.Add("T1239", "Receive KITs/KIQs and determine requirements");
            techniques.Add("T1237", "Submit KITs, KIQs and intelligence requirements");
            techniques.Add("T1240", "Task requirements");

            // Add the TA0013->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0013'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0013'>TA0013 - Priority Definition Direction</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0013' class='collapse' aria-labelledby='heading-TA0013' data-parent='#collapse-pre'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            #endregion

            // tactics/pre/TA0014 -- count 5 at time of writing
            #region tactic T0014
            techniques = new Dictionary<string, string>();
            techniques.Add("T1245", "Determine approach/attack vector");
            techniques.Add("T1243", "Determine highest level tactical element");
            techniques.Add("T1242", "Determine operational element");
            techniques.Add("T1244", "Determine secondary level tactical element");
            techniques.Add("T1241", "Determine strategic target");

            // Add the TA0014->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0014'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0014'>TA0014 - Target Selection</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0014' class='collapse' aria-labelledby='heading-TA0014' data-parent='#collapse-pre'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            #endregion

            // tactics/pre/TA0015 -- count 20 at time of writing
            #region tactic TA0015
            techniques = new Dictionary<string, string>();
            techniques.Add("T1247", "Acquire OSINT data sets and information");
            techniques.Add("T1254", "Conduct active scanning");
            techniques.Add("T1253", "Conduct passive scanning");
            techniques.Add("T1249", "Conduct social engineering");
            techniques.Add("T1260", "Determine 3rd party infrastructure services");
            techniques.Add("T1250", "Determine domain and IP address space");
            techniques.Add("T1259", "Determine external network trust dependencies");
            techniques.Add("T1258", "Determine firmware version");
            techniques.Add("T1255", "Discover target logon/email address format");
            techniques.Add("T1262", "Enumerate client configurations");
            techniques.Add("T1261", "Enumerate externally facing software applications technologies, languages, and dependencies");
            techniques.Add("T1248", "Identify job postings and needs/gaps");
            techniques.Add("T1263", "Identify security defensive capabilities");
            techniques.Add("T1246", "Identify supply chains");
            techniques.Add("T1264", "Identify technology usage patterns");
            techniques.Add("T1256", "Identify web defensive services");
            techniques.Add("T1252", "Map network topology");
            techniques.Add("T1257", "Mine technical blogs/forums");
            techniques.Add("T1251", "Obtain domain/IP registration information");
            techniques.Add("T1397", "Spearphishing for Information");

            // Add the TA0015->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0015'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0015'>TA0015 - Technical Information Gathering</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0015' class='collapse' aria-labelledby='heading-TA0015' data-parent='#collapse-pre'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            #endregion

            // tactics/pre/TA0016 -- count 11 at time of writing
            #region tactic T0016
            techniques = new Dictionary<string, string>();
            techniques.Add("T1266", "Acquire OSINT data sets and information");
            techniques.Add("T1275", "Aggregate individual's digital footprint");
            techniques.Add("T1268", "Conduct social engineering");
            techniques.Add("T1272", "Identify business relationships");
            techniques.Add("T1270", "Identify groups/roles");
            techniques.Add("T1267", "Identify job postings and needs/gaps");
            techniques.Add("T1269", "Identify people of interest");
            techniques.Add("T1271", "Identify personnel with an authority/privilege");
            techniques.Add("T1274", "Identify sensitive personnel information");
            techniques.Add("T1265", "Identify supply chains");
            techniques.Add("T1273", "Mine social media");

            // Add the TA0016->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0016'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0016'>TA0016 - People Information Gathering</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0016' class='collapse' aria-labelledby='heading-TA0016' data-parent='#collapse-pre'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            #endregion

            // tactics/pre/TA0017 -- count 11 at time of writing
            #region tactic T0017
            techniques = new Dictionary<string, string>();
            techniques.Add("T1277", "Acquire OSINT data sets and information");
            techniques.Add("T1279", "Conduct social engineering");
            techniques.Add("T1284", "Determine 3rd party infrastructure services");
            techniques.Add("T1285", "Determine centralization of IT management");
            techniques.Add("T1282", "Determine physical locations");
            techniques.Add("T1286", "Dumpster dive");
            techniques.Add("T1280", "Identify business processes/tempo");
            techniques.Add("T1283", "Identify business relationships");
            techniques.Add("T1278", "Identify job postings and needs/gaps");
            techniques.Add("T1276", "Identify supply chains");
            techniques.Add("T1281", "Obtain templates/branding materials");

            // Add the TA0017->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0017'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0017'>TA0017 - Organizational Information Gathering</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0017' class='collapse' aria-labelledby='heading-TA0017' data-parent='#collapse-pre'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            #endregion

            // tactics/pre/TA0018 -- count 9 at time of writing
            #region tactic T0018
            techniques = new Dictionary<string, string>();
            techniques.Add("T1293", "Analyze application security posture");
            techniques.Add("T1288", "Analyze architecture and configuration posture");
            techniques.Add("T1287", "Analyze data collected");
            techniques.Add("T1294", "Analyze hardware/software security defensive capabilities");
            techniques.Add("T1289", "Analyze organizational skillsets and deficiiencies");
            techniques.Add("T1389", "Identify vulnerabilities in third-party software libraries");
            techniques.Add("T1291", "Research relevant vulnerabilities/CVEs");
            techniques.Add("T1290", "Research visibility gap of security vendors");
            techniques.Add("T1292", "Test signature detection");

            // Add the TA0018->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0018'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0018'>TA0018 - Technical Weakness Identification</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0018' class='collapse' aria-labelledby='heading-TA0018' data-parent='#collapse-pre'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            #endregion

            // tactics/pre/TA0019 -- count 3 at time of writing
            #region tactic T0019
            techniques = new Dictionary<string, string>();
            techniques.Add("T1297", "Analyze organizational skillsets and deficiencies");
            techniques.Add("T1295", "Analyze social and business relationships, interests and affiliations");
            techniques.Add("T1296", "Assess targeting options");

            // Add the TA0019->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0019'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0019'>TA0019 - People Weakness Identification</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0019' class='collapse' aria-labelledby='heading-TA0019' data-parent='#collapse-pre'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            #endregion

            // tactics/pre/TA0020 -- count 6 at time of writing
            #region tactic TA0020
            techniques = new Dictionary<string, string>();
            techniques.Add("T1301", "Analyze business processes");
            techniques.Add("T1300", "Analyze organizational skillsets and deficiencies");
            techniques.Add("T1303", "Analyze presence of outsourced capabilities");
            techniques.Add("T1299", "Assess opportunities created by business deals");
            techniques.Add("T1302", "Assess security posture of physical locations");
            techniques.Add("T1298", "Assess vulnerability of 3rd party vendors");

            // Add the TA0020->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0020'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0020'>TA0020 - Organizational Weakness Identification</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0020' class='collapse' aria-labelledby='heading-TA0020' data-parent='#collapse-pre'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            #endregion

            // tactics/pre/TA0021 -- count 20 at time of writing
            #region tactic T0021
            techniques = new Dictionary<string, string>();
            techniques.Add("T1307", "Acquire and/or use 3rd party infrastructure services");
            techniques.Add("T1308", "Acquire and/or use 3rd party software services");
            techniques.Add("T1310", "Acquire or compromise 3rd party signing certificates");
            techniques.Add("T1306", "Anonymity services");
            techniques.Add("T1321", "Common, high volume protocols and software");
            techniques.Add("T1312", "Compromise 3rd party infrastructure to support delivery");
            techniques.Add("T1320", "Data Hiding");
            techniques.Add("T1311", "Dynamic DNS");
            techniques.Add("T1314", "Host-based hiding techniques");
            techniques.Add("T1322", "Misattributable credentials");
            techniques.Add("T1315", "Network-based hiding techniques");
            techniques.Add("T1316", "Non-traditional or less attributable payment options");
            techniques.Add("T1309", "Obfuscate infrastructure");
            techniques.Add("T1318", "Obfuscate operational infrastructure");
            techniques.Add("T1319", "Obfuscate or encrypt code");
            techniques.Add("T1313", "Obfuscation or cryptography");
            techniques.Add("T1390", "OS-vendor provided communication channels");
            techniques.Add("T1305", "Private whois services");
            techniques.Add("T1304", "Proxy/protocol relays");
            techniques.Add("T1317", "Secure and protect infrastructure");

            // Add the TA0021->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0021'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0021'>TA0021 - Adversary OPSEC</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0021' class='collapse' aria-labelledby='heading-TA0021' data-parent='#collapse-pre'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            #endregion

            // tactics/pre/TA0022 -- count 16 at time of writing
            #region tactic T0022
            techniques = new Dictionary<string, string>();
            techniques.Add("T1329", "Acquire and/or use 3rd party infrastructure services");
            techniques.Add("T1330", "Acquire and/or use 3rd party software services");
            techniques.Add("T1332", "Acquire or compromise 3rd party signing certificates");
            techniques.Add("T1328", "Buy domain name");
            techniques.Add("T1334", "Compromise 3rd party infrastructure to support delivery");
            techniques.Add("T1339", "Create backup infrastructure");
            techniques.Add("T1326", "Domain registration hijacking");
            techniques.Add("T1333", "Dynamic DNS");
            techniques.Add("T1336", "Install and configure hardware, network and systems");
            techniques.Add("T1331", "Obfuscate infrastructure");
            techniques.Add("T1396", "Obtain booter/stressor subscription");
            techniques.Add("T1335", "Procure required equipment and software");
            techniques.Add("T1340", "Shadow DNS");
            techniques.Add("T1337", "SSL certificate acquisition for domain");
            techniques.Add("T1338", "SSL certificate acquisition for trust breaking");
            techniques.Add("T1327", "Use multiple DNS infrastructure");

            // Add the TA0022->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0022'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0022'>TA0022 - Establish & Maintain Infrastructure</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0022' class='collapse' aria-labelledby='heading-TA0022' data-parent='#collapse-pre'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            #endregion

            // tactics/pre/TA0023 -- count 6 at time of writing
            #region tactic T0023
            techniques = new Dictionary<string, string>();
            techniques.Add("T1341", "Build social network persona");
            techniques.Add("T1391", "Choose pre-compromised mobile app developer account credentials or signing keys");
            techniques.Add("T1343", "Choose pre-compromised persona and affiliated accounts");
            techniques.Add("T1342", "Develop social network persona digital footprint");
            techniques.Add("T1344", "Friend/Follow/Connect to targets of interest");
            techniques.Add("T1392", "Obtain Apple iOS enterprise distribution key pair and certificate");

            // Add the TA0023->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0023'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0023'>TA0023 - Persona Development</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0023' class='collapse' aria-labelledby='heading-TA0023' data-parent='#collapse-pre'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            #endregion

            // tactics/pre/TA0024 -- count 11 at time of writing
            #region tactic TA0024
            techniques = new Dictionary<string, string>();
            techniques.Add("T1347", "Build and configure delivery systems");
            techniques.Add("T1349", "Build or acquire exploits");
            techniques.Add("T1352", "C2 protocol development");
            techniques.Add("T1354", "Compromise 3rd party or closed-source vulnerability/exploit infromation");
            techniques.Add("T1345", "Create custom payloads");
            techniques.Add("T1355", "Create infected removable media");
            techniques.Add("T1350", "Discover new exploitsand monitor exploit-provider forums");
            techniques.Add("T1348", "Identify resources required to build capabilities");
            techniques.Add("T1346", "Obtain/re-use payloads");
            techniques.Add("T1353", "Post compromise tool development");
            techniques.Add("T1351", "Remote access tool development");

            // Add the TA0024->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0024'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0024'>TA0024 - Build Capabilities</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0024' class='collapse' aria-labelledby='heading-TA0024' data-parent='#collapse-pre'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            #endregion

            // tactics/pre/TA0025 -- count 7 at time of writing
            #region tactic TA0025
            techniques = new Dictionary<string, string>();
            techniques.Add("T1358", "Review logs and residual traces");
            techniques.Add("T1393", "Test ability to evade automated mobile application security analysis performed by app stores");
            techniques.Add("T1356", "Test callback functionality");
            techniques.Add("T1357", "Test malware in various execution environments");
            techniques.Add("T1359", "Test malware to evade detection");
            techniques.Add("T1360", "Test physical access");
            techniques.Add("T1361", "Test signature detection for file upload/email filters");

            // Add the TA0025->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0025'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0025'>TA0025 - Test Capabilities</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0025' class='collapse' aria-labelledby='heading-TA0025' data-parent='#collapse-pre'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            #endregion

            // tactics/pre/TA0026 -- count 6 at time of writing
            #region tactic TA0026
            techniques = new Dictionary<string, string>();
            techniques.Add("T1379", "Disseminate removable media");
            techniques.Add("T1394", "Distribute malicious software development tools");
            techniques.Add("T1364", "Friend/Follow/Connect to targets of interest");
            techniques.Add("T1365", "Hardware of software supply chain implant");
            techniques.Add("T1363", "Port redirector");
            techniques.Add("T1362", "Upload, install and configure software/tools");

            // Add the TA0026->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0026'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0026'>TA0026 - Stage Capabilities</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0026' class='collapse' aria-labelledby='heading-TA0026' data-parent='#collapse-pre'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            #endregion

            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion
            
            // tactics/enterprise -- count 12 at time of writing
            #region tactics/enterprise

            //htmlContent.Add("<optgroup label='Enterprise'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark' id='heading-enterprise'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-enterprise'>MITRE ATT&CK ENTERPRISE</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-enterprise' class='collapse' aria-labelledby='heading-enterprise' data-parent='#accordion'>");

            // tactics/enterprise/TA0001 -- count 19 at time of writing
            #region tactics TA0001

            techniques = new Dictionary<string, string>();
            techniques.Add("T1189", "Drive by compromise");
            techniques.Add("T1190", "Exploit public-facing application");
            techniques.Add("T1133", "External remote services");
            techniques.Add("T1200", "Hardware additions");
            techniques.Add("T1566", "Phishing");
            techniques.Add("T1566/001", "Phishing: Spearphishing attachment");
            techniques.Add("T1566/002", "Phishing: Spearphishing link");
            techniques.Add("T1566/003", "Phishing: Spearphishing via service");
            techniques.Add("T1091", "Replication through removable media");
            techniques.Add("T1195", "Supply chain compromise");
            techniques.Add("T1195/001", "Supply chain compromise: Compromise software dependencies and development tools");
            techniques.Add("T1195/002", "Supply chain compromise: Compromise software supply chain");
            techniques.Add("T1195/003", "Supply chain compromise: Compromise hardware supply chain");
            techniques.Add("T1199", "Trusted relationship");
            techniques.Add("T1078", "Valid accounts");
            techniques.Add("T1078/001", "Valid accounts: Default accounts");
            techniques.Add("T1078/002", "Valid accounts: Domain accounts");
            techniques.Add("T1078/003", "Valid accounts: Local accounts");
            techniques.Add("T1078/004", "Valid accounts: Cloud accounts");

            // Add the TA0001->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0001'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0001'>TA0001 - Initial Access</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0001' class='collapse' aria-labelledby='heading-TA0001' data-parent='#collapse-enterprise'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/enterprise/TA0002 -- count 28 at time of writing
            #region tactics TA0002

            techniques = new Dictionary<string, string>();
            techniques.Add("T1059", "Command and scripting interpreter");
            techniques.Add("T1059/001", "Command and scripting interpreter: PowerShell");
            techniques.Add("T1059/002", "Command and scripting interpreter: AppleScript");
            techniques.Add("T1059/003", "Command and scripting interpreter: Windows Command Shell");
            techniques.Add("T1059/004", "Command and scripting interpreter: Unix Shell");
            techniques.Add("T1059/005", "Command and scripting interpreter: Visual Basic");
            techniques.Add("T1059/006", "Command and scripting interpreter: Python");
            techniques.Add("T1059/007", "Command and scripting interpreter: JavaScript/JScript");
            techniques.Add("T1203", "Exploitation for client execution");
            techniques.Add("T1559", "Inter-process communication");
            techniques.Add("T1559/001", "Inter-process communication: Component Object Model");
            techniques.Add("T1559/002", "Inter-process communication: Dynamic Data Exchange");
            techniques.Add("T1106", "Native API");
            techniques.Add("T1053", "Scheduled task/job");
            techniques.Add("T1053/001", "Scheduled task/job: At (Linux)");
            techniques.Add("T1053/002", "Scheduled task/job: At (Windows)");
            techniques.Add("T1053/003", "Scheduled task/job: Cron");
            techniques.Add("T1053/004", "Scheduled task/job: Launchd");
            techniques.Add("T1053/005", "Scheduled task/job: Scheduled task");
            techniques.Add("T1129", "Shared modules");
            techniques.Add("T1072", "Software development tools");
            techniques.Add("T1569", "System services");
            techniques.Add("T1569/001", "System services: Launchctl");
            techniques.Add("T1569/002", "System services: Service execution");
            techniques.Add("T1204", "User execution");
            techniques.Add("T1204/001", "User execution: Malicious link");
            techniques.Add("T1204/002", "User execution: Malicious file");
            techniques.Add("T1047", "Windows management instrumentation");

            // Add the TA0002->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0002'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0002'>TA0002 - Execution</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0002' class='collapse' aria-labelledby='heading-TA0002' data-parent='#collapse-enterprise'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/enterprise/TA0003 -- count 93 at time of writing
            #region tactics TA0003

            techniques = new Dictionary<string, string>();
            techniques.Add("T1098", "Account manipulation");
            techniques.Add("T1098/001", "Account manipulation: Additional azure service principal credentials");
            techniques.Add("T1098/002", "Account manipulation: Exchange email delegate permissions");
            techniques.Add("T1098/003", "Account manipulation: Add office 365 global administrator role");
            techniques.Add("T1098/004", "Account manipulation: SSH authorized keys");
            techniques.Add("T1197", "BITS jobs");
            techniques.Add("T1547", "Boot or logon autostart exeution");
            techniques.Add("T1547/001", "Boot or logon autostart exeution: Registry run keys/startup folder");
            techniques.Add("T1547/002", "Boot or logon autostart exeution: Authentication package");
            techniques.Add("T1547/003", "Boot or logon autostart exeution: Time providers");
            techniques.Add("T1547/004", "Boot or logon autostart exeution: Winlogon helper DLL");
            techniques.Add("T1547/005", "Boot or logon autostart exeution: Security support provider");
            techniques.Add("T1547/006", "Boot or logon autostart exeution: Kernel modules and extensions");
            techniques.Add("T1547/007", "Boot or logon autostart exeution: Re-opened applications");
            techniques.Add("T1547/008", "Boot or logon autostart exeution: LSASS driver");
            techniques.Add("T1547/009", "Boot or logon autostart exeution: Shortcut modification");
            techniques.Add("T1547/010", "Boot or logon autostart exeution: Port monitors");
            techniques.Add("T1547/011", "Boot or logon autostart exeution: Plist modification");
            techniques.Add("T1037", "Boot or logon initialization scripts");
            techniques.Add("T1037/001", "Boot or logon initialization scripts: Logon script (Windows)");
            techniques.Add("T1037/002", "Boot or logon initialization scripts: Logon script (Linux)");
            techniques.Add("T1037/003", "Boot or logon initialization scripts: Network logon script");
            techniques.Add("T1037/004", "Boot or logon initialization scripts: Rc.common");
            techniques.Add("T1037/005", "Boot or logon initialization scripts: Startup items");
            techniques.Add("T1176", "Browser extensions");
            techniques.Add("T1554", "Compromise client software binary");
            techniques.Add("T1136", "Create account");
            techniques.Add("T1136/001", "Create account: Local account");
            techniques.Add("T1136/002", "Create account: Domain account");
            techniques.Add("T1136/003", "Create account: Cloud account");
            techniques.Add("T1543", "Create or modify system process");
            techniques.Add("T1543/001", "Create or modify system process: Launch agent");
            techniques.Add("T1543/002", "Create or modify system process: Systemd service");
            techniques.Add("T1543/003", "Create or modify system process: Windows service");
            techniques.Add("T1543/004", "Create or modify system process: Launch daemon");
            techniques.Add("T1546", "Event triggered execution");
            techniques.Add("T1546/001", "Event triggered execution: Change default file association");
            techniques.Add("T1546/002", "Event triggered execution: Screensaver");
            techniques.Add("T1546/003", "Event triggered execution: Windows management instrumentation event subscription");
            techniques.Add("T1546/004", "Event triggered execution: .bash_profile and .bashrc");
            techniques.Add("T1546/005", "Event triggered execution: Trap");
            techniques.Add("T1546/006", "Event triggered execution: LC_LOAD_DYLIB addition");
            techniques.Add("T1546/007", "Event triggered execution: Netsh helper DLL");
            techniques.Add("T1546/008", "Event triggered execution: Accessibility features");
            techniques.Add("T1546/009", "Event triggered execution: AppCert DLLs");
            techniques.Add("T1546/010", "Event triggered execution: AppInit DLLs");
            techniques.Add("T1546/011", "Event triggered execution: Application shimming");
            techniques.Add("T1546/012", "Event triggered execution: Image file execution options injection");
            techniques.Add("T1546/013", "Event triggered execution: PowerShell profile");
            techniques.Add("T1546/014", "Event triggered execution: Emond");
            techniques.Add("T1546/015", "Event triggered execution: Component object model hijacking");
            techniques.Add("T1133", "External remote services");
            techniques.Add("T1574", "Hijack execution flow");
            techniques.Add("T1574/001", "Hijack execution flow: DLL search order hijacking");
            techniques.Add("T1574/002", "Hijack execution flow: DLL side-loading");
            techniques.Add("T1574/004", "Hijack execution flow: Dylib hijacking");
            techniques.Add("T1574/005", "Hijack execution flow: Executable installer file permissions weakness");
            techniques.Add("T1574/006", "Hijack execution flow: LD_PRELOAD");
            techniques.Add("T1574/007", "Hijack execution flow: Path interception by PATH environment variable");
            techniques.Add("T1574/008", "Hijack execution flow: Path interception by search order hijacking");
            techniques.Add("T1574/009", "Hijack execution flow: Path interception by unquoted path");
            techniques.Add("T1574/010", "Hijack execution flow: Services file permissions weakness");
            techniques.Add("T1574/011", "Hijack execution flow: Services registry permissions weakness");
            techniques.Add("T1574/012", "Hijack execution flow: COR_PROFILER");
            techniques.Add("T1525", "Implant container image");
            techniques.Add("T1137", "Office application startup");
            techniques.Add("T1137/001", "Office application startup: Office template macros");
            techniques.Add("T1137/002", "Office application startup: Office test");
            techniques.Add("T1137/003", "Office application startup: Outlook forms");
            techniques.Add("T1137/004", "Office application startup: Outlook home page");
            techniques.Add("T1137/005", "Office application startup: Outlook rules");
            techniques.Add("T1137/006", "Office application startup: Add-ins");
            techniques.Add("T1542", "Pre-OS boot");
            techniques.Add("T1542/001", "Pre-OS boot: System firmware");
            techniques.Add("T1542/002", "Pre-OS boot: Component firmware");
            techniques.Add("T1542/003", "Pre-OS boot: Bootkit");
            techniques.Add("T1053", "Scheduled task/job");
            techniques.Add("T1053/001", "Scheduled task/job: At (Linux)");
            techniques.Add("T1053/002", "Scheduled task/job: At (Windows)");
            techniques.Add("T1053/003", "Scheduled task/job: Cron");
            techniques.Add("T1053/004", "Scheduled task/job: Launchd");
            techniques.Add("T1053/005", "Scheduled task/job: Scheduled task");
            techniques.Add("T1505", "Server software component");
            techniques.Add("T1505/001", "Server software component: SQL stored procedures");
            techniques.Add("T1505/002", "Server software component: Transport agent");
            techniques.Add("T1505/003", "Server software component: Web shell");
            techniques.Add("T1205", "Traffic signaling");
            techniques.Add("T1205/001", "Traffic signaling: Port knocking");
            techniques.Add("T1078", "Valid accounts");
            techniques.Add("T1078/001", "Valid accounts: Default accounts");
            techniques.Add("T1078/002", "Valid accounts: Domain accounts");
            techniques.Add("T1078/003", "Valid accounts: Local accounts");
            techniques.Add("T1078/004", "Valid accounts: Cloud accounts");
            
            // Add the TA0003->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0003'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0003'>TA0003 - Persistence</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0003' class='collapse' aria-labelledby='heading-TA0003' data-parent='#collapse-enterprise'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/enterprise/TA0004 -- count 87 at time of writing
            #region tactics TA0004

            techniques = new Dictionary<string, string>();
            techniques.Add("T1548", "Abuse elevation control mechanism");
            techniques.Add("T1548/001", "Abuse elevation control mechanism: Setuid and Setgid");
            techniques.Add("T1548/002", "Abuse elevation control mechanism: Bypass user access control");
            techniques.Add("T1548/003", "Abuse elevation control mechanism: Sudo and sudo control");
            techniques.Add("T1548/004", "Abuse elevation control mechanism: Elevated execution with prompt");
            techniques.Add("T1134", "Access token manipulation");
            techniques.Add("T1134/001", "Access token manipulation: Token impersonation/theft");
            techniques.Add("T1134/002", "Access token manipulation: Create process with token");
            techniques.Add("T1134/003", "Access token manipulation: Make and impersonate token");
            techniques.Add("T1134/004", "Access token manipulation: Parent PID spoofing");
            techniques.Add("T1134/005", "Access token manipulation: SID-history injection");
            techniques.Add("T1547", "Boot or logon autostart execution");
            techniques.Add("T1547/001", "Boot or logon autostart execution: Registry run keys/startup folder");
            techniques.Add("T1547/002", "Boot or logon autostart execution: Authenticaton package");
            techniques.Add("T1547/003", "Boot or logon autostart execution: Time providers");
            techniques.Add("T1547/004", "Boot or logon autostart execution: Winlogon helper DLL");
            techniques.Add("T1547/005", "Boot or logon autostart execution: Security support provider");
            techniques.Add("T1547/006", "Boot or logon autostart execution: Kernel modules and extensions");
            techniques.Add("T1547/007", "Boot or logon autostart execution: Re-opened applications");
            techniques.Add("T1547/008", "Boot or logon autostart execution: LSASS driver");
            techniques.Add("T1547/009", "Boot or logon autostart execution: Shortcut modification");
            techniques.Add("T1547/010", "Boot or logon autostart execution: Port monitors");
            techniques.Add("T1547/011", "Boot or logon autostart execution: Plist modification");
            techniques.Add("T1037", "Boot or logon initialization scripts");
            techniques.Add("T1037/001", "Boot or logon initialization scripts: Logon script (Windows)");
            techniques.Add("T1037/002", "Boot or logon initialization scripts: Logon script (Linux)");
            techniques.Add("T1037/003", "Boot or logon initialization scripts: Network logon script");
            techniques.Add("T1037/004", "Boot or logon initialization scripts: Rc.common");
            techniques.Add("T1037/005", "Boot or logon initialization scripts: Startup items");
            techniques.Add("T1543", "Create or modify system process");
            techniques.Add("T1543/001", "Create or modify system process: Launch agent");
            techniques.Add("T1543/002", "Create or modify system process: Systemd service");
            techniques.Add("T1543/003", "Create or modify system process: Windows service");
            techniques.Add("T1543/004", "Create or modify system process: Launch daemon");
            techniques.Add("T1546", "Event triggered execution");
            techniques.Add("T1546/001", "Event triggered execution: Change default file association");
            techniques.Add("T1546/002", "Event triggered execution: Screensaver");
            techniques.Add("T1546/003", "Event triggered execution: Windows management instrumentation event subscription");
            techniques.Add("T1546/004", "Event triggered execution: .bash_profile and .bashrc");
            techniques.Add("T1546/005", "Event triggered execution: Trap");
            techniques.Add("T1546/006", "Event triggered execution: LC_LOAD_DYLIB addition");
            techniques.Add("T1546/007", "Event triggered execution: Netsh helper DLL");
            techniques.Add("T1546/008", "Event triggered execution: Accessibility features");
            techniques.Add("T1546/009", "Event triggered execution: AppCert DLLs");
            techniques.Add("T1546/010", "Event triggered execution: AppInit DLLs");
            techniques.Add("T1546/011", "Event triggered execution: Application shimming");
            techniques.Add("T1546/012", "Event triggered execution: Image file execution options injection");
            techniques.Add("T1546/013", "Event triggered execution: PowerShell profile");
            techniques.Add("T1546/014", "Event triggered execution: Emond");
            techniques.Add("T1546/015", "Event triggered execution: Component object model hijacking");
            techniques.Add("T1068", "Exploitation for privilege escalation");
            techniques.Add("T1484", "Group policy modification");
            techniques.Add("T1574", "Hijack execution flow");
            techniques.Add("T1574/001", "Hijack execution flow: DLL search order hijacking");
            techniques.Add("T1574/002", "Hijack execution flow: DLL side-loading");
            techniques.Add("T1574/004", "Hijack execution flow: Dylib hijacking");
            techniques.Add("T1574/005", "Hijack execution flow: Executable installer file permissions weakness");
            techniques.Add("T1574/006", "Hijack execution flow: LD_PRELOAD");
            techniques.Add("T1574/007", "Hijack execution flow: Path interception by PATH environment variable");
            techniques.Add("T1574/008", "Hijack execution flow: Path interception by search order hijacking");
            techniques.Add("T1574/009", "Hijack execution flow: Path interception by unquoted path");
            techniques.Add("T1574/010", "Hijack execution flow: Services file permissions weakness");
            techniques.Add("T1574/011", "Hijack execution flow: Services registry permissions weakness");
            techniques.Add("T1574/012", "Hijack execution flow: COR_PROFILER");
            techniques.Add("T1055", "Process injection");
            techniques.Add("T1055/001", "Process injection: Dynamic-link library injection");
            techniques.Add("T1055/002", "Process injection: Portable executable injection");
            techniques.Add("T1055/003", "Process injection: Thread execution hijacking");
            techniques.Add("T1055/004", "Process injection: Asynchronous procedure call");
            techniques.Add("T1055/005", "Process injection: Thread local storage");
            techniques.Add("T1055/008", "Process injection: Ptrace system calls");
            techniques.Add("T1055/009", "Process injection: Proc memory");
            techniques.Add("T1055/011", "Process injection: Extra window memory injection");
            techniques.Add("T1055/012", "Process injection: Process hollowing");
            techniques.Add("T1055/013", "Process injection: Process doppelganging");
            techniques.Add("T1055/014", "Process injection: VDSO hijacking");
            techniques.Add("T1053", "Scheduled task/job");
            techniques.Add("T1053/001", "Scheduled task/job: At (Linux)");
            techniques.Add("T1053/002", "Scheduled task/job: At (Windows)");
            techniques.Add("T1053/003", "Scheduled task/job: Cron");
            techniques.Add("T1053/004", "Scheduled task/job: Launchd");
            techniques.Add("T1053/005", "Scheduled task/job: Scheduled task");
            techniques.Add("T1078", "Valid accounts");
            techniques.Add("T1078/001", "Valid accounts: Default accounts");
            techniques.Add("T1078/002", "Valid accounts: Domain accounts");
            techniques.Add("T1078/003", "Valid accounts: Local accounts");
            techniques.Add("T1078/004", "Valid accounts: Cloud accounts");

            // Add the TA0004->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0004'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0004'>TA0004 - Privilege Escalation</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0004' class='collapse' aria-labelledby='heading-TA0004' data-parent='#collapse-enterprise'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/enterprise/TA0005 -- count 138 at time of writing
            #region tactics TA0005

            techniques = new Dictionary<string, string>();
            techniques.Add("T1548", "Abuse elevation control mechanism");
            techniques.Add("T1548/001", "Abuse elevation control mechanism: Setuid and setgid");
            techniques.Add("T1548/002", "Abuse elevation control mechanism: Bypass user access control");
            techniques.Add("T1548/003", "Abuse elevation control mechanism: Sudo and sudo caching");
            techniques.Add("T1548/004", "Abuse elevation control mechanism: Elevated execution with prompt");
            techniques.Add("T1134", "Access token manipulation");
            techniques.Add("T1134/001", "Access token manipulation: Token impersonation/theft");
            techniques.Add("T1134/002", "Access token manipulation: Create process with token");
            techniques.Add("T1134/003", "Access token manipulation: Make and impersonate token");
            techniques.Add("T1134/004", "Access token manipulation: Parent PID spoofing");
            techniques.Add("T1134/005", "Access token manipulation: SID-history injection");
            techniques.Add("T1197", "BITS jobs");
            techniques.Add("T1140", "Deobfuscate/decode files or information");
            techniques.Add("T1006", "Direct volume access");
            techniques.Add("T1480", "Execution guardrails");
            techniques.Add("T1480/001", "Execution guardrails: Environment keying");
            techniques.Add("T1211", "Exploitation for defense evasion");
            techniques.Add("T1222", "File and directory permissions modificaton");
            techniques.Add("T1222/001", "File and directory permissions modificaton: Windows file and directory permissions modification");
            techniques.Add("T1222/002", "File and directory permissions modificaton: Linux and Mac file and directory permissions modification");
            techniques.Add("T1484", "Group policy modification");
            techniques.Add("T1564", "Hide artifacts");
            techniques.Add("T1564/001", "Hide artifacts: Hidden files and directories");
            techniques.Add("T1564/002", "Hide artifacts: Hidden users");
            techniques.Add("T1564/003", "Hide artifacts: Hidden window");
            techniques.Add("T1564/004", "Hide artifacts: NTFS file attributes");
            techniques.Add("T1564/005", "Hide artifacts: Hidden file system");
            techniques.Add("T1564/006", "Hide artifacts: Run virtual instance");
            techniques.Add("T1574", "Hijack execution flow");
            techniques.Add("T1574/001", "Hijack execution flow: DLL search order hijacking");
            techniques.Add("T1574/002", "Hijack execution flow: DLL side-loading");
            techniques.Add("T1574/004", "Hijack execution flow: Dylib Hijacking");
            techniques.Add("T1574/005", "Hijack execution flow: Executable intaller file permissions weakness");
            techniques.Add("T1574/006", "Hijack execution flow: LD_PRELOAD");
            techniques.Add("T1574/007", "Hijack execution flow: Path interception by PATH environment variable");
            techniques.Add("T1574/008", "Hijack execution flow: Path interception by search order hijacking");
            techniques.Add("T1574/009", "Hijack execution flow: Path interception by unquoted path");
            techniques.Add("T1574/010", "Hijack execution flow: Services file permissions weakness");
            techniques.Add("T1574/011", "Hijack execution flow: Services registry permissions weakness");
            techniques.Add("T1574/012", "Hijack execution flow: COR_PROFILER");
            techniques.Add("T1562", "Impair defenses");
            techniques.Add("T1562/001", "Impair defenses: Disable or modify tools");
            techniques.Add("T1562/002", "Impair defenses: Disable Windows event logging");
            techniques.Add("T1562/003", "Impair defenses: HISTCONTROL");
            techniques.Add("T1562/004", "Impair defenses: Disable or modify system firewall");
            techniques.Add("T1562/006", "Impair defenses: Indicator blocking");
            techniques.Add("T1562/007", "Impair defenses: Disable or modify cloud firewall");
            techniques.Add("T1070", "Indicator removal on host");
            techniques.Add("T1070/001", "Indicator removal on host: Clear Windows event logs");
            techniques.Add("T1070/002", "Indicator removal on host: Clear Linux or Mac system logs");
            techniques.Add("T1070/003", "Indicator removal on host: Clear command history");
            techniques.Add("T1070/004", "Indicator removal on host: File deletion");
            techniques.Add("T1070/005", "Indicator removal on host: Network share connection removal");
            techniques.Add("T1070/006", "Indicator removal on host: Timestomp");
            techniques.Add("T1202", "Indirect command execution");
            techniques.Add("T1036", "Masquerading");
            techniques.Add("T1036/001", "Masquerading: Invalid code signature");
            techniques.Add("T1036/002", "Masquerading: Right-to-Left Override");
            techniques.Add("T1036/003", "Masquerading: Rename system utilities");
            techniques.Add("T1036/004", "Masquerading: Masquerade task or service");
            techniques.Add("T1036/005", "Masquerading: Match legitimate name or location");
            techniques.Add("T1036/006", "Masquerading: Space after filename");
            techniques.Add("T1556", "Modify authentication process");
            techniques.Add("T1556/001", "Modify authentication process: Domain controller authentication");
            techniques.Add("T1556/002", "Modify authentication process: Password filter DLL");
            techniques.Add("T1556/003", "Modify authentication process: Pluggable authentication modules");
            techniques.Add("T1578", "Modify cloud compute infrastructure");
            techniques.Add("T1578/001", "Modify cloud compute infrastructure: Create snapshot");
            techniques.Add("T1578/002", "Modify cloud compute infrastructure: Create cloud instance");
            techniques.Add("T1578/003", "Modify cloud compute infrastructure: Delete cloud instance");
            techniques.Add("T1578/004", "Modify cloud compute infrastructure: Revert cloud instance");
            techniques.Add("T1112", "Modify registry");
            techniques.Add("T1027", "Obfuscated files or information");
            techniques.Add("T1027/001", "Obfuscated files or information: Binary padding");
            techniques.Add("T1027/002", "Obfuscated files or information: Software packing");
            techniques.Add("T1027/003", "Obfuscated files or information: Steganography");
            techniques.Add("T1027/004", "Obfuscated files or information: Compile after delivery");
            techniques.Add("T1027/005", "Obfuscated files or information: Indicator removal from tools");
            techniques.Add("T1542", "Pre-OS boot");
            techniques.Add("T1542/001", "Pre-OS boot: System firmware");
            techniques.Add("T1542/002", "Pre-OS boot: Component firmware");
            techniques.Add("T1542/003", "Pre-OS boot: Bootkit");
            techniques.Add("T1055", "Process injection");
            techniques.Add("T1055/001", "Process injection: Dynamic-link library injection");
            techniques.Add("T1055/002", "Process injection: Portable executable injection");
            techniques.Add("T1055/003", "Process injection: Thread execution hijacking");
            techniques.Add("T1055/004", "Process injection: Asynchronous procedure call");
            techniques.Add("T1055/005", "Process injection: Thread local storage");
            techniques.Add("T1055/008", "Process injection: Ptrace system calls");
            techniques.Add("T1055/009", "Process injection: Proc memory");
            techniques.Add("T1055/011", "Process injection: Extra window memory injection");
            techniques.Add("T1055/012", "Process injection: Process hollowing");
            techniques.Add("T1055/013", "Process injection: Process doppelganging");
            techniques.Add("T1055/014", "Process injection: VDSO hijacking");
            techniques.Add("T1207", "Rogue domain controller");
            techniques.Add("T1014", "Rootkit");
            techniques.Add("T1218", "Signed binary proxy execution");
            techniques.Add("T1218/001", "Signed binary proxy execution: Compiled HTML file");
            techniques.Add("T1218/002", "Signed binary proxy execution: Control panel");
            techniques.Add("T1218/003", "Signed binary proxy execution: CMSTP");
            techniques.Add("T1218/004", "Signed binary proxy execution: InstallUtil");
            techniques.Add("T1218/005", "Signed binary proxy execution: Mshta");
            techniques.Add("T1218/007", "Signed binary proxy execution: Msiexec");
            techniques.Add("T1218/008", "Signed binary proxy execution: Odbcconf");
            techniques.Add("T1218/009", "Signed binary proxy execution: Regsvcs/Regasm");
            techniques.Add("T1218/010", "Signed binary proxy execution: Regsvr32");
            techniques.Add("T1218/011", "Signed binary proxy execution: Rundll32");
            techniques.Add("T1216", "Signed script proxy execution");
            techniques.Add("T1216/001", "Signed script proxy execution: PubPrn");
            techniques.Add("T1553", "Subvert trust controls");
            techniques.Add("T1553/001", "Subvert trust controls: Gatekeeper bypass");
            techniques.Add("T1553/002", "Subvert trust controls: Code signing");
            techniques.Add("T1553/003", "Subvert trust controls: SIP and trust provider hijacking");
            techniques.Add("T1553/004", "Subvert trust controls: Install root certificate");
            techniques.Add("T1221", "Template injection");
            techniques.Add("T1205", "Traffic signaling");
            techniques.Add("T1205/001", "Traffic signaling: Port knocking");
            techniques.Add("T1127", "Trusted developer utilities proxy execution");
            techniques.Add("T1127/001", "Trusted developer utilities proxy execution: MSBuilt");
            techniques.Add("T1535", "Unused/Unsupported cloud regions");
            techniques.Add("T1550", "Use alternative authentication material");
            techniques.Add("T1550/001", "Use alternative authentication material: Application access token");
            techniques.Add("T1550/002", "Use alternative authentication material: Pass the hash");
            techniques.Add("T1550/003", "Use alternative authentication material: Pass the ticket");
            techniques.Add("T1550/004", "Use alternative authentication material: Web session cookie");
            techniques.Add("T1078", "Valid Accounts");
            techniques.Add("T1078/001", "Valid Accounts: Default accounts");
            techniques.Add("T1078/002", "Valid Accounts: Domain accounts");
            techniques.Add("T1078/003", "Valid Accounts: Local accounts");
            techniques.Add("T1078/004", "Valid Accounts: Cloud accounts");
            techniques.Add("T1497", "Virtualization/Sandbox evasion");
            techniques.Add("T1497/001", "Virtualization/Sandbox evasion: System checks");
            techniques.Add("T1497/002", "Virtualization/Sandbox evasion: User activity based checks");
            techniques.Add("T1497/003", "Virtualization/Sandbox evasion: Time based evasion");
            techniques.Add("T1220", "XSL script processing");
            
            // Add the TA0005->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0005'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0005'>TA0005 - Defense Evasion</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0005' class='collapse' aria-labelledby='heading-TA0005' data-parent='#collapse-enterprise'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/enterprise/TA0006 -- count 46 at time of writing
            #region tactics TA0006

            techniques = new Dictionary<string, string>();
            techniques.Add("T1110", "Brute force");
            techniques.Add("T1110/001", "Brute force: Password guessing");
            techniques.Add("T1110/002", "Brute force: Password cracking");
            techniques.Add("T1110/003", "Brute force: Password spraying");
            techniques.Add("T1110/004", "Brute force: Credential stuffing");
            techniques.Add("T1555", "Credentials from password stores");
            techniques.Add("T1555/001", "Credentials from password stores: Keychain");
            techniques.Add("T1555/002", "Credentials from password stores: Securityd memory");
            techniques.Add("T1555/003", "Credentials from password stores: Credentials from web browsers");
            techniques.Add("T1212", "Exploitation for credential access");
            techniques.Add("T1187", "Forced authentication");
            techniques.Add("T1056", "Input capture");
            techniques.Add("T1056/001", "Input capture: Keylogging");
            techniques.Add("T1056/002", "Input capture: GUI input capture");
            techniques.Add("T1056/003", "Input capture: Web portal capture");
            techniques.Add("T1056/004", "Input capture: Credential API hooking");
            techniques.Add("T1557", "Man-in-the-Middle");
            techniques.Add("T1557/001", "Man-in-the-Middle: LLMNR/NBT-NS poisoning and SMB relay");
            techniques.Add("T1556", "Modify authentication process");
            techniques.Add("T1556/001", "Modify authentication process: Domain controller authentication");
            techniques.Add("T1556/002", "Modify authentication process: Password filter DLL");
            techniques.Add("T1556/003", "Modify authentication process: Pluggable authentication modules");
            techniques.Add("T1040", "Network sniffing");
            techniques.Add("T1003", "OS credential dumping");
            techniques.Add("T1003/001", "OS credential dumping: LSASS memory");
            techniques.Add("T1003/002", "OS credential dumping: Security account manager");
            techniques.Add("T1003/003", "OS credential dumping: NTDS");
            techniques.Add("T1003/004", "OS credential dumping: LSA secrets");
            techniques.Add("T1003/005", "OS credential dumping: Cached domain credentials");
            techniques.Add("T1003/006", "OS credential dumping: DCSync");
            techniques.Add("T1003/007", "OS credential dumping: Proc filesystem");
            techniques.Add("T1003/008", "OS credential dumping: /etc/passwd and /etc/shadow");
            techniques.Add("T1528", "Steal application access token");
            techniques.Add("T1558", "Steal or forge kerberos tickets");
            techniques.Add("T1558/001", "Steal or forge kerberos tickets: Golden ticket");
            techniques.Add("T1558/002", "Steal or forge kerberos tickets: Silver ticket");
            techniques.Add("T1558/003", "Steal or forge kerberos tickets: Kerberoasting");
            techniques.Add("T1539", "Steal web session cookie");
            techniques.Add("T1111", "Two-factor authentication interception");
            techniques.Add("T1552", "Unsecured credentials");
            techniques.Add("T1552/001", "Unsecured credentials: Credentials in files");
            techniques.Add("T1552/002", "Unsecured credentials: Credentials in registry");
            techniques.Add("T1552/003", "Unsecured credentials: Bash history");
            techniques.Add("T1552/004", "Unsecured credentials: Private keys");
            techniques.Add("T1552/005", "Unsecured credentials: Cloud instance metadata API");
            techniques.Add("T1552/006", "Unsecured credentials: Group policy preferences");

            // Add the TA0006->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0006'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0006'>TA0006 - Credential Access</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0006' class='collapse' aria-labelledby='heading-TA0006' data-parent='#collapse-enterprise'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/enterprise/TA0007 -- count 35 at time of writing
            #region tactics TA0007

            techniques = new Dictionary<string, string>();
            techniques.Add("T1087", "Account discovery");
            techniques.Add("T1087/001", "Account discovery: Local account");
            techniques.Add("T1087/002", "Account discovery: Domain account");
            techniques.Add("T1087/003", "Account discovery: Email account");
            techniques.Add("T1087/004", "Account discovery: Cloud account");
            techniques.Add("T1010", "Application window discovery");
            techniques.Add("T1217", "Browser bookmark discovery");
            techniques.Add("T1538", "Cloud service dashboard");
            techniques.Add("T1526", "Cloud service discovery");
            techniques.Add("T1482", "Domain trust discovery");
            techniques.Add("T1083", "File and directory discovery");
            techniques.Add("T1046", "Network service scanning");
            techniques.Add("T1135", "Network share discovery");
            techniques.Add("T1040", "Network sniffing");
            techniques.Add("T1201", "Password policy discovery");
            techniques.Add("T1120", "Peripheral device discovery");
            techniques.Add("T1069", "Permission groups discovery");
            techniques.Add("T1069/001", "Permission groups discovery: Local groups");
            techniques.Add("T1069/002", "Permission groups discovery: Domain groups");
            techniques.Add("T1069/003", "Permission groups discovery: Cloud groups");
            techniques.Add("T1057", "Process discovery");
            techniques.Add("T1012", "Query registry");
            techniques.Add("T1018", "Remote system discovery");
            techniques.Add("T1518", "Software discovery");
            techniques.Add("T1518/001", "Software discovery: Security software discovery");
            techniques.Add("T1082", "System information discovery");
            techniques.Add("T1016", "System network configuration discovery");
            techniques.Add("T1049", "System network connections discovery");
            techniques.Add("T1033", "System owner/user discovery");
            techniques.Add("T1007", "System service discovery");
            techniques.Add("T1124", "System time discovery");
            techniques.Add("T1497", "Virtualization/Sandbox evasion");
            techniques.Add("T1497/001", "Virtualization/Sandbox evasion: System checks");
            techniques.Add("T1497/002", "Virtualization/Sandbox evasion: User activity based checks");
            techniques.Add("T1497/003", "Virtualization/Sandbox evasion: Time based evasion");

            // Add the TA0007->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0007'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0007'>TA0007 - Discovery</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0007' class='collapse' aria-labelledby='heading-TA0007' data-parent='#collapse-enterprise'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/enterprise/TA0008 -- count 21 at time of writing
            #region tactics TA0008

            techniques = new Dictionary<string, string>();
            techniques.Add("T1210", "Exploitation of remote services");
            techniques.Add("T1534", "Internal spearphishing");
            techniques.Add("T1570", "Lateral tool transfer");
            techniques.Add("T1563", "Remote service session hijacking");
            techniques.Add("T1563/001", "Remote service session hijacking: SSH hijacking");
            techniques.Add("T1563/002", "Remote service session hijacking: RDP hijacking");
            techniques.Add("T1021", "Remote services");
            techniques.Add("T1021/001", "Remote services: Remote desktop protocol");
            techniques.Add("T1021/002", "Remote services: SMB/Windows admin shares");
            techniques.Add("T1021/003", "Remote services: Distributed component object model");
            techniques.Add("T1021/004", "Remote services: SSH");
            techniques.Add("T1021/005", "Remote services: VNC");
            techniques.Add("T1021/006", "Remote services: Windows remote management");
            techniques.Add("T1091", "Replication through removable media");
            techniques.Add("T1072", "Software deployment tools");
            techniques.Add("T1080", "Taint shared content");
            techniques.Add("T1550", "Use alternate authentication method");
            techniques.Add("T1550/001", "Use alternate authentication method: Application access token");
            techniques.Add("T1550/002", "Use alternate authentication method: Pass the hash");
            techniques.Add("T1550/003", "Use alternate authentication method: Pass the ticket");
            techniques.Add("T1550/004", "Use alternate authentication method: Web session cookie");

            // Add the TA0008->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0008'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0008'>TA0008 - Lateral Movement</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0008' class='collapse' aria-labelledby='heading-TA0008' data-parent='#collapse-enterprise'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/enterprise/TA0009 -- count 31 at time of writing
            #region tactics TA0009

            techniques = new Dictionary<string, string>();
            techniques.Add("T1560", "Archive collected data");
            techniques.Add("T1560/001", "Archive collected data: Archive via utility");
            techniques.Add("T1560/002", "Archive collected data: Archive via library");
            techniques.Add("T1560/003", "Archive collected data: Archive via custom method");
            techniques.Add("T1123", "Audio capture");
            techniques.Add("T1119", "Automated collection");
            techniques.Add("T1115", "Clipboard data");
            techniques.Add("T1530", "Data from cloud storage object");
            techniques.Add("T1213", "Data from information repositories");
            techniques.Add("T1213/001", "Data from information repositories: Confluence");
            techniques.Add("T1213/002", "Data from information repositories: Sharepoint");
            techniques.Add("T1005", "Data from local system");
            techniques.Add("T1039", "Data from network shared drive");
            techniques.Add("T1025", "Data from removable media");
            techniques.Add("T1074", "Data staged");
            techniques.Add("T1074/001", "Data staged: Local data staging");
            techniques.Add("T1074/002", "Data staged: Remote data staging");
            techniques.Add("T1114", "Email collection");
            techniques.Add("T1114/001", "Email collection: Local email collection");
            techniques.Add("T1114/002", "Email collection: Remote email collection");
            techniques.Add("T1114/003", "Email collection: Email forwarding rule");
            techniques.Add("T1056", "Input capture");
            techniques.Add("T1056/001", "Input capture: Keylogging");
            techniques.Add("T1056/002", "Input capture: GUI input capture");
            techniques.Add("T1056/003", "Input capture: Web portal capture");
            techniques.Add("T1056/004", "Input capture: Credential API hooking");
            techniques.Add("T1185", "Man in the browser");
            techniques.Add("T1557", "Man-in-the-Middle");
            techniques.Add("T1557/001", "Man-in-the-Middle: LLMNR/NBT-NS poisoning and SMB relay");
            techniques.Add("T1113", "Screen capture");
            techniques.Add("T1125", "Video capture");

            // Add the TA0009->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0009'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0009'>TA0009 - Collection</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0009' class='collapse' aria-labelledby='heading-TA0009' data-parent='#collapse-enterprise'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/enterprise/TA0011 -- count 36 at time of writing
            #region tactics TA0011

            techniques = new Dictionary<string, string>();
            techniques.Add("T1071", "Application layer protocol");
            techniques.Add("T1071/001", "Application layer protocol: Web protocols");
            techniques.Add("T1071/002", "Application layer protocol: File transfer protocols");
            techniques.Add("T1071/003", "Application layer protocol: Mail protocols");
            techniques.Add("T1071/004", "Application layer protocol: DNS");
            techniques.Add("T1092", "Communication through removable media");
            techniques.Add("T1132", "Data encoding");
            techniques.Add("T1132/001", "Data encoding: Standard encoding");
            techniques.Add("T1132/002", "Data encoding: Non-standard encoding");
            techniques.Add("T1001", "Data obfuscation");
            techniques.Add("T1001/001", "Data obfuscation: Junk data");
            techniques.Add("T1001/002", "Data obfuscation: Steganography");
            techniques.Add("T1001/003", "Data obfuscation: Protocol impersonation");
            techniques.Add("T1568", "Dynamic resolution");
            techniques.Add("T1568/001", "Dynamic resolution: Fast flux DNS");
            techniques.Add("T1568/002", "Dynamic resolution: Domain generation algorithms");
            techniques.Add("T1568/003", "Dynamic resolution: DNS calculation");
            techniques.Add("T1573", "Encrypted channel");
            techniques.Add("T1573/001", "Encrypted channel: Symmetric Cryptography");
            techniques.Add("T1573/002", "Encrypted channel: Asymmetric cryptography");
            techniques.Add("T1008", "Fallback channels");
            techniques.Add("T1105", "Ingress tool transfer");
            techniques.Add("T1104", "Multi-stage channels");
            techniques.Add("T1095", "Non-application layer protocol");
            techniques.Add("T1571", "Non-standard port");
            techniques.Add("T1572", "Protocol tunneling");
            techniques.Add("T1090", "Proxy");
            techniques.Add("T1090/001", "Proxy: Internal proxy");
            techniques.Add("T1090/002", "Proxy: External proxy");
            techniques.Add("T1090/003", "Proxy: Multi-hop proxy");
            techniques.Add("T1090/004", "Proxy: Domain fronting");
            techniques.Add("T1219", "Remote access software");
            techniques.Add("T1205", "Traffic signaling");
            techniques.Add("T1205/001", "Traffic signaling: Port knocking");
            techniques.Add("T1102", "Web service");
            techniques.Add("T1102/001", "Web service: Dead drop resolver");
            techniques.Add("T1102/002", "Web service: Bidirectional communication");
            techniques.Add("T1102/003", "Web service: One-way communication");

            // Add the TA0011->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0011'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0011'>TA0011 - Command and Control</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0011' class='collapse' aria-labelledby='heading-TA0011' data-parent='#collapse-enterprise'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/enterprise/TA0010 -- count 16 at time of writing
            #region tactics TA0010

            techniques = new Dictionary<string, string>();
            techniques.Add("T1020", "Automated exfiltration");
            techniques.Add("T1030", "Data trasnfer size limits");
            techniques.Add("T1048", "Exfiltration over alternative protocol");
            techniques.Add("T1048/001", "Exfiltration over alternative protocol: Exfiltration over symmetric encrypted non-C2 protocol");
            techniques.Add("T1048/002", "Exfiltration over alternative protocol: Exfiltration over asymmetric encrypted non-C2 protocol");
            techniques.Add("T1048/003", "Exfiltration over alternative protocol: Exfiltration over unencrypted/obfuscated non-C2 protocol");
            techniques.Add("T1041", "Exfiltration over C2 channel");
            techniques.Add("T1011", "Exfiltration over other network medium");
            techniques.Add("T1011/001", "Exfiltration over other network medium: Exfiltration over bluetooth");
            techniques.Add("T1052", "Exfiltration over physical medium");
            techniques.Add("T1052/001", "Exfiltration over physical medium: Exfiltration over USB");
            techniques.Add("T1567", "Exfiltration over web service");
            techniques.Add("T1567/001", "Exfiltration over web service: Exfiltration to code repository");
            techniques.Add("T1567/002", "Exfiltration over web service: Exfiltration to cloud storage");
            techniques.Add("T1029", "Scheduled transfer");
            techniques.Add("T1537", "Transfer data to cloud account");

            // Add the TA0010->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0010'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0010'>TA0010 - Exfiltration</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0010' class='collapse' aria-labelledby='heading-TA0010' data-parent='#collapse-enterprise'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/enterprise/TA0040 -- count 26 at time of writing
            #region tactics TA0040

            techniques = new Dictionary<string, string>();
            techniques.Add("T1531", "Account access removal");
            techniques.Add("T1485", "Data destruction");
            techniques.Add("T1486", "Data encrypted for impact");
            techniques.Add("T1565", "Data manipulation");
            techniques.Add("T1565/001", "Data manipulation: Stored data manipulation");
            techniques.Add("T1565/002", "Data manipulation: Transmitted data manipulation");
            techniques.Add("T1565/003", "Data manipulation: Runtime data manipulation");
            techniques.Add("T1491", "Defacement");
            techniques.Add("T1491/001", "Defacement: Internal defacement");
            techniques.Add("T1491/002", "Defacement: External defacement");
            techniques.Add("T1561", "Disk wipe");
            techniques.Add("T1561/001", "Disk wipe: Disk content wipe");
            techniques.Add("T1561/002", "Disk wipe: Disk structure wipe");
            techniques.Add("T1499", "Endpoint denial of service");
            techniques.Add("T1499/001", "Endpoint denial of service: OS exhaustion flood");
            techniques.Add("T1499/002", "Endpoint denial of service: Service exhaustion flood");
            techniques.Add("T1499/003", "Endpoint denial of service: Application exhaustion flood");
            techniques.Add("T1499/004", "Endpoint denial of service: Application or system exploitation");
            techniques.Add("T1495", "Firmware corruption");
            techniques.Add("T1490", "Inhibit system recovery");
            techniques.Add("T1498", "Network denial of service");
            techniques.Add("T1498/001", "Network denial of service: Direct network flood");
            techniques.Add("T1498/002", "Network denial of service: Reflection amplification");
            techniques.Add("T1496", "Resource hijacking");
            techniques.Add("T1489", "Service stop");
            techniques.Add("T1529", "System shutdown/reboot");

            // Add the TA0040->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0040'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0040'>TA0040 - Impact</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0040' class='collapse' aria-labelledby='heading-TA0040' data-parent='#collapse-enterprise'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion
            
            // tactics/mobile -- count 14 at time of writing
            #region tactics/mobile

            //htmlContent.Add("<optgroup label='Mobile'>");

            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark' id='heading-mobile'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-mobile'>MITRE ATT&CK MOBILE</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-mobile' class='collapse' aria-labelledby='heading-mobile' data-parent='#accordion'>");

            // tactics/mobile/TA0027 -- count 9 at time of writing
            #region tactics TA0027

            techniques = new Dictionary<string, string>();
            techniques.Add("T1475", "Deliver malicious app via authorized app store");
            techniques.Add("T1476", "Deliver malicious app via other means");
            techniques.Add("T1456", "Drive-by compromise");
            techniques.Add("T1458", "Exploit via charging station or PC");
            techniques.Add("T1477", "Exploit via radio interfaces");
            techniques.Add("T1478", "Install insecure of malicious configuration");
            techniques.Add("T1461", "Lockscreen bypass");
            techniques.Add("T1444", "Masquerade as legitimate application");
            techniques.Add("T1474", "Supply chain compromise");

            // Add the TA0027->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0027'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0027'>TA0027 - Initial Access</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0027' class='collapse' aria-labelledby='heading-TA0027' data-parent='#collapse-mobile'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");


            #endregion

            // tactics/mobile/TA0041 -- count 2 at time of writing
            #region tactics TA0041

            techniques = new Dictionary<string, string>();
            techniques.Add("T1402", "Broadcast receivers");
            techniques.Add("T1575", "Native code");

            // Add the TA0041->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0041'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0041'>TA0041 - Execution</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0041' class='collapse' aria-labelledby='heading-TA0041' data-parent='#collapse-mobile'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");


            #endregion

            // tactics/mobile/TA0028 -- count 9 at time of writing
            #region tactics TA0028

            techniques = new Dictionary<string, string>();
            techniques.Add("T1401", "Abuse device administrator access to prevent removal");
            techniques.Add("T1402", "Broadcast receivers");
            techniques.Add("T1540", "Code injection");
            techniques.Add("T1577", "Compromise application executable");
            techniques.Add("T1541", "Foreground persistence");
            techniques.Add("T1403", "Modify cached executable code");
            techniques.Add("T1398", "Modify OS kernal or boot partition");
            techniques.Add("T1400", "Modify system partition");
            techniques.Add("T1399", "Modify trusted execution environment");

            // Add the TA0028->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0028'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0028'>TA0028 - Persistence</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0028' class='collapse' aria-labelledby='heading-TA0028' data-parent='#collapse-mobile'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");


            #endregion

            // tactics/mobile/TA0029 -- count 3 at time of writing
            #region tactics TA0029

            techniques = new Dictionary<string, string>();
            techniques.Add("T1540", "Code injection");
            techniques.Add("T1404", "Exploit OS vulnerability");
            techniques.Add("T1405", "Exploit TEE vulnerability");

            // Add the TA0029->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0029'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0029'>TA0029 - Privilege Escalation</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0029' class='collapse' aria-labelledby='heading-TA0029' data-parent='#collapse-mobile'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/mobile/TA0030 -- count 16 at time of writing
            #region tactics TA0030

            techniques = new Dictionary<string, string>();
            techniques.Add("T1418", "Application discovery");
            techniques.Add("T1540", "Code injection");
            techniques.Add("T1446", "Device lockout");
            techniques.Add("T1408", "Disguise root/jailbreak indicators");
            techniques.Add("T1407", "Download new code at runtime");
            techniques.Add("T1523", "Evade analysis environment");
            techniques.Add("T1516", "Input injection");
            techniques.Add("T1478", "Install insecure or malicious configuration");
            techniques.Add("T1444", "Masquerade as legitimate application");
            techniques.Add("T1398", "Modify OS kernel or boot partition");
            techniques.Add("T1400", "Modify system partition");
            techniques.Add("T1399", "Modify trusted execution environment");
            techniques.Add("T1575", "Native code");
            techniques.Add("T1406", "Obfuscated files or information");
            techniques.Add("T1508", "Suppress application icon");
            techniques.Add("T1576", "Uninstall malicious application");

            // Add the TA0030->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0030'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0030'>TA0030 - Defense Evasion</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0030' class='collapse' aria-labelledby='heading-TA0030' data-parent='#collapse-mobile'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/mobile/TA0031 -- count 12 at time of writing
            #region tactics TA0031

            techniques = new Dictionary<string, string>();
            techniques.Add("T1517", "Access notifications");
            techniques.Add("T1413", "Access sensitive data in device logs");
            techniques.Add("T1409", "Access stored application data");
            techniques.Add("T1416", "Android intent hijacking");
            techniques.Add("T1414", "Capture clipboard data");
            techniques.Add("T1412", "Capture SMS messages");
            techniques.Add("T1405", "Exploit TEE vulnerability");
            techniques.Add("T1417", "Input capture");
            techniques.Add("T1411", "Input prompt");
            techniques.Add("T1579", "Keychain");
            techniques.Add("T1410", "Network traffic capture or redirection");
            techniques.Add("T1415", "URL scheme hijacking");

            // Add the TA0031->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0031'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0031'>TA0031 - Credential Access</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0031' class='collapse' aria-labelledby='heading-TA0031' data-parent='#collapse-mobile'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/mobile/TA0032 -- count 9 at time of writing
            #region tactics TA0032

            techniques = new Dictionary<string, string>();
            techniques.Add("T1418", "Application discovery");
            techniques.Add("T1523", "Evade analysis environment");
            techniques.Add("T1420", "File and directory discovery");
            techniques.Add("T1430", "Location tracking");
            techniques.Add("T1423", "Network service scanning");
            techniques.Add("T1424", "Process discovery");
            techniques.Add("T1426", "System infromation discovery");
            techniques.Add("T1422", "System netwrok configuration discovery");
            techniques.Add("T1421", "System network connections discovery");

            // Add the TA0032->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0032'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0032'>TA0032 - Discovery</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0032' class='collapse' aria-labelledby='heading-TA0032' data-parent='#collapse-mobile'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/mobile/TA0033 -- count 2 at time of writing
            #region tactics TA0033

            techniques = new Dictionary<string, string>();
            techniques.Add("T1427", "Attack PC via USB connection");
            techniques.Add("T1428", "Exploit enterprise resources");

            // Add the TA0033->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0033'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0033'>TA0033 - Lateral Movement</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0033' class='collapse' aria-labelledby='heading-TA0033' data-parent='#collapse-mobile'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/mobile/TA0035 -- count 17 at time of writing
            #region tactics TA0035

            techniques = new Dictionary<string, string>();
            techniques.Add("T1435", "Access calendar entries");
            techniques.Add("T1433", "Access call log");
            techniques.Add("T1432", "Access contact list");
            techniques.Add("T1517", "Access notifications");
            techniques.Add("T1413", "Access sensitive data in device logs");
            techniques.Add("T1409", "Access stored application data");
            techniques.Add("T1429", "Capture audio");
            techniques.Add("T1512", "Capture camera");
            techniques.Add("T1414", "Capture clipboard data");
            techniques.Add("T1412", "Capture SMS messages");
            techniques.Add("T1533", "Data from local system");
            techniques.Add("T1541", "Foreground persistence");
            techniques.Add("T1417", "Input capture");
            techniques.Add("T1430", "Location tracking");
            techniques.Add("T1507", "Network information discovery");
            techniques.Add("T1410", "Network traffic capture or redirection");
            techniques.Add("T1513", "Screen capture");

            // Add the TA0035->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0035'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0035'>TA0035 - Collection</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0035' class='collapse' aria-labelledby='heading-TA0035' data-parent='#collapse-mobile'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/mobile/TA0037 -- count 8 at time of writing
            #region tactics TA0037

            techniques = new Dictionary<string, string>();
            techniques.Add("T1438", "Alternate network mediums");
            techniques.Add("T1436", "Commonly used port");
            techniques.Add("T1520", "Domain generation algorithms");
            techniques.Add("T1544", "Remote file copy");
            techniques.Add("T1437", "Standard application layer protocol");
            techniques.Add("T1521", "Standard cryptographic protocol");
            techniques.Add("T1509", "Uncommonly used port");
            techniques.Add("T1481", "Web service");

            // Add the TA0037->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0037'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0037'>TA0037 - Command and Control</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0037' class='collapse' aria-labelledby='heading-TA0037' data-parent='#collapse-mobile'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/mobile/TA0036 -- count 4 at time of writing
            #region tactics TA0036

            techniques = new Dictionary<string, string>();
            techniques.Add("T1438", "Alternate network mediums");
            techniques.Add("T1436", "Commonly used port");
            techniques.Add("T1532", "Data encrypted");
            techniques.Add("T1437", "Standard application layer protocol");

            // Add the TA0036->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0036'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0036'>TA0036 - Exfiltration</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0036' class='collapse' aria-labelledby='heading-TA0036' data-parent='#collapse-mobile'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/mobile/TA0034 -- count 9 at time of writing
            #region tactics TA0034

            techniques = new Dictionary<string, string>();
            techniques.Add("T1448", "Carrier billing fraud");
            techniques.Add("T1510", "Clipboard modification");
            techniques.Add("T1471", "Data encrypted for impact");
            techniques.Add("T1447", "Delete device data");
            techniques.Add("T1446", "Device lockout");
            techniques.Add("T1472", "Generate fraudulent advertising revenue");
            techniques.Add("T1516", "Input injection");
            techniques.Add("T1452", "Manipulate app store rankings or ratings");
            techniques.Add("T1400", "Modify system partition");

            // Add the TA0034->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0034'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0034'>TA0034 - Impact</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0034' class='collapse' aria-labelledby='heading-TA0034' data-parent='#collapse-mobile'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/mobile/TA0038 -- count 9 at time of writing
            #region tactics TA0038

            techniques = new Dictionary<string, string>();
            techniques.Add("T1466", "Downgrade to insecure protocols");
            techniques.Add("T1439", "Eavesdrop on insecure network communication");
            techniques.Add("T1449", "Exploit SS7 to redirect phone calls/SMS");
            techniques.Add("T1450", "Exploit SS7 to track device location");
            techniques.Add("T1464", "Jamming or denial of service");
            techniques.Add("T1463", "Manipulate device communication");
            techniques.Add("T1467", "Rogue cellular base station");
            techniques.Add("T1465", "Rogue Wi-Fi access points");
            techniques.Add("T1451", "SIM card swap");

            // Add the TA0038->techniques to our options list
            htmlContent.Add("<div class='card-body bg-dark' id='TA0038'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0038'>TA0038 - Network Effects</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0038' class='collapse' aria-labelledby='heading-TA0038' data-parent='#collapse-mobile'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            // tactics/mobile/TA0039 -- count 3 at time of writing
            #region tactics TA0039

            techniques = new Dictionary<string, string>();
            techniques.Add("T1470", "Obtain device cloud backups");
            techniques.Add("T1468", "Remotely track device without authorization");
            techniques.Add("T1469", "Remotely wipe data without authorization");

            // Add the TA0039->techniques to our options list
            htmlContent.Add("<optgroup label='TA0039 - Remote Service Effects'>");
            htmlContent = AddHtml(htmlContent, techniques, selected);

            htmlContent.Add("<div class='card-body bg-dark' id='TA0039'>");
            htmlContent.Add("<div class='card'>");
            htmlContent.Add("<div class='card-header bg-dark'>");
            htmlContent.Add("<a href='#' data-toggle='collapse' data-target='#collapse-TA0039'>TA0039 - Remote Service Effects</a>");
            htmlContent.Add("</div>");
            htmlContent.Add("<div id='collapse-TA0039' class='collapse' aria-labelledby='heading-TA0039' data-parent='#collapse-mobile'>");

            htmlContent = AddHtml(htmlContent, techniques, selected);
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            htmlContent.Add("</div>");

            #endregion

            htmlContent.Add("</div>");
            htmlContent.Add("</div>");
            
            #endregion
    
            htmlContent.Add("</div>");
        }

        private List<string> AddHtml(List<string> htmlContent, Dictionary<string, string> techniques, string selected)
        {
            foreach (var technique in techniques)
            {
                htmlContent.Add("<div class='card-body bg-dark' id='" + technique.Key + "'>");
                htmlContent.Add("<div class='card' style='border:none;'>");
                htmlContent.Add("<div class='card-header bg-dark' id='heading-" + technique.Key + "'>");
                
                if (selected == technique.Key)
                {
                    htmlContent.Add("<input class='form-check-input' value='" + technique.Key + "' id='radio-" + technique.Key + "' type='radio' name='mitreId' checked='checked'>");
                }
                else { htmlContent.Add("<input class='form-check-input' value='" + technique.Key + "' id='radio-" + technique.Key + "' type='radio' name='mitreId'>"); }
                
                htmlContent.Add("<label class='form-check-label' for='radio-" + technique.Key + "'>" + technique.Value + "</label>");
                htmlContent.Add("<a style='margin-left: 5px;' href='https://attack.mitre.org/techniques/" + technique.Key +"/' target='_blank'>");
                htmlContent.Add("<svg width='1em' height='1em' viewBox='0 0 16 16' class='bi bi-info-square' fill='currentColor' xmlns='http://www.w3.org/2000/svg'>");
                htmlContent.Add("<path fill-rule='evenodd' d='M14 1H2a1 1 0 0 0-1 1v12a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1zM2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2z' />");
                htmlContent.Add("<path d='M8.93 6.588l-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533L8.93 6.588z' />");
                htmlContent.Add("<circle cx='8' cy='4.5' r='1' />");
                htmlContent.Add("</svg>");
                htmlContent.Add("</a>");

                htmlContent.Add("</div>");
                htmlContent.Add("</div>");
                htmlContent.Add("</div>");
            }

            return htmlContent;
        }
    }
}
