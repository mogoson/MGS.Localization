/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LanguageSetting.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  01/29/2026
 *  Description  :  Initial development version.
 *************************************************************************/

//#define CLEAR_ORIGIN_LANGUAGE_ON_SWITCH

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MGS.Localize
{
    public abstract class LanguageSetting : MonoBehaviour
    {
        public abstract void Refresh();
    }

    [Serializable]
    public struct Language
    {
        public string displayName;
        public string name;
    }

    public abstract class LanguageSetting<T> : LanguageSetting
    {
        public T target;
        public List<Language> languages;

        protected virtual void Reset()
        {
            target = GetComponent<T>();
        }

        protected virtual void Start()
        {
            Global.Localization.OnChanged += OnLanguageChanged;
            Refresh();
        }

        protected virtual void OnDestroy()
        {
            Global.Localization.OnChanged -= OnLanguageChanged;
        }

        protected virtual void OnLanguageChanged(string language)
        {
            var localizers = FindObjectsOfType<Localizer>();
            foreach (var localizer in localizers)
            {
                localizer.Localize();
            }
        }

        protected void ChangeLanguage(int index)
        {
            var language = languages[index].name;

#if CLEAR_ORIGIN_LANGUAGE_ON_SWITCH
            Global.Localization.Clear();
            DeserializeLanguage(language);
#else
            if (!Global.Localization.Languages.Contains(language))
            {
                DeserializeLanguage(language);
            }
#endif
            Global.Localization.Current = language;
        }

        protected void DeserializeLanguage(string language)
        {
            var file = $"{Application.streamingAssetsPath}/Languages/{language}.txt";
            Global.Localization.Deserialize(language, file, Encoding.UTF8);
        }

        public override void Refresh()
        {
            OnRefresh(target, languages);
        }

        protected abstract void OnRefresh(T target, IEnumerable<Language> languages);
    }
}