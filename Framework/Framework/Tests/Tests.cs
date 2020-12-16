using Framework;
using Framework.Model;
using Framework.PageObjects;
using Framework.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.DataLayer;
using PageObject.PageObjects;
using System;
using System.Collections.Generic;

namespace PageObject
{
    //[Parallelizable(ParallelScope.All)]
    class Tests
    {
        IWebDriver driver;
        public List<Product> products;
        public List<Product> expectedProducts;
        Product expectedProduct;

        [SetUp]
        public void SetupTests()
        {
            driver = DriverSingleton.GetDriver(Browser.Developer);
            Logger.InitLogger();
        }

        [Test, Description("CheckProductAttributesAfterBasketAdding Test Failed")]
        public void CheckProductAttributesAfterBasketAdding()
        {
            Logger.Log.Info("CheckProductAttributesAfterBasketAdding");
            Product startProduct = ProductCreator.withManyColors_Black();
            expectedProduct = ProductCreator.withManyColors_Black();
            ProductPage productPageCheckProductAttributesAfterBasketAdding = new ProductPage(driver);
            try
            {
                BasketPage basketCheckProductAttributesAfterBasketAdding =
                    productPageCheckProductAttributesAfterBasketAdding
                                                          .OpenPage(startProduct.URL)
                                                          .AcceptCookies()
                                                          .AddProductToBasket()
                                                          .NavigateToBasket();

                products = basketCheckProductAttributesAfterBasketAdding.GetProducts();
            }
            catch (Exception ex)
            {
                Logger.ErrorHandler(driver, ex);
            }
            Assert.AreEqual(expectedProduct.name, products[0].name, "invalid name");
            Assert.AreEqual(expectedProduct.color.ToLower(), products[0].color, "invalid color");
            Assert.AreEqual(expectedProduct.size, products[0].size, "invalid size");
            Assert.AreEqual(expectedProduct.item, products[0].item, "invalid item");
            Assert.AreEqual(expectedProduct.price, products[0].price, "invalid price");
            Assert.AreEqual(expectedProduct.count, products[0].count, "invalid count");
        }

        [Test, Description("CheckProductAttributesAfterColorChange Test Failed")]
        public void CheckProductAttributesAfterColorChange()
        {
            Logger.Log.Info("CheckProductAttributesAfterColorChange");
            Product startProduct = ProductCreator.withManyColors_Black();
            expectedProduct = ProductCreator.withManyColors_ArchiveBeige();
            ProductPage productPageCheckProductAttributesAfterColorChange = new ProductPage(driver);
            try
            {
                BasketPage basketCheckProductAttributesAfterColorChange =
                    productPageCheckProductAttributesAfterColorChange
                                                          .OpenPage(startProduct.URL)
                                                          .AcceptCookies()
                                                          .ChooseColor(expectedProduct.color, expectedProduct.name)
                                                          .AddProductToBasket()
                                                          .NavigateToBasket();

                products = basketCheckProductAttributesAfterColorChange.GetProducts();
            }
            catch (Exception ex)
            {
                Logger.ErrorHandler(driver, ex);
            }
            Assert.AreEqual(expectedProduct.name,            products[0].name,  "invalid name");
            Assert.AreEqual(expectedProduct.color.ToLower(), products[0].color, "invalid color");
            Assert.AreEqual(expectedProduct.size,            products[0].size,  "invalid size");
            Assert.AreEqual(expectedProduct.item,            products[0].item,  "invalid item");
            Assert.AreEqual(expectedProduct.price,           products[0].price, "invalid price");
            Assert.AreEqual(expectedProduct.count,           products[0].count, "invalid count");
        }

        [Test, Description("CheckProductAttributesAfterSizeChoice Test Failed")]
        public void CheckProductAttributesAfterSizeChoice()
        {
            Logger.Log.Info("CheckProductAttributesAfterSizeChoice");
            expectedProduct = ProductCreator.withManySizes_04();
            ProductPage productPageCheckProductAttributesAfterSizeChoice = new ProductPage(driver);
            try
            {
                BasketPage basketCheckProductAttributesAfterSizeChoice =
                    productPageCheckProductAttributesAfterSizeChoice
                                                          .OpenPage(expectedProduct.URL)
                                                          .AcceptCookies()
                                                          .ChooseSize(expectedProduct.size)
                                                          .AddProductToBasket()
                                                          .NavigateToBasket();

                products = basketCheckProductAttributesAfterSizeChoice.GetProducts();
            }
            catch (Exception ex)
            {
                Logger.ErrorHandler(driver, ex);
            }
            Assert.AreEqual(expectedProduct.name,            products[0].name,  "invalid name");
            Assert.AreEqual(expectedProduct.color.ToLower(), products[0].color, "invalid color");
            Assert.AreEqual(expectedProduct.size,            products[0].size,  "invalid size");
            Assert.AreEqual(expectedProduct.item,            products[0].item,  "invalid item");
            Assert.AreEqual(expectedProduct.price,           products[0].price, "invalid price");
            Assert.AreEqual(expectedProduct.count,           products[0].count, "invalid count");
        }

