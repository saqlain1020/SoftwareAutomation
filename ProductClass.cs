using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Final_Lab_Automation
{
    public class ProductPage : DriverClass
    {
        string url;
        string pid;
        string name;
        By productPrice = By.ClassName("price-container");
        By addtoCartBtn = By.CssSelector("#tbodyid > div.row > div > a");
        By nameHeading = By.ClassName("name");
        public int price;

        public void openProductPage(string pid)
        {
            this.pid = pid;
            this.url = "https://www.demoblaze.com/prod.html?idp_=" + pid;
            driver.Url= url;
            //Thread.Sleep(2000);
            this.price = int.Parse(driver.FindElement(productPrice).Text.Split()[0].Remove(0, 1));
            this.name = driver.FindElement(nameHeading).Text;
        }

        public void checkProductName(string name)
        {
            Assert.AreEqual(name, this.name, "AssertFailed and Product name does not match");
        }

        public void addToCart()
        {
            driver.FindElement(addtoCartBtn).Click();
            Thread.Sleep(2000);
            string actualText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            Assert.AreEqual("Product added", actualText, "AssertFailed");
        }
    }
}
