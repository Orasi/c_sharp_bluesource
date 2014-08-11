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
        private String websiteLoginURL;

        /***************************************************
         *  CONSTRUCTORS
         ***************************************************/
        public Bluesource()
        {
            this.websiteLoginURL = "http://bluesourcestaging.herokuapp.com/login";
            this.websiteURL = "http://bluesourcestaging.herokuapp.com/";
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

        public String getWebsiteLoginURL()
        {
            return this.websiteLoginURL;
        }

        public void setWebsiteLoginURL(String websiteLoginURL)
        {
            this.websiteLoginURL = websiteLoginURL;
        }

        /***************************************************
         *  FUNCTIONS
         ***************************************************/
        public void navigateToLoginPage()
        {
            this.openURL(this.getWebsiteLoginURL());
        }

        public void navigateToWebsite()
        {
            this.openURL(this.getWebsiteURL());
        }

        //should this be a bool?
        public void Logout()
        {
            //webDriver.FindElement(By.LinkText("Sign Out")).Click();
            OSI.Web.Link.ClickByText("Sign Out");
        }
    }
}