        [Test, Description("CheckTheSelectionOfClothesWithoutSize Test Failed")]
        public void CheckTheSelectionOfClothesWithoutSize()
        {
            Logger.Log.Info("CheckTheSelectionOfClothesWithoutSize");
            Product productForTest = ProductCreator.withManySizes_04();
            string expectedMessage = "Please select a size";
            ProductPage productPageCheckTheSelectionOfClothesWithoutSize = new ProductPage(driver);
            string actualMessage = "";
            try
            {
                productPageCheckTheSelectionOfClothesWithoutSize.OpenPage(productForTest.URL)
                                                                .AcceptCookies()
                                                                .AddProductToBasket();

                actualMessage = productPageCheckTheSelectionOfClothesWithoutSize.GetNoSizeErrorLabel();
            }
            catch (Exception ex)
            {
                Logger.ErrorHandler(driver, ex);
            }

            Assert.AreEqual(expectedMessage, actualMessage, "invalid error message") ;
        }

        [Test, Description("CheckAddingToFavorites Test Failed")]
        [TestCase(3)]
        public void CheckAddingToFavorites(int countOfProductsToAddToFavourites)
        {
            Logger.Log.Info("CheckAddingToFavorites");
            int currentCountOfFavouriteProducts = countOfProductsToAddToFavourites;
            Catalog catalogForTest = CatalogCreator.withWomensScarves();
            CatalogPage catalogPageCheckAddingToFavorites = new CatalogPage(driver);
            try
            {
                catalogPageCheckAddingToFavorites.OpenPage(catalogForTest.URL)
                                                 .AcceptCookies();
                currentCountOfFavouriteProducts = catalogPageCheckAddingToFavorites.GetNumberOfFavouriteProducts();
            catalogPageCheckAddingToFavorites.AddProductsToFavourites(countOfProductsToAddToFavourites);
            currentCountOfFavouriteProducts = catalogPageCheckAddingToFavorites.GetNumberOfFavouriteProducts() - currentCountOfFavouriteProducts;
        }
            catch (Exception ex)
            {
                Logger.ErrorHandler(driver, ex);
            }

            Assert.AreEqual(countOfProductsToAddToFavourites, 
                            currentCountOfFavouriteProducts,
                            "invalid favourite products count");
        }

        [Test, Description("CheckAddingPersonalisation Test Failed")]
        public void CheckAddingPersonalisation()
        {
            Logger.Log.Info("CheckAddingPersonalisation");
            expectedProduct = ProductCreator.withPersonalisation();
            ProductPage productPageCheckAddingPersonalisation = new ProductPage(driver);
            try
            {

                BasketPage basketPageCheckAddingPersonalisation = 
                    productPageCheckAddingPersonalisation.OpenPage(expectedProduct.URL)
                                                                .AcceptCookies()
                                                                .AddPersonalization(expectedProduct.personalisation)
                                                                .AddProductToBasket()
                                                                .NavigateToBasket();

                products = basketPageCheckAddingPersonalisation.GetProducts();
            }
            catch (Exception ex)
            {
                Logger.ErrorHandler(driver, ex);
            }
            Assert.AreEqual(expectedProduct.name, products[0].name, "invalid name");
            Assert.AreEqual(expectedProduct.color.ToLower(), products[0].color, "invalid color");
            Assert.AreEqual(expectedProduct.size, products[0].size, "invalid size");
            Assert.AreEqual(expectedProduct.item, products[0].item, "invalid item");
            Assert.AreEqual(expectedProduct.personalisation, products[0].personalisation, "invalid personalisation");
            Assert.AreEqual(expectedProduct.personalisationColor, products[0].personalisationColor, "invalid personalisation color");
            Assert.AreEqual(expectedProduct.price, products[0].price, "invalid price");
            Assert.AreEqual(expectedProduct.count, products[0].count, "invalid count");
        }

