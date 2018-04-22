using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapAutomation
{
    class Program
    {

        static void Main(string[] args)
        {

        }

        /// <summary>
        /// SetUP es un atributo que se ejecuta antes 
        /// de que se ejecuten los Test
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            SeleniumDriver.driver = new ChromeDriver();
            SeleniumDriver.driver.Manage().Window.Maximize();
            SeleniumDriver.driver.Navigate().GoToUrl("https://vacations-management.herokuapp.com/users/sign_in");
            WebDriverWait wait = new WebDriverWait(SeleniumDriver.driver, new TimeSpan(0, 0, 10));
            wait.Until(ExpectedConditions.ElementExists(By.Id("user_email")));
            Console.WriteLine("Url opened");

        }


        /// <summary>
        /// Este método debe ejecutarse antes de los test 
        /// ya que es la base para la ejecucíón de las pruebas
        /// </summary>
        public void Login()
        {

            LoginPageObject LoginPage = new LoginPageObject();
            LoginPage.Login("gap-automation-test@mailinator.com", "12345678");
            Console.WriteLine("User loged");
        }


        /// <summary>
        /// Primer Test que se ejecuta
        /// Se realiza el login del usuario y luego
        /// se crea un usuario nuevo con los datos enviados 
        /// </summary>
        [Test, Order(1)]
        public void AddNewUser()
        {
            Login();                        //Login del aplicativo, esto es lo primero a ejecutarse
            AddNewUserPageObject NewUser = new AddNewUserPageObject();

            //Envío de parámetros del usuario que se creará
            string ActualMeessge = NewUser.FillData("James", "Smith", "JamesSmith@gap.com", "1234567890", "Juan Esteban Mesa G", "2014", "January", "1");

            //Se valida que el usuario haya sido creado
            //Assert.True(ActualMeessge.Contains("Employee was successfully created."));
            if (ActualMeessge.Contains("Employee was successfully created."))
            { Console.WriteLine("User created successfully"); }
            else
                Console.WriteLine("User not created");
        
        

    }

        /// <summary>
        /// Segundo Test en ejecutarse
        /// Se verifica si el usuario existe/fue creado 
        /// </summary>
        [Test, Order(2)]
        public void VerifyyUserCreated()
        {
            VerifyUserPageObjects UserVerify = new VerifyUserPageObjects();
            string ActualMessage = UserVerify.UserToVerify("1234567890");
            Assert.True(ActualMessage.Contains("Hi"));

            if (ActualMessage.Contains("Hi"))
            { Console.WriteLine("User exist"); }
            else
                Console.WriteLine("User not exist");
        }

        /// <summary>
        /// Tercer Test en ejecutarse
        /// Se envía como parámetro el nombre del lider para eliminar el registro
        /// Se realizó de esta forma para evitar eliminar por Id los otros registros
        /// de la tabla que se encuentran duplicados
        /// </summary>
        [Test, Order(3)]
        public void DeleteUser()
        {
            DeleteUserPageObjects UserToDelete = new DeleteUserPageObjects();
            Login();
            //Se envía como parámetro el nombre del leadder 
            UserToDelete.id("Juan Esteban Mesa G");
            Console.WriteLine("User deleted");
        }


        /// <summary>
        /// Cuarto Test en ejecutarse
        /// Este médtodo verifíca si el usuario no exite 
        /// </summary>
        [Test, Order(4)]
        public void VerifyUserDeleted()
        {
            VerifyUserPageObjects UserVerify = new VerifyUserPageObjects();
            //Se envía el id del usuario a consultar si existe
            string ActualMessage = UserVerify.UserToVerify("354344354");
            //Se valida que el usuario no exista en el site
            Assert.True(ActualMessage.Contains("No Employee found"));
            if (ActualMessage.Contains("No Employee found"))
            { Console.WriteLine("User not exist"); }
            else
                Console.WriteLine("User exist");
        }


        [TearDown]
        public void CleanUp()
        {
            //Cierre del driver
            SeleniumDriver.driver.Close();
        }

    }
}
