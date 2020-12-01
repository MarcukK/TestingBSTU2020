using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject.PageObjects
{
    public class ProductPage : Page
    {

        [FindsBy(How = How.CssSelector, Using = "h1>span:nth-child(1)")]
        protected readonly IWebElement productName;

        [FindsBy(How = How.ClassName, Using = "add-to-bag__button-content")]
        protected readonly IWebElement addButton;

        [FindsBy(How = How.CssSelector, Using = ".icon.icon--glyph-bag.icon--glyph-box.icon--size-m.header__icon")]
        protected readonly IWebElement basket;

        [FindsBy(How = How.XPath, Using = "//li[3]/a/span[2]")]
        protected readonly IWebElement basketCounter;

        public ProductPage(IWebDriver driver) : base(driver) { }

        public new ProductPage OpenPage()
        {
            driver.Navigate().GoToUrl(pageURL);
            return this;
        }

        public new ProductPage AcceptCookies()
        {
            IWebElement cookiesPopup = WaitForTheElement(fluentWait, By.Id(cookiesId));
            cookiesPopup.Click();
            return this;
        }

        public ProductPage AddProductToBasket()
        {
            addButton.Click();
            return this;
        }

        public BasketPage NavigateToBasket()
        {
            while (!basket.Displayed);
            basket.Click();
            return new BasketPage(driver);
        }

    }
}
