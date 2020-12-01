using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObject.PageObjects.BasketPages;

namespace PageObject.PageObjects.ProductPages
{
    public class ProductPageForCheckingTheSizeChangeOfTheSelectedClothing : ProductPage
    {
        new string pageURL = "https://uk.burberry.com/logo-applique-silk-satin-oversized-shirt-p45669041?searchQuery=Logo%20Applique%20Silk%20Satin%20Oversized%20Shirt";

        public string productSizeForCheckingSizeChangeOfClothingTest;

        [FindsBy(How = How.XPath, Using = "//*[@class='size-picker__size-box']")]
        private readonly IWebElement sizeChoice;

        public ProductPageForCheckingTheSizeChangeOfTheSelectedClothing(IWebDriver driver) : base(driver) { }


        public new ProductPageForCheckingTheSizeChangeOfTheSelectedClothing OpenPage()
        {
            driver.Navigate().GoToUrl(pageURL);
            return this;
        }

        public new ProductPageForCheckingTheSizeChangeOfTheSelectedClothing AcceptCookies()
        {
            IWebElement cookiesPopup = WaitForTheElement(fluentWait, By.Id(cookiesId));
            cookiesPopup.Click();
            return this;
        }

        public ProductPageForCheckingTheSizeChangeOfTheSelectedClothing ChooseSize()
        {
            productSizeForCheckingSizeChangeOfClothingTest = sizeChoice.Text;
            sizeChoice.Click();
            return this;
        }

        public new ProductPageForCheckingTheSizeChangeOfTheSelectedClothing AddProductToBasket()
        {
            addButton.Click();
            return this;
        }

        public new BasketForCheckingTheSizeChangeOfTheSelectedClothing NavigateToBasket()
        {
            while (basketCounter.Text != "1") ;
            while (!basket.Displayed) ;
            basket.Click();
            return new BasketForCheckingTheSizeChangeOfTheSelectedClothing(driver);
        }

    }
}
