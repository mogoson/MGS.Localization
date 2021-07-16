/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LogUtilityEditor.cs
 *  Description  :  Editor for log utility.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  1/3/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Logger
{
    /// <summary>
    /// Editor for log utility.
    /// </summary>
    public sealed class LogUtilityEditor
    {
        #region Public Method
        /// <summary>
        /// Awake editor.
        /// </summary>
#if UNITY_5_3_OR_NEWER
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
#else
        [RuntimeInitializeOnLoadMethod]
#endif
        private static void Awake()
        {
            LogUtility.Register(new UnityDebugger());
        }
        #endregion
    }
}