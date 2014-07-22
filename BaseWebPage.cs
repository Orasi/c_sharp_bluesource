using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//use Selenium namespaces after adding references
using OpenQA.Selenium;

//use for ReadOnlyCollection
using OpenQA.Selenium.Remote;

//Namespace for Select/dropdown objects
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject
{
    //A list of the currently available search types. Helps for if/switch statements and data validation
    public enum SearchType{ Id, LinkText, Name, Xpath };
   
    public abstract class BaseWebPage
    {
        #region Members
            //Our WebDriver object
            private IWebDriver webDriver;
        #endregion

        #region Properties
            //Read-only access to our WebDriver object.
            public IWebDriver WebDriver{
                get {
                    return webDriver;
                }
            }
        #endregion

        #region Constructor
            //Requires an object of interface type WebDriver
            //TODO - add handling for null drivers, possibly a default constructor
            public BaseWebPage(IWebDriver webDriver) {
                this.webDriver = webDriver;    
            }
        #endregion

        #region Methods
            //Attempts to click the element on the page, with specific and default exception handling
            public void Click(SearchType type, string text){
                try{
                    if (type == SearchType.Id){
                        WebDriver.FindElement(By.Id(text)).Click();
                    }
                    else if (type == SearchType.LinkText){
                        WebDriver.FindElement(By.LinkText(text)).Click();
                    }
                    else if (type == SearchType.Name){
                        WebDriver.FindElement(By.Name(text)).Click();
                    }
                    else if (type == SearchType.Xpath){
                        WebDriver.FindElement(By.XPath(text)).Click();
                    }
                    else{
                        System.Console.WriteLine(type.ToString() + " is an unsupported SearchType for this method.");
                    }
                }
                catch (NoSuchElementException ex){
                    System.Console.WriteLine("Error, could not find webElement of type " + type.ToString() + " with id {0}", text);
                    System.Console.WriteLine(ex.ToString());
                    return;
                }
                catch (Exception ex){
                    System.Console.WriteLine("Unspecified exception in Click().");
                    System.Console.WriteLine(ex.ToString());
                    return;
                }
            }

            //Attempts to enter the given text string in a specific element on the page, with specific and default exception handling
            public void TextEntry(SearchType type, string searchText, string input)
            {
                try{
                    IWebElement textField;
                    if (type == SearchType.Id){
                        textField = WebDriver.FindElement(By.Id(searchText));
                    }
                    else if (type == SearchType.LinkText){
                        textField = WebDriver.FindElement(By.LinkText(searchText));
                    }
                    else if (type == SearchType.Name){
                        textField = WebDriver.FindElement(By.Name(searchText));
                    }
                    else if (type == SearchType.Xpath){
                        textField = WebDriver.FindElement(By.XPath(searchText));
                    }
                    else{
                        textField = null;
                        System.Console.WriteLine(type.ToString() + " is an unsupported SearchType for this method.");
                    }
                    textField.Clear();
                    textField.SendKeys(input);
                    System.Console.WriteLine("Text '{0}' entered successfully in '{1}'", input, searchText);
                }
                catch (NoSuchElementException ex){
                    System.Console.WriteLine("Could not successfully enter text '{0}' in '{1}'", input, searchText);
                    System.Console.WriteLine(ex.ToString());
                    return;
                }
                catch (Exception ex){
                    System.Console.WriteLine("Unspecified exception in TextEntry().");
                    System.Console.WriteLine(ex.ToString());
                    return;
                }
            }

            //Attempts to select the text from a dropdown element on the page, with specific and default exception handling
            public void Selection(string name, string text){
                try {
                    SelectElement select = new SelectElement(WebDriver.FindElement(By.Name(name)));
                    select.SelectByText(text);
                }
                catch (NoSuchElementException ex){
                    System.Console.WriteLine("Could not successfully select text '{0}' from '{1}'", text, name);
                    System.Console.WriteLine(ex.ToString());
                    return;
                }
                catch (Exception ex){
                    System.Console.WriteLine("Unspecified exception in Selection().");
                    System.Console.WriteLine(ex.ToString());
                    return;
                }
            }

            //Just  object exists
            //Attempts to verify that an element exists on the page, with specific and default exception handling
            //Returns the string if found, "" if not found
            public string Validate(SearchType type, string text){
                try{
                    string textString;
                    if (type == SearchType.Id){
                        textString = WebDriver.FindElement(By.Id(text)).Text;
                    }
                    else if (type == SearchType.LinkText){
                        textString = WebDriver.FindElement(By.LinkText(text)).Text;
                    }
                    else if (type == SearchType.Name){
                        textString = WebDriver.FindElement(By.Name(text)).Text;
                    }
                    else if (type == SearchType.Xpath){
                        textString = WebDriver.FindElement(By.XPath(text)).Text;
                    }
                    else{
                        System.Console.WriteLine(type.ToString() + " is an unsupported SearchType for this method.");
                        return "";
                    }
                    System.Console.WriteLine("{0} '{1}' found", type.ToString(), text);
                    return textString;
                }
                catch (NoSuchElementException ex) {
                    System.Console.WriteLine("Could not successfully find {0} '{1}'", type.ToString(), text);
                    System.Console.WriteLine(ex.ToString());
                    return "";
                }
                catch (Exception ex){
                    System.Console.WriteLine("Unspecified exception in Validate().");
                    System.Console.WriteLine(ex.ToString());
                    return "";
                }
            }
        #endregion
    }
}
