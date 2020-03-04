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
using KavakoWebBotTools.Objects;
using OpenQA.Selenium.Support.UI;
using KavakoWebBotTools.Elements;
using KavakoWebBotTools.Process;
using ChatBotSuitTools.Commons;

namespace KavakoWebBotTools.Process
{
    public class KOSComplianceProcess
    {
        int sleepTimerFast = 2500;
        int sleepTimerMiddle = 3500;
        int sleepTimerSlow = 7000;
        int sleepTimerFail = 20000;

        private bool resultadoKOSCompliance;

        // INSTANCIAR 
        LoginProcess procesoLogin = new LoginProcess();
        ComplianceObject objetosComplians = new ComplianceObject();

        LoginObjects objetosLogin = new LoginObjects();
        LoginElements elementosLogin = new LoginElements();
        KOSHomeElements elementosKOSHome = new KOSHomeElements();
        Actions soporte = new Actions();

        public void KOS_01_ConfirnarInspeccion_HP(LoginObjects objetosLogin, ComplianceObject objetosComplians, string numeroCaso)
        {
            IWebDriver driver;

            // REPORTE PDF
            #region REPORTE PDF
            string Logo = Path.GetFullPath("..\\..\\..\\KavakoWebBotTools\\Commons\\Support\\logo.png");
            Document documento = null;
            FileStream docPDF = File.Create("..\\..\\..\\KavakoWebBotTools\\Commons\\Reportes\\" + objetosLogin.CasoPrueba + ".pdf");
            documento = soporte.CrearReporte(Logo, documento, docPDF, objetosLogin.CasoPrueba);
            #endregion

            // SELECCIONAR EL NAVEGADOR
            driver = procesoLogin.InicializarNavegadorWeb(objetosLogin);

            // CAPTURAR DATOS DEL USUARIO
            procesoLogin.AccesoLogin(driver, objetosLogin, "Login");

            // ESPERAR A QUE SE VISUALICE EL ELEMENTO.
            soporte.Loading(elementosKOSHome.MenuHamburguesa(driver));

            // SELECCIONA EL CAMINO POR CUAL INGRESAR
            switch (objetosLogin.OpcionIngreso)
            {
                case "Menu":
                    // DAR CLIC AL MENU DE HAMBURGUESA
                    elementosKOSHome.MenuHamburguesa(driver).Click();

                    soporte.Loading(elementosKOSHome.Menu(driver, objetosLogin.Menu));
                    elementosKOSHome.Menu(driver, objetosLogin.Menu).Click();
                    Thread.Sleep(sleepTimerFast);

                    soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCION DESDE MENU LA OPCION", objetosLogin.CasoPrueba);

                    elementosKOSHome.SubMenu(driver, objetosLogin.SubMenu).Click();
                    Thread.Sleep(sleepTimerMiddle);
                    break;

                case "HomePanel":
                    soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONA OPCION DESDE EL HOME PANEL", objetosLogin.CasoPrueba);
                    // DAR CLIC A LA OPCION DE OPCIONES DEL PANEL "HOME PANEL"
                    soporte.Loading(elementosKOSHome.OpcionSupply(driver, objetosLogin.OpcionesSecundarias));
                    elementosKOSHome.OpcionSupply(driver, objetosLogin.OpcionesSecundarias).Click();
                    Thread.Sleep(sleepTimerMiddle);
                    break;
            }

            // SELECCIONAR DESDE LA "BANDEJA" UNA FICHA - FUNNEL
            try
            {
                soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONA UNA OPCIÓN DESDE LA BANDEJA DE FUNNEL, CORRESPONDIENTE A " + objetosComplians.Funnel_Bandeja + "", objetosLogin.CasoPrueba);
                soporte.ClickWithOption(driver, KOS_Compliance.Funnel_Bandeja, objetosComplians.Funnel_Bandeja);
            }
            catch
            {
                soporte.ObtenerEvidenciaCaso(driver, documento, "¡OCURRIO UN PROBLEMA!, NO SE ENCONTRO LA OPCIÓN DESDE LA BANDEJA DE FUNNEL, CORRESPONDIENTE A " + objetosComplians.Funnel_Bandeja + "", objetosLogin.CasoPrueba);
                Thread.Sleep(sleepTimerFail);
                resultadoKOSCompliance = false;
                // CERRAR NAVEGADOR
                soporte.CerrarDriver(driver);
                soporte.CerrarDocumento(documento);
            }
            
            // DAR CLIC AL BOTON "INICIAR INVESTIGACIÓN"
            try
            {
                soporte.ObtenerEvidenciaCaso(driver, documento, "DAR CLIC AL BOTON 'INICIAR INVESTIGACION' CORRESPONDIENTE A FICHA - FUNNEL", objetosLogin.CasoPrueba);
                soporte.Click(driver, "XPath", KOS_Compliance.Funnel_Ficha_GuardarCambios);
            }
            catch
            {
                soporte.ObtenerEvidenciaCaso(driver, documento, "¡OCURRIO UN PROBLEMA!, NO SE ENCONTRO EL BOTON 'INICIAR INVESTIGACION' CORRESPONDIENTE A " + KOS_Compliance.Funnel_Ficha_GuardarCambios + " FICHA - FUNNEL", objetosLogin.CasoPrueba);
                Thread.Sleep(sleepTimerFail);
                resultadoKOSCompliance = false;
                // CERRAR NAVEGADOR
                soporte.CerrarDriver(driver);
                soporte.CerrarDocumento(documento);
            }

            // CAPTURAR INFORMACIÓN CORRESPONDIENTE A LA SECCIÓN DE "INVESTIGACIÓN"
            #region CAPTURAR INFORMACIÓN CORRESPONDIENTE A LA SECCIÓN DE "INVESTIGACIÓN"

            // CAPTURAR INFORMACION, CORRESPONDIENTE A LA SECCION "VIN"
            #region CAPTURAR INFORMACION, CORRESPONDIENTE A LA SECCION "VIN"
            // CAPTURAR INFORMACION DEL CAMPO "ESCRIBE EL NUMERO DE VIN", CORRESPONDIENTE A LA SECCION "VIN"
            try
            {
                soporte.WaitForElementPresent(driver, "XPath", KOS_Compliance.Investigacion_VIN_EscribeNumeroVIN);
                soporte.ObtenerEvidenciaCaso(driver, documento, "CAPTURA INFORMACIÓN DEL CAMPO 'ESCRIBE EL NUMERO DE VIN'", objetosLogin.CasoPrueba);
                soporte.SendText(driver, "XPath", KOS_Compliance.Investigacion_VIN_EscribeNumeroVIN, objetosComplians.Investigacion_VIN_EscribeNumeroVIN);
            }
            catch
            {
                soporte.ObtenerEvidenciaCaso(driver, documento, "¡OCURRIO UN PROBLEMA!, NO SE ENCONTRO EL CAMPO 'ESCRIBE EL NUMERO DE VIN' CORRESPONDIENTE A " + KOS_Compliance.Investigacion_VIN_EscribeNumeroVIN + " FICHA - FUNNEL", objetosLogin.CasoPrueba);
                Thread.Sleep(sleepTimerFail);
                resultadoKOSCompliance = false;
                // CERRAR NAVEGADOR
                soporte.CerrarDriver(driver);
                soporte.CerrarDocumento(documento);
            }

            // SELECCIONAR UNA OPCIÓN DE LA PREGUNTA "¿EL VIN DE CARNET DE SERVICIO COINCIDE CON EL VIN DE CHASIS?"
            if (objetosComplians.Investigacion_VIN_CoincideConChasis_Si == "Si")
            {
                try
                {
                    soporte.ObtenerEvidenciaCaso(driver, documento, " SELECCIONAR LA OPCION 'SI', DE LA PREGUNTA '¿EL VIN DE CARNET DE SERVICIO COINCIDE CON EL VIN DE CHASIS?'", objetosLogin.CasoPrueba);
                    soporte.Click(driver, "XPath", KOS_Compliance.Investigacion_VIN_CoincideConChasis_Si);
                }
                catch
                {
                    soporte.ObtenerEvidenciaCaso(driver, documento, "¡OCURRIO UN PROBLEMA!, NO SE ENCONTRO LA OPCION 'SI', DE LA PREGUNTA '¿EL VIN DE CARNET DE SERVICIO COINCIDE CON EL VIN DE CHASIS?'", objetosLogin.CasoPrueba);
                    Thread.Sleep(sleepTimerFail);
                    resultadoKOSCompliance = false;
                    // CERRAR NAVEGADOR
                    soporte.CerrarDriver(driver);
                    soporte.CerrarDocumento(documento);
                }
            }
            else
            {
                try
                {
                    soporte.Click(driver, "XPath", KOS_Compliance.Investigacion_VIN_CoincideConChasis_No);
                    soporte.Click(driver, "XPath", KOS_Compliance.Investigacion_VIN_CoincideConChasis_SinChasis);
                    soporte.Click(driver, "XPath", KOS_Compliance.Investigacion_VIN_CoincideConChasis_SinCarnet);
                    soporte.ObtenerEvidenciaCaso(driver, documento, "SE SELECCIONAN LAS OPCIONES 'NO', 'SIN CHASIS' Y 'SIN CARNET', DE LA PREGUNTA '¿EL VIN DE CARNET DE SERVICIO COINCIDE CON EL VIN DE CHASIS?'", objetosLogin.CasoPrueba);
                    soporte.Click(driver, "XPath", KOS_Compliance.Investigacion_VIN_CoincideConChasis_Si);
                    soporte.ObtenerEvidenciaCaso(driver, documento, " SELECCIONAR LA OPCION 'SI', DE LA PREGUNTA '¿EL VIN DE CARNET DE SERVICIO COINCIDE CON EL VIN DE CHASIS?'", objetosLogin.CasoPrueba);
                }
                catch
                {
                    soporte.ObtenerEvidenciaCaso(driver, documento, "¡OCURRIO UN PROBLEMA!, NO SE ENCONTRO LA OPCION 'NO', DE LA PREGUNTA '¿EL VIN DE CARNET DE SERVICIO COINCIDE CON EL VIN DE CHASIS?'", objetosLogin.CasoPrueba);
                    Thread.Sleep(sleepTimerFail);
                    resultadoKOSCompliance = false;
                    // CERRAR NAVEGADOR
                    soporte.CerrarDriver(driver);
                    soporte.CerrarDocumento(documento);
                }
            }
            #endregion

            // CAPTURAR INFORMACIÓN, CORRESPONDIENTE A LA SECCIÓN "REPUVE"
            #region CAPTURAR INFORMACIÓN, CORRESPONDIENTE A LA SECCIÓN "REPUVE"
            //  SELECCIONAR LA OPCIÓN "LINK NO ABRE"
            try
            {
                soporte.Click(driver, "XPath", KOS_Compliance.Investigacion_VIN_REPUVE_LinkNoAbre);
                soporte.Click(driver, "XPath", KOS_Compliance.Investigacion_VIN_REPUVE_LinkNoAbre);
                soporte.ObtenerEvidenciaCaso(driver, documento, "ACTIVAR Y DESACTIVAR LA OPCIÓN DE 'LINK NO ABRE', DE 'INVESTIGAR REPUVE'", objetosLogin.CasoPrueba);
            }
            catch
            {
                soporte.ObtenerEvidenciaCaso(driver, documento, "¡OCURRIO UN PROBLEMA!, NO SE ENCONTRO LA OPCIÓN DE 'LINK NO ABRE', " + KOS_Compliance.Investigacion_VIN_REPUVE_LinkNoAbre + " DE 'INVESTIGAR REPUVE'", objetosLogin.CasoPrueba);
                Thread.Sleep(sleepTimerFail);
                resultadoKOSCompliance = false;
                // CERRAR NAVEGADOR
                soporte.CerrarDriver(driver);
                soporte.CerrarDocumento(documento);
            }

            // SELECCIONA A LA OPCIÓN SI DE LA PREGUNTA "¿TIENE REPORTE DE ROBO ILÍCITO?"
            try
            {
                soporte.WaitForElementPresent(driver, "XPath", KOS_Compliance.Investigacion_VIN_REPUVE_TieneReporteRoboIlicito_Si);
                soporte.Click(driver, "XPath", KOS_Compliance.Investigacion_VIN_REPUVE_TieneReporteRoboIlicito_No);
                soporte.Click(driver, "XPath", KOS_Compliance.Investigacion_VIN_REPUVE_TieneReporteRoboIlicito_Si);
                soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONA A LA OPCIÓN 'SI' DE LA PREGUNTA '¿TIENE REPORTE DE ROBO ILÍCITO ?'", objetosLogin.CasoPrueba);
            }
            catch
            {
                soporte.ObtenerEvidenciaCaso(driver, documento, "¡OCURRIO UN PROBLEMA!, NO SE ENCONTRO LA OPCIÓN 'SI' " + KOS_Compliance.Investigacion_VIN_REPUVE_TieneReporteRoboIlicito_Si + " DE LA PREGUNTA '¿TIENE REPORTE DE ROBO ILÍCITO ?'", objetosLogin.CasoPrueba);
                Thread.Sleep(sleepTimerFail);
                resultadoKOSCompliance = false;
                // CERRAR NAVEGADOR
                soporte.CerrarDriver(driver);
                soporte.CerrarDocumento(documento);
            }

            // VALIDAR QUE EXISTA EL BOTÓN 'RECHAZAR INSPECCIÓN'

            if (driver.FindElement(By.XPath(KOS_Compliance.Investigacion_VIN_REPUVE_TieneReporteRoboIlicito_BotonRechazar)).Displayed)
            {

            }
            else
            {

            }

            // VALIDA LA SELECCIÓN DE LA PREGUNTA '¿EXISTE UNA PLACA REGISTRADA?'
            if (objetosComplians.Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Si == "Si")
            {
                // SELECCIONA LA OPCIÓN 'SI' CORRESPONDIENTE A LA PREGUNTA '¿EXISTE UNA PLACA REGISTRADA?'
                try
                {
                    soporte.Click(driver, "XPath", KOS_Compliance.Investigacion_VIN_REPUVE_ExistePlacaRegistrada_No);
                    soporte.Click(driver, "XPath", KOS_Compliance.Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Si);
                    soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONA LA OPCIÓN 'SI' CORRESPONDIENTE A LA PREGUNTA '¿EXISTE UNA PLACA REGISTRADA?'", objetosLogin.CasoPrueba);
                }
                catch
                {
                    soporte.ObtenerEvidenciaCaso(driver, documento, "¡OCURRIO UN PROBLEMA!, NO SE ENCONTRO LA OPCIÓN 'SI' " + KOS_Compliance.Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Si + "CORRESPONDIENTE A LA PREGUNTA '¿EXISTE UNA PLACA REGISTRADA?'", objetosLogin.CasoPrueba);
                    Thread.Sleep(sleepTimerFail);
                    resultadoKOSCompliance = false;
                    // CERRAR NAVEGADOR
                    soporte.CerrarDriver(driver);
                    soporte.CerrarDocumento(documento);
                }

                // CAPTURAR EL CAMPO 'PLACA' Y SELECCIONAR EL CAMPO 'ESTADO'
                try
                {
                    soporte.SendText(driver, "XPath", KOS_Compliance.Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Placa, objetosComplians.Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Placa);
                    soporte.SelectOpcionByText(driver, "XPath", KOS_Compliance.Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Estado, objetosComplians.Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Estado);
                    soporte.ObtenerEvidenciaCaso(driver, documento, "CAPTURAR EL CAMPO 'PLACA' Y SELECCIONAR EL CAMPO 'ESTADO', CORRESPONDIENTE A LA PREGUNTA '¿EXISTE UNA PLACA REGISTRADA?'", objetosLogin.CasoPrueba);
                }
                catch
                {
                    soporte.ObtenerEvidenciaCaso(driver, documento, "¡OCURRIO UN PROBLEMA!, NO SE ENCONTRO EL CAMPO 'PLACA' " + KOS_Compliance.Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Placa + "CORRESPONDIENTE A LA PREGUNTA '¿EXISTE UNA PLACA REGISTRADA?'", objetosLogin.CasoPrueba);
                    Thread.Sleep(sleepTimerFail);
                    resultadoKOSCompliance = false;
                    // CERRAR NAVEGADOR
                    soporte.CerrarDriver(driver);
                    soporte.CerrarDocumento(documento);
                }
            }
            else
            {
                // SELECCIONA LA OPCIÓN 'NO' CORRESPONDIENTE A LA PREGUNTA '¿EXISTE UNA PLACA REGISTRADA?'
                try
                {
                    soporte.Click(driver, "XPath", KOS_Compliance.Investigacion_VIN_REPUVE_ExistePlacaRegistrada_No);
                    soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONA LA OPCIÓN 'NO' CORRESPONDIENTE A LA PREGUNTA '¿EXISTE UNA PLACA REGISTRADA?'", objetosLogin.CasoPrueba);
                }
                catch
                {
                    soporte.ObtenerEvidenciaCaso(driver, documento, "¡OCURRIO UN PROBLEMA!, NO SE ENCONTRO LA OPCIÓN 'NO' " + KOS_Compliance.Investigacion_VIN_REPUVE_ExistePlacaRegistrada_No + "CORRESPONDIENTE A LA PREGUNTA '¿EXISTE UNA PLACA REGISTRADA?'", objetosLogin.CasoPrueba);
                    Thread.Sleep(sleepTimerFail);
                    resultadoKOSCompliance = false;
                    // CERRAR NAVEGADOR
                    soporte.CerrarDriver(driver);
                    soporte.CerrarDocumento(documento);
                }
            }

            // CAPTURAR LA OPCIÓN 'SÍ' DE LA PREGUNTA CORRESPONDIENTE A '¿EL MODELO, LA VERSIÓN Y EL AÑO COTIZADO COINCIDE CON EL DE REPUVE?'
            try
            {
                soporte.Click(driver, "XPath", KOS_Compliance.Investigacion_VIN_REPUVE_ModeloCoincideConREPUVE_No);
                soporte.Click(driver, "XPath", KOS_Compliance.Investigacion_VIN_REPUVE_ModeloCoincideConREPUVE_Si);
                soporte.ObtenerEvidenciaCaso(driver, documento, "CAPTURAR LA OPCIÓN 'SÍ' DE LA PREGUNTA CORRESPONDIENTE A '¿EL MODELO, LA VERSIÓN Y EL AÑO COTIZADO COINCIDE CON EL DE REPUVE?'", objetosLogin.CasoPrueba);
            }
            catch
            {
                soporte.ObtenerEvidenciaCaso(driver, documento, "¡OCURRIO UN PROBLEMA!, NO SE ENCONTRO LA OPCIÓN 'NO' " + KOS_Compliance.Investigacion_VIN_REPUVE_ModeloCoincideConREPUVE_No + "DE LA PREGUNTA CORRESPONDIENTE A '¿EL MODELO, LA VERSIÓN Y EL AÑO COTIZADO COINCIDE CON EL DE REPUVE?'", objetosLogin.CasoPrueba);
                Thread.Sleep(sleepTimerFail);
                resultadoKOSCompliance = false;
                // CERRAR NAVEGADOR
                soporte.CerrarDriver(driver);
                soporte.CerrarDocumento(documento);
            }

            // 'CARGAR RESPALDO REPUVE'
            try
            {
                soporte.ScrollToElement(driver, driver.FindElement(By.XPath(KOS_Compliance.Investigacion_VIN_REPUVE_CargarRespaldoREPUVE)));
                //driver.FindElement(By.XPath(KOS_Compliance.Investigacion_VIN_REPUVE_CargarRespaldoREPUVE)).SendKeys(objetosComplians.Investigacion_VIN_REPUVE_CargarRespaldoREPUVE);
                soporte.SendKeyUpLoad(driver, objetosComplians.Investigacion_VIN_REPUVE_CargarRespaldoREPUVE, KOS_Compliance.Investigacion_VIN_REPUVE_CargarRespaldoREPUVE);
                //soporte.UpLoading(driver.FindElement(By.XPath(KOS_Compliance.Investigacion_VIN_REPUVE_CargarRespaldoREPUVE)), objetosComplians.Investigacion_VIN_REPUVE_CargarRespaldoREPUVE);
                //soporte.SendText(driver, "XPath", KOS_Compliance.Investigacion_VIN_REPUVE_CargarRespaldoREPUVE, objetosComplians.Investigacion_VIN_REPUVE_CargarRespaldoREPUVE);
                soporte.ObtenerEvidenciaCaso(driver, documento, "CARGA RESPALDO REPUVE", objetosLogin.CasoPrueba);
                
            }
            catch
            {
                soporte.ObtenerEvidenciaCaso(driver, documento, "¡OCURRIO UN PROBLEMA!, NO SE ENCONTRO LA OPCIÓN 'CARGA RESPALDO REPUVE' " + KOS_Compliance.Investigacion_VIN_REPUVE_CargarRespaldoREPUVE + "", objetosLogin.CasoPrueba);
                Thread.Sleep(sleepTimerFail);
                resultadoKOSCompliance = false;
                // CERRAR NAVEGADOR
                soporte.CerrarDriver(driver);
                soporte.CerrarDocumento(documento);
            }

            /////////////////////////
            resultadoKOSCompliance = true;
            // CERRAR NAVEGADOR
            soporte.CerrarDriver(driver);
            soporte.CerrarDocumento(documento);
            #endregion

            #endregion
        }

