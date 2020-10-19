/*
# -------------------------------------------------------------------------------
# Author:      Cody Martin <cody.martin@blacklanternsecurity.com>
#
# Created:     10-15-2020
# Copyright:   (c) BLS OPS LLC. 2020
# Licence:     GPL
# -------------------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enter_The_Matrix.FactorModels
{
    public class Targeting
    {
        public Dictionary<string, string> nistDescriptions { get; set; }

        public Targeting()
        {
            nistDescriptions = new Dictionary<string, string>();
            nistDescriptions.Add("Very High", @"The adversary analyzes information obtained via reconnaissance and attacks to target persistently
                a specific organization, enterprise, program, mission or business function, focusing on specific
                high-value or mission-critical information, resources, supply flows, or functions; specific employees
                or positions; supporting infrastructure providers/suppliers; or partnering organizations.");
            nistDescriptions.Add("High", @"The adversary analyzes information obtained via reconnaissance to target persistently a specific
                organization, enterprise, program, mission or business function, focusing on specific high-value or
                mission-critical information, resources, supply flows, or functions, specific employees supporting
                those functions, or key positions.");
            nistDescriptions.Add("Moderate", @"The adversary analyzes publicly available information to target persistently specific high-value
                organizations (and key positions, such as Chief Information Officer), programs, or information.");
            nistDescriptions.Add("Low", @"The adversary uses publicly available information to target a class of high-value organizations or
                information, and seeks targets of opportunity within that class.");
            nistDescriptions.Add("Very Low", @"The adversary may or may not target any specific organizations or classes of organizations.");
        }
    }
}
