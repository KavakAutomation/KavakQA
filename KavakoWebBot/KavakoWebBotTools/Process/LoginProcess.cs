using System;
using OpenQA.Selenium;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Threading;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using LinqToExcel;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Remotion;
using System.Drawing;
using OpenQA.Selenium.Support.UI;

namespace KavakoWebBotTools.Process
{
    public class LoginProcess
    {
        int sleepTimerFast = 3000;
        int sleepTimerMiddle = 5000;
        int sleepTimerSlow = 7000;

        private bool resultadoLogin;

        // INSTANCIA DE OBJETOS 
        Objects.LoginObjects objetosLogin = new Objects.LoginObjects();
        Elements.LoginElements elementosLogin = new Elements.LoginElements();
        Elements.KOSHomeElements elementosHOME_KOS = new Elements.KOSHomeElements();
        Validations.LoginValidations validacionesLogin = new Validations.LoginValidations();
        //Elements.MenuElements elementosMenu = new Elements.MenuElements();
        //Commons.Actions SoporteAcciones = new Commons.Actions();


        //List<Objects.LoginObjects> Objects.objetosLogin.ListaUsuarios(String pathDataPool);

        public void AccesoLogin(IWebDriver driver, KavakoWebBotTools.Objects.LoginObjects objetosLogin, string numeroCaso)
        {
            // VALIDA QUE EXISTAN LOS ELEMENTOS DEL LOGIN
            if (validacionesLogin.ValidaElementosInicialesKOS(driver))
            {
                // DAR CLIC AL BOTON DE INICIAR SESION CON UN USUARIO GOOGLE
                elementosLogin.BotonIngresarConGoogle(driver).Click();
                Thread.Sleep(15000);

                #region ABRIR UNA NUEVA VENTANA DE CHAT (VENTANA EMERGENTE)
                ///////////////////////////////////////////////////////////////////////////////////////////
                ////Step 1
                //var newBrowserWindowButton = elementosLogin.ElementoUsuario(driver);
                //Assert.AreEqual(1, driver.WindowHandles.Count);

                //Thread.Sleep(sleepTimerSlow);

                //string originalWindowTitle = "KOS";
                //Assert.AreEqual(originalWindowTitle, driver.Title);

                ////Step 2
                //newBrowserWindowButton.Click();
                //Assert.AreEqual(2, driver.WindowHandles.Count);

                ////Step 3
                //string newWindowHandle = driver.WindowHandles.Last();
                //var newWindow = driver.SwitchTo().Window(newWindowHandle);

                //string expectedNewWindowTitle = "Cuentas de Google";
                //Assert.AreEqual(expectedNewWindowTitle, newWindow.Title);

                //Thread.Sleep(sleepTimerFast);
                //////////////////////////////////////////////////////////////////////////////////////////
                #endregion
            }
            else
            {
                resultadoLogin = false;
            }

        }// FIN DEL  public void AccesoLogin

