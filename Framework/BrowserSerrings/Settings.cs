using System;

namespace Framework.BrowserSettings
{
    public class Settings : ISettings
    {
        public TimeSpan TimeWait => TimeSpan.FromSeconds(20);
        public TimeSpan ReportTimeWait => TimeSpan.FromSeconds(60);
        public string Browser => "chrome";
    }
}
