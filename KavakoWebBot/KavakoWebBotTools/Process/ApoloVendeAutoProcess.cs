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

namespace KavakoWebBotTools.Process
{
    public class ApoloVendeAutoProcess
    {
        int sleepTimerFast = 3000;
        int sleepTimerMiddle = 5000;
        int sleepTimerSlow = 7000;

        private bool resultadoVendeAuto;

        // INSTANCIA DE OBJETOS 
        Objects.LoginObjects objetosLogin = new Objects.LoginObjects();
        Objects.ApoloVendeAutoObjects objetosApoloVendeAuto = new Objects.ApoloVendeAutoObjects();
        Elements.LoginElements elementosLogin = new Elements.LoginElements();
        Process.LoginProcess procesoLogin = new Process.LoginProcess();
        Elements.ApoloVendeAutoElements elementosApoloVendeAuto = new Elements.ApoloVendeAutoElements();
        Validations.ApoloVendeAutoValidations validacionApoloVendeAuto = new Validations.ApoloVendeAutoValidations();

        ChatBotSuitTools.Commons.Actions soporte = new ChatBotSuitTools.Commons.Actions();


        // LOGICA PARA VENDER AUTO DE APOLO
        public void Apolo_01_VenderAuto_HP(Objects.LoginObjects objetosLogin, Objects.ApoloVendeAutoObjects objetosApoloVendeAuto, string numeroCaso)
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

            // ESPERAR A QUE SE PRESENTE EL ELEMENTO
            //Thread.Sleep(sleepTimerFast);

