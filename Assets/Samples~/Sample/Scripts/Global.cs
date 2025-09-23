/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Global.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/23/2025
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Localization.Sample
{
    public sealed class Global
    {
        public static ILocalizer Localizer { get; }

        static Global()
        {
            Localizer = new Localizer();
        }
    }
}