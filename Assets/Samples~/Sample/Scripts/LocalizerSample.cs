/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LocalizerSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/23/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.Localization.Sample
{
    public class LocalizerSample : MonoBehaviour
    {
        public Dropdown dropdown;
        public Text text;
        string[] lang = new string[] { "zh-CN", "en-US" };

        private void Start()
        {
            var langDir = $"{Application.dataPath}/Samples/Localization/1.0.0/Sample/Language";
            Global.Localizer.Deserialize(lang[0], $"{langDir}/{lang[0]}.txt", Encoding.UTF8);
            Global.Localizer.Deserialize(lang[1], $"{langDir}/{lang[1]}.txt", Encoding.UTF8);
            Global.Localizer.OnChanged += Localizer_OnChanged;

            dropdown.onValueChanged.AddListener(Dropdown_OnValueChanged);
            dropdown.options.Clear();
            dropdown.options.Add(new Dropdown.OptionData("简体中文"));
            dropdown.options.Add(new Dropdown.OptionData("English"));
            dropdown.value = 0;
        }

        private void OnDestroy()
        {
            Global.Localizer.OnChanged -= Localizer_OnChanged;
        }

        private void Dropdown_OnValueChanged(int select)
        {
            Global.Localizer.Current = lang[select];
        }

        private void Localizer_OnChanged(string language)
        {
            text.text = Global.Localizer.GetParagraph("key0");
        }
    }
}