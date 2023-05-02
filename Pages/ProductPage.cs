using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Pages
{
    public class ProductPage : BasePage
    {

        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement addtoCartButton => _driver.FindElement(By.Name("add-to-cart"));
    }
}
