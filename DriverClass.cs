using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
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
        //public static WebDriver driver;
        public void Selenium_driver()
        {
            var mydriver = new ChromeDriver();
            //var mydriver = new InternetExplorerDriver();
            
            driver = mydriver;
            // Wait before finding element in html
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
        }

        public void close_driver()
        {
            driver.Close();
        }

    }
}
