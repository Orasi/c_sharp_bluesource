﻿using System;
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
    class BlueSource_Employee : Bluesource
    {
        public BlueSource_Employee()
        {

        }

        // Open time off details for the selected employee.
        public void openTimeOffDetails()
        {
            try
            {
                // Select the "Time Off" view.
                OSI.Web.Link.ClickByText("View");
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Unspecified exception in BlueSource_EmployeeSearch.getTimeOffDetailTotalsForEmployee().");
                System.Console.WriteLine(e.ToString());
            }
        }

        // Open management details for the selected employee.
        public void openManagementDetails()
        {
            try
            {
                // Select the "Manage" view.
                OSI.Web.Link.ClickByText("Manage");
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Unspecified exception in BlueSource_EmployeeSearch.openManagementDetails().");
                System.Console.WriteLine(e.ToString());
            }
        }

        // Tells if you're on the correct page or not.
        public Boolean isOnEmployeePage()
        {
            Boolean onPage = false;

            try
            {
                // Using two identifiers to avoid false positives from other pages.  The IDs in the CSS don't seem unique and may be on other pages.
                onPage = OSI.Web.Sync.SyncByLinkText("username", 7);
                onPage = OSI.Web.Sync.SyncByLinkText("role", 7);
            }
            catch(Exception e)
            {
                System.Console.WriteLine("Unspecified exception in BlueSource_EmployeeSearch.isOnEmployeePage().");
                System.Console.WriteLine(e.ToString());
            }

            return onPage;
        }
    }
}
