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
    public class Severity
    {
        public Dictionary<string, string> nistDescriptions { get; set; }

        public Severity()
        {
            nistDescriptions = new Dictionary<string, string>();
            nistDescriptions.Add("Very High", @"The vulnerability is exposed and exploitable, and its exploitation could result in severe impacts.
                Relevant security control or other remediation is not implemented and not planned; or no security
                measure can be identified to remediate the vulnerability.");
            nistDescriptions.Add("High", @"The vulnerability is of high concern, based on the exposure of the vulnerability and ease of
                exploitation and/or on the severity of impacts that could result from its exploitation.
                Relevant security control or other remediation is planned but not implemented; compensating
                controls are in place and at least minimally effective.");
            nistDescriptions.Add("Moderate", @"The vulnerability is of moderate concern, based on the exposure of the vulnerability and ease of
                exploitation and/or on the severity of impacts that could result from its exploitation.
                Relevant security control or other remediation is partially implemented and somewhat effective.");
            nistDescriptions.Add("Low", @"The vulnerability is of minor concern, but effectiveness of remediation could be improved.
                Relevant security control or other remediation is fully implemented and somewhat effective");
            nistDescriptions.Add("Very Low", @"The vulnerability is not of concern.
                Relevant security control or other remediation is fully implemented, assessed, and effective");
        }
    }
}
