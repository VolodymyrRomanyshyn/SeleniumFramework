using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Framework.Driver.Support
{
    public class JavaScriptExecutor
    {
        private IWebElement _webElement;

        public JavaScriptExecutor(IWebElement webElement) => _webElement = webElement;

        public void ScrollIntoView() => Get().ExecuteScript("arguments[0].scrollIntoView(true);", _webElement);

        private IJavaScriptExecutor Get()
        {
            var remoteWebDriver = _webElement as RemoteWebElement;
            return (IJavaScriptExecutor)remoteWebDriver.WrappedDriver;
        }
    }
}
