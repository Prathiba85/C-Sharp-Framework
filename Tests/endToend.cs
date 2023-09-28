using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using CSharp_Selenium_Framework.Page_Objects;

namespace CSharp_Selenium_Framework.Tests
{
    public class Tests : Base
    {


        [Test]
        public void EndToEndFlow()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            loginpage.validLogin("rahulshettyacademy", "learning");
            productPage productpage = loginpage.validLogin("rahulshettyacademy", "learning");
            productpage.waitforCheckoutDisplay();

            //IWebElement checkout = driver.FindElement(By.XPath("//a[@class='nav-link btn btn-primary']"));
            WebDriverWait wc = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //send products list

            string[] products = { "iphone X", "Blackberry" };
            IList<IWebElement> cards = productpage.getCards();

            foreach (IWebElement product in cards)
            {
                string producttitle = product.FindElement(productpage.getCardTitle()).Text;


                 if (products.Contains(producttitle))
                {
                    //click cart
                    //  product.FindElement(By.XPath("//button[@class='btn btn-info']")).Click();
                    product.FindElement(productpage.addToCart()).Click();

                }




            }
            //IWebElement checkout = driver.FindElement(By.XPath("//a[@class='nav-link btn btn-primary']"));
            //checkout.Click();
            checkoutPage checkoutpage = productpage.getcheckout();          
            string[] actualproducts = new string[2];

            //Check if products added are available in the list
            //IList<IWebElement> allproductesadded = driver.FindElements(By.XPath("//tbody//tr//h4"));

            IList<IWebElement> allproductesadded = checkoutpage.getalladdedproduct();

            TestContext.Progress.WriteLine("**************** Added Products Are **************");
            for (int i = 0; i < allproductesadded.Count; i++)
            {
                actualproducts[i] = allproductesadded[i].Text;
            }

            //Assert.That(actualproducts, Is.EqualTo(products));
            Assert.AreEqual(actualproducts,products);

            //Checkout
            // driver.FindElement(By.XPath("//button[@class='btn btn-success']")).Click();
            checkoutpage.clickCheckout();
            driver.FindElement(By.XPath("//input[@id='country']")).SendKeys("ind");

            wc.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='India']")));
            IWebElement country = driver.FindElement(By.XPath("//a[text()='India']"));
            country.Click();
            //IJavaScriptExecutor jc = (IJavaScriptExecutor)driver;
            // jc.ExecuteScript("arguments[0].scrollIntoView(true)", frame);
            driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            string confirmation = driver.FindElement(By.XPath("//div[@class='alert alert-success alert-dismissible']")).Text;
            string expectedconfirmation_message = "Success";
            StringAssert.Contains(expectedconfirmation_message, confirmation);


        }
    }
}