using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuTorial.PageObjects
{


 public class ProductsPage
    {
        private IWebDriver driver;
        By cardtitle = By.CssSelector(".card-title a");
         By addtocard = By.CssSelector(".card-footer");

        public ProductsPage (IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;


        public IList<IWebElement> getcards()
        {
            return cards;
        }

        public By getcardtitle()
        {
            return cardtitle;
        }


        public By getcardfooter()
        {
            return addtocard;
        }
        [FindsBy(How = How.XPath, Using = "//a[@class='nav-link btn btn-primary']")]
        private IWebElement checkout;

            public IWebElement Getcheckout()
        {
            return checkout;
        }

    }
}
