using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject.PageObjects.BasketPages
{
    public class BasketForCheckingTheSizeChangeOfTheSelectedClothing : BasketPage
    {
        [FindsBy(How = How.ClassName, Using = "size-value")]
        private readonly IWebElement productInBasketSize;

        public BasketForCheckingTheSizeChangeOfTheSelectedClothing(IWebDriver driver) : base(driver) { }

        public string GetSize()
        {
            return productInBasketSize.Text;
        }
    }
}
