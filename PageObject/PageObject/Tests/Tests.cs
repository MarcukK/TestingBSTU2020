using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObject.DataLayer;
using PageObject.PageObjects;
using System;
using System.Collections.Generic;

namespace PageObject
{
    class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void SetupTests()
        {
            //driver = new ChromeDriver();
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-fullscreen");
            driver = new ChromeDriver(options);
        }

        [Test, Description("CheckProductAttributesAfterColorChange Test Failed")]
        public void CheckProductAttributesAfterColorChange()
        {
            ProductPage productPageCheckProductAttributesAfterColorChange = new ProductPage(driver);

            BasketPage basketCheckProductAttributesAfterColorChange = 
                productPageCheckProductAttributesAfterColorChange
                                                      .OpenPage(TestingProducts.SonnyBumBagBlack.URL)
                                                      .AcceptCookies()
                                                      .ChooseColor("Archive beige", TestingProducts.CottonBumBag.name)
                                                      .AddProductToBasket()
                                                      .NavigateToBasket();

            List<Product> products = basketCheckProductAttributesAfterColorChange.GetProducts();

            Assert.AreEqual(TestingProducts.CottonBumBag.name,  products[0].name,  "invalid name");
            Assert.AreEqual(TestingProducts.CottonBumBag.color, products[0].color, "invalid color");
            Assert.AreEqual(TestingProducts.CottonBumBag.size,  products[0].size,  "invalid size");
            Assert.AreEqual(TestingProducts.CottonBumBag.item,  products[0].item,  "invalid item");
            Assert.AreEqual(TestingProducts.CottonBumBag.price, products[0].price, "invalid price");
            Assert.AreEqual(TestingProducts.CottonBumBag.count, products[0].count, "invalid count");
        }

        [Test, Description("Test is not complete")]
        public void CheckProductAttributesAfterSizeChange()
        {
            ProductPage productPageCheckProductAttributesAfterSizeChange = new ProductPage(driver);

            BasketPage basketCheckProductAttributesAfterSizeChange =
                productPageCheckProductAttributesAfterSizeChange
                                                      .OpenPage(TestingProducts.OversizedShirt.URL)
                                                      .AcceptCookies()
                                                      .ChooseSize("04")
                                                      .AddProductToBasket()
                                                      .NavigateToBasket();

            List<Product> products = basketCheckProductAttributesAfterSizeChange.GetProducts();

            Assert.AreEqual(TestingProducts.OversizedShirt.name,            products[0].name,  "invalid name");
            Assert.AreEqual(TestingProducts.OversizedShirt.color.ToLower(), products[0].color, "invalid color");
            Assert.AreEqual(TestingProducts.OversizedShirt.size,            products[0].size,  "invalid size");
            Assert.AreEqual(TestingProducts.OversizedShirt.item,            products[0].item,  "invalid item");
            Assert.AreEqual(TestingProducts.OversizedShirt.price,           products[0].price, "invalid price");
            Assert.AreEqual(TestingProducts.OversizedShirt.count,           products[0].count, "invalid count");
        }

        [TearDown]
        public void TearDownTests()
        {
            if (driver != null)
                driver.Quit();
        }

    }
}


