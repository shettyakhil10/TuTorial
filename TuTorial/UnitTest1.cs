using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;


namespace TuTorial
{
    public class Tests
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
            string href1 =driver.Url=("https://www.rahulshettyacademy.com/loginpagePractise/");

            driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.XPath("//input[@name='password'][1]")).SendKeys("learning");
            driver.FindElement(By.XPath("//input[@type='checkbox'][1]")).Click();
            driver.FindElement(By.CssSelector("input[name=signin]")).Click();


           string name= driver.FindElement(By.XPath("//div[@class='alert alert-danger col-md-12']")).Text;
            TestContext.Progress.WriteLine("name");

            IWebElement linktext = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            string href = linktext.GetAttribute("href");
            string expectedUrl = "https://www.rahulshettyacademy.com/loginpagePractise/";

                Assert.AreEqual(expectedUrl,href1);


        }
    }
}