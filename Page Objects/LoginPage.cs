using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Selenium_Framework.Page_Objects
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

                    }
        /*driver.FindElement(By.Id("username")).Clear();
        driver.FindElement(By.Name("password")).SendKeys("learning");
        driver.FindElement(By.XPath("//input[@id='terms']")).Click();
        driver.FindElement(By.XPath("//input[@id='signInBtn']")).Click();*/

        //Page Object Factory syntax
        [FindsBy(How = How.Id, Using = "username")] private IWebElement username;
        [FindsBy(How = How.Name, Using = "password")] private IWebElement password;
        [FindsBy(How = How.XPath, Using = "//input[@id='terms']")] private IWebElement checkTerms;
        [FindsBy(How = How.XPath, Using = "//input[@id='signInBtn']")] private IWebElement signIn;


        

        public productPage validLogin(String user_username, String user_password)
        {
            username.Clear();
            username.SendKeys(user_username);
            password.Clear();
            password.SendKeys(user_password);
            checkTerms.Click();
            signIn.Click();
            return new productPage(driver);
        }

    }
}
