using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;


namespace Royal_Society_of_Chemistry.Hook
{
    public class Browser_Factory
    {
        //A Dictionary Object of Browser name to Browser is stored as a private member. 
        //So nobody can directly access it.
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }
        //In the InitBrowser() method a browser is created only once,
        //that will be when the very first call to get the browser of a particular type will come. 
        //After that only the existing browser is returned. 
        //This means that the browser will be cached through the session.
        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (Driver == null)
                    {
                        driver = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver);
                    }
                    break;

                case "IE":
                    if (Driver == null)
                    {
                        driver = new InternetExplorerDriver(@"C:\PathTo\IEDriverServer");
                        Drivers.Add("IE", Driver);
                    }
                    break;

                case "Chrome":
                    if (Driver == null)
                    {
                        driver = new ChromeDriver(@"C:\PathTo\CHDriverServer");
                        Drivers.Add("Chrome", Driver);
                    }
                    break;
            }
        }
        //Here is a method that opens the URL each time the method is called.
        public static void LoadApplication(string url)
        {
            Driver.Url = url;
        }
        //Here this method closes all drivers including browsers.
        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}