        [Test, Description("CheckTheTotalPriceOfTwoIdenticalGoods Test Failed")]
        public void CheckTheTotalPriceOfTwoIdenticalGoods()
        {
            Logger.Log.Info("CheckTheTotalPriceOfTwoIdenticalGoods");
            expectedProduct = ProductCreator.withCountAndPriceMultiplyedByTwo();
            string totalPrice = "";
            ProductPage productPageCheckTheTotalPriceOfTwoIdenticalGoods = new ProductPage(driver);
            try
            {

                BasketPage basketPageCheckTheTotalPriceOfTwoIdenticalGoods =
                    productPageCheckTheTotalPriceOfTwoIdenticalGoods.OpenPage(expectedProduct.URL)
                                                                .AcceptCookies()
                                                                .AddProductToBasketSeveralTimes(expectedProduct.count)
                                                                .NavigateToBasket();

                products = basketPageCheckTheTotalPriceOfTwoIdenticalGoods.GetProducts();
                totalPrice = basketPageCheckTheTotalPriceOfTwoIdenticalGoods.GetTotalPrice();
            }
            catch (Exception ex)
            {
                Logger.ErrorHandler(driver, ex);
            }
            Assert.AreEqual(expectedProduct.name, products[0].name, "invalid name");
            Assert.AreEqual(expectedProduct.color.ToLower(), products[0].color, "invalid color");
            Assert.AreEqual(expectedProduct.size, products[0].size, "invalid size");
            Assert.AreEqual(expectedProduct.item, products[0].item, "invalid item");
            Assert.AreEqual(expectedProduct.personalisation, products[0].personalisation, "invalid personalisation");
            Assert.AreEqual(expectedProduct.personalisationColor, products[0].personalisationColor, "invalid personalisation color");
            Assert.AreEqual(expectedProduct.price, totalPrice, "invalid price");
            Assert.AreEqual(expectedProduct.count, products[0].count, "invalid count");
        }

        [Test, Description("CheckTheTotalPriceOfTwoDifferentGoods Test Failed")]
        public void CheckTheTotalPriceOfTwoDifferentGoods()
        {
            Logger.Log.Info("CheckTheTotalPriceOfTwoDifferentGoods");
            expectedProducts = new List<Product>();
            expectedProducts.Add(ProductCreator.withManyColors_Black());
            expectedProducts.Add(ProductCreator.withManyColors_ArchiveBeige());
            string totalPrice = "";
            ProductPage productPageCheckTheTotalPriceOfTwoDifferentGoods = new ProductPage(driver);
            try
            {

                productPageCheckTheTotalPriceOfTwoDifferentGoods.OpenPage(expectedProducts[0].URL)
                                                                .AcceptCookies()
                                                                .AddProductToBasket()
                                                                .NavigateToBasket();               


                BasketPage basketPageCheckTheTotalPriceOfTwoDifferentGoods =
                    productPageCheckTheTotalPriceOfTwoDifferentGoods.OpenPage(expectedProducts[1].URL)
                                                                .AddProductToBasket()
                                                                .NavigateToBasket();

                products = basketPageCheckTheTotalPriceOfTwoDifferentGoods.GetProducts();
                totalPrice = basketPageCheckTheTotalPriceOfTwoDifferentGoods.GetTotalPrice();
            }
            catch (Exception ex)
            {
                Logger.ErrorHandler(driver, ex);
            }
            Assert.AreEqual(expectedProducts[0].name, products[0].name, "invalid name");
            Assert.AreEqual(expectedProducts[0].color.ToLower(), products[0].color, "invalid color");
            Assert.AreEqual(expectedProducts[0].size, products[0].size, "invalid size");
            Assert.AreEqual(expectedProducts[0].item, products[0].item, "invalid item");
            Assert.AreEqual(expectedProducts[0].personalisation, products[0].personalisation, "invalid personalisation");
            Assert.AreEqual(expectedProducts[0].personalisationColor, products[0].personalisationColor, "invalid personalisation color");
            Assert.AreEqual(expectedProducts[0].count, products[0].count, "invalid count");

            Assert.AreEqual(expectedProducts[1].name, products[1].name, "invalid name");
            Assert.AreEqual(expectedProducts[1].color.ToLower(), products[1].color, "invalid color");
            Assert.AreEqual(expectedProducts[1].size, products[1].size, "invalid size");
            Assert.AreEqual(expectedProducts[1].item, products[1].item, "invalid item");
            Assert.AreEqual(expectedProducts[1].personalisation, products[1].personalisation, "invalid personalisation");
            Assert.AreEqual(expectedProducts[1].personalisationColor, products[1].personalisationColor, "invalid personalisation color");
            Assert.AreEqual(expectedProducts[1].count, products[1].count, "invalid count");

            string productsTotalPrice = "£1,040";
            Assert.AreEqual(productsTotalPrice, totalPrice, "invalid price");
        }

