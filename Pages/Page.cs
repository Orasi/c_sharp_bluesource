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
    public class Page
    {
        /***************************************************
         *  VARIABLES 
         ***************************************************/
        public IWebDriver Driver;

        /***************************************************
         *  CONSTRUCTORS
         ***************************************************/
        public Page(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
        /***************************************************
         *  GETTERS/SETTERS
         ***************************************************/
        public IWebDriver getDriver(){
            return this.Driver;
        }

        public void setDriver(IWebDriver Driver){
            this.Driver = Driver;
        }
        /***************************************************
         *  FUNCTIONS
         ***************************************************/

        // Open a browser and navigate to the given URL.
        public void openURL(String url)
        {
           // this.Driver.Navigate().GoToUrl(url);
            OSI.Web.NavigateToURL(url);
        }

        // Navigate to the next page.
        public void navigateForwards()
        {
            this.Driver.Navigate().Forward();
        }

        // Navigate to the previous page.
        public void navigateBackwards()
        {
            this.Driver.Navigate().Back();
        }

        // Wait specified amount of time.
        public void wait(int WaitTimeInSeconds)
        {
            OSI.Utilities.Wait(WaitTimeInSeconds);
        }

        public void wait(int WaitTimeInSeconds, int WaitTimeInMilliseconds){
            OSI.Utilities.Wait(WaitTimeInSeconds, WaitTimeInMilliseconds);
        }

        // Get random number.
        public int getRandomNumber(int minimumNumber, int maxNumber)
        {
            return OSI.Utilities.RandomNumber(minimumNumber, maxNumber);
        }


    }
}
