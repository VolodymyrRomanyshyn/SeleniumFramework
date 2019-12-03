using System;

namespace Framework.BrowserSettings
{
    public class Settings : ISettings
    {
        public TimeSpan TimeWait => ConfigReader.TimeWait;
        public TimeSpan ReportTimeWait => ConfigReader.ReportTimeWait;
        public Browsers Browser => ConfigReader.Browser;
    }
}
