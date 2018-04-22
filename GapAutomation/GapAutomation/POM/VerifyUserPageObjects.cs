using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapAutomation
{
    class VerifyUserPageObjects
    {

        public VerifyUserPageObjects()
        {
            PageFactory.InitElements(SeleniumDriver.driver, this);
        }


        [FindsBy(How = How.LinkText, Using = "public site")]
        public IWebElement LinkPublicSite { get; set; }


        [FindsBy(How = How.Id, Using = "employee_identification")]
        public IWebElement txtUserId { get; set; }

        [FindsBy(How = How.Name, Using = "commit")]
        public IWebElement CreateEmployeeButton
        { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='content']/h1")]
        public IWebElement ActualMessage
        { get; set; }

        //Parámetros recibidos del usuario que se consultará si tiene acceso a la 
        //información de sus vacaciones
        public string UserToVerify(string userId)
        {
            LinkPublicSite.Click();
            txtUserId.SendKeys(userId);
            CreateEmployeeButton.Click();
            return ActualMessage.Text;   
        }

    }
}
   
