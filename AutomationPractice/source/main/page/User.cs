using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.source.main.page
{
    class User
    {
        IWebDriver driver;

        public User(IWebDriver driver)
        {
            this.driver = driver;
        }

        public CartPage _CartPage() { return new CartPage(driver); }
        public WomanPage _WomanPage() { return new WomanPage(driver); }
    }
}
