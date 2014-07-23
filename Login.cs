using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//use Selenium namespaces after adding references
using OpenQA.Selenium;

namespace SeleniumProject
{
    public class Login : BaseWebPage
    {
        #region Members
            protected string title;
        #endregion

        #region Properties
        #endregion

        #region Constructors
            //Default test case constructor
            public Login(IWebDriver webDriver): base(webDriver) {
                if (WebDriver.Title == "Google")
                {
                    System.Console.WriteLine("Successfully visited login page");
                }
                else {
                    System.Console.WriteLine("Error, title is {0}, expecting Google", WebDriver.Title);
                    throw new InvalidOperationException(String.Format("Error, title is {0}, expecting Google", WebDriver.Title));
                }
            }

            public Login(IWebDriver webDriver, string title): base(webDriver) {          
                if (WebDriver.Title == title)
                {
                    System.Console.WriteLine("Successfully visited login page");
                }
                else
                {
                    System.Console.WriteLine("Error, title is {0}, expecting {1}", WebDriver.Title, title);
                    throw new InvalidOperationException(String.Format("Error, title is {0}, expecting {1}", WebDriver.Title, title));
                }
            }
        #endregion

        #region Methods
            //Attempts to click the Login button using the given html element name.  Calls Click, which we inherit from BaseWebPage.
            public void ClickLogin(string name){
                //<input disabled="" class="btn btn-primary" data-loading-text="Logging in..." name="commit" value="Login" type="submit">
                Click(SearchType.Name, name);   
            }

            public void Username(string name)
            {
                //<input autofocus="autofocus" class="form-control" id="employee_username" name="employee[username]" required="required" type="text">
                //IWebElement usernameField = webDriver.FindElement(By.Id("session_key-login"));
                if (name != "")
                {
                    TextEntry(SearchType.Id, "employee_username", name);
                }
                else
                {
                    TextEntry(SearchType.Id, "employee_username", "Steve");
                }
            }

            public void Password(string password)
            {
                //<input class="form-control" id="employee_password" name="employee[password]" required="required" type="password">
                //IWebElement password = webDriver.FindElement(By.Id("session_password-login"));
                if (password != "")
                {
                    TextEntry(SearchType.Id, "employee_password", password);
                }
                else
                {
                    TextEntry(SearchType.Id, "employee_password", "1234");
                }
            }
        #endregion

    }
}
