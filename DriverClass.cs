using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Lab_Automation
{
    public class DriverClass
    {
        public static IWebDriver driver;
        public static WebDriverWait wait;
        public void Selenium_driver(string browser)
        {

            switch (browser)
            {
                case "edge":
                    var mydriver = new EdgeDriver();
                    driver = mydriver;
                    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                    break;
                case "chrome":
                    var mydriver2 = new ChromeDriver();
                    driver = mydriver2;
                    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                    break;
                default:
                    var mydriver3 = new ChromeDriver();
                    driver = mydriver3;
                    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                    break;
            }


            //var mydriver = new EdgeDriver();
            //var mydriver = new ChromeDriver();
            //var mydriver = new InternetExplorerDriver();

            //driver = mydriver;
            // Wait before finding element in html
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

            // Wait with timeout
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public void close_driver()
        {
            driver.Close();
        }

        public IWebElement WaitForElement(By by)
        {   
          return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}
