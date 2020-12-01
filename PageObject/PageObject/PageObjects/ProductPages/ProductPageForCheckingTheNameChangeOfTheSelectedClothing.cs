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
    public class ProductPageForCheckingTheNameChangeOfTheSelectedClothing : ProductPage
    {
        new string pageURL = "https://uk.burberry.com/logo-detail-econyl-sonny-bum-bag-p80256681?searchQuery=Logo%20Detail%20ECONYL%C2%AE%20Sonny%20Bum%20Bag";

        string productNameForCheckingNameChangeOfClothingTest = "Medium Vintage Check Bonded Cotton Bum Bag";

        [FindsBy(How = How.CssSelector, Using = "div.swatch:nth-child(1)>a:nth-child(1)>span:nth-child(1)")]
        private readonly IWebElement colorChoice;

        public ProductPageForCheckingTheNameChangeOfTheSelectedClothing(IWebDriver driver) : base(driver) { }


        public new ProductPageForCheckingTheNameChangeOfTheSelectedClothing OpenPage()
        {
            driver.Navigate().GoToUrl(pageURL);
            return this;
        }

        public new ProductPageForCheckingTheNameChangeOfTheSelectedClothing AcceptCookies()
        {
            IWebElement cookiesPopup = WaitForTheElement(fluentWait, By.Id(cookiesId));
            cookiesPopup.Click();
            return this;
        }

        public ProductPageForCheckingTheNameChangeOfTheSelectedClothing ChooseColor()
        {
            colorChoice.Click();
            while (productName.Text != productNameForCheckingNameChangeOfClothingTest) ;
            return this;
        }

        public new ProductPageForCheckingTheNameChangeOfTheSelectedClothing AddProductToBasket()
        {
            addButton.Click();
            return this;
        }

        public new BasketForCheckingTheNameChangeOfTheSelectedClothing NavigateToBasket()
        {
            while (basketCounter.Text != "1") ;
            while (!basket.Displayed) ;
            basket.Click();
            return new BasketForCheckingTheNameChangeOfTheSelectedClothing(driver);
        }

    }
}
