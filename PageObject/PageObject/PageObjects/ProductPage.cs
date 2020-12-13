using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace PageObject.PageObjects
{
    public class ProductPage : BasePage
    {

        [FindsBy(How = How.ClassName, Using = "add-to-bag__button-content")]
        protected readonly IWebElement addButton;
        
        [FindsBy(How = How.ClassName, Using = "header__button--with-one-digit-counter")]
        protected readonly IWebElement basketCounter;

        [FindsBy(How = How.XPath, Using = "//a[@title='Bag']")]
        protected readonly IWebElement basket;

        public ProductPage(IWebDriver driver) : base(driver) { }

        public new ProductPage OpenPage(string pageURL)
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

        public ProductPage ChooseColor(string color, string newName)
        {
            IWebElement colorChoise = fluentWait.Until(x => x.FindElement(By.XPath("//a[@aria-label='" + color + "']")));
            colorChoise.Click();
            IWebElement productName = fluentWait.Until(x => x.FindElement(By.XPath("//h1[@class='product-info-panel__title']/span")));
            while (productName.Text != newName) ;
            return this;
        }

        public ProductPage ChooseSize(string size)
        {
            IWebElement sizeChoise = fluentWait.Until(x => x.FindElement(By.XPath("//label[@value='" + size + "']")));
            sizeChoise.Click();
            return this;
        }

        public ProductPage AddProductToBasket()
        {
            while (!basket.Displayed) ;
            addButton.Click();
            return this;
        }

        public BasketPage NavigateToBasket()
        {
            IWebElement anyCounter = WaitForTheElement(fluentWait, By.XPath("//span[@class='header__button-text header__button-text--show']"));
            List<IWebElement> counters = fluentWait.Until(x => x.FindElements(By.XPath("//span[@class='header__button-text header__button-text--show']"))).ToList();
            IWebElement basketCounter = counters.Last();
            while (!basketCounter.Displayed) ;
            while (!basket.Displayed) ;
            basket.Click();
            return new BasketPage(driver);
        }


    }
}
