using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//use Selenium namespaces after adding references
using OpenQA.Selenium;

namespace SeleniumProject
{
    public class Employee : BaseWebPage
    {
        
        #region Constructors
        //default test case constructor
        public Employee(IWebDriver webDriver): base(webDriver) {
            if (WebDriver.Title == "Google")
            {
                System.Console.WriteLine("Successfully visited Employee page");
            }
            else {
                System.Console.WriteLine("Error, title is {0}, expecting Google", WebDriver.Title);
                throw new InvalidOperationException(String.Format("Error, title is {0}, expecting Google", WebDriver.Title));
            }
        }

        public Employee(IWebDriver webDriver, string title) : base(webDriver)
        {
            if (WebDriver.Title == title)
            {
                System.Console.WriteLine("Successfully visited Employee page");
            }
            else
            {
                System.Console.WriteLine("Error, title is {0}, expecting {1}", WebDriver.Title, title);
                throw new InvalidOperationException(String.Format("Error, title is {0}, expecting {1}", WebDriver.Title, title));
            }
        }
        #endregion

        #region Methods
            //Clicks on the given employee name if it exists.  Click is located in the BaseWebPage class, which we inherit from.
            public void SelectEmployee(string name){
                Click(SearchType.LinkText, name);
            }

/*username: 	stephen.king
role: 	Base
Title: 	
Manager: 	Adam Thomas
Status: 	Permanent
Location: 	
Start Date: 	February 13, 2012
Time with Orasi: 	2 years, 4 months, 3 weeks, 2 days
Cell Phone: 	
Office Phone: 	
Email: 	stephen.king@orasi.com
IM Username: 	
IM Client: 	
Department
*/        

            //Compares our employee data to what's recorded in BlueSource.  Returns true if it matches, false otherwise
            public bool CompareEmployee(Dictionary<string, string> employee){
                //Sadly, these don't match up 100%.  I don't like this fact, or this code.  And yes, I blame Lew fully.
                if (Validate(SearchType.Xpath, "//table/tbody/tr[1]/td[2]") != employee["username"])
                    return false;
                if (Validate(SearchType.Xpath, "//table/tbody/tr[2]/td[2]") != employee["role"])
                    return false;
                if (Validate(SearchType.Xpath, "//table/tbody/tr[3]/td[2]") != employee["title_id"])
                    return false;
                if (Validate(SearchType.Xpath, "//table/tbody/tr[4]/td[2]") != employee["manager_id"])
                    return false;
                if (Validate(SearchType.Xpath, "//table/tbody/tr[5]/td[2]") != employee["status"])
                    return false;
                if (Validate(SearchType.Xpath, "//table/tbody/tr[6]/td[2]") != employee["location"])
                    return false;
                //if (FindByXPath("//table/tbody/tr[7]/td[2]") != employee["start_date"]) return false;  //different format, must update later
                //bridge time not used here?
                if (Validate(SearchType.Xpath, "//table/tbody/tr[9]/td[2]") != employee["cell_phone"])
                    return false;
                if (Validate(SearchType.Xpath, "//table/tbody/tr[10]/td[2]") != employee["office_phone"])
                    return false;
                if (Validate(SearchType.Xpath, "//table/tbody/tr[11]/td[2]") != employee["email"])
                    return false;
                if (Validate(SearchType.Xpath, "//table/tbody/tr[12]/td[2]") != employee["im_name"])
                    return false;
                if (Validate(SearchType.Xpath, "//table/tbody/tr[13]/td[2]") != employee["im_client"])
                    return false;
                if (Validate(SearchType.Xpath, "//table/tbody/tr[14]/td[2]") != employee["department_id"])
                    return false;

                //If we're still here then we have a 100% match.  Return true.
                return true;
            }
        #endregion
    }
}
