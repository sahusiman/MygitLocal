using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
namespace LandingPageTest
{
    [TestClass]
    public class LPageTest
    {
        private TestContext testContextInstance;
        public IWebDriver driver;
        private string appURL;
        //private readonly object clickElement;

        [TestMethod]
        [TestCategory("IE")]
        public void TheLpageload()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            Console.WriteLine(driver.Manage().Window.Size);
            // set window size
            driver.Manage().Window.Size = new Size(480, 320);
            Console.WriteLine(driver.Manage().Window.Size);

            // maximize window
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Manage().Window.Size);
            //Going to the child window
            String parentWindowHandle = driver.CurrentWindowHandle;
            // Store all the opened window into the list 
            // Print each and every items of the list
            List<string> lstWindow = driver.WindowHandles.ToList();
            foreach (var handle in lstWindow)
            {
                Console.WriteLine(handle);
                driver.SwitchTo().Window(handle);
            }
            driver.FindElement(By.XPath(".//*[@id='i0116']")).SendKeys("simanchal.sahu@vodafone.com");
            driver.FindElement(By.XPath(".//*[@id='idSIButton9']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath(".//*[@id='passwordInput']")).SendKeys("Vodass@63");
            driver.FindElement(By.XPath(".//*[@id='submitButton']")).Click();
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id='continueButton']")).Click();
            System.Threading.Thread.Sleep(70000);
            String parentWindowHandle1 = driver.CurrentWindowHandle;
            for (var i = 0; i < 3; i++)
            {
                Thread.Sleep(3000);
            }
            List<string> lstWindow1 = driver.WindowHandles.ToList();
            // Traverse each and every window 
            foreach (var handle in lstWindow1)
            {
                //Switch to the desired window first and then execute commands using driver
                driver.SwitchTo().Window(handle);
            }
            Thread.Sleep(10000);
            driver.FindElement(By.XPath(".//*[@id='idSIButton9']")).Click();
        }



        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public object Public { get; private set; }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "https://vodafone.sharepoint.com/";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        ///[TestCleanup()]
        ///public void MyTestCleanup()
        ///{
        ///  driver.Quit();
        ///}
    }
}

