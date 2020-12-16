using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageObjects
{
    public class CatalogPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//span[@class='favourites-items js-favourites-amount']")]
        protected readonly IWebElement favouriteProductsCount;

        [FindsBy(How = How.XPath, Using = "//button[@title='Add to Favourites']")]
        protected readonly IWebElement buttonToAddToFavourites;

        public CatalogPage(IWebDriver driver) : base(driver) { }

        public new CatalogPage OpenPage(string pageURL)
        {
            Logger.Log.Info("Open page");
            driver.Navigate().GoToUrl(pageURL);
            return this;
        }

        public new CatalogPage AcceptCookies()
        {
            Logger.Log.Info("Accept cookies");
            IWebElement cookiesPopup = WaitForTheElement(fluentWait, By.Id(cookiesId));
            cookiesPopup.Click();
            return this;
        }

        public int GetNumberOfFavouriteProducts()
        {
            Logger.Log.Info("Get number of favourite products");
            try
            {
                return Convert.ToInt32(favouriteProductsCount.Text);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public CatalogPage AddProductsToFavourites(int numberOfProducts)
        {
            Logger.Log.Info("Add products to Favourites");
            IWebElement addToFavouritesNote = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='add-to-favourites-note']")));
            WaitForTheElement(fluentWait, By.XPath("//button[@title='Add to Favourites' and @aria-pressed='false']"));
            for (int i = 0, n = 100; i < numberOfProducts;)
            {
                try
                {
                    List<IWebElement> buttonsToAddToFavourites = fluentWait.Until(x => x.FindElements(By.XPath("//button[@title='Add to Favourites' and @aria-pressed='false']"))).ToList();
                    buttonsToAddToFavourites[0].Click();

                    int j = 0;
                    List<IWebElement> buttonsToAddToFavourites2 = fluentWait.Until(x => x.FindElements(By.XPath("//button[@title='Add to Favourites' and @aria-pressed='false']"))).ToList();
                    while ((buttonsToAddToFavourites2.Count == buttonsToAddToFavourites.Count) 
                            && (j < n))
                    {
                        buttonsToAddToFavourites2 = fluentWait.Until(x => x.FindElements(By.XPath("//button[@title='Add to Favourites' and @aria-pressed='false']"))).ToList();
                        j++;
                    }
                    if(j < n)
                        i++;
                }
                catch (Exception exc) { }
            }
            return this;
        }
    }
}
