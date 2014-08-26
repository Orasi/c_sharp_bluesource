using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using CSharp_Blusource_Selenium.Pages;
using CSharp_Blusource_Selenium.Toolkit;


namespace CSharp_Blusource_Selenium
{
    [TestClass]
    public class BlueSourceTestCase_0000
    {
        /*********************************************************************************************************************************************************************
        * TEST INFORMATION
        * Username to use: company.admin
        * Password: Anything will work, I use 1234
        * 
        * When you first log in you should land at the employees screen.
        * 
        * Click the add button to add a new employee.
        * 
        * Fill out the relevant form with any data that you would like.  
        * 
        * Submit form.
        * 
        * Search for the newly created employee in the seach bar.
        * 
        * Validate that the employee exists in the employee table -Click on the employee to go to employee detail screen.
        * 
        * Validate information is consistent with what you entered in form.
        * 
        ******************************************************************************************************************************************************************** */

        static int RnNum;
        static string SeleniumGridIP;

        static String userName;
        static String password;

        static String employeeUserName;
        static String employeeFirstName;
        static String employeeLastName;
        static String employeeEmail;

        static BlueSource_Login bsLogin;
        static BlueSource_EmployeeSearch bsEmployeeSearch;

        [ClassInitialize]
        public static void StartItUp(TestContext TC)
        {
            RnNum = OSI.Utilities.RandomNumber(1000, 9999);
            SeleniumGridIP = "http://10.238.242.50:4444/wd/hub";

            userName = "company.admin";
            password = "1234";

            employeeUserName = "CSharpScript" + RnNum;
            employeeFirstName = "Csharp" + RnNum;
            employeeLastName = "Script" + RnNum;
            employeeEmail = "Shield.Knight" + RnNum + "@orasi.com";

            //OSI.Forms.MsgBox(System.Environment.GetEnvironmentVariable("PATH"));
            //OSI.Forms.MsgBox("%HOMEPATH%");
            OSI.Web.WebDriver = new FirefoxDriver();
            OSI.Web.jse = (IJavaScriptExecutor)OSI.Web.WebDriver;
            //OSI.Web.WebDriver = new ChromeDriver();
            //OSI.Web.WebDriver = new RemoteWebDriver(new Uri(SeleniumGridIP), DesiredCapabilities.Firefox());

            bsLogin = new BlueSource_Login();
            bsEmployeeSearch = new BlueSource_EmployeeSearch();
        }

        [TestMethod]
        public void NavigateToBlueSource()
        {
            bsLogin.navigateToLoginPage();
            Assert.IsTrue(bsLogin.IsOnLogInPage());
        }

        [TestMethod]
        public void LoginToBlueSource()
        {
            bsLogin.loginToBlueSource(userName, password);
            Assert.IsTrue(bsLogin.IsLoggedIn());
        }

        [TestMethod]
        public void AddEmployee()
        {
            Assert.IsTrue(bsEmployeeSearch.isOnEmployeeSearchPage());
            bsEmployeeSearch.addEmployee(employeeUserName, employeeFirstName, employeeLastName, employeeEmail);
        }

        [TestMethod]
        public void SearchForEmployee()
        {
            String foundName = bsEmployeeSearch.searchForEmployee(employeeFirstName);
            Assert.AreEqual(employeeFirstName, foundName);
        }

        [ClassCleanup]
        public static void ShutErDown()
        {
            bsLogin.wait(10);
            bsEmployeeSearch.LogOut();
            bsEmployeeSearch.closeBrowser();
        }


    }

    [TestClass]
    public class BlueSourceTestCase_0001
    {
        static int RnNum;
        static string SeleniumGridIP;

        static String userName;
        static String password;

        static String employeeUserName;
        static String employeeFirstName;
        static String employeeLastName;
        static String employeeEmail;

        static BlueSource_Login bsLogin;
        static BlueSource_EmployeeSearch bsEmployeeSearch;
        static BlueSource_Employee bsEmployeeDetails;
        static BlueSource_EmployeeTimeOff bsEmployeeTimeOffDetails;

        [ClassInitialize]
        public static void StartItUp(TestContext TC)
        {
            RnNum = OSI.Utilities.RandomNumber(1000, 9999);
            SeleniumGridIP = "http://10.238.242.50:4444/wd/hub";

            userName = "company.admin";
            password = "1234";

            employeeUserName = "CSharpScript" + RnNum;
            employeeFirstName = "Csharp" + RnNum;
            employeeLastName = "Script" + RnNum;
            employeeEmail = "Shield.Knight" + RnNum + "@orasi.com";

            //OSI.Forms.MsgBox(System.Environment.GetEnvironmentVariable("PATH"));
            //OSI.Forms.MsgBox("%HOMEPATH%");
            OSI.Web.WebDriver = new FirefoxDriver();
            OSI.Web.jse = (IJavaScriptExecutor)OSI.Web.WebDriver;
            //OSI.Web.WebDriver = new ChromeDriver();
            //OSI.Web.WebDriver = new RemoteWebDriver(new Uri(SeleniumGridIP), DesiredCapabilities.Firefox());

            bsLogin = new BlueSource_Login();
            bsEmployeeSearch = new BlueSource_EmployeeSearch();
            bsEmployeeDetails = new BlueSource_Employee();
            bsEmployeeTimeOffDetails = new BlueSource_EmployeeTimeOff();
        }

        [TestMethod]
        // Visual Studios Express lacks the options to control the order in which your tests runs and for some weird reason, will swap their order.
        public void TestsInOrder()
        {
            NavigateToBlueSource();

            LoginToBlueSource();

            SelectFirstEmployeeInSearch();

            GetDaysOffOfEmployee();

            navigateBackFromDayOffAndManageEmployee();
        }
       // [TestMethod]
        public void NavigateToBlueSource()
        {
            bsLogin.navigateToLoginPage();
            Assert.IsTrue(bsLogin.IsOnLogInPage());
        }

       // [TestMethod]
        public void LoginToBlueSource()
        {
            bsLogin.loginToBlueSource(userName, password);
            Assert.IsTrue(bsLogin.IsLoggedIn());
        }

       // [TestMethod]
        public void SelectFirstEmployeeInSearch()
        {
            Assert.IsTrue(bsEmployeeSearch.isOnEmployeeSearchPage());
            bsEmployeeSearch.clickOnFirstEmployeeInSearch();
        }

       // [TestMethod]
        public void GetDaysOffOfEmployee()
        {
            Assert.IsTrue(bsEmployeeDetails.isOnEmployeePage());

            String[] daysOff = new String[3];

            bsEmployeeDetails.openTimeOffDetails();

            daysOff = bsEmployeeTimeOffDetails.getTimeOffDetailTotalsForEmployee();
            System.Console.WriteLine("Day[0]: " + daysOff[0]);
            System.Console.WriteLine("Day[1]: " + daysOff[1]);
            System.Console.WriteLine("Day[2]: " + daysOff[2]);
        }

       // [TestMethod]
        public void navigateBackFromDayOffAndManageEmployee()
        {
            bsEmployeeTimeOffDetails.navigateBackwards();
            bsEmployeeDetails.openManagementDetails();
        }

        [ClassCleanup]
        public static void ShutErDown()
        {
            bsLogin.wait(10);
            bsEmployeeSearch.LogOut();
            bsEmployeeSearch.closeBrowser();
        }
    }
}
