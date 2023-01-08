using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Final_Lab_Automation
{
    [TestClass]
    public class MainClass
    {

        LoginPage loginpage = new LoginPage();
        DriverClass driverClass = new DriverClass();

        [TestMethod]
        [TestCategory("Login_Positive")]
        public void TestCase_001()
        {
            driverClass.Selenium_driver();
            loginpage.Login();
            driverClass.close_driver();

        }

        [TestMethod]
        [TestCategory("Login_Negative")]
        public void TestCase_002()
        {
            driverClass.Selenium_driver();
            loginpage.LoginEmpty();
            driverClass.close_driver();
        }

        [TestMethod]
        [TestCategory("Login_Negative")]
        public void TestCase_003()
        {
            driverClass.Selenium_driver();
            loginpage.LoginWrongPass();
            driverClass.close_driver();
        }

        [TestMethod]
        [TestCategory("ProductPage")]
        public void TestCase_004()
        {
            driverClass.Selenium_driver();
            ProductPage product = new ProductPage();
            product.openProductPage("1");
            product.checkProductName("Samsung galaxy s6");            
            driverClass.close_driver();
        }

        [TestMethod]
        [TestCategory("ProductPage"),TestCategory("Cart")]
        public void TestCase_005()
        {
            driverClass.Selenium_driver();
            ProductPage product = new ProductPage();
            product.openProductPage("1");
            product.addToCart();
            driverClass.close_driver();
        }

    }
}
