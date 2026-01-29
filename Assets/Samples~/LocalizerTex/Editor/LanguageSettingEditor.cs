/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LanguageSettingEditor.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  01/27/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;
using UnityEngine;

namespace MGS.Localize.Editors
{
    [CustomEditor(typeof(LanguageSetting), true)]
    public class LanguageSettingEditor : Editor
    {
        protected LanguageSetting Target { get { return target as LanguageSetting; } }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            OnSettingGUI();
        }

        protected virtual void OnSettingGUI()
        {
            if (GUILayout.Button("Refresh"))
            {
                Target.Refresh();
                EditorUtility.SetDirty(Target);
            }
        }
    }
}