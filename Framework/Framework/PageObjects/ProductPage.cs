using Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace PageObject.PageObjects
{
    public class ProductPage : BasePage
    {
        public static readonly string noSizeErrorMessage = "Please select a size";

        [FindsBy(How = How.ClassName, Using = "add-to-bag__button-content")]
        protected readonly IWebElement addButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='button find-in-store button-secondary']")]
        protected readonly IWebElement findInStoreButton;

        [FindsBy(How = How.ClassName, Using = "header__button--with-one-digit-counter")]
        protected readonly IWebElement basketCounter;

        [FindsBy(How = How.XPath, Using = "//a[@title='Bag']")]
        protected readonly IWebElement basket;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Opens a pop-up']")]
        protected readonly IWebElement addPersonalisationButton;

        [FindsBy(How = How.XPath, Using = "//input[@class='monogramming-modal__input']")]
        protected readonly IWebElement inputPersonalisationField;

        [FindsBy(How = How.XPath, Using = "//button[@class='button monogramming-modal__choose-text-color-button button-primary']")]
        protected readonly IWebElement chooseTextColourButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='button monogramming-modal__confirm-button button-primary']")]
        protected readonly IWebElement confirmTextColourButton;

        public ProductPage(IWebDriver driver) : base(driver) { }

        public new ProductPage OpenPage(string pageURL)
        {
            Logger.Log.Info("Open page");
            driver.Navigate().GoToUrl(pageURL);
            return this;
        }

        public new ProductPage AcceptCookies()
        {
            Logger.Log.Info("Accept cookies");
            IWebElement cookiesPopup = WaitForTheElement(fluentWait, By.Id(cookiesId));
            cookiesPopup.Click();
            return this;
        }

        public ProductPage ChooseColor(string color, string newName)
        {
            Logger.Log.Info("Choose color");
            IWebElement colorChoise = fluentWait.Until(x => x.FindElement(By.XPath("//a[@aria-label='" + color + "']")));
            colorChoise.Click();
            IWebElement productName = fluentWait.Until(x => x.FindElement(By.XPath("//h1[@class='product-info-panel__title']/span")));
            while (productName.Text != newName) ;
            return this;
        }

        public ProductPage ChooseSize(string size)
        {
            Logger.Log.Info("Choose size");
            IWebElement sizeChoise = fluentWait.Until(x => x.FindElement(By.XPath("//label[@value='" + size + "']")));
            sizeChoise.Click();
            return this;
        }

        public ProductPage AddProductToBasket()
        {
            Logger.Log.Info("Add product to basket");
            WaitForTheElement(addButton);
            addButton.Click();
            return this;
        }

        public ProductPage AddProductToBasketSeveralTimes(int times)
        {
            Logger.Log.Info("Add product to basket several times");
            for (int i = 0; i < times; i++)
            {
                while (!basket.Displayed) ;
                addButton.Click();
                IWebElement basketLabel = WaitForTheElement(fluentWait, By.CssSelector("div.minibag-notification__counter-wrapper"));
                while (!basketLabel.Displayed) ;

            }
            return this;
        }

        public ProductPage AddPersonalization(string personalisation)
        {
            Logger.Log.Info("Add Personalization");
            WaitForTheElement(addPersonalisationButton); addPersonalisationButton.Click();
            WaitForTheElement(inputPersonalisationField) ; inputPersonalisationField.SendKeys(personalisation);
            WaitForTheElement(chooseTextColourButton) ; chooseTextColourButton.Click();
            WaitForTheElement(confirmTextColourButton) ; confirmTextColourButton.Click();
            return this;
        }

        public string GetNoSizeErrorLabel()
        {
            Logger.Log.Info("Get No Size Error Label");
            IWebElement noSizeErrorLabel = WaitForTheElement(fluentWait, By.XPath("//div[@class='product-details-error-generic']"));
            return noSizeErrorLabel.Text;
        }

        public ProductPage FindInStore()
        {
            Logger.Log.Info("Find In Store");
            WaitForTheElement(findInStoreButton);
            findInStoreButton.Click();
            return this;
        }

        public ProductPage AddStoresWithNoCurrentAvailability()
        {
            Logger.Log.Info("Add Stores With No Current Availability");
            IWebElement includeStoresWithNoCurrentAvailabilityButton = WaitForTheElement(fluentWait, By.XPath("//span[text()='Include stores with no current availability']"));
            includeStoresWithNoCurrentAvailabilityButton.Click();
            return this;
        }

        public string GetNumberOfShopsLabel()
        {
            Logger.Log.Info("Get Number Of Shops Label");
            return WaitForTheElement(fluentWait, By.XPath("//div[@class='stores-list__title']")).Text;
        }

        public BasketPage NavigateToBasket()
        {
            Logger.Log.Info("Navigate to Basket");
            WaitForTheElement(fluentWait, By.XPath("//span[@class='header__button-text header__button-text--show']"));
            List<IWebElement> counters = fluentWait.Until(x => x.FindElements(By.XPath("//span[@class='header__button-text header__button-text--show']"))).ToList();
            IWebElement basketCounter = counters.Last();

            IWebElement checkoutLabel = WaitForTheElement(fluentWait, By.XPath("//div[text()='Checkout']"));
            IWebElement basketLabel = WaitForTheElement(fluentWait, By.CssSelector("div.minibag-notification__counter-wrapper"));
            WaitForTheElement(basketLabel);
            basketLabel.Click();
            return new BasketPage(driver);
        }


    }
}
