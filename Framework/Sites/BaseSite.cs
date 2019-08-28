﻿using Framework.BrowserSettings;
using Framework.Driver;
using Framework.SiteDecorators;
using System;

namespace Framework.Sites
{
    public class BaseSite : IDisposable
    {
        public ISettings Settings { get; }
        public BaseDriver BaseDriver { get; }

        public BaseSite(BaseDriver baseDriver)
        {
            BaseDriver = baseDriver;
            SiteFactory.InitElements(this, BaseDriver);
        }

        public BaseSite()
        {
            BaseDriver = new BaseDriver();
            Settings = BaseDriver.Settings;
            SiteFactory.InitElements(this, BaseDriver);
        }

        public BaseSite(ISettings settings)
        {
            Settings = settings;
            BaseDriver = new BaseDriver(Settings);
            SiteFactory.InitElements(this, BaseDriver);
        }

        public void Dispose()
        {
            BaseDriver?.Close();
            BaseDriver?.Quit();
        }
    }
}
