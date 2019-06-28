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

using MGS.Common.Utility;
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
            MultilingualUtility.Instance.Initialize(Application.dataPath + "/Resources/Multilingualism/");
            MultilingualUtility.Instance.SetLanguage(languages[0]);
            helloWorldContent = MultilingualUtility.Instance.GetParagraph(helloWorldKey);
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
                MultilingualUtility.Instance.SetLanguage(languages[0]);
            }

            if (GUILayout.Button(languages[1]))
            {
                MultilingualUtility.Instance.SetLanguage(languages[1]);
            }

            if (GUILayout.Button("Reload"))
            {
                helloWorldContent = MultilingualUtility.Instance.GetParagraph(helloWorldKey);
            }

            GUILayout.EndHorizontal();
        }
        #endregion
    }
}