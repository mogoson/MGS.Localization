/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TestLocalization.cs
 *  Description  :  Test localization.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/7/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Text;
using UnityEngine;

namespace MGS.Localization.Demo
{
    public class TestLocalization : MonoBehaviour
    {
        #region Field and Property
        public float top = 10;
        public float left = 10;

        private readonly string[] languages = new string[] { "zh-CN", "en-US" };
        private const string INT_HW = "INT_HW";
        private string paragraph;
        #endregion

        #region Private Method
        private void Start()
        {
            //Deserialize all languages just for example,
            //if you do not need switch language frequently, you should only Deserialize a language in your project,
            //when need switch to new language, you can Clear language and Deserialize a new.

            foreach (var language in languages)
            {
                var languageFile = string.Format("{0}/MGS.Packages/Localization/Demo/Language/{1}.txt", Application.dataPath, language);
                LocalizationAPI.Handler.Deserialize(language, languageFile, Encoding.UTF8);
            }
            paragraph = LocalizationAPI.Handler.GetParagraph(languages[0], INT_HW);
        }

        private void OnGUI()
        {
            GUILayout.Space(top);
            GUILayout.BeginHorizontal();
            GUILayout.Space(left);
            GUILayout.Label(paragraph);
            GUILayout.Space(5);

            if (GUILayout.Button(languages[0]))
            {
                paragraph = LocalizationAPI.Handler.GetParagraph(languages[0], INT_HW);
            }

            if (GUILayout.Button(languages[1]))
            {
                paragraph = LocalizationAPI.Handler.GetParagraph(languages[1], INT_HW);
            }

            GUILayout.EndHorizontal();
        }
        #endregion
    }
}