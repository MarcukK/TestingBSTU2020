using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverLab
{
    class Tests
    {
        string productNameChangeOfClothingTest = "Medium Vintage Check Bonded Cotton Bum Bag";
        string productColorChangeOfClothingTest = "archive beige";
        string productItemChangeOfClothingTest = "80104301";
        

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


            IWebElement colorChoice = fluentWait.Until(x => x.FindElement(By.XPath("//a[@aria-label='Archive beige']")));
            colorChoice.Click();

            IWebElement productName = fluentWait.Until(x => x.FindElement(By.XPath("//h1[@class='product-info-panel__title']/span")));
            while(productName.Text != productNameChangeOfClothingTest) ;

            IWebElement addButton = fluentWait.Until(x => x.FindElement(By.ClassName("add-to-bag__button-content")));
            addButton.Click();

            IWebElement basketCounter = WaitForTheElement(fluentWait, By.ClassName("header__button--with-one-digit-counter"));
            while (!basketCounter.Displayed) ;
            IWebElement basket = fluentWait.Until(x => x.FindElement(By.XPath("//a[@title='Bag']")));
            while (!basket.Displayed);
            basket.Click();

            IWebElement productInBasketName = fluentWait.Until(x => x.FindElement(By.XPath("//h2[text()='Medium Vintage Check Bonded Cotton Bum Bag']")));
            IWebElement productInBasketColor = fluentWait.Until(x => x.FindElement(By.XPath("//dd[text()='\n                                                        Archive beige']")));
            IWebElement productInBasketItem = fluentWait.Until(x => x.FindElement(By.XPath("//dd[text()='\n                                                        80104301']")));

            //IWebElement productInBasketColor = fluentWait.Until(x => x.FindElement(By.XPath("//dd[@class='color-value']")));
            //IWebElement productInBasketItem = fluentWait.Until(x => x.FindElement(By.XPath("//dd[@class='id-value']")));

            Assert.AreEqual(productInBasketName.Text.Trim(), productNameChangeOfClothingTest);
            Assert.AreEqual(productInBasketColor.Text.Trim(), productColorChangeOfClothingTest);
            Assert.AreEqual(productInBasketItem.Text.Trim(), productItemChangeOfClothingTest);
        }

        [TearDown]
        public void TearDownTests()
        {
            if (driver != null)
                driver.Quit();
        }

    }
}
