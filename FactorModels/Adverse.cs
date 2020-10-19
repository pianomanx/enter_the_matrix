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
    public class Adverse
    {
        public Dictionary<string, string> nistDescriptions;

        public Adverse()
        {
            nistDescriptions = new Dictionary<string, string>();
            nistDescriptions.Add("Very High", "If the threat event is initiated or occurs, it is almost certain to have adverse impacts.");
            nistDescriptions.Add("High", "If the threat event is initiated or occurs, it is highly likely to have adverse impacts.");
            nistDescriptions.Add("Moderate", "If the threat event is initiated or occurs, it is somewhat likely to have adverse impacts.");
            nistDescriptions.Add("Low", "If the threat event is initiated or occurs, it is unlikely to have adverse impacts.");
            nistDescriptions.Add("Very Low", "If the threat event is initiated or occurs, it is highly unlikely to have adverse impacts.");
        }
    }
}
