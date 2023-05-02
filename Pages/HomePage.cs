using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Pages
{
    public class HomePage : BasePage
    {

        public HomePage(IWebDriver driver) : base(driver)
        {
        }
   
        private IWebElement gridProduct => _driver.FindElement(By.Id("main"));

        private ProductPage product;

        public HomePage AddRandomItemsToCart(int numberOfItems)
        {
            var productList = gridProduct.FindElements(By.TagName("h2")).Take(numberOfItems);
            var productListNames = new List<string>();
            
            foreach (var item in productList)
            {
                var name = item.GetAttribute("innerHTML");
                productListNames.Add(name);
            }

            foreach (var product in productListNames)
            {
                _driver.FindElement(By.PartialLinkText(product)).Click();

                new ProductPage(_driver).addtoCartButton.Click();
                lnkHome.Click();
            }
            return this;
        }

        public HomePage Go()
        {
            _driver.Navigate().GoToUrl("https://cms.demo.katalon.com/");
            return this;
        }

        public void Clickcart()
        {
            lnkCart.Click();
        }

        internal IWebElement GetLowestPriceItem()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            IWebElement lowestTr;    
            var tr = _driver.FindElements(By.ClassName("cart_item")).ToList();
            lowestTr = tr[0];


            var lowestprice = 0.0;
            foreach (var item in tr)
            {
                var spanEle = item.FindElement(By.ClassName("amount")).FindElement(By.TagName("span"));
                js.ExecuteScript("return arguments[0].remove();", spanEle);

                var currentPrice = decimal.Parse(item.FindElement(By.ClassName("amount")).GetAttribute("innerHTML"));

                if (lowestprice == 0.0)
                {
                    lowestTr = item;
                    lowestprice = (double)currentPrice;
                }
                else
                {
                    if((double)currentPrice < lowestprice)
                    {
                        lowestTr = item;
                        lowestprice = (double)currentPrice;
                    }
                }
            }

            return lowestTr.FindElement(By.ClassName("remove"));
        }

        internal int GetTotalCartItem()
        {
            var el =_driver.FindElement(By.CssSelector("form[class='woocommerce-cart-form']"));
            var col = el.FindElements(By.CssSelector("input[type='number']"));
            var count = 0;
            foreach (var item in col)
            {
               count = count + int.Parse(item.GetAttribute("value"));
            }
            return count;
        }
    }
}
