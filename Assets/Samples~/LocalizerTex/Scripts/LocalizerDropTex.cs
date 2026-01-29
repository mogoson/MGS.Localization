/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LocalizerDropTex.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  01/23/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine.UI;
using static UnityEngine.UI.Dropdown;

namespace MGS.Localize
{
    public class LocalizerDropTex : LocalizerPro<Dropdown>
    {
        protected override void OnLocalize(Dropdown target, IEnumerable<string> localTexs)
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