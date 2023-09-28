using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Selenium_Framework.Page_Objects
{
    public class checkoutPage
    {
        private IWebDriver driver;

        public checkoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

                    }

        //Page Object Factory syntax


        //[FindsBy(How = How.TagName, Using = "app-card")] private IList <IWebElement> cards;
        //[FindsBy(How = How.XPath, Using = "//a[@class='nav-link btn btn-primary']")] private IWebElement checkout;
        // IList<IWebElement> allproductesadded = driver.FindElements(By.XPath("//tbody//tr//h4"));
        //driver.FindElement(By.XPath("//button[@class='btn btn-success']")).Click();

        [FindsBy(How = How.XPath, Using = "//tbody//tr//h4")] private IList<IWebElement> wb_allproductsadded;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-success']")] private IWebElement wb_checkout;

        public IList<IWebElement> getalladdedproduct()
        {
            return wb_allproductsadded;
        }

        public void clickCheckout()
        {
            wb_checkout.Click();
        }
    }
}
