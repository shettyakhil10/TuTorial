using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TuTorial.utilities
{
    public class Base
    {
        public IWebDriver driver;

       
        [SetUp]
        public void Setup()
        {
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

          //  [TearDown]
           //// public void Teardown()
           // {
           //     driver.Quit();
           // }
        }
    }

