using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuTorial.PageObjects
{
    class Checkoutpage
    {
        private IWebDriver driver;
        public Checkoutpage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//h4/a")]

        private IList<IWebElement> checkout;
        
       public IList<IWebElement> getout()
        {
            return checkout;
        }

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]

        private IWebElement Success;

        public IWebElement getsuccess()
        {
            return Success;
        }


    }
}
