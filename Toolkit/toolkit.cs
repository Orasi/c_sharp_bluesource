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
      /* 
       public static IWebDriver WebDriver;
       public OSI(IWebDriver Driver)
       {
           WebDriver = Driver;
       }
       */
        public class Utilities
        {


            public static void Wait(int WaitTimeInSeconds)
            {
                var MilSec = WaitTimeInSeconds * 1000;
                System.Threading.Thread.Sleep(MilSec);
            }

            public static void Wait(int WaitTimeInSeconds, int WaitTimeInMilliSeconds)
            {
                var MilSec = WaitTimeInSeconds * 1000;
                var TotMilSec = MilSec + WaitTimeInMilliSeconds;
                System.Threading.Thread.Sleep(MilSec);
            }

            private static readonly Random getrandom = new Random();
            private static readonly object syncLock = new object();
            public static int RandomNumber(int min, int max)
            {
                lock (syncLock)
                {
                    return getrandom.Next(min, max);
                }
            }

            public static String ExceptionToDetailedString(Exception e)
            {
                String errorString = "Error: " + e.Message;
                return errorString;
            }
        }

        public class Forms
        {
            public static void MsgBox(string StringToDisplay)
            {
                MessageBox.Show(StringToDisplay);
            }

         }

        public class Excel
        {
        }

        public class Web
        {
            public static IWebDriver WebDriver;

            public static void NavigateToURL(string URL)
            {
                WebDriver.Navigate().GoToUrl(URL);
            }

            public static void NavigateToURL(string URL, IWebDriver driver)
            {
               driver.Navigate().GoToUrl(URL);
            }
            
            public static void CloseBrowser()
            {
                WebDriver.Close();
            }

            public class Sync
            {
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
                            if (int.Parse(x)>0)
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
                public static void SetTextByID(string ObjectID, string TextToSet)
                {
                    IWebElement we = WebDriver.FindElement(By.Id(ObjectID));
                    we.SendKeys(TextToSet);
                }

                public static void SetTextByID(string ObjectID, string TextToSet, IWebDriver driver)
                {
                    IWebElement we = driver.FindElement(By.Id(ObjectID));
                    we.SendKeys(TextToSet);
                }

                public static void SetTextToMultiByID(string ObjectID, string TextToSet)
                {
                    ReadOnlyCollection<IWebElement> cwe = WebDriver.FindElements(By.Id(ObjectID));
                    foreach (IWebElement we in cwe)
                    {
                       we.SendKeys(TextToSet); 
                    }
                }

                public static void SetTextByCSSPath(string CSSPath, string TextToSet)
                {
                    IWebElement we = WebDriver.FindElement(By.CssSelector(CSSPath));
                    we.SendKeys(TextToSet);
                }

                public static void SetTextByXPath(string XPath, string TextToSet)
                {
                    IWebElement we = WebDriver.FindElement(By.XPath(XPath));
                    we.SendKeys(TextToSet);
                }

                public static string GetTextByID(string ObjectID)
                {
                    IWebElement we = WebDriver.FindElement(By.Id(ObjectID));
                    return we.GetAttribute("value");
                }
            }

            public class Button
            {
                public static void ClickByXPath(string XPath)
                {
                    IWebElement we = WebDriver.FindElement(By.Name(XPath));
                    we.Click();
                }

                public static void ClickByName(string Name)
                {
                    IWebElement we = WebDriver.FindElement(By.Name(Name));
                    we.Click();
                }

                public static void ClickByID(string ObjectID)
                {
                    IWebElement we = WebDriver.FindElement(By.Id(ObjectID));
                    we.Click();
                }

                public static void ClickByCSSPath(string CSSPath)
                {
                    IWebElement we = WebDriver.FindElement(By.CssSelector(CSSPath));
                    we.Click();
                }

                public static void ClickByLinkText(string linkText)
                {
                    IWebElement we = WebDriver.FindElement(By.LinkText(linkText));
                    we.Click();
                }

                public static void ClickByLinkText(string linkText, IWebDriver driver)
                {
                    IWebElement we = driver.FindElement(By.LinkText(linkText));
                    we.Click();
                }

                public static void ClickByTagName(string tagName, IWebDriver driver)
                {
                    IWebElement we = driver.FindElement(By.TagName(tagName));
                    we.Click();
                }

                public static void ClickByClassName(string className, IWebDriver driver)
                {
                    IWebElement we = driver.FindElement(By.ClassName(className));
                    we.Click();
                }
            }

            public class Link
            {
                public static void ClickByXPath(string XPath)
                {
                    IWebElement we = WebDriver.FindElement(By.Name(XPath));
                    we.Click();
                }

                public static void ClickByText(string Text)
                {
                    IWebElement we = WebDriver.FindElement(By.LinkText(Text));
                    we.Click();
                }

                public static void ClickByID(string ObjectID)
                {
                    IWebElement we = WebDriver.FindElement(By.Id(ObjectID));
                    we.Click();
                }

                public static void ClickIfExistByXPath(string XPath)
                {
                    IWebElement we = WebDriver.FindElement(By.Name(XPath));
                    we.Click();
                }

                public static void ClickIfExistByName(string Name)
                {
                    IWebElement we = WebDriver.FindElement(By.Name(Name));
                    we.Click();
                }

                public static void ClickIfExistByID(string ObjectID)
                {
                    IWebElement we = WebDriver.FindElement(By.Id(ObjectID));
                    we.Click();
                }


            }

            public class Table
            {
                public static string FindRecordWithRowColByCSSPath(string CSSPath, int row, int col)
                {

                    IWebElement table = WebDriver.FindElement(By.CssSelector(CSSPath));
                    ReadOnlyCollection<IWebElement> allRows = table.FindElements(By.TagName("tr"));

                    IWebElement CurRow = allRows[row - 1];
                    ReadOnlyCollection<IWebElement> CurCells = CurRow.FindElements(By.TagName("td"));
                    IWebElement CurCell = CurCells[col - 1];
                    return CurCell.Text;


                    
                }
            }

            public class Element
            {
                public static bool ExistsByCSSPath(string CSSPath)
                {
                    bool Exists = false;
                    try
                    {
                        IWebElement we = WebDriver.FindElement(By.CssSelector(CSSPath));
                        Exists = we.Displayed;
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    return Exists;

                   
                }
            }

        }
    }

}

     



