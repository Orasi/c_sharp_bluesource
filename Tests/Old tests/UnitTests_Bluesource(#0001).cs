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

/*********************************************************************************************************************************************************************
TEST INFORMATION
Objective: To verify that the employee’s summary screen for time off is the same as the ‘manage pto’ screen

Steps: 
1)	Login to BlueSource using a role that is manager or above
2)	Click on an employee’s name to be taken to the ‘Employee Summary’ page
3)	Expand the ‘Time Off Details’  area and note the totals given to employee
4)	Click the ‘Manage’ button
5)	Verify the totals given above the table match the summary numbers noted earlier

Data Variations:
-	Employee here less than 1 year
-	Employee here more than 3 years
-	Employee here more than 6 years
-	Employee with above year anniversaries happening in the middle of the fiscal year

******************************************************************************************************************************************************************** */

namespace CSharp_Blusource_Selenium
{
    [TestClass]
    public class UnitTest1
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
        public void CodeTester()
        {

        }

        [TestMethod]
        public void SelectFirstEmployeeInSearch()
        {
            bsEmployeeSearch.clickOnFirstEmployeeInSearch();
        }

        [TestMethod]
        public void GetDaysOffOfEmployee()
        {
            String[] daysOff = new String[3];

            bsEmployeeDetails.openTimeOffDetails();

            daysOff = bsEmployeeTimeOffDetails.getTimeOffDetailTotalsForEmployee();
            System.Console.WriteLine("Day[0]: " + daysOff[0]);
            System.Console.WriteLine("Day[1]: " + daysOff[1]);
            System.Console.WriteLine("Day[2]: " + daysOff[2]);
        }

        [TestMethod]
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
