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
//using OpenQA.Selenium.Support.UI;

namespace BlueSource_Selenium_Project.Pages
{
    public class Page
    {
        /***************************************************
         *  VARIABLES 
         ***************************************************/
        
        /***************************************************
         *  CONSTRUCTORS
         ***************************************************/

        /***************************************************
         *  GETTERS/SETTERS
         ***************************************************/

        /***************************************************
         *  FUNCTIONS
         ***************************************************/
       

        // Open a browser and navigate to the given URL.
        public void openURL(String url, object driver, String browserName)
        {
            switch (browserName.ToUpper())
            {
                case "FIREFOX":
                    FirefoxDriver fireFoxDriver = (FirefoxDriver) driver;
                    fireFoxDriver.Navigate().GoToUrl(url);
                    //fireFoxDriver.Dispose();
                    break;
                case "CHROME":
                    ChromeDriver chromeDriver = (ChromeDriver) driver;
                    chromeDriver.Navigate().GoToUrl(url);
                    //chromeDriver.Dispose();
                    break;
                default: // Internet Explorer
                    InternetExplorerDriver internetExplorerDriver = (InternetExplorerDriver) driver;
                    internetExplorerDriver.Navigate().GoToUrl(url);
                   // internetExplorerDriver.Dispose();
                    break;
            }
            
        }

        // Navigate to the next page.
        public void navigateForwards(object driver, String browserName)
        {
            switch (browserName.ToUpper())
            {
                case "FIREFOX":
                    FirefoxDriver fireFoxDriver = (FirefoxDriver)driver;
                    fireFoxDriver.Navigate().Forward();
                    break;
                case "CHROME":
                    ChromeDriver chromeDriver = (ChromeDriver)driver;
                    chromeDriver.Navigate().Forward();
                    break;
                default: // Internet Explorer
                    InternetExplorerDriver internetExplorerDriver = (InternetExplorerDriver)driver;
                    internetExplorerDriver.Navigate().Forward();
                    break;
            }

        }

        // Navigate to the previous page.
        public void navigateBackwards(object driver, String browserName)
        {
            switch (browserName.ToUpper())
            {
                case "FIREFOX":
                    FirefoxDriver fireFoxDriver = (FirefoxDriver)driver;
                    fireFoxDriver.Navigate().Back();
                    break;
                case "CHROME":
                    ChromeDriver chromeDriver = (ChromeDriver)driver;
                    chromeDriver.Navigate().Back();
                    break;
                default: // Internet Explorer
                    InternetExplorerDriver internetExplorerDriver = (InternetExplorerDriver)driver;
                    internetExplorerDriver.Navigate().Back();
                    break;
            }

        }
       

    }
}
