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
    public class Impact
    {
        public Dictionary<string, string> nistDescriptions { get; set; }

        public Impact()
        {
            nistDescriptions = new Dictionary<string, string>();
            nistDescriptions.Add("Very High", @"The threat event could be expected to have multiple severe or catastrophic adverse effects on
                organizational operations, organizational assets, individuals, other organizations, or the Nation.");
            nistDescriptions.Add("High", @"The threat event could be expected to have a severe or catastrophic adverse effect on
                organizational operations, organizational assets, individuals, other organizations, or the Nation. A
                severe or catastrophic adverse effect means that, for example, the threat event might: (i) cause a
                severe degradation in or loss of mission capability to an extent and duration that the organization is
                not able to perform one or more of its primary functions; (ii) result in major damage to
                organizational assets; (iii) result in major financial loss; or (iv) result in severe or catastrophic harm
                to individuals involving loss of life or serious life-threatening injuries.");
            nistDescriptions.Add("Moderate", @"The threat event could be expected to have a serious adverse effect on organizational operations,
                organizational assets, individuals other organizations, or the Nation. A serious adverse effect
                means that, for example, the threat event might: (i) cause a significant degradation in mission
                capability to an extent and duration that the organization is able to perform its primary functions,
                but the effectiveness of the functions is significantly reduced; (ii) result in significant damage to
                organizational assets; (iii) result in significant financial loss; or (iv) result in significant harm to
                individuals that does not involve loss of life or serious life-threatening injuries.");
            nistDescriptions.Add("Low", @"The threat event could be expected to have a limited adverse effect on organizational operations,
                organizational assets, individuals other organizations, or the Nation. A limited adverse effect
                means that, for example, the threat event might: (i) cause a degradation in mission capability to an
                extent and duration that the organization is able to perform its primary functions, but the
                effectiveness of the functions is noticeably reduced; (ii) result in minor damage to organizational
                assets; (iii) result in minor financial loss; or (iv) result in minor harm to individuals.");
            nistDescriptions.Add("Very Low", @"The threat event could be expected to have a negligible adverse effect on organizational
                operations, organizational assets, individuals other organizations, or the Nation.");
        }
    }
}
