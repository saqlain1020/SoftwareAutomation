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
            LoginPage login = new LoginPage();
            ProductPage product = new ProductPage();
            login.Login();
            product.openProductPage("1");
            product.addToCart();
            driverClass.close_driver();
        }

        [TestMethod]
        [TestCategory("ProductPage")]
        public void TestCase_006()
        {
            driverClass.Selenium_driver();
            ProductPage product = new ProductPage();
            product.openProductPage("1");
            product.checkProductPrice(360);
            driverClass.close_driver();
        }

        [TestMethod]
        [TestCategory("Cart")]
        public void TestCase_007()
        {
            driverClass.Selenium_driver();
            CartPage cart = new CartPage();
            cart.openCartPage();
            driverClass.close_driver();
        }

        [TestMethod]
        [TestCategory("Cart"), TestCategory("ProductPage")]
        public void TestCase_008() {
            driverClass.Selenium_driver();
            LoginPage login = new LoginPage();            
            ProductPage product = new ProductPage();
            CartPage cart = new CartPage();
            login.Login();
            cart.openCartPage();
            cart.emptyCart();
            product.openProductPage("1");
            product.addToCart();
            cart.openCartPage();
            cart.checkProductsQty(1);
            driverClass.close_driver();
        }

        [TestMethod]
        [TestCategory("Cart")]
        public void TestCase_009()
        {
            driverClass.Selenium_driver();
            LoginPage login = new LoginPage();
            CartPage cart = new CartPage();
            login.Login();
            cart.openCartPage();
            cart.emptyCart();
            driverClass.close_driver();
        }
    }
}
    