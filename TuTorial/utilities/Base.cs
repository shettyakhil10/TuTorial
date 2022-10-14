using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TuTorial.utilities
{
    public class Base:Json_reader
    {
        public IWebDriver driver;
        ExtentReports extentreports;
         //public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

    

        [OneTimeSetUp]
        public void Setup1()
        {

            string workdingdirectory = Environment.CurrentDirectory;
            string projectdirectory = Directory.GetParent(workdingdirectory).Parent.Parent.FullName;
            string reportpath = projectdirectory + "//index.html";
            var htmlreporter = new ExtentHtmlReporter(reportpath);
            extentreports.AttachReporter(htmlreporter);
            
        }

        [SetUp]
        public void Setup()
        {
            extentreports.CreateTest(TestContext.CurrentContext.Test.Name)
           string browsername= ConfigurationManager.AppSettings["browser"];

            Initbrowser(browsername);

            driver.Manage().Window.Maximize();

        }

        public IWebDriver getdriver()
        {
            return driver;
        }
        public void Initbrowser(string browsername)
        {
            switch (browsername)
            {
                case "Firefox":


                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();

                    break;

                case "chrome":


                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();

                    break;

                case "Edge":


                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();

                    break;



            }
        }

      
       public static Json_reader GetdataParser()
        {
            return new Json_reader();
        }

        [TearDown]
        public void Teardown()
        {

            var status =TestContext.CurrentContext.Result.Outcome.Status;
            if(status==TestStatus.Failed)
            {

            }
            else if(status==TestStatus.Passed)
            {

            }

            driver.Quit();
            
        }
        public capturescreenshot()
        { }
}
    }

