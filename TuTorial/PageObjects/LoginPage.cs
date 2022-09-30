using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuTorial.PageObjects
{
    class LoginPage
    {
        //driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("rahulshettyacademy");
        private IWebDriver driver;
       


        
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "username")]

        private IWebElement username;
        public IWebElement getusername()

        {
            return username;
        }

        [FindsBy(How =How.XPath,Using = "//input[@name='password'][1]")]
        private IWebElement password;
        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox'][1]")]
        private IWebElement Checkbox;
        [FindsBy(How = How.CssSelector, Using = "input[name = signin]")]
        private IWebElement Signin;



        public ProductsPage ValidLogin(string user,string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            Checkbox.Click();
            Signin.Click();
             return new ProductsPage();
        }
        public IWebElement getpasword()
        {
            return password;
        }


    }

}