            // VALIDAR QUE EXISTAN EL BOTON INICIAL PARA LA COMPRA
            if (validacionApoloVendeAuto.ValidarBotonVendeTuAuto(driver))
            {

                // DAR CLIC AL BOTON DE "VENDE TU AUTO"
                soporte.ObtenerEvidenciaCaso(driver, documento, "DAR CLIC AL BOTON DE VENDE TU AUTO", objetosLogin.CasoPrueba);
                elementosApoloVendeAuto.BotonVendeTuAuto(driver).Click();
                Thread.Sleep(sleepTimerFast);

                // VALIDAR QUE EXISTA EL BOTON "COTIZAR MI AUTO"
                if(validacionApoloVendeAuto.ValidarBotonCotizarMiAuto(driver))
                {
                    soporte.ObtenerEvidenciaCaso(driver, documento, "DAR CLIC AL BOTON COTIZAR MI AUTO", objetosLogin.CasoPrueba);
                    elementosApoloVendeAuto.BotonCotizarMiAuto(driver).Click();
                    Thread.Sleep(sleepTimerMiddle);

                    if(validacionApoloVendeAuto.ValidarAnioAuto(driver))
                    {
                       

                        // SELECCIONAR EL AÑO DEL AUTO
                        soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONAR EL AÑO DEL AUTO", objetosLogin.CasoPrueba);
                        elementosApoloVendeAuto.AnioAuto(driver, objetosApoloVendeAuto.Anio).Click();
                        Thread.Sleep(sleepTimerFast);

                        if(validacionApoloVendeAuto.ValidarMarcaAuto(driver))
                        {
                            // SELECCIONAR LA MARCA DEL AUTO
                            soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONAR MARCA DEL AUTO", objetosLogin.CasoPrueba);
                            elementosApoloVendeAuto.MarcaAuto(driver, objetosApoloVendeAuto.Marca).Click();
                            Thread.Sleep(sleepTimerFast);

                            if(validacionApoloVendeAuto.ValidarModeloAuto(driver))
                            {
                                // SELECCIONAR MODELO DEL AUTO
                                soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONAR MODELO DEL AUTO", objetosLogin.CasoPrueba);
                                elementosApoloVendeAuto.ModeloAuto(driver, objetosApoloVendeAuto.Modelo).Click();
                                Thread.Sleep(sleepTimerMiddle);

                                if (validacionApoloVendeAuto.ValidarVersionAuto(driver))
                                {
                                    // SELECCIONAR VERSIÓN DEL AUTO
                                    soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONAR VERSIÓN DEL AUTO", objetosLogin.CasoPrueba);
                                    elementosApoloVendeAuto.VersionAuto(driver, objetosApoloVendeAuto.Version).Click();
                                    Thread.Sleep(sleepTimerFast);

                                    if(validacionApoloVendeAuto.ValidarColorAuto(driver))
                                    {
                                        // SELECCIONAR COLOR DEL AUTO
                                        soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONAR COLOR DEL AUTO", objetosLogin.CasoPrueba);
                                        elementosApoloVendeAuto.ColorAuto(driver, objetosApoloVendeAuto.Color).Click();
                                        Thread.Sleep(sleepTimerFast);

                                        if(validacionApoloVendeAuto.ValidarKilometrajeAuto(driver))
                                        {
                                            // CAPTURAR KILOMETRAJE DEL AUTO
                                            elementosApoloVendeAuto.KilometrajeAuto(driver).SendKeys(objetosApoloVendeAuto.Kilometraje);
                                            soporte.ObtenerEvidenciaCaso(driver, documento, "CAPTURAR KILOMETRAJE DEL AUTO", objetosLogin.CasoPrueba);
                                            Thread.Sleep(sleepTimerFast);

                                            // DAR CLIC AL BOTON "SIGUIENTE"
                                            elementosApoloVendeAuto.BotonSiguiente(driver).Click();
                                            Thread.Sleep(sleepTimerFast);

                                            if(validacionApoloVendeAuto.ValidarUbicacionCP(driver))
                                            {
                                                // CAPTURAR CODIGO POSTAL DEL CAMPO "¿Dónde esta ubicado tu auto?"
                                                elementosApoloVendeAuto.CodigoPostal(driver).SendKeys(objetosApoloVendeAuto.CodigoPostalAuto);
                                                soporte.ObtenerEvidenciaCaso(driver, documento, "CAPTURAR UBICACIÓN DEL AUTO", objetosLogin.CasoPrueba);
                                                Thread.Sleep(sleepTimerFast);

                                                // DAR CLIC AL BOTON "SIGUIENTE"
                                                elementosApoloVendeAuto.BotonSiguiente(driver).Click();
                                                Thread.Sleep(sleepTimerFast);

                                                if(validacionApoloVendeAuto.ValidarDatosPropietario(driver))
                                                {
                                                    // CAPTURAR DATOS DEL VENDEDOR
                                                    elementosApoloVendeAuto.NombrePropietario(driver).SendKeys(objetosApoloVendeAuto.NombrePropietario);
                                                    elementosApoloVendeAuto.EmailPropietario(driver).SendKeys(objetosApoloVendeAuto.EmailPropietario);
                                                    elementosApoloVendeAuto.TelefonoPropietario(driver).SendKeys(objetosApoloVendeAuto.TelefonoPropietario);
                                                    soporte.ObtenerEvidenciaCaso(driver, documento, "CAPTURAR DATOS DEL VENDEDOR", objetosLogin.CasoPrueba);
                                                    Thread.Sleep(sleepTimerFast);

                                                    // CEPTAR TERMINOS Y CONDICIONES DE LA OFERTA
                                                    elementosApoloVendeAuto.AceptarTeminosCondiciones(driver).Click();
                                                    soporte.ObtenerEvidenciaCaso(driver, documento, "CAPTURAR DATOS DEL VENDEDOR", objetosLogin.CasoPrueba);

                                                    // RECUERDA QUE ESTE TIEMPO EXTENDIDO ES PARA CAPTURAR MANUALMENTE EL CAPTCHA Y DARLE TIEMPO A QUE SE CARGUE LA INFORMACION QUE PROCESA KAVAK

                                                    // ESPERA A QUE CARGUE LA PAGINA
                                                    new WebDriverWait(driver, TimeSpan.FromSeconds(sleepTimerSlow)).Until(ExpectedConditions.ElementExists(By.XPath("//li[1]/a/div/div/div/div/div")));


                                                    if(validacionApoloVendeAuto.ValidarOfertaKavak(driver))
                                                    {
                                                        // SELECCIONAR OFERTA KAVAK
                                                        elementosApoloVendeAuto.OfertaKavak(driver, objetosApoloVendeAuto.OfertaKavak).Click();
                                                        soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONAR OFERTA KAVAK", objetosLogin.CasoPrueba);
                                                        Thread.Sleep(sleepTimerFast);

                                                        // DAR CLIC AL BOTON "SIGUIENTE"
                                                        elementosApoloVendeAuto.BotonAceptarOfertaSiguiente(driver).Click();
                                                        Thread.Sleep(sleepTimerMiddle);

                                                        if(validacionApoloVendeAuto.ValidarLugarDeInspeccionAuto(driver))
                                                        {
                                                            // SELECCIONA UN CENTRO KAVAK PARA LA INSPECCION DE TU AUTO
                                                            soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONA UN CENTRO KAVAK PARA LA INSPECCION DE TU AUTO", objetosLogin.CasoPrueba);
                                                            Thread.Sleep(sleepTimerSlow);

                                                            //// ESPERA A QUE EL LA LISTA SEA VISIBLE
                                                            //new WebDriverWait(driver, TimeSpan.FromSeconds(sleepTimerSlow)).Until(ExpectedConditions.ElementExists(By.XPath("//li[1]/a/div/div/div[2]/div/div/h5")));

                                                            // VALIDAR SI LA INSPECCION DEL AUTO ES A DOMICILIO O EN UN CENTRO KAVAK
                                                            if (objetosApoloVendeAuto.LugarInspeccionAuto == "Mi domicilio / oficina")
                                                            {
                                                                // SELECCIONA LA INSPECCION A DOMICILIO
                                                                elementosApoloVendeAuto.LugarInspeccionAuto(driver, objetosApoloVendeAuto.LugarInspeccionAuto).Click();
                                                                Thread.Sleep(sleepTimerFast);

                                                                // CAPTURAR LA UBICACION DE LA INSPECCION DEL AUTO
                                                                elementosApoloVendeAuto.InspeccionCalle(driver).SendKeys(objetosApoloVendeAuto.InspeccionCalle);
                                                                elementosApoloVendeAuto.InspeccionNoExterior(driver).SendKeys(objetosApoloVendeAuto.InspeccionNoExterior);
                                                                elementosApoloVendeAuto.InspeccionNoInterior(driver).SendKeys(objetosApoloVendeAuto.InspeccionNoInterior);
                                                                elementosApoloVendeAuto.InspeccionCodigoPostal(driver).SendKeys(objetosApoloVendeAuto.InspeccionCodigoPostal);
                                                                // SELECCIONAR LA COLONIA

                                                                soporte.ObtenerEvidenciaCaso(driver, documento, "CAPTURAR LA UBICACION DE LA INSPECCION DEL AUTO", objetosLogin.CasoPrueba);
                                                                Thread.Sleep(sleepTimerFast);
                                                                // DAR CLIC AL BOTON DE SIGUIENTE
                                                                elementosApoloVendeAuto.InspeccionBotonSiguiente(driver).Click();
                                                                Thread.Sleep(sleepTimerSlow);
                                                            }

                                                            // SELECCIONA UN CENTRO KAVAK PARA LA INSPECCIÓN DEL AUTO
                                                            elementosApoloVendeAuto.LugarInspeccionAuto(driver, objetosApoloVendeAuto.LugarInspeccionAuto).Click();
                                                            soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONA UN CENTRO KAVAK PARA LA INSPECCIÓN DEL AUTO", objetosLogin.CasoPrueba);
                                                            Thread.Sleep(sleepTimerFast);

                                                            // DAR CLIC AL BOTON "SIGUIENTE" UNA VEZ SELECCIONADA UN CENTRO KAVAK
                                                            elementosApoloVendeAuto.BotonSiguienteCentroKavak(driver).Click();
                                                            Thread.Sleep(sleepTimerSlow);

                                                            if(validacionApoloVendeAuto.ValidarCitaFechaHora(driver))
                                                            {
                                                                // VALIDAR SI LA FECHA ES "AGENDAR EN OTRA FECHA"
                                                                if (objetosApoloVendeAuto.CitaFecha == "Agendar en otra fecha")
                                                                {
                                                                    // SELECCIONAR FECHA DE LA CITA DE LA INSPECCION DEL AUTO
                                                                    elementosApoloVendeAuto.CitaFecha(driver, objetosApoloVendeAuto.CitaFecha).Click();

                                                                    soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONA AGENDAR EN OTRA FECHA", objetosLogin.CasoPrueba);
                                                                    Thread.Sleep(sleepTimerFast);

                                                                    // DAR CLIC AL BOTON "SIGUIENTE"
                                                                    elementosApoloVendeAuto.BotonSiguienteCita(driver).Click();
                                                                }

                                                                // SELECCIONAR FECHA DE LA CITA DE LA INSPECCION DEL AUTO
                                                                elementosApoloVendeAuto.CitaFecha(driver, objetosApoloVendeAuto.CitaFecha).Click();
                                                                Thread.Sleep(sleepTimerMiddle);

                                                                // SELECCIONA LA HORA DE LA INSPECCIÓN
                                                                elementosApoloVendeAuto.CitaHoraDisponible(driver).Click();
                                                                Thread.Sleep(sleepTimerMiddle);

                                                                if (elementosApoloVendeAuto.CitaHoraDisponible(driver).Text == objetosApoloVendeAuto.CitaHora)
                                                                {
                                                                    // SELECCIONA LA HORA DE LA INSPECCIÓN
                                                                    elementosApoloVendeAuto.CitaHora(driver, objetosApoloVendeAuto.CitaHora).Click();
                                                                    Thread.Sleep(sleepTimerMiddle);

                                                                }

                                                                soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONA FECHA Y HORA DE LA INSPECCIÓN DEL AUTO", objetosLogin.CasoPrueba);
                                                                Thread.Sleep(sleepTimerFast);

                                                                // DAR CLIC AL BOTON DE "SIGUIENTE"
                                                                elementosApoloVendeAuto.BotonSiguienteCita(driver).Click();
                                                                Thread.Sleep(sleepTimerMiddle);

                                                                if(validacionApoloVendeAuto.ValidarArchivosAdjuntos(driver))
                                                                {
                                                                    // ADJUNTA DOCUMENTO 1

                                                                    // ADJUNTA DOCUMENTO 1

                                                                    soporte.ObtenerEvidenciaCaso(driver, documento, "ADJUNTAR DOCUMENTACIÓN, ESTE PASO ES OPCIONAL", objetosLogin.CasoPrueba);
                                                                    Thread.Sleep(sleepTimerFast);

                                                                    // DAR CLIC AL BOTÓN "SIGUIENTE"
                                                                    elementosApoloVendeAuto.BotonSiguienteAdjuntado(driver).Click();
                                                                    Thread.Sleep(sleepTimerMiddle);

                                                                    if(validacionApoloVendeAuto.ValidarInformacionFinal(driver))
                                                                    {
                                                                        soporte.ObtenerEvidenciaCaso(driver, documento, "INFORMACIÓN FINAL Y COMENTARIOS", objetosLogin.CasoPrueba);
                                                                        Thread.Sleep(sleepTimerFast);

                                                                        // VISUALIZAR LA SECCIÓN DE "VER MI OFERTA"
                                                                        elementosApoloVendeAuto.VerMiOferta(driver).Click();

                                                                        soporte.ObtenerEvidenciaCaso(driver, documento, "VISUALIZAR MI OFERTA", objetosLogin.CasoPrueba);
                                                                        Thread.Sleep(sleepTimerFast);

                                                                        // VISUALIZAR "RESUMEN DE INSPECCION"
                                                                        elementosApoloVendeAuto.VerResumenInspeccion(driver).Click();

                                                                        soporte.ObtenerEvidenciaCaso(driver, documento, "RESUMEN DE INSPECCION", objetosLogin.CasoPrueba);
                                                                        Thread.Sleep(sleepTimerFast);

                                                                        // REALIZA SCROLL
                                                                        soporte.ScrollTo(driver, 999, 9999);

                                                                        // CAPTURAR COMENTARIOS
                                                                        elementosApoloVendeAuto.ComentariosFinales(driver).SendKeys(objetosApoloVendeAuto.ComentariosFinales);
                                                                        Thread.Sleep(sleepTimerMiddle);

                                                                        // ESPERA A QUE EL BOTON SEA VISIBLE
                                                                        new WebDriverWait(driver, TimeSpan.FromSeconds(sleepTimerSlow)).Until(ExpectedConditions.ElementExists(By.XPath("(//button[@type='button'])[6]")));

                                                                        //ENVIAR COMENTARIOS FINALES
                                                                        elementosApoloVendeAuto.BotonEnviarComentariosFinales(driver).Click();
                                                                        Thread.Sleep(sleepTimerSlow);

                                                                        soporte.ObtenerEvidenciaCaso(driver, documento, "FIN DE LA PRUEBA - PRUEBA EXITOSA", objetosLogin.CasoPrueba);
                                                                        Thread.Sleep(sleepTimerFast);

                                                                        resultadoVendeAuto = true;

                                                                        // CERRAR NAVEGADOR
                                                                        soporte.CerrarDriver(driver);
                                                                        soporte.CerrarDocumento(documento);
                                                                    }
                                                                    else
                                                                    {
                                                                        soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO", objetosLogin.CasoPrueba);
                                                                        Thread.Sleep(sleepTimerFast);

                                                                        resultadoVendeAuto = false;

                                                                        // CERRAR NAVEGADOR
                                                                        soporte.CerrarDriver(driver);
                                                                        soporte.CerrarDocumento(documento);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO", objetosLogin.CasoPrueba);
                                                                    Thread.Sleep(sleepTimerFast);

                                                                    resultadoVendeAuto = false;

                                                                    // CERRAR NAVEGADOR
                                                                    soporte.CerrarDriver(driver);
                                                                    soporte.CerrarDocumento(documento);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO", objetosLogin.CasoPrueba);
                                                                Thread.Sleep(sleepTimerFast);

                                                                resultadoVendeAuto = false;

                                                                // CERRAR NAVEGADOR
                                                                soporte.CerrarDriver(driver);
                                                                soporte.CerrarDocumento(documento);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO", objetosLogin.CasoPrueba);
                                                            Thread.Sleep(sleepTimerFast);

                                                            resultadoVendeAuto = false;

                                                            // CERRAR NAVEGADOR
                                                            soporte.CerrarDriver(driver);
                                                            soporte.CerrarDocumento(documento);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO", objetosLogin.CasoPrueba);
                                                        Thread.Sleep(sleepTimerFast);

                                                        resultadoVendeAuto = false;

                                                        // CERRAR NAVEGADOR
                                                        soporte.CerrarDriver(driver);
                                                        soporte.CerrarDocumento(documento);
                                                    }
                                                }
                                                else
                                                {
                                                    soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO", objetosLogin.CasoPrueba);
                                                    Thread.Sleep(sleepTimerFast);

                                                    resultadoVendeAuto = false;

                                                    // CERRAR NAVEGADOR
                                                    soporte.CerrarDriver(driver);
                                                    soporte.CerrarDocumento(documento);
                                                }
                                            }
                                            else
                                            {
                                                soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO", objetosLogin.CasoPrueba);
                                                Thread.Sleep(sleepTimerFast);

                                                resultadoVendeAuto = false;

                                                // CERRAR NAVEGADOR
                                                soporte.CerrarDriver(driver);
                                                soporte.CerrarDocumento(documento);
                                            }
                                        }
                                        else
                                        {
                                            soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO", objetosLogin.CasoPrueba);
                                            Thread.Sleep(sleepTimerFast);

                                            resultadoVendeAuto = false;

                                            // CERRAR NAVEGADOR
                                            soporte.CerrarDriver(driver);
                                            soporte.CerrarDocumento(documento);
                                        }
                                    }
                                    else
                                    {
                                        soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO", objetosLogin.CasoPrueba);
                                        Thread.Sleep(sleepTimerFast);

                                        resultadoVendeAuto = false;

                                        // CERRAR NAVEGADOR
                                        soporte.CerrarDriver(driver);
                                        soporte.CerrarDocumento(documento);
                                    }
                                }
                                else
                                {
                                    soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO", objetosLogin.CasoPrueba);
                                    Thread.Sleep(sleepTimerFast);

                                    resultadoVendeAuto = false;

                                    // CERRAR NAVEGADOR
                                    soporte.CerrarDriver(driver);
                                    soporte.CerrarDocumento(documento);
                                }
                            }
                            else
                            {
                                soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO", objetosLogin.CasoPrueba);
                                Thread.Sleep(sleepTimerFast);

                                resultadoVendeAuto = false;

                                // CERRAR NAVEGADOR
                                soporte.CerrarDriver(driver);
                                soporte.CerrarDocumento(documento);
                            }
                        }
                        else
                        {
                            soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO", objetosLogin.CasoPrueba);
                            Thread.Sleep(sleepTimerFast);

                            resultadoVendeAuto = false;

                            // CERRAR NAVEGADOR
                            soporte.CerrarDriver(driver);
                            soporte.CerrarDocumento(documento);
                        }
                    }
                    else
                    {
                        soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO", objetosLogin.CasoPrueba);
                        Thread.Sleep(sleepTimerFast);

                        resultadoVendeAuto = false;

                        // CERRAR NAVEGADOR
                        soporte.CerrarDriver(driver);
                        soporte.CerrarDocumento(documento);
                    }
                }
                else
                {
                    soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE VISUALIZO EL BOTÓN COTIZA TU AUTO", objetosLogin.CasoPrueba);
                    Thread.Sleep(sleepTimerFast);

                    resultadoVendeAuto = false;

                    // CERRAR NAVEGADOR
                    soporte.CerrarDriver(driver);
                    soporte.CerrarDocumento(documento);
                } 
   
            }
            else
            {
                soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE VISUALIZO EL BOTÓN VENDE TU AUTO", objetosLogin.CasoPrueba);
                Thread.Sleep(sleepTimerFast);

                resultadoVendeAuto = false;

                // CERRAR NAVEGADOR
                soporte.CerrarDriver(driver);
                soporte.CerrarDocumento(documento);
            }
            

        }


        // OBTENER RESULTADO DEL PROCESO DE VENDE TU AUTO
        #region OBTENER RESULTADO DEL PROCESO DE VENDE TU AUTO
        public bool ObtenerResultadoVendeAuto()
        {
            return resultadoVendeAuto;
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

        // LLAMAR LISTA PARA EL DATAPOOL "VENTA AUTOS"
        #region Lista APOLO Vende Auto
        public List<Objects.ApoloVendeAutoObjects> ListaVendeAuto(string pathDelFicheroExcel)
        {
            var book = new ExcelQueryFactory(Path.GetFullPath("..\\..\\..\\KavakoWebBotTools\\DataPool\\" + pathDelFicheroExcel));
            var resultado = (from row in book.Worksheet("VendeAuto")
                             let item = new Objects.ApoloVendeAutoObjects
                             {
                                 Anio = row["Anio"].Cast<string>(),
                                 Marca = row["Marca"].Cast<string>(),
                                 Modelo = row["Modelo"].Cast<string>(),
                                 Version = row["Version"].Cast<string>(),
                                 Color = row["Color"].Cast<string>(),
                                 Kilometraje = row["Kilometraje"].Cast<string>(),
                                 CodigoPostalAuto = row["CodigoPostalAuto"].Cast<string>(),
                                 NombrePropietario = row["NombrePropietario"].Cast<string>(),
                                 EmailPropietario = row["EmailPropietario"].Cast<string>(),
                                 TelefonoPropietario = row["TelefonoPropietario"].Cast<string>(),
                                 AceptarTeminosCondiciones = row["AceptarTeminosCondiciones"].Cast<string>(),
                                 OfertaKavak = row["OfertaKavak"].Cast<string>(),
                                 LugarInspeccionAuto = row["LugarInspeccionAuto"].Cast<string>(),
                                 InspeccionCalle = row["InspeccionCalle"].Cast<string>(),
                                 InspeccionNoExterior = row["InspeccionNoExterior"].Cast<string>(),
                                 InspeccionNoInterior = row["InspeccionNoInterior"].Cast<string>(),
                                 InspeccionCodigoPostal = row["InspeccionCodigoPostal"].Cast<string>(),
                                 InspeccionColonia = row["InspeccionColonia"].Cast<string>(),
                                 CitaFecha = row["CitaFecha"].Cast<string>(),
                                 CitaHora = row["CitaHora"].Cast<string>(),
                                 ArchivoAdjunto1 = row["ArchivoAdjunto1"].Cast<string>(),
                                 ArchivoAdjunto2 = row["ArchivoAdjunto2"].Cast<string>(),
                                 Resumen = row["Resumen"].Cast<string>(),
                                 ComentariosFinales = row["ComentariosFinales"].Cast<string>()
                             }
                             select item).ToList();
            book.Dispose();
            return resultado;
        }
        #endregion
    }
}