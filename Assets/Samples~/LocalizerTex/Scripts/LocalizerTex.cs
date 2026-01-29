/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LocalizerTex.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  01/23/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine.UI;

namespace MGS.Localize
{
    public class LocalizerTex : Localizer<Text>
    {
        protected override void OnLocalize(Text target, string localTex)
        {
            target.text = localTex;
        }
    }
}