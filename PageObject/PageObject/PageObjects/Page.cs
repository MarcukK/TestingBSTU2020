using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace PageObject.PageObjects
{
    public class Page
    {
        protected string pageURL = "";

        protected DefaultWait<IWebDriver> fluentWait;
        protected IWebDriver driver;
        protected int timeoutInSeconds = 30;
        protected string cookiesId = "onetrust-accept-btn-handler";

        public Page(IWebDriver driver)
        {
            fluentWait = GetFluentWait(driver);
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public Page OpenPage()
        {
            driver.Navigate().GoToUrl(pageURL);
            return this;
        }

        public Page AcceptCookies()
        {
            IWebElement cookiesPopup = WaitForTheElement(fluentWait, By.Id(cookiesId));
            cookiesPopup.Click();
            return this;
        }

        [Obsolete]
        private ReadOnlyCollection<IWebElement> WaitForElement(IWebDriver webDriver, By by)
        {
            return (new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds))
                .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by)));
        }

        public DefaultWait<IWebDriver> GetFluentWait(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(50);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait;
        }

        public IWebElement WaitForTheElement(DefaultWait<IWebDriver> fluentWait, By by)
        {
            while (true) //required to wait until element will be created(not showed, just created)
            {
                try
                {
                    IWebElement webElement = fluentWait.Until(x => x.FindElement(by));
                    return webElement;
                }
                catch (Exception e)
                { }
            }
        }
    }
}
