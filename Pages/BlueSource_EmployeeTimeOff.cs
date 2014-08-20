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
    class BlueSource_EmployeeTimeOff : Bluesource
    {
        public BlueSource_EmployeeTimeOff()
        {

        }

        // Gets the time off detail of an employee after selecting them.
        public String[] getTimeOffDetailTotalsForEmployee()
        {
            String sickDaysLeft = "";
            String vacationDaysLeft = "";
            String floatingHolidaysLeft = "";

            String[] daysLeft = new String[3];

            try
            {
                // Wait for the page to load.
                OSI.Web.Sync.SyncByID("fy", 5);

                sickDaysLeft = OSI.Web.Edit.GetTextByXPath("//*[@id='content']/DIV[1]/SPAN[2]");
                vacationDaysLeft = OSI.Web.Edit.GetTextByXPath("//*[@id='content']/DIV[1]/SPAN[3]");
                floatingHolidaysLeft = OSI.Web.Edit.GetTextByXPath("//*[@id='content']/DIV[1]/SPAN[4]");


            }
            catch (Exception e)
            {
                System.Console.WriteLine("Unspecified exception in BlueSource_EmployeeSearch.getTimeOffDetailTotalsForEmployee().");
                System.Console.WriteLine(e.ToString());
            }

            daysLeft[1] = sickDaysLeft;
            daysLeft[2] = vacationDaysLeft;
            daysLeft[3] = floatingHolidaysLeft;

            return daysLeft;
        }
    }
}
