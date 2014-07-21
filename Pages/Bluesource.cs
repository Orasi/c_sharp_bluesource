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
    public class Bluesource : Page
    {
        /***************************************************
        *  VARIABLES 
        ***************************************************/
        private String websiteURL;
        /***************************************************
         *  CONSTRUCTORS
         ***************************************************/
        public Bluesource(IWebDriver Driver) : base(Driver)
        {
            this.websiteURL = "http://bluesourcestaging.herokuapp.com/login";
        }
        /***************************************************
         *  GETTERS/SETTERS
         ***************************************************/
        public String getWebsiteURL()
        {
            return this.websiteURL;
        }

        public void setWebsiteURL(String websiteURL)
        {
            this.websiteURL = websiteURL;
        }

        /***************************************************
         *  FUNCTIONS
         ***************************************************/
        public void navigateToLoginPage()
        {
            this.openURL(this.getWebsiteURL());
        }
    }
}
