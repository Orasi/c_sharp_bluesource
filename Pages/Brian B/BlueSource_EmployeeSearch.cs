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
        public void addEmployee(string userName, string firstName, string lastName, string email)
        {
            try
            {
                String addButtonName = "";
                String createEmployeeName = "";

                // Find class name.
                addButtonName = "button";

                // Click add to bring up "Add Employee" form.
                OSI.Web.Button.ClickByName(addButtonName);

                // Fill out the form.
                string[,] elementIDsAndInputsForEmployee = new string[,]
                {
                   {"employee_username" , userName},
                   {"employee_first_name" , firstName},
                   {"employee_last_name" , lastName},
                   {"employee_role" , "Base"},
                   {"employee_manager_id" , "Adam Thomas"},
                   {"employee_location" , "Greensboro"},
                   {"employee_email" , email},
                   {"employee_department_id" , "Support"}
                };

                OSI.Forms.fillFormByID(elementIDsAndInputsForEmployee);

                // Add the new employee.
                createEmployeeName = "commit";
                OSI.Web.Button.ClickByName(createEmployeeName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error trying to add employee. " + OSI.Utilities.ExceptionToDetailedString(e));
            }

        }

        public void LogOut()
        {
            OSI.Web.Link.ClickByText("Logout");
        }
    }
}
