/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ILocalizer.cs
 *  Description  :  Interface of localizer.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/27/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using System.Text;

namespace MGS.Localization
{
    /// <summary>
    /// Interface of localizer.
    /// </summary>
    public interface ILocalizer
    {
        /// <summary>
        /// Current language name.
        /// </summary>
        string Current { set; get; }

        /// <summary>
        /// Deserialize language paragraphs from local file.
        /// </summary>
        /// <param name="language">Name of language.</param>
        /// <param name="languageFile">File path of language content.</param>
        /// <param name="encoding">Encoding of file content.</param>
        /// <returns>Deserialize succeed?</returns>
        bool Deserialize(string language, string languageFile, Encoding encoding);

        /// <summary>
        /// Deserialize language paragraphs from paragraph lines.
        /// </summary>
        /// <param name="language">Name of language.</param>
        /// <param name="paragraphLines">Paragraph lines of language.</param>
        /// <returns>Deserialize succeed?</returns>
        bool Deserialize(string language, string[] paragraphLines);

        /// <summary>
        /// Get all deserialized languages.
        /// </summary>
        /// <returns>All deserialized languages.</returns>
        ICollection<string> GetLanguages();

        /// <summary>
        /// Get paragraphs of target language.
        /// </summary>
        /// <param name="language">Name of language.</param>
        /// <returns>Paragraphs of target language.</returns>
        IDictionary<string, string> GetParagraphs(string language);

        /// <summary>
        /// Get a paragraph text of key in current language.
        /// </summary>
        /// <param name="key">Key of paragraph text.</param>
        /// <returns>A paragraph text of key in current language.</returns>
        string GetParagraph(string key);

        /// <summary>
        /// Get a paragraph text of key in language.
        /// </summary>
        /// <param name="language">Name of language.</param>
        /// <param name="key">Key of paragraph text.</param>
        /// <returns>A paragraph text of key in language.</returns>
        string GetParagraph(string language, string key);

        /// <summary>
        /// Clear paragraphs of language.
        /// </summary>
        /// <param name="language">Name of language.</param>
        void Clear(string language);

        /// <summary>
        /// Clear paragraphs of languages.
        /// </summary>
        void Clear();
    }
}