using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using CSharp_Blusource_Selenium.Pages;

namespace CSharp_Blusource_Selenium
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            String userName = "company.admin";
            String password = "1234";

            IWebDriver WebDriver;
            WebDriver = new FirefoxDriver();

            BlueSource_Login bsLogin = new BlueSource_Login(WebDriver);
            bsLogin.navigateToLoginPage();
            bsLogin.loginToBlueSource(userName, password);

            bsLogin.wait(10);

            WebDriver.Close();
            WebDriver.Quit();
        }

        
    }


}
