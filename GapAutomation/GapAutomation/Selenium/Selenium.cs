using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using NUnit.Framework;



namespace GapAutomation
{
    class Selenium
    {
        public static void DeleteUser(string value)
        {
            string fullpath = string.Format("//tr[td='{0}']//td[last()]", value);
            SeleniumDriver.driver.FindElement(By.XPath(fullpath)).Click();
            SeleniumDriver.driver.SwitchTo().Alert().Accept();
        }


    }
}
