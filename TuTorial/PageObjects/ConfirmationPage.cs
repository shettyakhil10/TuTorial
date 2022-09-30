using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuTorial.PageObjects
{
    class ConfirmationPage
    {

        private IWebDriver driver;
        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='country']")]

        private IWebElement Country;

        public IWebElement getcountry()
        {
            return Country;
        }

        [FindsBy(How = How.LinkText, Using = "India")]

        private IWebElement clickcountry;

            public IWebElement getcountryclick()
        {
            return clickcountry;
        }

        [FindsBy(How=How.XPath,Using = "//label[@for='checkbox2']")]
        private IWebElement agreeterms;
        public IWebElement getagree()
        {
            return agreeterms;
        }

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]

        private IWebElement Successmessage;

        public IWebElement Getsuccessmsg()
        {
            return Successmessage;
        }

             
    }
}
