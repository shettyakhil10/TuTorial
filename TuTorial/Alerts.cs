using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TuTorial
{
    class Alerts
    {

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {

            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();

            driver.Manage().Window.Maximize();

        }
        [Test]
        public void Test1()
        {
            


        }
    }
}
