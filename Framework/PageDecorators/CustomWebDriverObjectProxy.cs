using Framework.Driver;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Framework.PageDecorators
{
    public abstract class CustomWebDriverObjectProxy : DispatchProxy
    {
        protected IElementLocator Locator { get; private set; }
        protected IEnumerable<By> Bys { get; private set; }
        protected bool Cache { get; private set; }

        protected Type ElementOfGenericListType { get; private set; }
        protected BaseDriver BaseDriver { get; private set; }
        protected string Name { get; private set; }

        protected void SetSearchProperites(BaseDriver baseDriver, string name, Type elementOfGenericListType, IElementLocator locator, IEnumerable<By> bys, bool cache)
        {

            ElementOfGenericListType = elementOfGenericListType;
            BaseDriver = baseDriver;
            Name = name;

            Locator = locator;
            Bys = bys;
            Cache = cache;
        }
    }
}
