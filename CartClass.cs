using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Final_Lab_Automation
{
    public class CartPage : DriverClass
    {
        string url = "https://www.demoblaze.com/cart.html";
        By title = By.CssSelector("#page-wrapper > div > div.col-lg-8 > h2");
        By deleteBtn = By.CssSelector("#tbodyid > tr > td:nth-child(4) > a");
        By table = By.Id("tbodyid");

        public void openCartPage()
        {
            driver.Url = url;
            string titleText = driver.FindElement(title).Text;
            Assert.AreEqual(titleText, "Products","AssertFailed Wrong Page");
        }


        int getProductsQty()
        {
            try
            {
                WaitForElement(By.CssSelector("#tbodyid .success"));
                int count = WaitForElement(table).FindElements(By.TagName("tr")).Count;
                return count;
            }
            catch (NoSuchElementException)
            {

            }
            catch (WebDriverTimeoutException) { }
            return 0;
        }

        public void checkProductsQty(int qty)
        {           
            int count = getProductsQty();
            Assert.AreEqual(qty, count, "AssertFailed Products Count not matched");
        }

        public void emptyCart()
        {
            driver.Url = url;
            if (getProductsQty() == 0) return;
            WaitForElement(deleteBtn).Click();
            emptyCart();
        }
    }
}
