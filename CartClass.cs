using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;


namespace Final_Lab_Automation
{
    public class CartPage : DriverClass
    {
        string url = "https://www.demoblaze.com/cart.html";
        By title = By.CssSelector("#page-wrapper > div > div.col-lg-8 > h2");
        By deleteBtn = By.CssSelector("#tbodyid > tr > td:nth-child(4) > a");
        By table = By.Id("tbodyid");
        By checkoutName = By.Id("name");
        By chckoutCreditCard = By.Id("card");
        By countryInput = By.Id("country");
        By cityInput = By.Id("city");
        By monthInput = By.Id("month");
        By yearInput = By.Id("year");
        By checkoutSubmit = By.CssSelector("#orderModal > div > div > div.modal-footer > button.btn.btn-primary");
        By checkoutActualText = By.CssSelector("body > div.sweet-alert.showSweetAlert.visible > h2");
        By totalPrice = By.Id("totalp");

        public void openCartPage()
        {
            driver.Url = url;
            string titleText = driver.FindElement(title).Text;
            Assert.AreEqual(titleText, "Products","AssertFailed Wrong Page");
        }


       public int getProductsQty()
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
            //driver.Url = url;
            if (getProductsQty() == 0)
            {
                return;
            }
            else
            {

            WaitForElement(deleteBtn).Click();
            emptyCart();
            }
        }

        public void isCartEmpty()
        {
            bool isEmptyExpected = true;
            driver.Url = url;
            if (getProductsQty() == 0)
            {
                Assert.AreEqual(isEmptyExpected, true, "assert failed, cart is not empty");
            }
            else
            {
                Assert.AreEqual(isEmptyExpected, false, "assert failed");
            }
            
        }

        public bool CreditCardFormat(string inputCreditCardNumber)
        {
            driver.Url = url;
            string creditCardPattern = @"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$";
            return Regex.IsMatch(inputCreditCardNumber, creditCardPattern);
        }

        public void checkout(string name,string creditCardNumber)
        {
            driver.Url=url;
            driver.FindElement(By.CssSelector("#page-wrapper > div > div.col-lg-1 > button")).Click();
            WaitForElement(checkoutName).SendKeys(name);
            driver.FindElement(chckoutCreditCard).SendKeys(creditCardNumber);
            driver.FindElement(checkoutSubmit).Click();
            string actualText = WaitForElement(checkoutActualText).Text;
            Assert.AreNotEqual("Thank you for your purchase!", actualText, "Assert Failed, checkout completed but rest fields should be required fields too");
        }

        public void checkout()
        {
            driver.Url = url;
            driver.FindElement(By.CssSelector("#page-wrapper > div > div.col-lg-1 > button")).Click();
            WaitForElement(checkoutName);
            driver.FindElement(checkoutSubmit).Click();
            string actualText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            Assert.AreEqual("Please fill out Name and Creditcard.", actualText, "assert failed");
        }
        
        public void checkout(string name, string creditCardNumber,string country , string city, string month , string year)
        {
            driver.Url = url;
            driver.FindElement(By.CssSelector("#page-wrapper > div > div.col-lg-1 > button")).Click();
            WaitForElement(checkoutName).SendKeys(name);
            driver.FindElement(countryInput).SendKeys(country);
            driver.FindElement(cityInput).SendKeys(city);
            driver.FindElement(chckoutCreditCard).SendKeys(creditCardNumber);
            driver.FindElement(monthInput).SendKeys(month);
            driver.FindElement(yearInput).SendKeys(year);
            driver.FindElement(checkoutSubmit).Click();
            string actualText = WaitForElement(checkoutActualText).Text;
            Assert.AreEqual("Thank you for your purchase!", actualText, "assert failed,Checkout not performed");
        }
        
        public void checkoutEmptyCart(string name, string creditCardNumber,string country , string city, string month , string year)
        {
            openCartPage();
            emptyCart();
            driver.FindElement(By.CssSelector("#page-wrapper > div > div.col-lg-1 > button")).Click();
            WaitForElement(checkoutName).SendKeys(name);
            driver.FindElement(countryInput).SendKeys(country);
            driver.FindElement(cityInput).SendKeys(city);
            driver.FindElement(chckoutCreditCard).SendKeys(creditCardNumber);
            driver.FindElement(monthInput).SendKeys(month);
            driver.FindElement(yearInput).SendKeys(year);
            driver.FindElement(checkoutSubmit).Click();
            string actualText = WaitForElement(checkoutActualText).Text;
            Assert.AreNotEqual("Thank you for your purchase!", actualText, "assert failed,Checkout performed With Empty Cart as well.");
        }


        public void cartAmountCheck()
        {
            driver.Url=url;
            int qty = getProductsQty();
            int [] arr = new int[qty];
            for (int i = 0; i < qty; i++)
            {
               arr[i] = Int32.Parse(driver.FindElement(By.CssSelector("#tbodyid > tr:nth-child("+(i+1)+") > td:nth-child(3)")).Text);

            }

            int calculatedTotal = arr.Sum();
            int actualTotal = Int32.Parse(driver.FindElement(totalPrice).Text);

            Assert.AreEqual(calculatedTotal, actualTotal, "Assert Failed, both totals are not same");
            

        }
    }
}
