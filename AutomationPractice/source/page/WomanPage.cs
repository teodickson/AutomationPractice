using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace AutomationPractice.source.main.page
{
    public class WomanPage : BasePage
    {
        //public IWebDriver driver;
       
        public WomanPage(IWebDriver driver) : base(driver) // C# uses "base" keyword whenever Java uses "super" 
        {
            //this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//a[@class='product_img_link']/ancestor::li")]
        [CacheLookup]
        protected IList<IWebElement> Product_items { get; set; }

        public WomanPage SelectCategory()
        {
            Wait(3000);
            //Click(By.XPath(string.Format(categories, category)));
            Click(By.XPath("//li/a[text()='Women']"));
            return this;
        }

        public WomanPage AddItemToCart()
        {
            //webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath("//a[@class='product_img_link']")));
            Wait(3500);
            IList<IWebElement> p = driver.FindElements(By.XPath("//span[text()='Quick view']"));
            //MoveMouseTo(p[0]);
            Click(p[0]);
            /**foreach (IWebElement product_item in p)
            {
                Click(p[0]);
                Wait(1500);
            }**/
            Wait(3000);
            Click(Add_to_cart);
            return this;
        }

        public WomanPage ContinueShopping()
        {
            Click(Continue_shopping);
            return this;
        }
    }
}
