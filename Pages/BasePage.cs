using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;

        protected BasePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        protected IWebElement lnkHome => _driver.FindElement(By.LinkText("Katalon Shop"));
        protected IWebElement lnkCart => _driver.FindElement(By.XPath("//*[@id=\"primary-menu\"]/ul/li[1]/a"));

        
    }
}
