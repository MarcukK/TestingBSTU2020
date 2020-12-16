using Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObject.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject.PageObjects
{
    public class BasketPage : BasePage
    {
        public BasketPage(IWebDriver driver) : base(driver) { }

        public List<string> GetProductsNames()
        {
            Logger.Log.Info("Get products names");
            List<string> names = new List<string>();
            List<IWebElement> listOfProductsNames = fluentWait.Until(x => x.FindElements(By.XPath("//h2[@class='item-name -h -h2']"))).ToList();
            foreach (var item in listOfProductsNames)
            {
                names.Add(item.Text.Trim());
            }
            return names;
        }

        public List<string> GetProductsColors()
        {
            Logger.Log.Info("Get products colors");
            List<string> colors = new List<string>();
            List<IWebElement> listOfProductsColors = fluentWait.Until(x => x.FindElements(By.XPath("//dd[@class='color-value']"))).ToList();
            foreach (var item in listOfProductsColors)
            {
                colors.Add(item.Text.Trim());
            }
            return colors;
        }

        public List<string> GetProductsSizes()
        {
            Logger.Log.Info("Get products sizes");
            List<string> sizes = new List<string>();
            List<IWebElement> listOfProductsSizes = fluentWait.Until(x => x.FindElements(By.XPath("//dd[@class='size-value']"))).ToList();
            foreach (var item in listOfProductsSizes)
            {
                sizes.Add(item.Text.Trim());
            }
            return sizes;
        }

        public List<string> GetProductsItems()
        {
            Logger.Log.Info("Get products items");
            List<string> items = new List<string>();
            List<IWebElement> listOfProductsItems = fluentWait.Until(x => x.FindElements(By.XPath("//dd[@class='id-value']"))).ToList();
            foreach (var item in listOfProductsItems)
            {
                items.Add(item.Text.Trim());
            }
            return items;
        }

        public List<string> GetProductsPersonalisations()
        {
            Logger.Log.Info("Get products personalisations");
            List<string> personalisations = new List<string>();
            List<IWebElement> listOfProductsPersonalisations = fluentWait.Until(x => x.FindElements(By.XPath("//span[@class='monogramming-value js-monogramming-initials-value']"))).ToList();
            foreach (var item in listOfProductsPersonalisations)
            {
                personalisations.Add(item.Text.Trim());
            }
            return personalisations;
        }

        public List<string> GetProductsPersonalisationsColors()
        {
            Logger.Log.Info("Get products personalisations colors");
            List<string> personalisationsColors = new List<string>();
            List<IWebElement> listOfProductsPersonalisationsColors = fluentWait.Until(x => x.FindElements(By.XPath("//dd[@class='monogramming-value js-monogramming-font-color-value']"))).ToList();
            foreach (var item in listOfProductsPersonalisationsColors)
            {
                personalisationsColors.Add(item.Text.Trim());
            }
            return personalisationsColors;
        }
        

        public List<string> GetProductsPrices()
        {
            Logger.Log.Info("Get products prices");
            List<string> prices = new List<string>();
            List<IWebElement> listOfProductsPrices = fluentWait.Until(x => x.FindElements(By.XPath("//td[@class='item-price item-price-top cell']"))).ToList();
            foreach (var item in listOfProductsPrices)
            {
                prices.Add(item.Text.Trim());
            }
            return prices;
        }

        public List<int> GetProductsCounts()
        {
            Logger.Log.Info("Get products counts");
            List<int> counts = new List<int>();
            List<IWebElement> listOfProductsCounts = fluentWait.Until(x => x.FindElements(By.XPath("//option[@selected='selected']"))).ToList();
            foreach (var item in listOfProductsCounts)
            {
                counts.Add(Convert.ToInt32(item.Text.Trim()));
            }
            return counts;
        }

        public string GetTotalPrice()
        {
            Logger.Log.Info("Get products counts");
            string totalPrice = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='total-value']"))).Text;
            return totalPrice;
        }

        public List<Product> GetProducts()
        {
            Logger.Log.Info("Get products");
            List<Product> products = new List<Product>();
            List<string> sizes = GetProductsSizes();
            List<string> colors = GetProductsColors();
            List<string> personalisations = GetProductsPersonalisations();
            List<string> personalisationsColors = GetProductsPersonalisationsColors();
            List<int> personalisationsCounts = GetProductsCounts();
            for (int i = 0; i < GetProductsNames().Count; i++)
            {
                if (sizes.Count <= i)
                    sizes.Add(null);
                if (colors.Count <= i)
                    colors.Add(null);
                if (personalisations.Count <= i)
                    personalisations.Add(null);
                if (personalisationsColors.Count <= i)
                    personalisationsColors.Add(null);
                if (personalisationsCounts.Count <= i)
                    personalisationsCounts.Add(1);

                products.Add(new Product("",
                                         GetProductsNames()[i],
                                         GetProductsColors()[i],
                                         sizes[i],
                                         GetProductsItems()[i],
                                         personalisations[i],
                                         personalisationsColors[i],
                                         GetProductsPrices()[i],
                                         personalisationsCounts[i]
                                         )
                    );
            }
            return products;
        }
    }
}
