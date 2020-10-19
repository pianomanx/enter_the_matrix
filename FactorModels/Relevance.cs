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
    public class Relevance
    {
        public Dictionary<string, string> nistDescriptions { get; set; }
        public Relevance()
        {
            nistDescriptions = new Dictionary<string, string>();
            nistDescriptions.Add("Confirmed", "The threat event or TTP has been seen by the organization.");
            nistDescriptions.Add("Expected", "The threat event or TTP has been seen by the organization’s peers or partners.");
            nistDescriptions.Add("Anticipated", "The threat event or TTP has been reported by a trusted source.");
            nistDescriptions.Add("Predicted", "The threat event or TTP has been predicted by a trusted source.");
            nistDescriptions.Add("Possible", "The threat event or TTP has been described by a somewhat credible source.");
            nistDescriptions.Add("N/A", @"The threat event or TTP is not currently applicable. For example, a threat event or TTP could assume specific technologies,
                architectures, or processes that are not present in the organization, mission / business process, EA segment, or information
                system; or predisposing conditions that are not present(e.g., location in a flood plain).Alternately, if the organization is using
                detailed or specific threat information, a threat event or TTP could be deemed inapplicable because information indicates that
                no adversary is expected to initiate the threat event or use the TTP.");
        }

        public string getAbbreviation(string factor)
        {
            if (factor == "Confirmed") { return "C"; }
            else if (factor == "Expected") { return "E"; }
            else if (factor == "Anticipated") { return "A"; }
            else if (factor == "Predicted") { return "Pr"; }
            else if (factor == "Possible") { return "Po"; }
            else { return ""; }
        }
    }
}
