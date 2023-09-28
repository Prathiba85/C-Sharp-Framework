using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace CSharp_Selenium_Framework
{
    public class Base
    {
        public IWebDriver driver;
        Boolean flag = true;
        [SetUp]
        public void StartBrowser()
        {
            //Configuration
            String browserName= ConfigurationManager.AppSettings["browser"];

            InitBrowser(browserName);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

            //global implicit wait -Wait 5 seconds after every line
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        //Factory Design Pattern
        public void InitBrowser(String browserName)
        {
            switch (browserName)
            {
                case "FireFox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;

            }
        }
        public IWebDriver getDriver() 
        { return driver; 
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }
    }
}
