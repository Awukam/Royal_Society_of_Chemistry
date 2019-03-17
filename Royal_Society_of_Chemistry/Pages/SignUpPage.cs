using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royal_Society_of_Chemistry
{
    class SignUpPage
    {
        IWebDriver driver;
       public SignUpPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='navbar - collapse']/ul/li[2]/a")]
        public IWebElement SignUpBtn { get; set; }

        [FindsBy(How =How.Name, Using = "payment_plan_id")]
        public IWebElement selectpayment_plan { get; set; }

        [FindsBy(How =How.Name, Using = "first_name")]
        public IWebElement first_nameElement { get; set; }

        [FindsBy(How =How.Name, Using = "surname")]
        public IWebElement surnameElement { get; set; }

        [FindsBy(How =How.Name, Using = "email")]
        public IWebElement emailElement { get; set; }

        [FindsBy(How =How.Name, Using = "email_confirm")]
        public IWebElement email_confirmElement { get; set; }

        [FindsBy(How =How.Name, Using = "username")]
        public IWebElement usrenameElement { get; set; }

        [FindsBy(How =How.Name, Using = "password")]
        public IWebElement passwordElement { get; set; }

        [FindsBy(How =How.Name, Using = "passwordconfirm")]
        public IWebElement passwordconfirmElement { get; set; }

        [FindsBy(How =How.Name, Using = "agreeTerms")]
        public IWebElement agreetermElement { get; set; }

        [FindsBy(How =How.XPath, Using = "//*[@id='multipleForm']/div[12]/div")]
        public IWebElement submitElement { get; set; }

        ///Here we are creating the page object/functions
        
        public void ClickSignUpLink()
        {
            SignUpBtn.Click();
        }
        
        public void SelectPaymentPlan(String paymentplan)
        {
            SelectElement select = new SelectElement(selectpayment_plan);
            select.SelectByText(paymentplan);
        }
        
        public void SetFirstName(String FirstName)
        {
            first_nameElement.SendKeys(FirstName);
        }

        public void SetSurName(String Surname)
        {
            surnameElement.SendKeys(Surname);
        }

        public void SetEmail(String Email)
        {
            emailElement.SendKeys(Email);

        }

        public void SetEmail_Confirm(String SetEmailconfirm)
        {
            email_confirmElement.SendKeys(SetEmailconfirm);
        }

        public void SetUserName(String username)
        {
            usrenameElement.SendKeys(username);
        }

        public void SetPassword(String password)
        {
            passwordElement.SendKeys(password);
        }

        public void Setpassword_Confirmation(String passwordconfirm)
        {
            passwordconfirmElement.SendKeys(passwordconfirm);
        }

        public void ClickAgreeBtn()
        {
            agreetermElement.Click();
        }

        public Homepage ClickSubmitBtn()
        {
            submitElement.Click();
            return new Homepage();
        }

    }

}
