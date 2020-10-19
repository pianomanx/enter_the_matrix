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
    public class Initiation
    {
        public Dictionary<string, string> nistDescriptions { get; set; }

        public Initiation()
        {
            nistDescriptions = new Dictionary<string, string>();
            nistDescriptions.Add("Very High", "Adversary is almost certain to initiate the threat event.");
            nistDescriptions.Add("High", "Adversary is highly likely to initiate the threat event.");
            nistDescriptions.Add("Moderate", "Adversary is somewhat likely to initiate the threat event.");
            nistDescriptions.Add("Low", "Adversary is unlikely to initiate the threat event.");
            nistDescriptions.Add("Very Low", "Adversary is highly unlikely to initiate the threat event");
        }
    }
}
