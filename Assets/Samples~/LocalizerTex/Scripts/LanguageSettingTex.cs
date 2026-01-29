/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LanguageSettingTex.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  01/24/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine.UI;
using static UnityEngine.UI.Dropdown;

namespace MGS.Localize
{
    public class LanguageSettingTex : LanguageSetting<Dropdown>
    {
        protected override void Start()
        {
            base.Start();
            target.onValueChanged.AddListener(ChangeLanguage);
        }

        protected override void OnRefresh(Dropdown target, IEnumerable<Language> languages)
        {
            var index = 0;
            var current = 0;

            var options = new List<OptionData>();
            foreach (var language in languages)
            {
                options.Add(new OptionData(language.displayName));
                if (language.name == Global.Localization.Current)
                {
                    current = index;
                }
                index++;
            }

            target.ClearOptions();
            target.AddOptions(options);
            target.SetValueWithoutNotify(current);
        }
    }
}