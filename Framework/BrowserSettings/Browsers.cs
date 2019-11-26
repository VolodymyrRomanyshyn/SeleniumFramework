namespace Framework.BrowserSettings
{
    /// <summary>
    /// Represents the list of known and supported browsers that Framework runs on.
    /// </summary>
    public enum Browsers
    {
        /// <summary>
        /// The Chrome browser used to run the test.
        /// </summary>
        Chrome,

        /// <summary>
        /// The abbreviation for Chrome browser. The test will be run in the Chrome.
        /// </summary>
        CH,

        /// <summary>
        /// The test will be run in the Chrome headless mode in the background.
        /// </summary>
        ChromeHeadless,

        /// <summary>
        /// The abbreviation for Chrome Headless browser. The test will be run in the Chrome headless mode in the background.
        /// </summary>
        CHH,

        /// <summary>
        /// The Edge browser used to run the test.
        /// </summary>
        Edge,

        /// <summary>
        /// The abbreviation for Edge browser. The test will be run in the Edge.
        /// </summary>
        ED,

        /// <summary>
        /// The Firefox browser used to run the test.
        /// </summary>
        Firefox,

        /// <summary>
        /// The abbreviation for Firefox browser. The test will be run in the Firefox.
        /// </summary>
        FF,

        /// <summary>
        /// The test will be run in the InternetExplorer.
        /// </summary>
        InternetExplorer,

        /// <summary>
        /// The abbreviation for InternetExplorer browser. The test will be run in the InternetExplorer.
        /// </summary>
        IE,

        /// <summary>
        /// If the requested browser is either not supported or if the config setting is missing/contains invalid value.
        /// </summary>
        None
    }
}
