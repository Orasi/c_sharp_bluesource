using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//NUnit namespace
using NUnit.Framework;

//use Selenium namespaces after adding references
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumProject
{
    [TestFixture] //NUnit tag
    public class SeleniumProject
    {
        #region Members
            private Dictionary<string, string> employeeData;
            private Employee employee;
            private Form form;
            private IWebDriver webDriver;
            private Login login;
            private Logout logout;
            private Search search;
            private string title;
        #endregion

        #region Properties
            public string Title{
                get {
                    return title;
                }
                set {
                    if (value != "") {
                        title = value;
                    }
                    else{
                        title = "Google";
                    }
                }
            }

            public Dictionary<string, string> EmployeeData
            {
                get {
                    return employeeData;
                }
            }
        #endregion

        #region Constructor
            public SeleniumProject(){
                employeeData = new Dictionary<string, string>();
                employeeData.Add("username", "TempEmployee6");
                employeeData.Add("first_name", "Steve6");
                employeeData.Add("last_name", "King6");
                employeeData.Add("bridge_time", "");
                employeeData.Add("start_date", "2012-08-20");
                employeeData.Add("cell_phone", "(336) 336-3363");
                employeeData.Add("office_phone", "(336) 336-3363");
                employeeData.Add("email", "Stephen.king6@orasi.com");
                employeeData.Add("im_name", "");
                employeeData.Add("title_id", "Top Swagger");
                employeeData.Add("role", "Company Admin");
                employeeData.Add("manager_id", "Adam Otherthomas");
                employeeData.Add("status", "Permanent");
                employeeData.Add("location", "Greensboro");
                employeeData.Add("im_client", "Skype");
                employeeData.Add("department_id", "Services");
            }
        #endregion

        #region Methods
            [SetUp]   //NUnit tag
            public void Setup(){
                webDriver = new FirefoxDriver();
                webDriver.Url = "http://www.google.com";
                webDriver.Navigate();
            }

            [SetUp]   //NUnit tag
            public void Setup(string url)
            {
                webDriver = new FirefoxDriver();
                webDriver.Url = url;
                webDriver.Navigate();
            }

            [TearDown]   //NUnit tag
            public void TearDown(){
                webDriver.Quit();
            }

            /*[Test]   //NUnit tag
            public void VeryifyLoginAndLogout(){
                login = new Login(webDriver);
                login.Username("company.admin"); //Steve";
                login.Password("1234");
                login.ClickLogin("commit");

                form = new Form(webDriver, "Google");
                form.AddEmployee(EmployeeData);

                logout = new Logout(webDriver);
                Assert.IsTrue(webDriver.PageSource.Contains("Google"));
                logout.ClickLogout("Sign Out");

                Assert.IsTrue(webDriver.Title.Equals("Google"));
            }
            */

            [Test]   //NUnit tag
            public void ExecuteTestCase(string title){
                Title = title;
                Login();
                AddEmployee();
                SearchForEmployee();
                ClickOnEmployee();
                Logout();
            }

            [Test]   //NUnit tag
            public void Login()
            {
                login = new Login(webDriver, Title);
                login.Username("company.admin");
                login.Password("1234");
                login.ClickLogin("commit");

                try{
                    Assert.IsTrue(webDriver.Title.Equals(Title));
                }
                catch (AssertionException ex){
                    System.Console.WriteLine(ex.ToString());
                }
            }

            [Test]  //NUnit tag
            public void AddEmployee(){
                form = new Form(webDriver, Title);
                form.AddEmployee(EmployeeData);
                /*
                    TODO - update with handling for an employee already existing
                 */
            }

            [Test]  //NUnit tag
            public void SearchForEmployee(){
                search = new Search(webDriver, Title);
                search.SearchForEmployee(EmployeeData["first_name"], EmployeeData["last_name"]);
            }

            [Test]  //NUnit tag
            public void ClickOnEmployee(){
                employee = new Employee(webDriver, Title);
                employee.SelectEmployee(EmployeeData["first_name"]);
                try{
                    Assert.IsTrue(employee.CompareEmployee(EmployeeData));
                }
                catch (AssertionException ex){
                    System.Console.WriteLine(ex.ToString());
                }
            }

            [Test]  //NUnit tag
            public void Logout(){
                logout = new Logout(webDriver, Title);
                Assert.IsTrue(webDriver.PageSource.Contains(Title));
                logout.ClickLogout("Logout");
            }
        #endregion
    }
}
