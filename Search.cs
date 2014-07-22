using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//use Selenium namespaces after adding references
using OpenQA.Selenium;

namespace SeleniumProject
{
    public class Search : BaseWebPage
    {
        //default test case
        public Search(IWebDriver webDriver): base(webDriver) {
            if (WebDriver.Title == "Google")
            {
                System.Console.WriteLine("Successfully visited search page");
            }
            else {
                System.Console.WriteLine("Error, title is {0}, expecting Google", WebDriver.Title);
                throw new InvalidOperationException(String.Format("Error, title is {0}, expecting Google", WebDriver.Title));
            }
        }

        public Search(IWebDriver webDriver, string title) : base(webDriver)
        {
            if (WebDriver.Title == title)
            {
                System.Console.WriteLine("Successfully visited search page");
            }
            else
            {
                System.Console.WriteLine("Error, title is {0}, expecting {1}", WebDriver.Title, title);
                throw new InvalidOperationException(String.Format("Error, title is {0}, expecting {1}", WebDriver.Title, title));
            }
        }

        #region Methods
            public void SearchForEmployee(string fname, string lname){
                //id="search-bar" ng-model="query" ng-change="search()" class="form-control ng-pristine ng-valid" placeholder="Search here..." autofocus="" type="text">
                //ok, so, we can't use id since it's not unique, and ClassName doesn't support compound classes.  Xpath it is.
                TextEntry(SearchType.Xpath, "//html/body/div[1]/section/div[1]/div[2]/input", fname + " " + lname);
                //Give it a pause to catch up after the search
                WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                Validate(SearchType.LinkText, fname);
                Validate(SearchType.LinkText, lname);
            }
        #endregion
    }
}
