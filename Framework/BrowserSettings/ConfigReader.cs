using System;
using Microsoft.Extensions.Configuration;

namespace Framework.BrowserSettings
{
    public class ConfigReader
    {
        private static IConfiguration config;

        protected static IConfiguration Config => config ?? (config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());

        public static Browsers Browser
        {
            get
            {
                bool supportedBrowser = Enum.TryParse(Environment.GetEnvironmentVariable("Browser"), true,
                    out Browsers browserType);
                if (!supportedBrowser)
                {
                    supportedBrowser = Enum.TryParse(Config.GetSection("SeleniumSettings")["browser"], true,
                        out browserType);
                }

                return supportedBrowser ? browserType : Browsers.None;
            }
        }
    }
}
