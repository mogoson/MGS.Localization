/*************************************************************************
 *  Copyright © 2026 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Localization.cs
 *  Description  :  Localization.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/12/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace MGS.Localize
{
    /// <summary>
    /// Localization.
    /// </summary>
    public class Localization : ILocalization
    {
        #region Field and Property
        /// <summary>
        /// Separator of paragraph key and value.
        /// </summary>
        public static readonly char SEPARATOR = '=';

        /// <summary>
        /// Event on current language changed.
        /// </summary>
        public event Action<string> OnChanged;

        /// <summary>
        /// Current language name.
        /// </summary>
        public string Current
        {
            set
            {
                if (string.IsNullOrEmpty(value) || current == value)
                {
                    return;
                }
                if (languages.ContainsKey(value))
                {
                    current = value;
                    OnChanged?.Invoke(current);
                }
                else
                {
                    Debug.LogError($"Set current language error: The language {value} is not deserialize.");
                }
            }
            get { return current; }
        }

        /// <summary>
        /// All deserialized languages.
        /// </summary>
        public ICollection<string> Languages { get { return languages.Keys; } }

        /// <summary>
        /// Current language name.
        /// </summary>
        private string current = string.Empty;

        /// <summary>
        /// Languages paragraphs dictionary.
        /// </summary>
        protected Dictionary<string, Dictionary<string, string>> languages = new();
        #endregion

        #region Public Method
        /// <summary>
        /// Deserialize language paragraphs from local file.
        /// </summary>
        /// <param name="language">Name of language.</param>
        /// <param name="languageFile">File path of language content.</param>
        /// <param name="encoding">Encoding of file content.</param>
        /// <returns>Deserialize succeed?</returns>
        public bool Deserialize(string language, string languageFile, Encoding encoding)
        {
            if (string.IsNullOrEmpty(language))
            {
                Debug.LogError("Deserialize language error: The language name is null or empty.");
                return false;
            }

            if (!File.Exists(languageFile))
            {
                Debug.LogError($"Deserialize language error: Can not find the language file at path {languageFile}");
                return false;
            }

            string[] fileLines = null;
#if UNITY_ANDROID || UNITY_WEBGL
            using (var request = UnityWebRequest.Get(languageFile))
            {
                request.SendWebRequest();
                while (!request.isDone) { }

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Deserialize language error: {request.error}");
                    return false;
                }

                var languageContent = request.downloadHandler.text;
                if (!string.IsNullOrEmpty(languageContent))
                {
                    fileLines = languageContent.Split("\r\n");
                }
            }
#else
            try
            {
                fileLines = File.ReadAllLines(languageFile, encoding);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Deserialize language exception: {ex.Message}/r/n{ex.StackTrace}");
                return false;
            }
#endif
            if (fileLines == null || fileLines.Length == 0)
            {
                Debug.LogError($"Deserialize language error: None content in the language file at path {languageFile}");
                return false;
            }

            return Deserialize(language, fileLines);
        }

        /// <summary>
        /// Deserialize language paragraphs from paragraph lines.
        /// </summary>
        /// <param name="language">Name of language.</param>
        /// <param name="paragraphLines">Paragraph lines of language.</param>
        /// <returns>Deserialize succeed?</returns>
        public bool Deserialize(string language, string[] paragraphLines)
        {
            if (string.IsNullOrEmpty(language))
            {
                Debug.LogError("Deserialize language error: The language name is null or empty.");
                return false;
            }

            if (paragraphLines == null)
            {
                Debug.LogError("Deserialize language error: The paragraph lines is null.");
                return false;
            }

            if (languages.ContainsKey(language))
            {
                //Clear origin language content.
                languages[language].Clear();
            }
            else
            {
                languages.Add(language, new Dictionary<string, string>());
            }

            foreach (var line in paragraphLines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    //Ignore empty line.
                    continue;
                }

                var contents = line.Split(SEPARATOR, 2, StringSplitOptions.RemoveEmptyEntries);
                if (contents.Length < 2)
                {
                    //Ignore invalid line.
                    continue;
                }
                languages[language].Add(contents[0], contents[1]);
            }

            return true;
        }

        /// <summary>
        /// Get a paragraph text of key in current language.
        /// </summary>
        /// <param name="key">Key of paragraph text.</param>
        /// <returns>A paragraph text of key in current language.</returns>
        public string GetParagraph(string key)
        {
            if (string.IsNullOrEmpty(current))
            {
                Debug.LogError("Get paragraph error: The current language name is not set.");
                return null;
            }

            return GetParagraph(current, key);
        }

        /// <summary>
        /// Get a paragraph text of key in language.
        /// </summary>
        /// <param name="language">Name of language.</param>
        /// <param name="key">Key of paragraph text.</param>
        /// <returns>A paragraph text of key in language.</returns>
        public string GetParagraph(string language, string key)
        {
            if (!languages.ContainsKey(language))
            {
                Debug.LogError($"Get paragraph error: The language {language} is not deserialize.");
                return null;
            }

            if (!languages[language].ContainsKey(key))
            {
                Debug.LogError($"Get paragraph error: The key {key} can not find in the content of language {language}.");
                return null;
            }

            return languages[language][key];
        }

        /// <summary>
        /// Clear paragraphs of language.
        /// </summary>
        /// <param name="language">Name of language.</param>
        public void Clear(string language)
        {
            if (languages.ContainsKey(language))
            {
                languages.Remove(language);
            }

            if (current == language)
            {
                current = null;
            }
        }

        /// <summary>
        /// Clear paragraphs of languages.
        /// </summary>
        public void Clear()
        {
            languages.Clear();
            current = null;
        }
        #endregion
    }
}