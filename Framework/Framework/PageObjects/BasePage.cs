﻿using Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace PageObject.PageObjects
{
    public class BasePage
    {
        protected DefaultWait<IWebDriver> fluentWait;
        protected IWebDriver driver;
        protected const int timeoutInSeconds = 30;
        protected const string cookiesId = "onetrust-accept-btn-handler";

        public BasePage(IWebDriver driver)
        {
            fluentWait = GetFluentWait(driver);
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public BasePage OpenPage(string pageURL)
        {
            Logger.Log.Info("Open page");
            driver.Navigate().GoToUrl(pageURL);
            return this;
        }

        public BasePage AcceptCookies()
        {
            Logger.Log.Info("Accept cookies");
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
            Logger.Log.Info("Wait for the element");
            while (true) //required to wait until element will be created(not showed, just created)
            {
                try
                {
                    IWebElement webElement = fluentWait.Until(x => x.FindElement(by));
                    return webElement;
                }
                catch (Exception e)
                {  }
            }
        }

        public IWebElement WaitForTheElement(IWebElement element)
        {
            Logger.Log.Info("Wait for the element");
            while (true) //required to wait until element will be created(not showed, just created)
            {
                try
                {
                    while (!element.Displayed) ;
                    return element;
                }
                catch (Exception e)
                { }
            }
        }
    }
}
