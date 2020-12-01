using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObject.PageObjects;
using PageObject.PageObjects.ProductPages;
using PageObject.PageObjects.BasketPages;
using System;


namespace PageObject
{
    class Tests
    {


        IWebDriver driver;
        string websiteUrl = "https://uk.burberry.com/logo-detail-econyl-sonny-bum-bag-p80256681?searchQuery=Logo%20Detail%20ECONYL%C2%AE%20Sonny%20Bum%20Bag";

        private IWebDriver driverCheckingTheNameChangeOfTheSelectedClothing;
        private IWebDriver driverCheckingTheSizeChangeOfTheSelectedClothing;

        [SetUp]
        public void SetupTests()
        {
            //driver = new ChromeDriver();
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-fullscreen");
            driver = new ChromeDriver(options);


        }

        [Test, Description("CheckingTheNameChangeOfTheSelectedClothing Test Failed")]
        public void CheckingTheNameChangeOfTheSelectedClothing()
        {
            driverCheckingTheNameChangeOfTheSelectedClothing = driver;

            ProductPageForCheckingTheNameChangeOfTheSelectedClothing productPageCheckingTheNameChangeOfTheSelectedClothing = new ProductPageForCheckingTheNameChangeOfTheSelectedClothing(driver);

            BasketForCheckingTheNameChangeOfTheSelectedClothing basketCheckingTheNameChangeOfTheSelectedClothing = 
                productPageCheckingTheNameChangeOfTheSelectedClothing
                                                      .OpenPage()
                                                      .AcceptCookies()
                                                      .ChooseColor()
                                                      .AddProductToBasket()
                                                      .NavigateToBasket();

            Assert.IsTrue(basketCheckingTheNameChangeOfTheSelectedClothing.IsProductsNamesEqual(),
                          "CheckingTheNameChangeOfTheSelectedClothing");
        }

        [Test, Description("Test is not complete")]
        public void CheckingTheSizeChangeOfTheSelectedClothing()
        {
            driverCheckingTheSizeChangeOfTheSelectedClothing = driver;

            ProductPageForCheckingTheSizeChangeOfTheSelectedClothing productPageCheckingTheSizeChangeOfTheSelectedClothing = new ProductPageForCheckingTheSizeChangeOfTheSelectedClothing(driver);

            BasketForCheckingTheSizeChangeOfTheSelectedClothing basketCheckingTheSizeChangeOfTheSelectedClothing =
                productPageCheckingTheSizeChangeOfTheSelectedClothing
                                                      .OpenPage()
                                                      .AcceptCookies()
                                                      .ChooseSize()
                                                      .AddProductToBasket()
                                                      .NavigateToBasket();

            Assert.AreEqual(basketCheckingTheSizeChangeOfTheSelectedClothing.GetSize(),
                            productPageCheckingTheSizeChangeOfTheSelectedClothing.productSizeForCheckingSizeChangeOfClothingTest,
                           "CheckingTheSizeChangeOfTheSelectedClothing");
        }

        [TearDown]
        public void TearDownTests()
        {
            if (driver != null)
                driver.Quit();
        }

    }
}


