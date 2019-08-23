using Framework.BrowserSettings;
using Framework.Driver;
using Framework.SiteDecorators;

namespace Framework.Sites
{
    public class BaseSite
    {
        private readonly ISettings Settings;
        private readonly BaseDriver BaseDriver;

        public BaseSite(BaseDriver baseDriver)
        {
            BaseDriver = baseDriver;
            SiteFactory.InitElements(this, BaseDriver);
        }

        public BaseSite()
        {
            BaseDriver = new BaseDriver();
            SiteFactory.InitElements(this, BaseDriver);
        }

        public BaseSite(ISettings settings)
        {
            Settings = settings;
            BaseDriver = new BaseDriver(Settings);
            SiteFactory.InitElements(this, BaseDriver);
        }
    }
}
