/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Localizer.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  01/24/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Localize
{
    public abstract class Localizer : MonoBehaviour, ILocalizer
    {
        public abstract void Localize();
    }
}