using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;
using CSharp_Selenium_Framework;

namespace SeleniumLearning
{
    class windowhandles : Base
    {
      
        String username="";
        
        [Test]
        public void switchToWindow()
        {

            IWebElement blinkingtext = driver.FindElement(By.XPath("//a[@class='blinkingText']"));
            blinkingtext.Click();
           IList<String> allwindows = driver.WindowHandles;
            String childwindow = allwindows[1];
            String parentwindow = allwindows[0];
            //TestContext.Progress.WriteLine(allwindows.Count);
            driver.SwitchTo().Window(childwindow);
           
            String message = driver.FindElement(By.XPath("//p[@class='im-para red']")).Text;
            //TestContext.Progress.WriteLine(message);
            String[] Arrarymessage = message.Split(" ");
            //TestContext.Progress.WriteLine("email is " + Arrarymessage[5]);
            foreach (String str in Arrarymessage)
            {
               
                if (str .Contains(".com"))
                {
                   username = str;
                }
            }

            driver.SwitchTo().Window(parentwindow);
            driver.FindElement(By.Id("username")).SendKeys(username);

        }
    }
}
