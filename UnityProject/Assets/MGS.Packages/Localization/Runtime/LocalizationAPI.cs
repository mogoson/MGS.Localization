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