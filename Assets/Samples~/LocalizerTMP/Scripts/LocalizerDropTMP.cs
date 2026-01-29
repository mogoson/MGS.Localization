/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LocalizerDropTMP.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  01/27/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using TMPro;
using static TMPro.TMP_Dropdown;

namespace MGS.Localize
{
    public class LocalizerDropTMP : LocalizerPro<TMP_Dropdown>
    {
        protected override void OnLocalize(TMP_Dropdown target, IEnumerable<string> localTexs)
        {
            var select = target.value;
            target.ClearOptions();
            var options = new List<OptionData>();
            foreach (var localTex in localTexs)
            {
                options.Add(new OptionData(localTex));
            }
            target.AddOptions(options);
            target.SetValueWithoutNotify(select);
        }
    }
}