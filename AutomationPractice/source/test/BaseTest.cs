using AutomationPractice.source.main.page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationPractice.source.test
{
    public class BaseTest
    {
        public IWebDriver driver;
        //public CartPage Cart;
        //public WomanPage Woman;
        public User _User;

        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //Cart = new CartPage(driver);
            //Woman = new WomanPage(driver);
            _User = new User(driver);
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
