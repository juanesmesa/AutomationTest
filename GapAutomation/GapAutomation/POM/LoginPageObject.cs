using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapAutomation
{
            

    class LoginPageObject
    {

        public LoginPageObject()
        {
            PageFactory.InitElements(SeleniumDriver.driver, this);  

        }

        [FindsBy(How = How.Id, Using = "user_email")]
        public IWebElement txtEmail { get; set; }


        [FindsBy(How = How.Id, Using = "user_password")]
        public IWebElement txtPassword { get; set; }


        [FindsBy(How = How.Name, Using = "commit")]
        public IWebElement LoginButton { get; set; }




        public LoginPageObject Login(string email, string passWord)
        {
            //Email para login
            txtEmail.SendKeys(email);
            
            //Password para login
            txtPassword.SendKeys(passWord);

            //Clic en el boton para logueo
            LoginButton.Click();
            return new LoginPageObject();
        }
    }
}
