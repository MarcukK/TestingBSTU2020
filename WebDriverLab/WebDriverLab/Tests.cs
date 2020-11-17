using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverLab
{
    class Tests
    {

        IWebDriver driver;
        string websiteUrl = "https://uk.burberry.com/logo-detail-econyl-sonny-bum-bag-p80256681?searchQuery=Logo%20Detail%20ECONYL%C2%AE%20Sonny%20Bum%20Bag";

        [SetUp]
        public void SetupTests()
        {
            //driver = new ChromeDriver();
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-fullscreen");
            driver = new ChromeDriver(options);


        }


        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl(websiteUrl);

            IWebElement colorChoice = driver.FindElement(By.CssSelector("div.swatch:nth-child(1)>a:nth-child(1)>span:nth-child(1)"));
            colorChoice.Click();

            IWebElement cookiesPopup = driver.FindElement(By.CssSelector("#onetrust-accept-btn-handler"));
            cookiesPopup.Click();

            IWebElement addButton = driver.FindElement(By.CssSelector(".add-to-bag__button-title"));
            addButton.Click();

            IWebElement basket = driver.FindElement(By.CssSelector(".icon--glyph-bag>svg:nth-child(1)>path:nth-child(2)"));
            basket.Click();



            Assert.IsTrue(true);
        }

        [TearDown]
        public void TearDownTests()
        {
            driver.Quit();
        }

    }
}