        [Test, Description("CheckTheCountOfShopsInUK Test Failed")]
        public void CheckTheCountOfShopsInUK()
        {
            Logger.Log.Info("CheckTheCountOfShopsInUK");
            expectedProduct = ProductCreator.withManyColors_Black();
            string expectedLabel = "21 STORES IN UNITED KINGDOM";
            string actualLabel = "";
            ProductPage productPageCheckTheCountOfShopsInUK = new ProductPage(driver);
            try
            {
                productPageCheckTheCountOfShopsInUK.OpenPage(expectedProduct.URL)
                                                                .AcceptCookies()
                                                                .FindInStore()
                                                                .AddStoresWithNoCurrentAvailability();

                actualLabel = productPageCheckTheCountOfShopsInUK.GetNumberOfShopsLabel();
            }
            catch (Exception ex)
            {
                Logger.ErrorHandler(driver, ex);
            }
            Assert.AreEqual(expectedLabel, actualLabel, "invalid label");
        }

        [Test, Description("CheckTheBiggerPriceForBiggerSizeOfParfum Test Failed")]
        public void CheckTheBiggerPriceForBiggerSizeOfParfum()
        {
            Logger.Log.Info("CheckTheBiggerPriceForBiggerSizeOfParfum");
            expectedProducts = new List<Product>();
            expectedProducts.Add(ProductCreator.with100ml());
            expectedProducts.Add(ProductCreator.with30ml());
            ProductPage productPageCheckTheTotalPriceOfTwoDifferentGoods = new ProductPage(driver);
            try
            {

                productPageCheckTheTotalPriceOfTwoDifferentGoods.OpenPage(expectedProducts[0].URL)
                                                                .AcceptCookies()
                                                                .AddProductToBasket()
                                                                .NavigateToBasket();


                BasketPage basketPageCheckTheTotalPriceOfTwoDifferentGoods =
                    productPageCheckTheTotalPriceOfTwoDifferentGoods.OpenPage(expectedProducts[1].URL)
                                                                .AddProductToBasket()
                                                                .NavigateToBasket();

                products = basketPageCheckTheTotalPriceOfTwoDifferentGoods.GetProducts();
            }
            catch (Exception ex)
            {
                Logger.ErrorHandler(driver, ex);
            }
            Assert.AreEqual(expectedProducts[0].name, products[0].name, "invalid name");
            Assert.AreEqual(expectedProducts[0].color, products[0].size, "invalid color");
            Assert.AreEqual(expectedProducts[0].size, products[0].color, "invalid size");
            Assert.AreEqual(expectedProducts[0].item, products[0].item, "invalid item");
            Assert.AreEqual(expectedProducts[0].personalisation, products[0].personalisation, "invalid personalisation");
            Assert.AreEqual(expectedProducts[0].personalisationColor, products[0].personalisationColor, "invalid personalisation color");
            Assert.AreEqual(expectedProducts[0].price, products[0].price, "invalid price");
            Assert.AreEqual(expectedProducts[0].count, products[0].count, "invalid count");

            Assert.AreEqual(expectedProducts[1].name, products[1].name, "invalid name");
            Assert.AreEqual(expectedProducts[1].color, products[1].size, "invalid color");
            Assert.AreEqual(expectedProducts[1].size, products[1].color, "invalid size");
            Assert.AreEqual(expectedProducts[1].item, products[1].item, "invalid item");
            Assert.AreEqual(expectedProducts[1].personalisation, products[1].personalisation, "invalid personalisation");
            Assert.AreEqual(expectedProducts[1].personalisationColor, products[1].personalisationColor, "invalid personalisation color");
            Assert.AreEqual(expectedProducts[1].price, products[1].price, "invalid price");
            Assert.AreEqual(expectedProducts[1].count, products[1].count, "invalid count");

            Assert.Greater(products[0].price, products[1].price, "invalid price");
        }
        


        [TearDown]
        public void TearDownTests()
        {
            DriverSingleton.CloseDriver();
        }

    }
}


