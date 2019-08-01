using System;

namespace Framework.BrowserSettings
{
    public interface ISettings
    {
        TimeSpan TimeWait { get; }
        TimeSpan ReportTimeWait { get; }
        string Browser { get; }
    }
}
