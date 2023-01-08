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
            loginpage.LoginPositive_001("https://www.demoblaze.com/index.html", "izhan2001", "hello234");
            driverClass.close_driver();

        }



        [TestMethod]

        [TestCategory("Login_Negative")]
        public void TestCase_002()
        {
            driverClass.Selenium_driver();
            loginpage.LoginNegative_001("https://www.demoblaze.com/index.html");
            driverClass.close_driver();

        }

    }
}
