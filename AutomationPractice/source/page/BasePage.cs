using BAMCIS.Util.Concurrent;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace AutomationPractice.source.main.page
{
    public class BasePage
    {
        public IWebDriver driver;
        protected string categories = "//li/a[text()='%s']";
        //protected WebDriverWait webDriverWait;

        public BasePage(IWebDriver _driver)
        {
            this.driver = _driver;
            //webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(_driver, this);
        }

        // Page Objects
        [FindsBy(How = How.Id, Using = "search_query_top")]
        [CacheLookup]
        protected readonly IWebElement Search_box;

        [FindsBy(How = How.XPath, Using = "//div[@class='shopping_cart']//b[text()='Cart']")]
        [CacheLookup]
        protected IWebElement Shopping_cart;

        [FindsBy(How = How.CssSelector, Using = "p#add_to_cart button")]
        [CacheLookup]
        protected IWebElement Add_to_cart;

        [FindsBy(How = How.XPath, Using = "//span[@id='our_price_display']")]
        [CacheLookup]
        protected IWebElement Price;

        [FindsBy(How = How.XPath, Using = "//span[@title='Continue shopping']")]
        [CacheLookup]
        protected IWebElement Continue_shopping;

        

        public void Click(IWebElement element)
        {
            try
            {
                element.Click();
            }catch(Exception ex)
            {
                Console.WriteLine("Trying to click " + element + " by JavaScriptExecutor");
                ClickByJSExecutor(element);
            }
        }

        public void Click(By element)
        {
            try
            {
                driver.FindElement(element).Click();
            }catch(Exception ex)
            {
                Console.WriteLine("the cause is " + ex);
            }
        }

        protected void ClickByJSExecutor(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();",element);
        }

        public void Find(By element)
        {
            driver.FindElement(element);
        }

        public string GetHRefOfItem(IWebElement element)
        {
            return element.GetAttribute("href");
        }

        protected void Wait(int milliseconds)
        {
            TimeUnit.MILLISECONDS.Sleep(milliseconds);
            Console.WriteLine("User waits for " + milliseconds + " milliseconds");
        }

        protected void MoveMouseTo(IWebElement element)
        {
            Actions action = new(driver);
            action.MoveToElement(element).Perform();
        }

        public void ValidatePriceIsExpected(object expected,object actual)
        {
            Assert.AreEqual(expected,actual);
        }

        protected double GetProductPrice()
        {
            return double.Parse(Price.Text.Trim().Replace("$",""));
        }
    }
}
