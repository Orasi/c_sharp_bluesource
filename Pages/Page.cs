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

        /***************************************************
         *  CONSTRUCTORS
         ***************************************************/
        public Page()
        {
          
        }
        /***************************************************
         *  GETTERS/SETTERS
         ***************************************************/

        /***************************************************
         *  FUNCTIONS
         ***************************************************/

		 /*Brian - suggestion that's up for discussion.  All of these methods are calling a method that is the same or amazingly similarly-named from the Web object, so
					I would suggest we use a property for read-only access to that object, and therefore those methods.  If the code isn't adding reporting or output,
					then there might not be a reason to have these.  Also allows access to the Web object's other methods(If any. Need to check Web object class file)
					
					Example:
					public <WebType>  Web
					{
						get 
						{
							return OSI.Web;
						}
					}
		 */
        // Scroll the browser up or down.
        public void scrollUpwards()
        {
            OSI.Web.scrollUpwards();
        }

        public void scrollDownwards()
        {
            OSI.Web.scrollDownwards();
        }

        // Open a browser and navigate to the given URL.
        public void openURL(String url)
        {
           OSI.Web.NavigateToURL(url);
        }

        // Navigate to the next page.
        public void navigateForwards()
        {
            OSI.Web.NavigateForward();
        }

        // Navigate to the previous page.
        public void navigateBackwards()
        {
           OSI.Web.NavigateBackward();
        }

		
		
		/*
			These are similar to the above, only we would provide access to the OSI.Utilities object(if needed).  Just depends on what we think the coders would need.
		*/
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

        // Close the browser.
        public void closeBrowser()
        {
            OSI.Web.CloseBrowser();
            OSI.Web.WebDriver.Quit();
        }
    }
}
