using AutomationPractice.source.main.page;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.source.test
{
    public class CartTest : BaseTest
    {
        //new readonly IWebDriver driver;
        [Test]
        public void CheckCartItem()
        {
            //string category = "Women";
            string product = "Faded Short Sleeve T-shirts";
            WomanPage woman = new WomanPage(driver);
            CartPage cart = new CartPage(driver);
            woman.SelectCategory()
                .AddItemToCart()
                .ContinueShopping();
            cart.GoToCheckShoppingCart()
                //.VerifyProductIsAddedToCart(product)
                .VerifyProductNameIsCorrect(product);
        }
    }
}
