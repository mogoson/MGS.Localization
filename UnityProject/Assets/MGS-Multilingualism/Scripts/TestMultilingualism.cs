/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TestMultilingualism.cs
 *  Description  :  Test multilingualism.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/7/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Multilingualism
{
    [AddComponentMenu("MGS/Multilingualism/TestMultilingualism")]
    public class TestMultilingualism : MonoBehaviour
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
            foreach (var language in languages)
            {
                var languageFile = Application.dataPath + "/Resources/Multilingualism/" + language + ".txt";
                MultilingualUtility.Instance.Deserialize(languageFile);
            }

            helloWorldContent = MultilingualUtility.Instance.GetParagraph(languages[0], helloWorldKey);
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
                helloWorldContent = MultilingualUtility.Instance.GetParagraph(languages[0], helloWorldKey);
            }

            if (GUILayout.Button(languages[1]))
            {
                helloWorldContent = MultilingualUtility.Instance.GetParagraph(languages[1], helloWorldKey);
            }

            GUILayout.EndHorizontal();
        }
        #endregion
    }
}