using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//use Selenium namespaces after adding references
using OpenQA.Selenium;

namespace SeleniumProject
{
    class Homepage
    {
        protected readonly IWebDriver webDriver;

        public Homepage(IWebDriver webDriver) {
            this.webDriver = webDriver;

            if (this.webDriver.Title == "Google")
            {
                System.Console.WriteLine("HOODY HOO!!!");
            }
            else {
                System.Console.WriteLine("Error, title is {0}", this.webDriver.Title);
                throw new InvalidOperationException("Error, title is " + this.webDriver.Title);
            }
        }

        //should this be a bool?
        public void Logout() {
            webDriver.FindElement(By.LinkText("Sign Out")).Click();
        }
    }
}
