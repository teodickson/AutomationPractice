using AutomationPractice.source.main.page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.source.test
{
    class CartTest : BaseTest
    {
        [Test]
        public void CheckCartItem()
        {
            //string category = "Women";
            string product = "Faded Short Sleeve T-shirts";
            _User._WomanPage().SelectCategory()
                .AddItemToCart()
                .ContinueShopping();
            _User._CartPage().GoToCheckShoppingCart()
                //.VerifyProductIsAddedToCart(product)
                .VerifyProductNameIsCorrect(product);
        }
    }
}
