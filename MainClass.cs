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
            loginpage.LoginWrongPass("izhan2001","abc");
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
            cart.isCartEmpty();
            driverClass.close_driver();
        }

        [TestMethod]
        [TestCategory("Cart")]
        public void TestCase_010()
        {
            driverClass.Selenium_driver();
            LoginPage login = new LoginPage();
            ProductPage product = new ProductPage();
            CartPage cart = new CartPage();
            login.Login();
            cart.openCartPage();
            int qty = cart.getProductsQty();
            product.openProductPage("1");
            product.addToCart();
            cart.openCartPage();
            int newQty = cart.getProductsQty();
            qty++;
            Assert.AreEqual(qty, newQty , "Assert Failed, Product not added to cart, Quantity not updatedd");
            driverClass.close_driver();
        }

        [TestMethod]
        [TestCategory("Checkout")]
        public void TestCase_011()
        {
            driverClass.Selenium_driver();
            CartPage cart = new CartPage();
            cart.checkout();
            driverClass.close_driver();
        }

        [TestMethod]
        [TestCategory("Checkout")]
        public void TestCase_012()
        {
            driverClass.Selenium_driver();
            CartPage cart = new CartPage();
            //bool isCorrectFormat = cart.CreditCardFormat("40312412");
            bool isCorrectFormat = cart.CreditCardFormat("4012888888881881");
            cart.checkout("Sumaiya" , "4012888888881881");
            Assert.AreEqual(true, isCorrectFormat,"assert Failed, Creit Cart format not valid but checkout performed");
            driverClass.close_driver();
        }
        
        [TestMethod]
        [TestCategory("Checkout")]
        public void TestCase_013()
        {
            driverClass.Selenium_driver();
            CartPage cart = new CartPage();
            bool isCorrectFormat = cart.CreditCardFormat("45034");
            //bool isCorrectFormat = cart.CreditCardFormat("4012888888881881");
            cart.checkout("Sumaiya" , "45034","Pakistan","Karachi","05","2025");
            Assert.AreEqual(true, isCorrectFormat,"assert Failed, Creit Cart format not valid but checkout performed");
            driverClass.close_driver();
        }
        
        [TestMethod]
        [TestCategory("Login_Negative")]
        public void TestCase_014()
        {
            driverClass.Selenium_driver();
            loginpage.LoginWrongUsername("maaz","hello");
            driverClass.close_driver();
        }
        
        [TestMethod]
        [TestCategory("Cart")]
        public void TestCase_015()
        {
            CartPage cart = new CartPage();
            LoginPage login = new LoginPage();
            driverClass.Selenium_driver();
            login.Login();
            cart.cartAmountCheck();
            driverClass.close_driver();
        }
        
        
        [TestMethod]
        [TestCategory("Checkout")]
        public void TestCase_016()
        {
            CartPage cart = new CartPage();
            driverClass.Selenium_driver();
            cart.checkoutEmptyCart("Sumaiya", "4012888888881881", "Pakistan", "Karachi", "05", "2025");
            driverClass.close_driver();
        }
    }
}
    