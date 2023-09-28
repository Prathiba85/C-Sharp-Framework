using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using AngleSharp.Dom;
using CSharp_Selenium_Framework;

namespace SeleniumLearning
{
    class GreenkartWebTable : Base
    {

        [Test]
        public void compareSortedList()
        {
            
            
            IWebElement dropdown = driver.FindElement(By.XPath("//select[@id='page-menu']"));
            SelectElement sc = new SelectElement(dropdown);
              sc.SelectByValue("20");

           IList <IWebElement> fruitname = driver.FindElements(By.XPath("//tbody/tr//td[1]"));
            ArrayList al = new ArrayList();
            foreach (IWebElement element in fruitname)
            {
                al.Add(element.Text);

                TestContext.Progress.WriteLine(element.Text);
              
            }
            
            al.Sort();

            driver.FindElement(By.XPath("//span[text()='Veg/fruit name']")).Click();
            IList<IWebElement> fruitnamesorted = driver.FindElements(By.XPath("//tbody/tr//td[1]"));
            ArrayList sortedlist = new ArrayList();
            TestContext.Progress.WriteLine("*****************Sorted List **********************");
            foreach (IWebElement element in fruitnamesorted)
            {
                sortedlist.Add(element.Text);

                TestContext.Progress.WriteLine(element.Text);

            }

            Assert.AreEqual(sortedlist, al);

        }

    }
}
