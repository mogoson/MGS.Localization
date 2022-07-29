/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LocalizationAPI.cs
 *  Description  :  API for localization.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/27/2022
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Localization
{
    /// <summary>
    /// API for localization.
    /// </summary>
    public sealed class LocalizationAPI
    {
        /// <summary>
        /// A global instance of api.
        /// </summary>
        private static readonly ILocalization localization = new Localizer();

        /// <summary>
        /// A global instance of api (Thread safety).
        /// </summary>
        public static ILocalization Handler { get { return localization; } }
    }
}