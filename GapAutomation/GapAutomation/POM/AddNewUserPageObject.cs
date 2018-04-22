using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace GapAutomation
{
    class AddNewUserPageObject
    {
        public AddNewUserPageObject()
        {
            PageFactory.InitElements(SeleniumDriver.driver, this);
        }


        [FindsBy(How = How.LinkText, Using = "Create a new employee")]
        public IWebElement LinkNewUser { get; set; }


        [FindsBy(How = How.Id, Using = "employee_first_name")]
        public IWebElement txtEmployee_First_Name { get; set; }


        [FindsBy(How = How.Id, Using = "employee_last_name")]
        public IWebElement txtEmployee_Last_Name { get; set; }


        [FindsBy(How = How.Id, Using = "employee_email")]
        public IWebElement txtEmployee_Email { get; set; }


        [FindsBy(How = How.Id, Using = "employee_identification")]
        public IWebElement txtEmployee_identification { get; set; }


        [FindsBy(How = How.Id, Using = "employee_leader_name")]
        public IWebElement txtEmployee_leader_name { get; set; }


        [FindsBy(How = How.Id, Using = "employee_start_working_on_1i")]
        private IWebElement ageDropDown;
        public SelectElement ageDropdownElement
        {
            get { return new SelectElement(ageDropDown); }
        }


        [FindsBy(How = How.Id, Using = "employee_start_working_on_2i")]
        private IWebElement montDropDown;
        public SelectElement montDropdownElement
        {
            get { return new SelectElement(montDropDown); }
        }


        [FindsBy(How = How.Id, Using = "employee_start_working_on_3i")]
        private IWebElement daytDropDown;
        public SelectElement dayDropdownElement
        {
            get { return new SelectElement(daytDropDown); }
        }


        [FindsBy(How = How.Name, Using = "commit")]
        public IWebElement CreateEmployeeButton
        { get; set; }

   
        [FindsBy(How = How.XPath, Using = "//*[@id='notice']")]
        public IWebElement ActualMessage
        { get; set; }



        //Parámetros recibidos del usuario que se creará
        public string FillData(string firtName, string lastNmae, string email, string identification, string leaderNmae, string age, string month, string day)
        {
            LinkNewUser.Click();
            txtEmployee_First_Name.SendKeys(firtName);
            txtEmployee_Last_Name.SendKeys(lastNmae);
            txtEmployee_Email.SendKeys(email);
            txtEmployee_identification.SendKeys(identification);
            txtEmployee_leader_name.SendKeys(leaderNmae);
            ageDropdownElement.SelectByText(age);
            montDropdownElement.SelectByText(month);
            dayDropdownElement.SelectByText(day);
            CreateEmployeeButton.Click();

            //Se retorna el mensaje el cual indica si el usuario fue creado
            return ActualMessage.Text;
        }        

    }
}
