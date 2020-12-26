/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TestInternationalizer.cs
 *  Description  :  Test Internationalizer.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/7/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Internation
{
    [AddComponentMenu("MGS/Internation/TestInternationalizer")]
    public class TestInternationalizer : MonoBehaviour
    {
        #region Field and Property
        public float top = 10;
        public float left = 10;

        private readonly string[] languages = new string[] { "Simplified Chinese", "English" };
        private const string helloWorldKey = "HelloWorld";
        private string helloWorldContent;
        #endregion

        #region Private Method
        private void Start()
        {
            //Deserialize all languages just for example,
            //if you do not need switch language frequently, you should only Deserialize a language in your project,
            //when need switch to new language, you can ClearLanguage and Deserialize a new.

            foreach (var language in languages)
            {
                var languageFile = Application.dataPath + "/Resources/Internation/" + language + ".txt";
                Internationalizer.Instance.Deserialize(languageFile);
            }

            helloWorldContent = Internationalizer.Instance.GetParagraph(languages[0], helloWorldKey);
        }

        private void OnGUI()
        {
            GUILayout.Space(top);
            GUILayout.BeginHorizontal();
            GUILayout.Space(left);
            GUILayout.Label(helloWorldContent);
            GUILayout.Space(5);

            if (GUILayout.Button(languages[0]))
            {
                helloWorldContent = Internationalizer.Instance.GetParagraph(languages[0], helloWorldKey);
            }

            if (GUILayout.Button(languages[1]))
            {
                helloWorldContent = Internationalizer.Instance.GetParagraph(languages[1], helloWorldKey);
            }

            GUILayout.EndHorizontal();
        }
        #endregion
    }
}