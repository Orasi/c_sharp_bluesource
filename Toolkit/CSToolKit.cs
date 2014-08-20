
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Blusource_Selenium.Toolkit
{
    class OSI
    {
        /***************************************************
         * UTILITIES...Changes and junk.
         ***************************************************/
        public class Utilities
        {
            // Waits for the specified amount of seconds.
            public static void Wait(int WaitTimeInSeconds)
            {
                try
                {
                    var MilSec = WaitTimeInSeconds * 1000;
                    System.Threading.Thread.Sleep(MilSec);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Unspecified exception in OSI.Utilities.Wait().");
                    System.Console.WriteLine(ex.ToString());
                    return;
                }

            }

            // Waits for the specified amount of seconds and milliseconds.
            public static void Wait(int WaitTimeInSeconds, int WaitTimeInMilliSeconds)
            {
                try
                {
                    var MilSec = WaitTimeInSeconds * 1000;
                    var TotMilSec = MilSec + WaitTimeInMilliSeconds;
                    System.Threading.Thread.Sleep(MilSec);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Unspecified exception in OSI.Utilities.Wait().");
                    System.Console.WriteLine(ex.ToString());
                    return;
                }
            }

            // Provides a random number between the minimum and maximum values put in.
            private static readonly Random getrandom = new Random();
            private static readonly object syncLock = new object();
            public static int RandomNumber(int min, int max)
            {
                lock (syncLock)
                {
                    return getrandom.Next(min, max);
                }
            }

            // Converts general exception into a detailed string for output. (Needs work/more detail)
            public static String ExceptionToDetailedString(Exception e)
            {
                String errorString = "Error: " + e.Message;
                return errorString;
            }
        }

        /***************************************************
         *  FORMS
         ***************************************************/
        public class Forms
        {
            // Displays a message box with the string that is input.
            public static void MsgBox(string StringToDisplay)
            {
                try
                {
                    MessageBox.Show(StringToDisplay);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Unspecified exception in OSI.Forms.MsgBox().");
                    System.Console.WriteLine(ex.ToString());
                    return;
                }
            }

            // Uses a 2 dimensional list of element IDs and the input for each element to fill out a form.
            public static void fillFormByID(string[,] elementIDsAndInputs)
            {
                string elementID = "";
                string elementInput = "";


                try
                {
                    for (int row = 0; row < elementIDsAndInputs.GetLength(0); row++)
                    {
                        elementID = elementIDsAndInputs[row, 0] + "";
                        elementInput = elementIDsAndInputs[row, 1] + "";

                        OSI.Web.Edit.SetTextByID(elementID, elementInput);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Unspecified exception in OSI.Forms.fillFormByID().");
                    System.Console.WriteLine(ex.ToString());
                    return;
                }
            }

        }

        /***************************************************
         *  EXCEL
         ***************************************************/
        public class Excel
        {
        }

        /***************************************************
         *  WEB
         ***************************************************/
        public class Web
        {
            // Initialize these variables at test level before running tests.
            public static IWebDriver WebDriver;
            public static IJavaScriptExecutor jse/* = (IJavaScriptExecutor)WebDriver*/;

            // Scroll the browser up.
            public static void scrollUpwards()
            {
                try
                {
                    jse.ExecuteScript("window.scrollTo(0,-500)", "");
                    //jse.ExecuteScript("scroll(0, -500);");
                    //jse.ExecuteScript("scrollBy(0,-500);");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Unspecified exception in OSI.Web.scrollUpwards().");
                    System.Console.WriteLine(ex.ToString());
                    return;
                }
            }

            // Scroll the browser down.
            public static void scrollDownwards()
            {
                try
                {
                    jse.ExecuteScript("window.scrollTo(0,500)", "");
                    //jse.ExecuteScript("scroll(0, 500);");
                    //jse.ExecuteScript("scrollBy(0,500);");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Unspecified exception in OSI.Web.scrollDownwards().");
                    System.Console.WriteLine(ex.ToString());
                    return;
                }
            }

            // Navigates the browser to the specified URL.
            public static void NavigateToURL(string URL)
            {
                try
                {
                    WebDriver.Navigate().GoToUrl(URL);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Unspecified exception in OSI.Web.NavigateToURL().");
                    System.Console.WriteLine(ex.ToString());
                    return;
                }
            }

            // Navigates to the next page in the browsers/tabs current history.
            public static void NavigateForward()
            {
                try
                {
                    WebDriver.Navigate().Forward();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Unspecified exception in OSI.Web.NavigateForward().");
                    System.Console.WriteLine(ex.ToString());
                    return;
                }
            }

            // Navigates to the previous page in the browsers/tabs current history.
            public static void NavigateBackward()
            {
                try
                {
                    WebDriver.Navigate().Back();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Unspecified exception in OSI.Web.NavigateBackward().");
                    System.Console.WriteLine(ex.ToString());
                    return;
                }
            }

            // Closes the browser.
            public static void CloseBrowser()
            {
                WebDriver.Close();
            }

            public class Sync
            {
                // Looks for an Element by it's ID and waits for it to appear in the browser for the amount of time specified.
                public static bool SyncByID(string ObjectID, short TimeoutInSeconds)
                {
                    OSI.Utilities.Wait(0, 500);
                    var x = "";
                    var t = 0;
                    Console.WriteLine("Syncing on object by ID: " + ObjectID);
                    bool timeoutreached = true;
                    while (t < TimeoutInSeconds)
                    {
                        try
                        {
                            Console.Write(".");
                            IWebElement we = WebDriver.FindElement(By.Id(ObjectID));
                            x = we.Location.X.ToString();
                        }
                        catch (Exception e)
                        {
                            //Console.Write(e.ToString());
                        }
                        if (x != "")
                        {
                            Console.Write("Element Found!");
                            timeoutreached = false;
                            break;
                        }
                        System.Threading.Thread.Sleep(1000);
                        t++;
                        //assertTrue(dialog.isDisplayed())
                    }
                    OSI.Utilities.Wait(0, 500);
                    if (timeoutreached)
                    {
                        Console.WriteLine("Timeout of " + t + " Seconds Reached!");
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }

                // Looks for an Element by it's CSSPath and waits for it to appear in the browser for the amount of time specified.
                public static bool SyncByCSSPath(string CSSPath, short TimeoutInSeconds)
                {
                    OSI.Utilities.Wait(0, 500);
                    var x = "";
                    var t = 0;
                    Console.WriteLine("Syncing on object by ID: " + CSSPath);
                    bool timeoutreached = true;
                    while (t < TimeoutInSeconds)
                    {
                        try
                        {
                            Console.Write(".");
                            IWebElement we = WebDriver.FindElement(By.CssSelector(CSSPath));
                            x = we.Location.X.ToString();
                        }
                        catch (Exception e)
                        {
                            //Console.Write(e.ToString());
                        }
                        if (x != "")
                        {
                            if (int.Parse(x) > 0)
                            {
                                Console.Write("Element Found!");
                                timeoutreached = false;
                                break;
                            }

                        }
                        System.Threading.Thread.Sleep(1000);
                        t++;
                        //assertTrue(dialog.isDisplayed())
                    }
                    OSI.Utilities.Wait(0, 500);

                    if (timeoutreached)
                    {
                        Console.WriteLine("Timeout of " + t + " Seconds Reached!");
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }


            }

            public class Edit
            {
                // Sets an Edit object's text by it's ID.
                public static void SetTextByID(string ObjectID, string TextToSet)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.Id(ObjectID));
                        we.SendKeys(TextToSet);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Edit.SetTextByID().");
                        System.Console.WriteLine(ex.ToString());
                        return;
                    }
                }

                public static void SetTextToMultiByID(string ObjectID, string TextToSet)
                {
                    try
                    {
                        ReadOnlyCollection<IWebElement> cwe = WebDriver.FindElements(By.Id(ObjectID));
                        foreach (IWebElement we in cwe)
                        {
                            we.SendKeys(TextToSet);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Edit.SetTextToMultiByID().");
                        System.Console.WriteLine(ex.ToString());
                        return;
                    }
                }

                // Sets an Edit object's text by it's CSS path.
                public static void SetTextByCSSPath(string CSSPath, string TextToSet)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.CssSelector(CSSPath));
                        we.SendKeys(TextToSet);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Edit.SetTextTByCSSPath().");
                        System.Console.WriteLine(ex.ToString());
                        return;
                    }
                }

                // Sets an Edit object's text by it's Xpath.
                public static void SetTextByXPath(string XPath, string TextToSet)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.XPath(XPath));
                        we.SendKeys(TextToSet);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Edit.SetTextByXPath().");
                        System.Console.WriteLine(ex.ToString());
                        return;
                    }
                }

                // Get an Edit object's text by it's ID.
                public static string GetTextByID(string ObjectID)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.Id(ObjectID));
                        return we.GetAttribute("value");
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Edit.GetTextByID().");
                        System.Console.WriteLine(ex.ToString());
                        return "Value not Found";
                    }
                }

                // Get an Edit object's text by it's XPath.
                public static string GetTextByXPath(string ObjectXPath)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.XPath(ObjectXPath));
                        return we.GetAttribute("value");
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Edit.GetTextByXPath().");
                        System.Console.WriteLine(ex.ToString());
                        return "Value not Found";
                    }
                }
            }

            public class Button
            {
                // Click button by XPath.
                public static void ClickByXPath(string XPath)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.Name(XPath));
                        we.Click();
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Button.ClickByXPath().");
                        System.Console.WriteLine(ex.ToString());
                        return;
                    }
                }

                // Click button by Name.
                public static void ClickByName(string Name)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.Name(Name));
                        we.Click();
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Button.ClickByName().");
                        System.Console.WriteLine(ex.ToString());
                        return;
                    }
                }

                // Click button by ID.
                public static void ClickByID(string ObjectID)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.Id(ObjectID));
                        we.Click();
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Button.ClickByID().");
                        System.Console.WriteLine(ex.ToString());
                        return;
                    }
                }

                // Click button by CSS path.
                public static void ClickByCSSPath(string CSSPath)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.CssSelector(CSSPath));
                        we.Click();
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Button.ClickByCSSPath().");
                        System.Console.WriteLine(ex.ToString());
                        return;
                    }
                }

                // Click button by link text.
                public static void ClickByLinkText(string linkText)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.LinkText(linkText));
                        we.Click();
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Button.ClickByLinkText().");
                        System.Console.WriteLine(ex.ToString());
                        return;
                    }
                }

                // Click button by tag name.
                public static void ClickByTagName(string tagName)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.TagName(tagName));
                        we.Click();
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Button.ClickByTagName().");
                        System.Console.WriteLine(ex.ToString());
                        return;
                    }
                }

                // Click button by class name.
                public static void ClickByClassName(string className)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.ClassName(className));
                        we.Click();
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Button.ClickByClassName().");
                        System.Console.WriteLine(ex.ToString());
                        return;
                    }
                }
            }

            public class Link
            {
                // Click a link by XPath.
                public static void ClickByXPath(string XPath)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.Name(XPath));
                        we.Click();
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Link.ClickByXPath().");
                        System.Console.WriteLine(ex.ToString());

                        return;
                    }
                }

                // Click a link by text.
                public static void ClickByText(string Text)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.LinkText(Text));
                        we.Click();
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Link.ClickByText().");
                        System.Console.WriteLine(ex.ToString());

                        return;
                    }
                }

                // Click a link by ID.
                public static void ClickByID(string ObjectID)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.Id(ObjectID));
                        we.Click();
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Link.ClickByID().");
                        System.Console.WriteLine(ex.ToString());

                        return;
                    }
                }

                public static void ClickIfExistByXPath(string XPath)
                {
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.Name(XPath));
                        we.Click();
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Link.ClickIfExistsByXPath().");
                        System.Console.WriteLine(ex.ToString());

                        return;
                    }
                }

                public static void ClickIfExistByName(string Name)
                {
                    
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.Name(Name));
                        we.Click();
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Link.ClickIfExistsByName().");
                        System.Console.WriteLine(ex.ToString());

                        return;
                    }
                }

                public static void ClickIfExistByID(string ObjectID)
                { 
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.Id(ObjectID));
                        we.Click();
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Link.ClickIfExistsByID().");
                        System.Console.WriteLine(ex.ToString());

                        return;
                    }
                }


            }

            public class Table
            {
                // Finds and returns information in a table cell using the CSS path.
                public static string FindRecordWithRowColByCSSPath(string CSSPath, int row, int col)
                {
                    try
                    {
                        IWebElement table = WebDriver.FindElement(By.CssSelector(CSSPath));
                        ReadOnlyCollection<IWebElement> allRows = table.FindElements(By.TagName("tr"));

                        IWebElement CurRow = allRows[row - 1];
                        ReadOnlyCollection<IWebElement> CurCells = CurRow.FindElements(By.TagName("td"));
                        IWebElement CurCell = CurCells[col - 1];
                        return CurCell.Text;
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Table.FindRecordWithRowColByCSSPath().");
                        System.Console.WriteLine(ex.ToString());

                        return "";
                    }
                }
            }

            public class Element
            {
                // Returns whether or not an element exists using its CSS path.
                public static bool ExistsByCSSPath(string CSSPath)
                {
                    bool Exists = false;
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.CssSelector(CSSPath));
                        Exists = we.Displayed;
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unspecified exception in OSI.Web.Element.ExistsByCSSPath().");
                        System.Console.WriteLine(ex.ToString());

                        return Exists;
                    }

                    return Exists;


                }
            }

        }
    }

}





