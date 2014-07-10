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
    class Page
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
        protected void openURL(String url, object driver, String browserName)
        {
            switch (browserName.ToUpper())
            {
                case "FIREFOX":
                    FirefoxDriver fireFoxDriver = (FirefoxDriver) driver;
                    fireFoxDriver.Navigate().GoToUrl(url);
                    break;
                case "CHROME":
                    ChromeDriver chromeDriver = (ChromeDriver) driver;
                    chromeDriver.Navigate().GoToUrl(url);
                    break;
                default: // Internet Explorer
                    InternetExplorerDriver internetExplorerDriver = (InternetExplorerDriver) driver;
                    internetExplorerDriver.Navigate().GoToUrl(url);
                    break;
            }
            
        }

    }
}
