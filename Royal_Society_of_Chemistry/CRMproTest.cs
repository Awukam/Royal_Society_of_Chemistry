using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Royal_Society_of_Chemistry.Pages;



namespace Royal_Society_of_Chemistry.Pages
{
    
    class CRMproTest
    {
        IWebDriver driver;
        [SetUp]
        public void InitializeBroswer()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://classic.crmpro.com/index.html");
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(500));
            driver.Manage().Cookies.DeleteAllCookies();

        }

        [Test]
        public void SignUpPageTest()
        {
            SignUpPage page = new SignUpPage(driver);
            page.ClickSignUpLink();
            page.SelectPaymentPlan("Free Edition");
            page.SetFirstName("Daniel");
            page.SetSurName("Mark");
            page.SetEmail("danielmuller96@gmail.com");
            page.SetEmail_Confirm("danielmuller96@gmail.com");
            page.SetUserName("Boyo");
            page.SetPassword("Awub@123");
            page.Setpassword_Confirmation("Awub@123");
            page.ClickAgreeBtn();
            page.ClickSubmitBtn();

            //Verification of signUp
            Assert.That(driver.FindElement(By.XPath("//*[@id='footer']/div/div/div[1]/p[1]")).Displayed);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
            driver.Quit();

           // IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        }

        

    }
}
