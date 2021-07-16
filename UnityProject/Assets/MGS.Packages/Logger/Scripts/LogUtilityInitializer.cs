/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LogUtilityInitializer.cs
 *  Description  :  Initializer for log utility.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/19/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Logger
{
    /// <summary>
    /// Initializer for log utility.
    /// </summary>
    public sealed class LogUtilityInitializer
    {
        #region Public Method
        /// <summary>
        /// Awake initializer.
        /// </summary>
#if UNITY_5_3_OR_NEWER
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
#else
        [RuntimeInitializeOnLoadMethod]
#endif
        private static void Awake()
        {
            //Use persistentDataPath support more platforms, example Android.
            var logDir = string.Format("{0}/Log/", Application.persistentDataPath);
            LogUtility.Register(new FileLogger(logDir));
        }
        #endregion
    }
}