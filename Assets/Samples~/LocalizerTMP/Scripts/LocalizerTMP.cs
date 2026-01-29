/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LocalizerTMP.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  01/23/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using TMPro;

namespace MGS.Localize
{
    public class LocalizerTMP : Localizer<TextMeshProUGUI>
    {
        protected override void OnLocalize(TextMeshProUGUI target, string localTex)
        {
            target.text = localTex;
        }
    }
}