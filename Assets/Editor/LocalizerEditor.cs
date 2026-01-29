/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LocalizerEditor.cs
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
    [CustomEditor(typeof(Localizer), true)]
    public class LocalizerEditor : Editor
    {
        protected Localizer Target { get { return target as Localizer; } }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            OnLocalizerGUI();
        }

        protected virtual void OnLocalizerGUI()
        {
            if (GUILayout.Button("Localize"))
            {
                Target.Localize();
                EditorUtility.SetDirty(Target);
            }
        }
    }
}