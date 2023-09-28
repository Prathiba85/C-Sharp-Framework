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
    public class productPage
    {
        private IWebDriver driver;

        public productPage(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

                    }

        // IList<IWebElement> cards = driver.FindElements(By.TagName("app-card"));


        // IWebElement checkout = driver.FindElement(By.XPath("//a[@class='nav-link btn btn-primary']"));




        //Page Object Factory syntax
        By ppcardTitle = By.CssSelector(".card-title a");
        By ppAddToCart = By.CssSelector(".card-footer button");

        [FindsBy(How = How.TagName, Using = "app-card")] private IList <IWebElement> lscards;
        [FindsBy(How = How.XPath, Using = "//a[@class='nav-link btn btn-primary']")] private IWebElement ppcheckout;

        public void waitforCheckoutDisplay()
        {
                WebDriverWait wc = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wc.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            }

        public IList<IWebElement> getCards()
        { return lscards; 
        
        }

       
       
        public By getCardTitle()
        {
            return ppcardTitle;
        }

      
            public By addToCart()
             {
            return ppAddToCart;
               }

        public  checkoutPage getcheckout() {
            ppcheckout.Click();

            return new checkoutPage(driver);

        }
    }
}
