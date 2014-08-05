c_sharp_bluesource
==================
Welcome to the Orasi C# Selenium Bluesource project!

This project is using a 3 tiered system for developing code/scripts:

  1) Toolkit (Foundation Level):
      This level acts as the base for all the other levels.  The purpose of this level is to provide a large and ever
      growing repository of classes/functions that can be used for more than one project.  It should prevent the 
      re-writing of code.
  
  2) Pages (Middle-man Level):
      The pages are meant to simplify the look and increase the readability of the Tests level.  It uses the Toolkit to
      quickly and efficiently create functions that are useful for the page you are testing on in a website.  There is a
      base page object that all of the pages pull their shared functionality from (ex: Login_Page inherits from Page).
      For more information on the pages, read the "C# Page Object Model For Dummies" link below.
  
  3) Tests (Uppermost Level):
      The test level is the top most level and benefits from the pages and the toolkit.  The tests shouldn't have any 
      "code" in it.  Reading through the tests should look like normal english and explain what the test is doing at
      each step with a glance (ex: LoginPage.Login (userName,Password) vs Web.getObject("userName_Field").SetText(userName) etc..).
      Tests should be easy to create because all of the fine details that you would normally have to code/script
      are located in each pages' page object.
      
      
HELPFUL INFORMATION:

Visual Studio Express Download ( http://www.visualstudio.com/en-us/products/visual-studio-express-vs.aspx )

Selenium Download ( http://docs.seleniumhq.org/download/)

Selenium Installation Instructions ( http://docs.seleniumhq.org/docs/appendix_installing_dotnet_driver_client.jsp )

C# Page Object Model For Dummies ( http://seleniumautomation84.wordpress.com/2014/03/06/page-object-model-tutorial-using-selenium-webdriver-in-c-visual-studio-and-vs-unittest-for-dummies/ )
