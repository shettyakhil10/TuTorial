using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuTorial.PageObjects
{
//    IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
//            foreach(IWebElement product in products)
//            {
//                if(expectedproducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
//                {
//                    product.FindElement(By.CssSelector(".card-footer")).Click();
//}

 public class ProductsPage
    {
        private IWebDriver driver;
        By cardtitle = By.CssSelector(".card - title a");

        public ProductsPage (IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public ProductsPage()
        {
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

    }
}
