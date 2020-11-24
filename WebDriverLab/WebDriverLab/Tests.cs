using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebDriverLab
{
    class Tests
    {
        string productNameForCheckingNameChangeOfClothingTest = "Medium Vintage Check Bonded Cotton Bum Bag";

        IWebDriver driver;
        string websiteUrl = "https://uk.burberry.com/logo-detail-econyl-sonny-bum-bag-p80256681?searchQuery=Logo%20Detail%20ECONYL%C2%AE%20Sonny%20Bum%20Bag";

        private IWebDriver driverCheckingTheNameChangeOfTheSelectedClothing;

        [SetUp]
        public void SetupTests()
        {
            //driver = new ChromeDriver();
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-fullscreen");
            driver = new ChromeDriver(options);


        }

        public static DefaultWait<IWebDriver> GetFluentWait(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(50);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait;
        }

        public static IWebElement WaitForTheElement(DefaultWait<IWebDriver> fluentWait, By by)
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


        [Test, Description("Test is not complete")]
        public void CheckingTheNameChangeOfTheSelectedClothing()
        {
            driverCheckingTheNameChangeOfTheSelectedClothing = driver;
            
            driverCheckingTheNameChangeOfTheSelectedClothing.Navigate().GoToUrl(websiteUrl);
            
            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driverCheckingTheNameChangeOfTheSelectedClothing);


            IWebElement cookiesPopup = WaitForTheElement(fluentWait, By.Id("onetrust-accept-btn-handler"));
            cookiesPopup.Click();


            IWebElement colorChoice = fluentWait.Until(x => x.FindElement(By.CssSelector("div.swatch:nth-child(1)>a:nth-child(1)>span:nth-child(1)")));
            colorChoice.Click();

            IWebElement productName = fluentWait.Until(x => x.FindElement(By.CssSelector("h1>span:nth-child(1)")));
            while(productName.Text != productNameForCheckingNameChangeOfClothingTest) ;

            IWebElement addButton = fluentWait.Until(x => x.FindElement(By.ClassName("add-to-bag__button-content")));
            addButton.Click();

            IWebElement basketCounter = WaitForTheElement(fluentWait, By.ClassName("header__button--with-one-digit-counter"));
            IWebElement basket = fluentWait.Until(x => x.FindElement(By.CssSelector("div.header__icon-container>ul>li:nth-child(3)")));
            while (!basket.Displayed);
            basket.Click();

            IWebElement productInBasketName = fluentWait.Until(x => x.FindElement(By.CssSelector("td.item-description.item-description-top.item-description-oneline.cell>h2")));

            Assert.AreEqual(productInBasketName.Text, productNameForCheckingNameChangeOfClothingTest);
        }

        [TearDown]
        public void TearDownTests()
        {
            if (driver != null)
                driver.Quit();
        }

    }
}