        // OBTENER RESULTADO DEL PROCESO DE WINGMAN
        #region OBTENER RESULTADO DEL PROCESO DE WINGMAN
        public bool ObtenerResultadoresultadoKOSCompliance()
        {
            return resultadoKOSCompliance;
        }
        #endregion

        // LLAMAR LISTA PARA EL DATAPOOL DE LOGIN
        #region Lista Usuarios
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
                                 OpcionIngreso = row["OpcionIngreso"].Cast<string>(),
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
        #endregion

        // LLAMAR LISTA PARA EL DATAPOOL "WINGMAN CONFIRMAR INSPECCIÓN"
        #region Lista KOS Wingman Confirmar Inspeccion
        public List<Objects.ComplianceObject> ListaKOSCompliance(string pathDelFicheroExcel)
        {
            var book = new ExcelQueryFactory(Path.GetFullPath("..\\..\\..\\KavakoWebBotTools\\DataPool\\" + pathDelFicheroExcel));
            var resultado = (from row in book.Worksheet("Compliance")
                             let item = new Objects.ComplianceObject
                             {
                                 Funnel_Bandeja = row["Funnel_Bandeja"].Cast<string>(),
                                 Funnel_Ficha_GuardarCambios = row["Funnel_Bandeja"].Cast<string>(),
                                 //Funnel_Ficha_IconoCerrar = row[""].Cast<string>(),
                                 //FunnelAdmin_BandejaResultados = row[""].Cast<string>(),
                                 //FunnelAdmin_Buscar = row[""].Cast<string>(),
                                 //FunnelAdmin_Ficha_GuardarCambios = row[""].Cast<string>(),
                                 //FunnelAdmin_Ficha_IconoCerrar = row[""].Cast<string>(),
                                 //FunnelAdmin_Ficha_Investigador = row[""].Cast<string>(),
                                 //FunnelAdmin_ListaBuscarPor = row[""].Cast<string>(),
                                 //Investigacion_Bandeja = row[""].Cast<string>(),
                                 //Investigacion_TC_IconoTC = row[""].Cast<string>(),
                                 //Investigacion_VIN_REPUVE_TieneReporteRoboIlicito_Si = row["Investigacion_VIN_REPUVE_TieneReporteRoboIlicito_Si"].Cast<string>(),
                                 //Investigacion_VIN_CoincideConChasis_No = row[""].Cast<string>(),
                                 Investigacion_VIN_CoincideConChasis_Si = row["Investigacion_VIN_CoincideConChasis_Si"].Cast<string>(),
                                 //Investigacion_VIN_CoincideConChasis_SinChasisSinCarnet = row[""].Cast<string>(),
                                 Investigacion_VIN_EscribeNumeroVIN = row["Investigacion_VIN_EscribeNumeroVIN"].Cast<string>(),
                                 //Investigacion_VIN_IconoVin = row[""].Cast<string>(),
                                 //Investigacion_VIN_RAPI_LinkNoAbre = row[""].Cast<string>(),
                                 //Investigacion_VIN_RAPI_TieneReporteRoboIlicito_CargarRespaldoRAPI = row[""].Cast<string>(),
                                 //Investigacion_VIN_RAPI_TieneReporteRoboIlicito_No = row[""].Cast<string>(),
                                 //Investigacion_VIN_RAPI_TieneReporteRoboIlicito_RechazarInspeccion = row[""].Cast<string>(),
                                 //Investigacion_VIN_RAPI_TieneReporteRoboIlicito_Si = row[""].Cast<string>(),
                                 Investigacion_VIN_REPUVE_CargarRespaldoREPUVE = row["Investigacion_VIN_REPUVE_CargarRespaldoREPUVE"].Cast<string>(),
                                 Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Estado = row["Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Estado"].Cast<string>(),
                                 //Investigacion_VIN_REPUVE_ExistePlacaRegistrada_No = row["Investigacion_VIN_REPUVE_ExistePlacaRegistrada_No"].Cast<string>(),
                                 Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Placa = row["Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Placa"].Cast<string>(),
                                 Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Si = row["Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Si"].Cast<string>(),
                                 //Investigacion_VIN_REPUVE_LinkNoAbre = row[""].Cast<string>(),
                                 //Investigacion_VIN_REPUVE_ModeloCoincideConREPUVE_No = row[""].Cast<string>(),
                                 //Investigacion_VIN_REPUVE_ModeloCoincideConREPUVE_Si = row[""].Cast<string>(),
                                 Investigacion_VIN_REPUVE_TieneReporteRoboIlicito_BotonRechazar = row["Investigacion_VIN_REPUVE_TieneReporteRoboIlicito_BotonRechazar"].Cast<string>()
                                 //Investigacion_VIN_REPUVE_TieneReporteRoboIlicito_No = row[""].Cast<string>(),
                                 //Investigacion_VIN_Siguiente = row[""].Cast<string>(),
                                 //PestanhiaNavegacionDocumentos = row[""].Cast<string>(),
                                 //PestanhiaNavegacionFunnel = row[""].Cast<string>(),
                                 //PestanhiaNavegacionFunnelAdmin = row[""].Cast<string>(),
                                 //PestanhiaNavegacionInvestigacion = row["PestanhiaNavegacionInvestigacion"].Cast<string>()
                             }
                             select item).ToList();
            book.Dispose();
            return resultado;
        }
        #endregion*/
    }
}
