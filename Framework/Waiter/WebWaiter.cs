using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Framework.Waiter
{
    public class WebWaiter
    {
        private WebDriverWait wait;

        public WebWaiter(WebDriverWait wait) => this.wait = wait;

        public TResult Until<TResult>(Func<IWebDriver, TResult> condition) => wait.Until<TResult>(condition);

        public bool UntilToBeClickable(IWebElement element)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public bool UntilToBeVisible(IWebElement element)
        {
            try
            {
                wait.Until(el => element.Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public bool UntilToBeUnVisible(IWebElement element)
        {
            try
            {
                wait.Until(el => !element.Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public bool UntilElementAppearOnPage(By by)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementExists(by));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public bool UntilElementDisapearOnPage(By by)
        {
            try
            {
                IWebElement webElement = wait.Until(ExpectedConditions.ElementExists(by));
                Until(_ => !webElement.Displayed);
            }
            catch (StaleElementReferenceException) { }
            catch (NoSuchElementException) { }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public void UntilToBeVisible(By by) => wait.Until(ExpectedConditions.ElementIsVisible(by));

        public void WaitUtilTextToBePresentInElement(IWebElement element, string text) => wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));

        public void WaitUntilElementDisappear(IWebElement element)
        {
            try
            {
                wait.Until(el => !element.Displayed);
            }
            catch(Exception ex)
            {
                if(ex is StaleElementReferenceException || ex is NoSuchElementException)
                {
                }
            }
        }

        public void UntilTagHasValue(IWebElement element, string Tag, string Value) => wait.Until(el => element.GetAttribute(Tag).Equals(Value));
    }
}
