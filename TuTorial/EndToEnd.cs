using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TuTorial.PageObjects;
using TuTorial.utilities;
using WebDriverManager.DriverConfigs.Impl;


namespace TuTorial
{
    class EndToEnd : Base
    {
        //IWebDriver driver;
        //[SetUp]
        //public void Setup()
        //{

        //    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
        //    driver = new FirefoxDriver();

        //    driver.Manage().Window.Maximize();

        //}
        [Test]
        public void Test1()
        {

       string [] expectedproducts = {"iphone X", "Blackberry" };
            string[] actualproducts = new string[2];


            driver.Url = ("https://www.rahulshettyacademy.com/loginpagePractise/");
            LoginPage loginpage = new LoginPage(getdriver());

            ////driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("rahulshettyacademy");
            //loginpage.getusername().SendKeys("rahulshettyacademy");
            ////driver.FindElement(By.XPath("//input[@name='password'][1]")).SendKeys("learning");
            //loginpage.getpasword().SendKeys("learning");
            //driver.FindElement(By.XPath("//input[@type='checkbox'][1]")).Click();
           ProductsPage productpage= loginpage.ValidLogin("rahulshettyacademy", "learning");


            IWebElement dropdown = driver.FindElement(By.XPath("//select[@class='form-control']"));
            SelectElement s = new SelectElement(dropdown);
            s.SelectByValue("consult");

            IList<IWebElement> radiobutton = driver.FindElements(By.XPath("//input[@value='admin']"));

            foreach (IWebElement rdos in radiobutton)
            {

                if (rdos.GetAttribute("value").Equals("user"))
                {
                    rdos.Click();
                }
            }
            //driver.FindElement(By.CssSelector("input[name=signin]")).Click();
            Thread.Sleep(3000);
            IWebElement framescroll = driver.FindElement(By.XPath("//button[@class='btn btn-info'][1]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", framescroll);

            IList<IWebElement> products = productpage.getcards();
            //IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
            foreach( IWebElement product in products)
            {
            //    if(expectedproducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
            //    {
            //        product.FindElement(By.CssSelector(".card-footer")).Click();
            //    }


        }
        driver.FindElement(By.XPath("//a[@class='nav-link btn btn-primary']")).Click();

            IList<IWebElement> checkoutcards = driver.FindElements(By.XPath("//h4/a"));


               for (int i = 0; i < checkoutcards.Count; i++)
            {
                actualproducts[i] = checkoutcards[i].Text;
            }

            Assert.AreEqual(expectedproducts, actualproducts);

            driver.FindElement(By.CssSelector(".btn-success")).Click();

            driver.FindElement(By.XPath("//input[@id='country']")).SendKeys("ind");

            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait4.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("India")));

            driver.FindElement(By.LinkText("India")).Click();

            driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();


            driver.FindElement(By.CssSelector(".btn-success")).Click();

            string word = driver.FindElement(By.CssSelector(".alert-success")).Text;

            StringAssert.Contains("Success",word);







        }
    }
}
