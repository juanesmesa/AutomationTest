using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapAutomation
{
    class DeleteUserPageObjects


    {
        public void id(string userId)
        {
            //Búsqueda de la ruta completa, recibiendo como parámetros el 
            //userId, sin embargo para la prueba, se recive el nombred del leader
            //que en este caso sería único registro
            string fullpath = string.Format("//tr[td='{0}']//td[last()]", userId);
            SeleniumDriver.driver.FindElement(By.XPath(fullpath)).Click();

            //Se cambia a la ventana Alert para confirmar la eliminación
            SeleniumDriver.driver.SwitchTo().Alert().Accept();
         }
    }
}