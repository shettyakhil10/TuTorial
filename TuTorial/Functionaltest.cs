using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TuTorial
{
    class Functionaltest
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

            string href1 = driver.Url = ("https://www.rahulshettyacademy.com/loginpagePractise/");

            driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.XPath("//input[@name='password'][1]")).SendKeys("learning");
            driver.FindElement(By.XPath("//input[@type='checkbox'][1]")).Click();
          

            IWebElement dropdown = driver.FindElement(By.XPath("//select[@class='form-control']"));
            SelectElement s = new SelectElement(dropdown);
            s.SelectByValue("consult");
            Console.WriteLine("dropdown");

            IList<IWebElement> radiobutton = driver.FindElements(By.XPath("//input[@value='admin']"));

            foreach(IWebElement rdos in radiobutton)
            {

                if (rdos.GetAttribute("value").Equals("user"))
                    {
                    rdos.Click();
                }
            }
            
         // Console.WriteLine("dropdown");
        }
    }
}