        // INICIALIZAR NAVEGADORES
        public IWebDriver InicializarNavegadorWeb(Objects.LoginObjects objetosLogin)
        {
            IWebDriver driver = null;

            //INICIALIZA EL NAVEGADOR DEPENDIENDO DEL BROWSER QUE SE ESPECIFIQUE

            if (objetosLogin.Browser.Equals("Chrome"))
            {
                //driverPrueba = new ChromeDriver();
                ChromeOptions opciones = new ChromeOptions();
                //ChromeDriverService path = ChromeDriverService.CreateDefaultService(Path.GetFullPath("..\\..\\..\\KavakoWebBotTools\\Commons\\Navegadores\\"));
                //opciones.AddArguments("-incognito");
                
                //opciones.AddArguments("headless"); //Este funciona para que no se visualice la ventana de navegacion

                //opciones.AddArguments("--disable-infobars");
                //opciones.AddArguments("--disable-popup-bloking");
                //opciones.AddArguments("-start-maximized");

                driver = new ChromeDriver(opciones);
            }

            if (objetosLogin.Browser.Equals("Edge"))
            {
                EdgeOptions opcioneEDGE = new EdgeOptions();
                EdgeDriverService path = EdgeDriverService.CreateDefaultService("..\\..\\..\\KavakoWebBotTools\\Commons\\Navegadores\\");
                driver = new EdgeDriver(path);
            }

            if (objetosLogin.Browser.Equals("FireFox"))
            {
                FirefoxOptions opciones = new FirefoxOptions();
                //opciones.AddArguments("-incognito");
                //opciones.AddArguments("--disable-infobars");
                //opciones.AddArguments("--disable-popup-bloking");
                //opciones.AddArguments("-start-maximized");

                driver = new FirefoxDriver(opciones);
            }

            // VALIDAR SI SE INICIARA CON EL SISTEMA DE KOS
            if(objetosLogin.Sistema == "KOS")
            {
                driver.Navigate().GoToUrl("https://accounts.google.com/ServiceLogin");
                // ESPERAR A QUE SE PRESENTE EL ELEMENTO
                driver.Manage().Cookies.DeleteAllCookies();
                new WebDriverWait(driver, TimeSpan.FromSeconds(sleepTimerSlow)).Until(ExpectedConditions.ElementExists(By.Id("identifierId")));
                
                // LIMPIAR Y CAPTURAR CAMPO DE USUARIO
                elementosLogin.ElementoUsuario(driver).Clear();
                elementosLogin.ElementoUsuario(driver).SendKeys(objetosLogin.NombreUsuario);
                
                // DAR CLIC AL BOTON SIGUIENTE DE LA SECCION DE USUARIO
                elementosLogin.BotonSiguienteUsuario(driver).Click();
                Thread.Sleep(sleepTimerFast);

                if (elementosLogin.BotonNextGoogle(driver).Displayed)
                {
                    elementosLogin.BotonNextGoogle(driver).Click();
                    Thread.Sleep(sleepTimerFast);
                    new WebDriverWait(driver, TimeSpan.FromSeconds(sleepTimerSlow)).Until(ExpectedConditions.ElementExists(By.Id("identifierId")));

                    // LIMPIAR Y CAPTURAR CAMPO DE USUARIO
                    elementosLogin.ElementoUsuario(driver).Clear();
                    elementosLogin.ElementoUsuario(driver).SendKeys(objetosLogin.NombreUsuario);

                    // DAR CLIC AL BOTON SIGUIENTE DE LA SECCION DE USUARIO
                    elementosLogin.BotonSiguienteUsuario(driver).Click();
                    Thread.Sleep(sleepTimerFast);
                }

                // ESPERAR A QUE SE PRESENTE EL ELEMENTO
                new WebDriverWait(driver, TimeSpan.FromSeconds(sleepTimerSlow)).Until(ExpectedConditions.ElementExists(By.Name("password")));

                // LIMPIAR Y CAPTURAR EL CAMPO DE PASSWORD
                elementosLogin.ElementoPassword(driver).Clear();
                elementosLogin.ElementoPassword(driver).SendKeys(objetosLogin.PasswordUsuario);

                // DAR CLIC AL BOTON SIGUIENTE DE LA SECCION DEL PASSWORD
                elementosLogin.BotonSiguientePass(driver).Click();
                Thread.Sleep(sleepTimerFast);
            }

            //driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Size = new Size(1224, 1010);
            driver.Manage().Window.Position = new Point(680, 0);
            driver.Navigate().GoToUrl(objetosLogin.UrlTest);
            Thread.Sleep(sleepTimerFast);
            return driver;
        }

        // OBTENER RESULTADO DEL PROCESO DE LOGIN
        public bool ObtenerResultadoAccesoLogin()
        {
            return resultadoLogin;
        }

        // LLAMAR LISTA PARAEL DATAPOOL

        public List<Objects.LoginObjects> ListaUsuarios(string pathDelFicheroExcel)
        {
            var book = new ExcelQueryFactory(Path.GetFullPath("..\\..\\..\\KavakoWebBotTools\\DataPool\\" + pathDelFicheroExcel));
            var resultado = (from row in book.Worksheet("Login")
                             let item = new Objects.LoginObjects
                             {
                                 CasoPrueba = row["CasoPrueba"].Cast<string>(),
                                 Sistema = row["Sistema"].Cast<string>(),
                                 NombreUsuario = row["Usuario"].Cast<string>(),
                                 PasswordUsuario = row["Password"].Cast<string>(),
                                 UrlTest = row["Url"].Cast<string>(),
                                 Menu = row["Menu"].Cast<string>(),
                                 SubMenu = row["SubMenu"].Cast<string>(),
                                 OpcionesPrincipales = row["OpcionesPrincipales"].Cast<string>(),
                                 OpcionesSecundarias = row["OpcionesSecundarias"].Cast<string>(),
                                 ResultadoEsperado = row["ResultadoEsperado"].Cast<string>(),
                                 Browser = row["Browser"].Cast<string>()
                             }
                             select item).ToList();
            book.Dispose();
            return resultado;
        }
    }
}

