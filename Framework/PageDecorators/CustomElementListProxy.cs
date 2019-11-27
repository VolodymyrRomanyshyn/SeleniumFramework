using Framework.Driver;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Framework.PageDecorators
{
    public class CustomElementListProxy : CustomWebDriverObjectProxy
    {
        private object collection = null;

        private object ElementList
        {
            get
            {
                if (!Cache || collection == null)
                {
                    IList<IWebElement> webElements = Locator.LocateElements(Bys);

                    var listType = typeof(List<>);
                    var constructedListType = listType.MakeGenericType(ElementOfGenericListType);
                    var list = (IList)Activator.CreateInstance(constructedListType);
                    var number = 0;
                    foreach (IWebElement webElement in webElements)
                    {
                        var element = ElementOfGenericListType
                            .GetConstructor(new[] { typeof(IWebElement), typeof(BaseDriver), typeof(string) })
                            .Invoke(new object[] { webElement, BaseDriver, $"Element {number} from : {Name} list" });

                        list.Add(element);
                        number++;
                    }
                    return list;

                }
                return collection;
            }
        }

        public static object CreateProxy(BaseDriver baseDriver, string name, Type elementOfGenericListType, IElementLocator locator, IEnumerable<By> bys, bool cacheLookups)
        {
            var tlist = typeof(IList<>).MakeGenericType(elementOfGenericListType);
            var proxy = typeof(DispatchProxy).GetMethod("Create").MakeGenericMethod(tlist, typeof(CustomElementListProxy)).Invoke(null, new object[] { });
            ((CustomElementListProxy)proxy).SetSearchProperties(baseDriver, name, elementOfGenericListType, locator, bys, cacheLookups);
            return proxy;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            return targetMethod.Invoke(ElementList, args);
        }
    }
}
