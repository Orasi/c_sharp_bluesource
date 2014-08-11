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
		/*
			Is this necessary? Not very generic, and unsure why we have two strings that hold a web address, especially if we're giving them the ability to read/write both strings.
		*/
        public Bluesource()
        {
            this.websiteLoginURL = "http://bluesourcestaging.herokuapp.com/login";
            this.websiteURL = "http://bluesourcestaging.herokuapp.com/";
        }
		
		/*
			Would alternatively suggest an overloaded constructor(or two).  Furhter raises the question of two strings serving the same purpose, tho.
			Public Bluesource(String websiteURL){
				this.websiteURL = websiteURL;
				this.websiteLoginURL = "http://bluesourcestaging.herokuapp.com/login";
			}
			
			
			Public Bluesource(String websiteURL, String websiteLoginURL){
				this.websiteURL = websiteURL;
				this.websiteLoginURL = websiteLoginURL;
			}
		*/
        /***************************************************
         *  GETTERS/SETTERS
         ***************************************************/
        /*public String getWebsiteURL()
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
        }*/
		
		/*
			Since this is written in C# for people using C#, we (thankfully) get to use properties and not mutator methods.  Wo0t!
		*/
		#Region Properties
			public String WebsiteURL
			{
				get
				{
					return websiteURL;
				}
				set
				{
					websiteURL = value;
				}
			}
			
			public String WebsiteLoginURL
			{
				get
				{
					return websiteLoginURL;
				}
				set
				{
					websiteLoginURL = value;
				}
			}
		#Endregion

        /***************************************************
         *  FUNCTIONS
         ***************************************************/
		 
		 /*
			Ties in to previous statements.  Just unsure of the design here, as it's basically the same method, just using different hard-coded strings that can be set to the same value.
		 */
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
