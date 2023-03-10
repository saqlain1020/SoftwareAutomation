using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Final_Lab_Automation
{

    
    public class LoginPage : DriverClass
    {
        By userEmail = By.Id("loginusername");
        By userPass = By.Id("loginpassword");
        By SubmitBtn = By.CssSelector("#logInModal > div > div > div.modal-footer > button.btn.btn-primary");
        By loginModal = By.Id("login2");
        By actual = By.Id("nameofuser");
        By logOutBtn = By.Id("logout2");
        string url = "https://www.demoblaze.com/index.html";


        
        public void Login()
        {
            string email = "izhan2001";
            string pass = "hello234";
            driver.Manage().Window.Maximize();
            driver.Url = url;
            var check = driver.FindElement(loginModal);
            check.Click();
            //if (!driver.FindElement(userEmail).Displayed)
            //{
            //    Thread.Sleep(3000);
            //}
            WaitForElement(userEmail).SendKeys(email);
            driver.FindElement(userPass).SendKeys(pass);
            driver.FindElement(SubmitBtn).Click();
            //if (!driver.FindElement(actual).Displayed)
            //{
            //    Thread.Sleep(6000);
            //}
            string actualText = WaitForElement(actual).Text;
            Assert.AreEqual("Welcome " + email, actualText, "AssertFailed and Login not performed");
        }


        public void LoginEmpty()
        {
            driver.Manage().Window.Maximize();
            driver.Url = url;
            driver.FindElement(loginModal).Click();
            if (!driver.FindElement(SubmitBtn).Displayed)
            {
                Thread.Sleep(3000);
            }
            driver.FindElement(SubmitBtn).Click();
            string actualText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            Assert.AreEqual("Please fill out Username and Password.", actualText, "Assert Failed");
        }

        public void LoginWrongPass(string email , string pass)
        {
            driver.Manage().Window.Maximize();
            driver.Url = url;
            driver.FindElement(loginModal).Click();
            if (!driver.FindElement(SubmitBtn).Displayed)
            {
                Thread.Sleep(3000);
            }
            driver.FindElement(userEmail).SendKeys(email);
            driver.FindElement(userPass).SendKeys(pass);
            driver.FindElement(SubmitBtn).Click();
            Thread.Sleep(3000);
            string actualText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            Assert.AreEqual("Wrong password.", actualText, "Assert Failed");
        }
        
        public void LoginWrongUsername(string email , string pass)
        {
            driver.Manage().Window.Maximize();
            driver.Url = url;
            driver.FindElement(loginModal).Click();
            if (!driver.FindElement(SubmitBtn).Displayed)
            {
                Thread.Sleep(3000);
            }
            driver.FindElement(userEmail).SendKeys(email);
            driver.FindElement(userPass).SendKeys(pass);
            driver.FindElement(SubmitBtn).Click();
            Thread.Sleep(3000);
            string actualText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            Assert.AreEqual("User does not exist.", actualText, "Assert Failed");
        }

        public void Logout()
        {
            WaitForElement(logOutBtn).Click();
        }
    }
}
