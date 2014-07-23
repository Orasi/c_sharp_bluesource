using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//use Selenium namespaces after adding references
using OpenQA.Selenium;

namespace SeleniumProject
{
    public class Logout : BaseWebPage
    {

        //default test case
        public Logout(IWebDriver webDriver): base(webDriver) {
            if (WebDriver.Title == "Google")
            {
                System.Console.WriteLine("Successfully visited logout page");
            }
            else {
                System.Console.WriteLine("Error, title is {0}, expecting Google", WebDriver.Title);
                throw new InvalidOperationException(String.Format("Error, title is {0}, expecting Google", WebDriver.Title));
            }
        }

        public Logout(IWebDriver webDriver, string title) : base(webDriver)
        {
            if (WebDriver.Title == title)
            {
                System.Console.WriteLine("Successfully visited logout page");
            }
            else
            {
                System.Console.WriteLine("Error, title is {0}, expecting {1}", WebDriver.Title, title);
                throw new InvalidOperationException(String.Format("Error, title is {0}, expecting {1}", WebDriver.Title, title));
            }
        }

        public void ClickLogout(string text) {
            Click(SearchType.LinkText, text);
        }
    }
}
