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
    class WindowHandle
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

            driver.Url = ("https://www.rahulshettyacademy.com/loginpagePractise/");


            driver.FindElement(By.XPath("//a[@class='blinkingText']")).Click();
         Assert.AreEqual(2,driver.WindowHandles.Count);
           string childwindowname= driver.WindowHandles[1];
            driver.SwitchTo().Window(childwindowname);

            Console.WriteLine(driver.FindElement(By.XPath("//p[@class='im-para red']")).Text);


            string text = driver.FindElement(By.XPath("//p[@class='im-para red']")).Text;

           string [] arr= text.Split("at");
            string[] arr2 = arr[1].Trim().Split(" ");

        }


    }
}
