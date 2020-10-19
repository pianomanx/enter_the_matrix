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
    public class Capability
    {
        public Dictionary<string, string> nistDescriptions { get; set; }

        public Capability()
        {
            nistDescriptions = new Dictionary<string, string>();
            nistDescriptions.Add("Very High", @"The adversary has a very sophisticated level of expertise, is well-resourced, and can generate
                opportunities to support multiple successful, continuous, and coordinated attacks");
            nistDescriptions.Add("High", @"The adversary has a sophisticated level of expertise, with significant resources and opportunities
                to support multiple successful coordinated attacks.");
            nistDescriptions.Add("Moderate", @"The adversary has moderate resources, expertise, and opportunities to support multiple successful
                attacks.");
            nistDescriptions.Add("Low", @"The adversary has limited resources, expertise, and opportunities to support a successful attack.");
            nistDescriptions.Add("Very Low", @"The adversary has very limited resources, expertise, and opportunities to support a successful
                attack.");
        }
    }
}
