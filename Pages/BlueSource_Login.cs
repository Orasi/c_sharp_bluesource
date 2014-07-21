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
    public class BlueSource_Login : Bluesource
    {
        /***************************************************
        *  VARIABLES 
        ***************************************************/

        /***************************************************
         *  CONSTRUCTORS
         ***************************************************/
        public BlueSource_Login(IWebDriver Driver)
            : base(Driver)
        {

        }
        /***************************************************
         *  GETTERS/SETTERS
         ***************************************************/

        /***************************************************
         *  FUNCTIONS
         ***************************************************/
        
        // Login to Bluesource
        public void loginToBlueSource(String userName, String password)
        {
            String userNameEditFieldID = "";
            String passwordEditFieldID = "";

            try
            {
                // Grab the ID of the fields.
                userNameEditFieldID = "employee_username";
                passwordEditFieldID = "employee_password";

                // Set each field.
                OSI.Web.Edit.SetTextByID(userNameEditFieldID, userName);
                OSI.Web.Edit.SetTextByID(passwordEditFieldID, password);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error trying to login " + OSI.Utilities.ExceptionToDetailedString(e));
            }
        }
    }
}
