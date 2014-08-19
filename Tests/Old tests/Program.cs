using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Namespace of our custom project
using SeleniumProject;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is our NUnit driver.
            SeleniumProject.SeleniumProject testObject = new SeleniumProject.SeleniumProject();
            testObject.Setup("http://bluesourcestaging.herokuapp.com/login");
            testObject.ExecuteTestCase("BlueSource");
            testObject.TearDown();
            System.Console.ReadKey();
        }
    }
}

/*
    Add new page objects for Search page functionality
 
 
 */