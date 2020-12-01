using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject.PageObjects.BasketPages
{
    public class BasketForCheckingTheNameChangeOfTheSelectedClothing : BasketPage
    {
        public string productNameForCheckingNameChangeOfClothingTest = "Medium Vintage Check Bonded Cotton Bum Bag";

        [FindsBy(How = How.CssSelector, Using = "td.item-description.item-description-top.item-description-oneline.cell>h2")]
        private readonly IWebElement productInBasketName;

        public BasketForCheckingTheNameChangeOfTheSelectedClothing(IWebDriver driver) : base(driver) { }

        public bool IsProductsNamesEqual()
        {
            return productNameForCheckingNameChangeOfClothingTest == productInBasketName.Text;
        }
    }
}
