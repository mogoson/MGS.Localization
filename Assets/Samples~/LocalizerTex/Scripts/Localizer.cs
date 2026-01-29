/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Localizer.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  01/27/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.Localize
{
    public abstract class Localizer<T> : Localizer
    {
        public T target;
        public string key;

        protected virtual void Reset()
        {
            target = GetComponent<T>();
        }

        protected virtual void Start()
        {
            Localize();
        }

        public override void Localize()
        {
            var localTex = Global.Localization.GetParagraph(key);
            OnLocalize(target, localTex);
        }

        protected abstract void OnLocalize(T target, string localTex);
    }

    public abstract class LocalizerPro<T> : Localizer
    {
        public T target;
        public string[] keys;

        protected virtual void Reset()
        {
            target = GetComponent<T>();
        }

        protected virtual void Start()
        {
            Localize();
        }

        public override void Localize()
        {
            var localTexs = new List<string>();
            foreach (var key in keys)
            {
                var localTex = Global.Localization.GetParagraph(key);
                localTexs.Add(localTex);
            }
            OnLocalize(target, localTexs);
        }

        protected abstract void OnLocalize(T target, IEnumerable<string> localTexs);
    }
}