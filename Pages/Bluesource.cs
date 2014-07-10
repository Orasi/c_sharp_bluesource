using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSource_Selenium_Project.Pages
{
    public class Bluesource : Page
    {
        /***************************************************
        *  VARIABLES 
        ***************************************************/
        protected String websiteURL;
        /***************************************************
         *  CONSTRUCTORS
         ***************************************************/
        public Bluesource()
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
    }
}
