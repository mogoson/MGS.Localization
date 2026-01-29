/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Global.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/23/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Globalization;
using System.Text;
using UnityEngine;

namespace MGS.Localize
{
    public sealed class Global
    {
        public static ILocalization Localization { get; }

        static Global()
        {
            Localization = new Localization();
            var language = CultureInfo.CurrentCulture.Name;
            var file = $"{Application.streamingAssetsPath}/Languages/{language}.txt";
            Localization.Deserialize(language, file, Encoding.UTF8);
            Localization.Current = language;
        }
    }
}