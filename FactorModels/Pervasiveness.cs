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
    public class Pervasiveness
    {
        public Dictionary<string, string> nistDescriptions { get; set; }

        public Pervasiveness()
        {
            nistDescriptions = new Dictionary<string, string>();
            nistDescriptions.Add("Very High", @"Applies to all organizational missions/business functions (Tier 1), mission/business processes
                (Tier 2), or information systems (Tier 3).");
            nistDescriptions.Add("High", @"Applies to most organizational missions/business functions (Tier 1), mission/business processes
                (Tier 2), or information systems (Tier 3).");
            nistDescriptions.Add("Moderate", @"Applies to many organizational missions/business functions (Tier 1), mission/business processes
                (Tier 2), or information systems (Tier 3).");
            nistDescriptions.Add("Low", @"Applies to some organizational missions/business functions (Tier 1), mission/business processes
                (Tier 2), or information systems (Tier 3).");
            nistDescriptions.Add("Very Low", @"Applies to few organizational missions/business functions (Tier 1), mission/business processes
                (Tier 2), or information systems (Tier 3).");
        }
    }
}
