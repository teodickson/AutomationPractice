using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.source.main.page
{
    class CartPage : BasePage
    {
        //public new IWebDriver driver;
        public CartPage(IWebDriver driver) : base(driver) // C# uses "base" keyword whenever Java uses "super" 
        {
        }

        [FindsBy(How = How.CssSelector, Using = "td.cart_product")]
        [CacheLookup]
        protected IWebElement Cart_product { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id='cart_summary']//p[@class='product-name']/a")]
        [CacheLookup]
        public IWebElement Cart_product_name { get; set; }

        [FindsBy(How = How.CssSelector, Using = "table#cart_summary td[data-title='Total'] span.price")]
        [CacheLookup]
        protected IWebElement cart_product_price; // Total for a single product

        public CartPage GoToCheckShoppingCart()
        {
            Wait(2000);
            Click(Shopping_cart);
            Wait(1500);
            return this;
        }

        public string GetCartProductName() {
            Console.WriteLine("Cart product name : " + Cart_product_name.Text);
            return Cart_product_name.Text; }

        protected double GetCartProductPrice() { return double.Parse(cart_product_price.Text.Trim().Replace("$","")); }

        public CartPage VerifyProductIsAddedToCart(string product)
        {
            Wait(2000);
            IWebElement p = driver.FindElement(By.XPath("//td[@class='cart_product']/a/img[@alt='" + product + "']")); //Faded Short Sleeve T-shirts
            Assert.IsTrue(p.Displayed);
            Console.WriteLine("Product " + product + " is displayed");
            return this;
        }

        public CartPage VerifyProductNameIsCorrect(string expectedProduct)
        {
            if (driver != null)
            {
                Assert.IsTrue(GetCartProductName().Equals(expectedProduct));
                Console.WriteLine("Product name " + expectedProduct + " is expected");
            } else
            {
                throw new Exception();
            }
            return this;
        }
    }
}
