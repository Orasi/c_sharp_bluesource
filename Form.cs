using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//use Selenium namespaces after adding references
using OpenQA.Selenium;

namespace SeleniumProject
{
    public class Form : BaseWebPage
    {

        #region Constructors
            //default test case
            public Form(IWebDriver webDriver): base(webDriver) {
                if (WebDriver.Title == "Google")
                {
                    System.Console.WriteLine("Successfully visited form page");
                }
                else {
                    System.Console.WriteLine("Error, title is {0}, expecting Google", WebDriver.Title);
                    throw new InvalidOperationException(String.Format("Error, title is {0}, expecting Google", WebDriver.Title));
                }
            }

            public Form(IWebDriver webDriver, string title) : base(webDriver)
            {
                if (WebDriver.Title == title)
                {
                    System.Console.WriteLine("Successfully visited form page");
                }
                else
                {
                    System.Console.WriteLine("Error, title is {0}, expecting {1}", WebDriver.Title, title);
                    throw new InvalidOperationException(String.Format("Error, title is {0}, expecting {1}", WebDriver.Title, title));
                }
            }
        #endregion

            #region Methods
                //Attempts to add an employee using our Employee dictionary object
                public void AddEmployee(Dictionary<string, string> employee){
                    //click Add - html is <button class="btn btn-default" data-target="#modal_1" data-toggle="modal" name="button" type="submit">Add</button>
                    Click(SearchType.Name, "button");
            
                    //Input our test values in text boxes, calling TextEntry, which is inherited from BaseWebPage
                    TextEntry(SearchType.Name, "employee[username]", employee["username"]);
                    TextEntry(SearchType.Name, "employee[first_name]", employee["first_name"]);
                    TextEntry(SearchType.Name, "employee[last_name]", employee["last_name"]);
                    TextEntry(SearchType.Name, "employee[bridge_time]", employee["bridge_time"]);
                    TextEntry(SearchType.Name, "employee[start_date]", employee["start_date"]);
                    TextEntry(SearchType.Name, "employee[cell_phone]", employee["cell_phone"]);
                    TextEntry(SearchType.Name, "employee[office_phone]", employee["office_phone"]);
                    TextEntry(SearchType.Name, "employee[email]", employee["email"]);
                    TextEntry(SearchType.Name, "employee[im_name]", employee["im_name"]);

                    //Input our test data in dropdown menus, calling Selection, which is inherited from BaseWebPage
                    Selection("employee[title_id]", employee["title_id"]);
                    Selection("employee[role]", employee["role"]);
                    Selection("employee[manager_id]", employee["manager_id"]);
                    Selection("employee[status]", employee["status"]);
                    Selection("employee[location]", employee["location"]);
                    Selection("employee[im_client]", employee["im_client"]);
                    Selection("employee[department_id][]", employee["department_id"]);

                    //Click the commit button to finish adding the employee
                    Click(SearchType.Name, "commit");
                }
            #endregion

    }
}
