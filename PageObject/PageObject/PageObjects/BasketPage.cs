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
        [FindsBy(How = How.ClassName, Using = "size-value")]
        private readonly IWebElement productInBasketSize;

        [FindsBy(How = How.XPath, Using = "//h2[text()='Medium Vintage Check Bonded Cotton Bum Bag']")]
        private readonly IWebElement productInBasketName;

        [FindsBy(How = How.XPath, Using = "//dd[text()='\n                                                        Archive beige']")]
        private readonly IWebElement productInBasketColor;

        [FindsBy(How = How.XPath, Using = "//dd[text()='\n                                                        80104301']")]
        private readonly IWebElement productInBasketItem;

        public BasketPage(IWebDriver driver) : base(driver) { }

        public List<string> GetProductsNames()
        {
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
            List<string> colors = new List<string>();
            List<IWebElement> listOfProductsNames = fluentWait.Until(x => x.FindElements(By.XPath("//dd[@class='color-value']"))).ToList();
            foreach (var item in listOfProductsNames)
            {
                colors.Add(item.Text.Trim());
            }
            return colors;
        }

        public List<string> GetProductsSizes()
        {
            List<string> sizes = new List<string>();
            List<IWebElement> listOfProductsNames = fluentWait.Until(x => x.FindElements(By.XPath("//dd[@class='size-value']"))).ToList();
            foreach (var item in listOfProductsNames)
            {
                sizes.Add(item.Text.Trim());
            }
            return sizes;
        }

        public List<string> GetProductsItems()
        {
            List<string> items = new List<string>();
            List<IWebElement> listOfProductsNames = fluentWait.Until(x => x.FindElements(By.XPath("//dd[@class='id-value']"))).ToList();
            foreach (var item in listOfProductsNames)
            {
                items.Add(item.Text.Trim());
            }
            return items;
        }
        
        public List<string> GetProductsPrices()
        {
            List<string> prices = new List<string>();
            List<IWebElement> listOfProductsNames = fluentWait.Until(x => x.FindElements(By.XPath("//td[@class='item-price item-price-top cell']"))).ToList();
            foreach (var item in listOfProductsNames)
            {
                prices.Add(item.Text.Trim());
            }
            return prices;
        }

        public List<string> GetProductsCounts()
        {
            List<string> counts = new List<string>();
            List<IWebElement> listOfProductsNames = fluentWait.Until(x => x.FindElements(By.XPath("//option[@selected='selected']"))).ToList();
            foreach (var item in listOfProductsNames)
            {
                counts.Add(item.Text.Trim());
            }
            return counts;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            List<string> sizes = new List<string>(GetProductsNames().Count);
            sizes = GetProductsSizes();
            for (int i = 0; i < GetProductsNames().Count; i++)
            {
                if (sizes.Count <= i)
                    sizes.Add(null);
                products.Add(new Product("",
                                         GetProductsNames()[i],
                                         GetProductsColors()[i],
                                         sizes[i],
                                         GetProductsItems()[i],
                                         GetProductsPrices()[i],
                                         Convert.ToInt32(GetProductsCounts()[i])
                                         )
                    );
            }
            return products;
        }
    }
}
