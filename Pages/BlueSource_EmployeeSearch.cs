using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using CSharp_Blusource_Selenium.Toolkit;

namespace CSharp_Blusource_Selenium.Pages
{
    class BlueSource_EmployeeSearch : Bluesource
    {
        /***************************************************
        *  VARIABLES 
        ***************************************************/

        /***************************************************
         *  CONSTRUCTORS
         ***************************************************/
        public BlueSource_EmployeeSearch()
        {

        }
        /***************************************************
         *  GETTERS/SETTERS
         ***************************************************/

        /***************************************************
         *  FUNCTIONS
         ***************************************************/
        // Add employee to BlueSource
        public void addEmployee(string userName, string firstName, string lastName, string email)
        {
            try
            {
                String addButtonName = "";
                String createEmployeeCSSPath = "";

                // Find class name.
                addButtonName = "button";
                createEmployeeCSSPath = @"#new_employee > DIV.form-group.modal-footer > INPUT.btn.btn-primary";

                // Wait for page to load completely.
                OSI.Utilities.Wait(1);
                
                // Click add to bring up "Add Employee" form.
                OSI.Web.Button.ClickByName(addButtonName);

                // Fill out the form.
                OSI.Web.Sync.SyncByID("employee_username", 10);
                string[,] elementIDsAndInputsForEmployee = new string[,]
                {
                   {"employee_username" , userName},
                   {"employee_first_name" , firstName},
                   {"employee_last_name" , lastName},
                   {"employee_role" , "Base"},
                   {"employee_manager_id" , "Adam Thomas"},
                   {"employee_status" , "Permanent"},
                   {"employee_location" , "Greensboro"},
                   {"employee_cell_phone" , "3365585545"},
                   {"employee_office_phone" , "3364686645"},
                   {"employee_email" , email},
                   {"employee_department_id" , "Support"}
                };

                OSI.Forms.fillFormByID(elementIDsAndInputsForEmployee);

                // Add the new employee.
                OSI.Web.Button.ClickByCSSPath(createEmployeeCSSPath);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Unspecified exception in BlueSource_EmployeeSearch.addEmployee().");
                System.Console.WriteLine(e.ToString());
                //Console.WriteLine("Error trying to add employee. " + OSI.Utilities.ExceptionToDetailedString(e));
            }

        }

        // Search for Employee on BlueSource
        public String searchForEmployee(String userName)
        {
            String foundGuy = "";
            try
            {
                OSI.Web.Sync.SyncByCSSPath("#resource-content > DIV:nth-child(2) > P.pull-right.ng-binding", 10);
                OSI.Web.Edit.SetTextToMultiByID("search-bar", userName);
                foundGuy = OSI.Web.Table.FindRecordWithRowColByCSSPath("#resource-content > DIV.table-responsive > TABLE.table.table-bordered.table-condensed.table-hover", 2, 1);

                
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Unspecified exception in BlueSource_EmployeeSearch.searchForEmployee().");
                System.Console.WriteLine(e.ToString());
               // Console.WriteLine("Error trying to search for employee. " + OSI.Utilities.ExceptionToDetailedString(e));
            }
            return foundGuy;
        }

        // Log out
        public void LogOut()
        {
            OSI.Web.Link.ClickByText("Logout");
        }

        // Click on the first name shown in the employee search table
        public void clickOnFirstEmployeeInSearch()
        {
            try
            {
                String firstRowText = "";

                firstRowText = OSI.Web.Table.FindRecordWithRowColByCSSPath("#resource-content > DIV.table-responsive > TABLE.table.table-bordered.table-condensed.table-hover", 2, 1);
                OSI.Web.Link.ClickByText(firstRowText);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Unspecified exception in BlueSource_EmployeeSearch.clickOnFirstEmployeeInSearch().");
                System.Console.WriteLine(e.ToString());
            }
        }

       
    }
}
