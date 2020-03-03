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
    public class KOSWingmanProcess
    {
        int sleepTimerFast = 2500;
        int sleepTimerMiddle = 3500;
        int sleepTimerSlow = 7000;
        int sleepTimerFail = 20000;

        private bool resultadoKOSWingman;

        // INSTANCIA DE OBJETOS 
        Elements.KOSWingmanElements elementosKOSWingman = new Elements.KOSWingmanElements();
        Objects.KOSWingmanObjects objetosKOSWingman = new Objects.KOSWingmanObjects();

        Elements.KOSHomeElements elementosKOSHome = new Elements.KOSHomeElements();

        Objects.LoginObjects objetosLogin = new Objects.LoginObjects();
        Process.LoginProcess procesoLogin = new Process.LoginProcess();

        ChatBotSuitTools.Commons.Actions soporte = new ChatBotSuitTools.Commons.Actions();

        // LOGICA PARA CONFIRMAR INSPECCIÓN
        public void KOS_01_ConfirnarInspeccion_HP(Objects.LoginObjects objetosLogin, Objects.KOSWingmanObjects objetosKOSWingman, string numeroCaso)
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
            // CAPTURAR LOS FILTROS DE BUSQUEDA DE LA TARJETA
            try
            {
                soporte.ObtenerEvidenciaCaso(driver, documento, "CAPTURAR FILTROS DE LA BUSQUEDA", objetosLogin.CasoPrueba);

                // CAPTURAR EL CAMPO DE "BUSQUEDA"
                elementosKOSWingman.CampoBusqueda(driver).Clear();
                elementosKOSWingman.CampoBusqueda(driver).SendKeys(objetosKOSWingman.Buscar);
                Thread.Sleep(sleepTimerFast);

                // SELECCIONAR LISTA "CENTRO"
                soporte.Loading(elementosKOSWingman.ListaCentros(driver));
                new SelectElement(elementosKOSWingman.ListaCentros(driver)).SelectByText(objetosKOSWingman.ListaCentros);
                Thread.Sleep(sleepTimerMiddle);

                // VALIDAR SI SE EDITARA LA TARJETA DEL CLIENTE.
                if(objetosKOSWingman.EditarFicha == "Si")
                {
                    try
                    {
                        // SELECCIONAR TARJETA TARJETA
                        soporte.Loading(elementosKOSWingman.BandejaInspeccionesAgendadas(driver, objetosKOSWingman.Buscar));
                        elementosKOSWingman.BandejaInspeccionesAgendadas(driver, objetosKOSWingman.Buscar).Click();
                        Thread.Sleep(sleepTimerMiddle);

                        try
                        {
                            // ASIGNAR WINGMAN AL CLIENTE
                            new SelectElement(elementosKOSWingman.WingmanAsignadoInspeccion(driver)).SelectByText(objetosKOSWingman.WingmanAsignadoInspeccion);
                            Thread.Sleep(sleepTimerMiddle);

                            // VALIDAR SI SE EDITARAN DATOS DEL CLIENTE
                            if (objetosKOSWingman.EditarDatosCliente == "Si")
                            {
                                try
                                {
                                    soporte.ObtenerEvidenciaCaso(driver, documento, "DAR CLIC AL ICONO DE 'EDITAR'", objetosLogin.CasoPrueba);
                                    // DAR CLIC AL ICONO DE EDITAR
                                    elementosKOSWingman.IconoEditarDatosCliente(driver).Click();
                                    Thread.Sleep(sleepTimerFast);
                                    try
                                    {
                                        soporte.ObtenerEvidenciaCaso(driver, documento, "SE INICIA CON LA EDICIÓN DE LOS DATOS DEL CLIENTE", objetosLogin.CasoPrueba);

                                        // LIMPIAR Y CAPTURAR EL CAMPO "NOMBRE" DEL CLIENTE
                                        elementosKOSWingman.EditarNombreCliente(driver).Clear();
                                        elementosKOSWingman.EditarNombreCliente(driver).SendKeys(objetosKOSWingman.NombreCliente);
                                        // LIMPIAR Y CAPTURAR EL CAMPO "APELLIDO" DEL CLIENTE
                                        elementosKOSWingman.EditarApellidoCliente(driver).Clear();
                                        elementosKOSWingman.EditarApellidoCliente(driver).SendKeys(objetosKOSWingman.ApellidoCliente);
                                        // LIMPIAR Y CAPTURAR EL CAMPO "TELEFONO" DEL CLIENTE
                                        elementosKOSWingman.EditarTelefonoCliente(driver).Clear();
                                        elementosKOSWingman.EditarTelefonoCliente(driver).SendKeys(objetosKOSWingman.TelefonoCliente);

                                        // VALIDAR SI EL CLIENTE SERA ORGANICO "CHECK - CLIENTE ORGANICO" 
                                        if (objetosKOSWingman.ClienteOrganico == "Si")
                                        {
                                            // DAR CLIC AL CHECK "CLIENTE ORGANICO"
                                            elementosKOSWingman.EditarCheckBoxClienteOrganico(driver).Click();
                                        }

                                        // LIMPIAR Y CAPTURAR EL CAMPO "CALLE" DEL CLIENTE
                                        elementosKOSWingman.EditarCalleCliente(driver).Clear();
                                        elementosKOSWingman.EditarCalleCliente(driver).SendKeys(objetosKOSWingman.EditarCalleCliente);
                                        // LIMPIAR Y CAPTURAR EL CAMPO "NÚMERO EXTERIOR" DEL CLIENTE
                                        elementosKOSWingman.EditarNumeroExteriorCliente(driver).Clear();
                                        elementosKOSWingman.EditarNumeroExteriorCliente(driver).SendKeys(objetosKOSWingman.EditarNumeroExterior);
                                        // LIMPIAR Y CAPTURAR EL CAMPO "NÚMERO INTERIOR" DEL CLIENTE
                                        elementosKOSWingman.EditarNumeroInteriorCliente(driver).Clear();
                                        elementosKOSWingman.EditarNumeroInteriorCliente(driver).SendKeys(objetosKOSWingman.EditarNumeroInterior);
                                        // LIMPIAR Y CAPTURAR EL CAMPO "COLONIA" DEL CLIENTE
                                        elementosKOSWingman.EditarColoniaCliente(driver).Clear();
                                        elementosKOSWingman.EditarColoniaCliente(driver).SendKeys(objetosKOSWingman.EditarColoniaCliente);
                                        // LIMPIAR Y CAPTURAR EL CAMPO "DELEGACIÓN" DEL CLIENTE
                                        elementosKOSWingman.EditarDelegacionCliente(driver).Clear();
                                        elementosKOSWingman.EditarDelegacionCliente(driver).SendKeys(objetosKOSWingman.EditarDelegacionCliente);
                                        // LIMPIAR Y CAPTURAR EL CAMPO "CP" DEL CLIENTE
                                        elementosKOSWingman.EditarCPCliente(driver).Clear();
                                        elementosKOSWingman.EditarCPCliente(driver).SendKeys(objetosKOSWingman.EditarCPCliente);

                                        soporte.ObtenerEvidenciaCaso(driver, documento, "", objetosLogin.CasoPrueba);

                                    }
                                    catch
                                    {
                                        soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO EL ELEMENTO A EDITAR DE LA SECCIÓN 'DATOS DEL CLIENTE'", objetosLogin.CasoPrueba);
                                        Thread.Sleep(sleepTimerFail);

                                        resultadoKOSWingman = false;

                                        // CERRAR NAVEGADOR
                                        soporte.CerrarDriver(driver);
                                        soporte.CerrarDocumento(documento);
                                    }
                                }
                                catch
                                {
                                    soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO EL ELEMENTO ICONO 'EDITAR DATOS DEL CLIENTE'" + elementosKOSWingman.IconoEditarDatosCliente(driver) + " ", objetosLogin.CasoPrueba);
                                    Thread.Sleep(sleepTimerFail);

                                    resultadoKOSWingman = false;

                                    // CERRAR NAVEGADOR
                                    soporte.CerrarDriver(driver);
                                    soporte.CerrarDocumento(documento);
                                }
                            } //  FIN DE LA EDICIÓN DE DATOS DEL CLIENTE

                            // VALIDAR SI SE REALIZARA LA "OFERTA MANUAL"
                            if (objetosKOSWingman.OfertaManual == "Si")
                            {
                                try
                                {
                                    // REALIZAR SCROLL
                                    soporte.ScrollToElement(driver, elementosKOSWingman.CheckOfertaManual(driver));

                                    soporte.ObtenerEvidenciaCaso(driver, documento, "DAR CLIC AL CHECKBOX DE 'OFERTA MANUAL'", objetosLogin.CasoPrueba);

                                    // REALIZAR CHECK EN EL CAMPO "OFERTA MANUAL"
                                    elementosKOSWingman.CheckOfertaManual(driver).Click();
                                    Thread.Sleep(sleepTimerFast);

                                    try
                                    {
                                        // REALIZAR SCROLL
                                        soporte.ScrollToElement(driver, elementosKOSWingman.FechaCalendario1OfertaManual(driver));
                                        Thread.Sleep(sleepTimerFast);

                                        elementosKOSWingman.SubirDocumentoOfertaManual(driver).SendKeys(objetosKOSWingman.SubirDocumentoOfertaManual);

                                        soporte.ObtenerEvidenciaCaso(driver, documento, "CAPTURA LOS DATOS CORRESPONDIENTES A LA SECCIÓN DE 'OFERTA MANUAL'", objetosLogin.CasoPrueba);

                                        // LIMPIAR Y CAPTURAR EL CAMPO "COMENTARIO" DE LA OFERTA MANUAL
                                        elementosKOSWingman.ComentariosOfertaManual(driver).Clear();
                                        elementosKOSWingman.ComentariosOfertaManual(driver).SendKeys(objetosKOSWingman.ComentariosOfertaManual);
                                        // SELECCIONAR EL CAMPO "MOTIVO" DE LA OFERTA MANUAL
                                        new SelectElement(elementosKOSWingman.ListaMotivoOfertaManual(driver)).SelectByText(objetosKOSWingman.ListaMotivoOfertaManual);
                                        // SELECCIONAR EL CAMPO "VERSION" DE LA OFERTA MANUAL
                                        //new SelectElement(elementosKOSWingman.ListaVersionOfertaManual(driver)).SelectByValue(objetosKOSWingman.ListaVersionOfertaManual);
                                        // LIMPIAR Y CAPTURAR EL CAMPO "KILOMETRAJE" DE LA OFERTA MANUAL
                                        elementosKOSWingman.KilometrajeOfertaManual(driver).Clear();
                                        elementosKOSWingman.KilometrajeOfertaManual(driver).SendKeys(objetosKOSWingman.KilometrajeOfertaManual);
                                        // SELECCIONAR "FECHA" DE LA OFERTA MANUAL
                                        elementosKOSWingman.FechaCalendario1OfertaManual(driver).Click();
                                        Thread.Sleep(sleepTimerFast);
                                        elementosKOSWingman.FechaCalendario2OfertaManual(driver, objetosKOSWingman.FechaCalendarioOfertaManual).Click();
                                        // SUBIR ARCHIVO
                                        elementosKOSWingman.SubirDocumentoOfertaManual(driver).SendKeys(objetosKOSWingman.SubirDocumentoOfertaManual);
                                        soporte.ObtenerEvidenciaCaso(driver, documento, "", objetosLogin.CasoPrueba);

                                        Thread.Sleep(sleepTimerFast);

                                    }
                                    catch
                                    {
                                        soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO EL ELEMENTO 'COMENTARIOS' "+ elementosKOSWingman.ComentariosOfertaManual(driver) + "DE LA SECCIÓN 'OFERTA MANUAL'", objetosLogin.CasoPrueba);
                                        Thread.Sleep(sleepTimerFail);

                                        resultadoKOSWingman = false;

                                        // CERRAR NAVEGADOR
                                        soporte.CerrarDriver(driver);
                                        soporte.CerrarDocumento(documento);
                                    }
                                }
                                catch
                                {
                                    soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO EL ELEMENTO CHECKBOX DE 'OFERTA MANUAL'"+ elementosKOSWingman.CheckOfertaManual(driver) + "DE LA SECCIÓN 'OFERTA MANUAL'", objetosLogin.CasoPrueba);
                                    Thread.Sleep(sleepTimerFail);

                                    resultadoKOSWingman = false;

                                    // CERRAR NAVEGADOR
                                    soporte.CerrarDriver(driver);
                                    soporte.CerrarDocumento(documento);
                                }
                            } // FIN DE LA EDICIÓN DE LA "OFERTA MANUAL"

                            // VALIDA SI SE EDITARAN LOS DATOS DE LA SECCION DE "LUGAR DE INSPECCIÓN"
                            if (objetosKOSWingman.EditarInspeccion == "Si")
                            {
                                // EDITAR LA SECCIÓN DIRECCIÓN DE INSPECCIÓN
                                try
                                {
                                    // REALIZAR SCROLL
                                    soporte.ScrollToElement(driver, elementosKOSWingman.FechaLimiteCalendario1(driver));

                                    // SELECCIONAR CAMPO LISTA DE "DIRECCION DE LA INSPECCION"
                                    new SelectElement(elementosKOSWingman.ListaDireccionInspeccion(driver)).SelectByText(objetosKOSWingman.ListaDireccionInspeccion);
                                    // DAR CLIC AL CAMPO DE "FECHA LIMITE"
                                    elementosKOSWingman.FechaLimiteCalendario1(driver).Click();
                                    elementosKOSWingman.FechaLimiteCalendario2(driver, objetosKOSWingman.FechaLimiteCalendarioInspeccion).Click();

                                    // SELECCIONAR UN HORA (ES VARIABLE, PUEDE HABER HORA O NO DISPONIBLE, GENERAR LA LOGICA PARA ESTE CAMPO)
                                    new SelectElement(elementosKOSWingman.ListaHora(driver)).SelectByText(objetosKOSWingman.ListaHoraInspeccion);

                                }
                                catch
                                {
                                    soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO EL ELEMENTO"+ elementosKOSWingman.ListaDireccionInspeccion(driver) + "CORRESPONDIENTE A 'DIRECCIÓN DE LA INSPECCIÓN'", objetosLogin.CasoPrueba);
                                    Thread.Sleep(sleepTimerFail);

                                    resultadoKOSWingman = false;

                                    // CERRAR NAVEGADOR
                                    soporte.CerrarDriver(driver);
                                    soporte.CerrarDocumento(documento);
                                }
                            } // FIN DE LA EDICIÓN DE LA SECCION "LUGAR DE INSPECCIÓN"

                            // SELECCIONAR EL ESTATUS 
                            try
                            {
                                soporte.ObtenerEvidenciaCaso(driver, documento, "SELECIONAR OPCION DEL CAMPO 'ESTATUS'", objetosLogin.CasoPrueba);

                                // SELECCIONA DE LA LISTA "ESTATUS" UNA OPCIÓN
                                new SelectElement(elementosKOSWingman.ListaEstatus(driver)).SelectByText(objetosKOSWingman.ListaEstatus);
                            }
                            catch
                            {
                                soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO"+ elementosKOSWingman.ListaEstatus(driver)+" CAMPO 'ESTATUS'", objetosLogin.CasoPrueba);
                                Thread.Sleep(sleepTimerFail);

                                resultadoKOSWingman = false;

                                // CERRAR NAVEGADOR
                                soporte.CerrarDriver(driver);
                                soporte.CerrarDocumento(documento);
                            }

                            // VALIDAR SI SE GUARDAN LOS CAMBIOS
                            if (objetosKOSWingman.Guardar == "Si")
                            {
                                Thread.Sleep(sleepTimerFast);

                                // REALIZAR SCROLL
                                soporte.ScrollToElement(driver, elementosKOSWingman.BotonGuardarDatosCliente(driver));

                                soporte.ObtenerEvidenciaCaso(driver, documento, "DAR CLIC AL BOTON DE 'GUARDAR'", objetosLogin.CasoPrueba);

                                // DAR CLIC AL BOTÓN DE "GUARDAR" - GUARDA ASIGNACIÓN DE LA TRAJETA
                                elementosKOSWingman.BotonGuardarDatosCliente(driver).Click();

                                Thread.Sleep(sleepTimerFast);

                            }
                            if (objetosKOSWingman.Guardar == "No")
                            {
                                soporte.ObtenerEvidenciaCaso(driver, documento, "CANCELAR EL GUARDADO DE LA INFORMACIÓN, DANDO CLIC AL ICONO DE 'CERRAR'", objetosLogin.CasoPrueba);

                                // DAR CLIC AL BOTON DE "CERRAR"
                                elementosKOSWingman.BotonCerrarDatosCliente(driver).Click();
                                Thread.Sleep(sleepTimerFast);

                                // VALIDAR CONFIRMACION
                                if (objetosKOSWingman.ConfirmarNoGuardar == "Si")
                                {
                                    soporte.ObtenerEvidenciaCaso(driver, documento, "CONFIRMAR EL CANCELADO DE GUARDADADO DE LA INFORMACIÓN, DANDO CLIC AL BOTON 'ACEPTAR'", objetosLogin.CasoPrueba);

                                    // DAR CLIC AL BOTÓN DE "ACEPTAR"
                                    elementosKOSWingman.BotonAceptarCerrarDatosCliente(driver).Click();
                                    Thread.Sleep(sleepTimerFast);

                                    soporte.ObtenerEvidenciaCaso(driver, documento, "SE DESCARTAN LOS CAMBIOS EFECTUADOS EN LA FICHA", objetosLogin.CasoPrueba);
                                    Thread.Sleep(sleepTimerFast);

                                    // DA CLIC AL ICONO DE "FLECHA HACIA DELANTE" DE LA FICHA DEL CLIENTE
                                    elementosKOSWingman.IconoFlechaHaciaDelante(driver).Click();
                                    Thread.Sleep(sleepTimerMiddle);
                                }
                                else
                                {
                                    // DAR CLIC AL BOTÓN DE "CANCELAR"
                                    elementosKOSWingman.BotonCancelarCerrarDatosCliente(driver).Click();
                                    Thread.Sleep(sleepTimerFast);

                                    soporte.ObtenerEvidenciaCaso(driver, documento, "SE CANCELA EL MENSAJE DE CONFIRMACION", objetosLogin.CasoPrueba);
                                    Thread.Sleep(sleepTimerFast);

                                    // REALIZAR SCROLL
                                    soporte.ScrollToElement(driver, elementosKOSWingman.BotonGuardarDatosCliente(driver));

                                    soporte.ObtenerEvidenciaCaso(driver, documento, "DAR CLIC AL BOTON DE 'GUARDAR'", objetosLogin.CasoPrueba);

                                    // DAR CLIC AL BOTÓN DE "GUARDAR" - GUARDA ASIGNACIÓN DE LA TRAJETA
                                    elementosKOSWingman.BotonGuardarDatosCliente(driver).Click();
                                    Thread.Sleep(sleepTimerFast);
                                }
                            }

                        }
                        catch
                        {
                            soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO EL ELEMENTO"+ elementosKOSWingman.WingmanAsignadoInspeccion(driver) + "CORRESPONDIENTE A 'ASIGNAR WINGMAN AL CLIENTE'", objetosLogin.CasoPrueba);
                            Thread.Sleep(sleepTimerFail);

                            resultadoKOSWingman = false;

                            // CERRAR NAVEGADOR
                            soporte.CerrarDriver(driver);
                            soporte.CerrarDocumento(documento);
                        }

                    }
                    catch
                    {
                        soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO"+ elementosKOSWingman.BandejaInspeccionesAgendadas(driver, objetosKOSWingman.Buscar) + "CORRESPONDIENTE A LA FICHA QUE SE PRETENDIA BUSCAR", objetosLogin.CasoPrueba);
                        Thread.Sleep(sleepTimerFail);

                        resultadoKOSWingman = false;

                        // CERRAR NAVEGADOR
                        soporte.CerrarDriver(driver);
                        soporte.CerrarDocumento(documento);
                    }
                }
                // SOLO SE DA CLIC AL ICONO DE "FLECHA HACIA DELANTE"
                else
                {
                    // DA CLIC AL ICONO DE "FLECHA HACIA DELANTE" DE LA FICHA DEL CLIENTE
                    elementosKOSWingman.IconoFlechaHaciaDelante(driver).Click();
                    Thread.Sleep(sleepTimerMiddle);
                }

                // LOGICA PARA MOVER Y EDITAR FICHAS A ESTATUS "CONFIRMADOS" Y "CANCELADOS"

                // VALIDA SI SE REALIZARA CONFIRMACIÓN DEL FICHA "POR CONFIRMAR ASIGNADOS"
                if(objetosKOSWingman.FichaConfirmado  == "Si")
                {
                    try
                    {
                        soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONA LA FICHA DEL AL SECCION 'POR CONFIRMAR ASIGNADO' DE" + objetosKOSWingman.NombreFichaPorConfirmarAsignado + "QUE SE CAMBIARA A 'CONFIRMADO'", objetosLogin.CasoPrueba);
                        // SELECCIONAR DE LA COLUMNA "POR CONFIRMAR ASIGNADOS" AL USUARIO QUE SE SE VA A "CONFIRMAR"
                        elementosKOSWingman.FichaPorConfirmarAsignado(driver, objetosKOSWingman.NombreFichaPorConfirmarAsignado).Click();
                        Thread.Sleep(sleepTimerFast);

                        try
                        {
                            soporte.ObtenerEvidenciaCaso(driver, documento, "DAR CLIC AL ICONO DE 'EDITAR'", objetosLogin.CasoPrueba);
                            // DAR CLIC AL ICONO DE EDITAR
                            elementosKOSWingman.IconoEditarDatosCliente(driver).Click();
                            Thread.Sleep(sleepTimerFast);
                            try
                            {
                                soporte.ObtenerEvidenciaCaso(driver, documento, "SE INICIA CON LA EDICIÓN DE LOS DATOS DEL CLIENTE", objetosLogin.CasoPrueba);

                                // LIMPIAR Y CAPTURAR EL CAMPO "NOMBRE" DEL CLIENTE
                                elementosKOSWingman.EditarNombreCliente(driver).Clear();
                                elementosKOSWingman.EditarNombreCliente(driver).SendKeys(objetosKOSWingman.NombreCliente);
                                // LIMPIAR Y CAPTURAR EL CAMPO "APELLIDO" DEL CLIENTE
                                elementosKOSWingman.EditarApellidoCliente(driver).Clear();
                                elementosKOSWingman.EditarApellidoCliente(driver).SendKeys(objetosKOSWingman.ApellidoCliente);
                                // LIMPIAR Y CAPTURAR EL CAMPO "TELEFONO" DEL CLIENTE
                                elementosKOSWingman.EditarTelefonoCliente(driver).Clear();
                                elementosKOSWingman.EditarTelefonoCliente(driver).SendKeys(objetosKOSWingman.TelefonoCliente);

                                soporte.ObtenerEvidenciaCaso(driver, documento, "", objetosLogin.CasoPrueba);

                            }
                            catch
                            {
                                soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO EL ELEMENTO A EDITAR DE LA SECCIÓN 'DATOS DEL CLIENTE'", objetosLogin.CasoPrueba);
                                Thread.Sleep(sleepTimerFail);

                                resultadoKOSWingman = false;

                                // CERRAR NAVEGADOR
                                soporte.CerrarDriver(driver);
                                soporte.CerrarDocumento(documento);
                            }

                            soporte.ScrollToElement(driver, elementosKOSWingman.ListaEstatus(driver));
                            Thread.Sleep(sleepTimerFast);
                            soporte.ObtenerEvidenciaCaso(driver, documento, "SE REALIZA CAMBIO DE ESTATUS A 'CONFIRMADO'", objetosLogin.CasoPrueba);
                            // SELECCIONAR EL ESTATUS DESDE LA LISTA
                            elementosKOSWingman.ListaEstatus(driver).Click();
                            new SelectElement(elementosKOSWingman.ListaEstatus(driver)).SelectByText(objetosKOSWingman.EditarEstatusFichaConfirmado);
                            Thread.Sleep(sleepTimerFast);

                            try
                            {
                                soporte.ScrollToElement(driver, elementosKOSWingman.BotonGuardarDatosCliente(driver));
                                // GUARDAR CAMBIO
                                elementosKOSWingman.BotonGuardarDatosCliente(driver).Click();
                                Thread.Sleep(sleepTimerFast);

                                try
                                {
                                    // VALIDAR QUE LA FICHA SE ENCUENTRE EN LA COLUMNA DE "CONFIRMADOS"
                                    soporte.ObtenerEvidenciaCaso(driver, documento, "SE VALIDA CORRECTO CAMBIO DE ESTATUS A 'CONFIRMADO'", objetosLogin.CasoPrueba);
                                    elementosKOSWingman.FichaConfirmados(driver, objetosKOSWingman.NombreFichaPorConfirmarAsignado).Click();
                                    Thread.Sleep(sleepTimerFast);
                                    elementosKOSWingman.BotonCerrarDatosCliente(driver).Click();
                                }
                                catch
                                {
                                    soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO EL ELEMENTO - FICHA 'CONFIRMADO'" + elementosKOSWingman.FichaConfirmados(driver, objetosKOSWingman.NombreFichaPorConfirmarAsignado) + "", objetosLogin.CasoPrueba);
                                    Thread.Sleep(sleepTimerFail);

                                    resultadoKOSWingman = false;

                                    // CERRAR NAVEGADOR
                                    soporte.CerrarDriver(driver);
                                    soporte.CerrarDocumento(documento);
                                }
                            }
                            catch
                            {
                                soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO EL ELEMENTO - BOTON 'GUARDAR'" + elementosKOSWingman.BotonGuardarDatosCliente(driver) + "", objetosLogin.CasoPrueba);
                                Thread.Sleep(sleepTimerFail);

                                resultadoKOSWingman = false;

                                // CERRAR NAVEGADOR
                                soporte.CerrarDriver(driver);
                                soporte.CerrarDocumento(documento);
                            }
                        }
                        catch
                        {
                            soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO EL ELEMENTO - LISTA 'ESTATUS'" + objetosKOSWingman.EditarEstatusFichaConfirmado + "", objetosLogin.CasoPrueba);
                            Thread.Sleep(sleepTimerFail);

                            resultadoKOSWingman = false;

                            // CERRAR NAVEGADOR
                            soporte.CerrarDriver(driver);
                            soporte.CerrarDocumento(documento);
                        }
                    }
                    catch
                    {
                        soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO - FICHA EN EL ESTATUS 'POR CONFIRMAR ASIGNADO'"+ objetosKOSWingman.NombreFichaPorConfirmarAsignado + "", objetosLogin.CasoPrueba);
                        Thread.Sleep(sleepTimerFail);

                        resultadoKOSWingman = false;

                        // CERRAR NAVEGADOR
                        soporte.CerrarDriver(driver);
                        soporte.CerrarDocumento(documento);
                    }
                }

                // VALIDA SI SE REALIZARA CONFIRMACIÓN DEL FICHA "POR CONFIRMAR ASIGNADOS"
                if (objetosKOSWingman.FichaCancelado == "Si")
                {
                    // VALIDAR QUE LA FICHA SE ENCUENTRE EN LA COLUMNA DE "CONFIRMADOS"
                    soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONAR FICHA CON ESTATUS 'CONFIRMADO'", objetosLogin.CasoPrueba);
                    elementosKOSWingman.FichaConfirmados(driver, objetosKOSWingman.NombreFichaPorConfirmarAsignado).Click();
                    Thread.Sleep(sleepTimerFast);

                    try
                    {
                        soporte.ObtenerEvidenciaCaso(driver, documento, "DAR CLIC AL ICONO DE 'EDITAR'", objetosLogin.CasoPrueba);
                        // DAR CLIC AL ICONO DE EDITAR
                        elementosKOSWingman.IconoEditarDatosCliente(driver).Click();
                        Thread.Sleep(sleepTimerFast);
                        try
                        {
                            soporte.ObtenerEvidenciaCaso(driver, documento, "SE INICIA CON LA EDICIÓN DE LOS DATOS DEL CLIENTE", objetosLogin.CasoPrueba);

                            // LIMPIAR Y CAPTURAR EL CAMPO "NOMBRE" DEL CLIENTE
                            elementosKOSWingman.EditarNombreCliente(driver).Clear();
                            elementosKOSWingman.EditarNombreCliente(driver).SendKeys(objetosKOSWingman.NombreCliente);
                            // LIMPIAR Y CAPTURAR EL CAMPO "APELLIDO" DEL CLIENTE
                            elementosKOSWingman.EditarApellidoCliente(driver).Clear();
                            elementosKOSWingman.EditarApellidoCliente(driver).SendKeys(objetosKOSWingman.ApellidoCliente);
                            // LIMPIAR Y CAPTURAR EL CAMPO "TELEFONO" DEL CLIENTE
                            elementosKOSWingman.EditarTelefonoCliente(driver).Clear();
                            elementosKOSWingman.EditarTelefonoCliente(driver).SendKeys(objetosKOSWingman.TelefonoCliente);

                            soporte.ObtenerEvidenciaCaso(driver, documento, "", objetosLogin.CasoPrueba);

                            try
                            {
                                // CAMBIAR EL ESTATUS DE "CONFIRMADO" A "CANCELADO"
                                soporte.ScrollToElement(driver, elementosKOSWingman.ListaEstatus(driver));
                                Thread.Sleep(sleepTimerFast);
                                soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONAR ESTATUS 'CANCELADO'", objetosLogin.CasoPrueba);
                                new SelectElement(elementosKOSWingman.ListaEstatus(driver)).SelectByText(objetosKOSWingman.EditarEstatusFichaCancelado);
                                Thread.Sleep(sleepTimerFast);

                                try
                                {
                                    // SELECCIONAR EL CAMPO LISTA DE "MOTIVO"
                                    soporte.ObtenerEvidenciaCaso(driver, documento, "SELECCIONAR 'MOTIVO'", objetosLogin.CasoPrueba);
                                    new SelectElement(elementosKOSWingman.ListaMotivoCancelacion(driver)).SelectByText(objetosKOSWingman.ListaMotivoCancelacion);
                                    Thread.Sleep(sleepTimerFast);

                                    try
                                    {
                                        // DAR CLIC AL BOTON DE GUARDAR
                                        soporte.ScrollToElement(driver, elementosKOSWingman.BotonGuardarDatosCliente(driver));
                                        elementosKOSWingman.BotonGuardarDatosCliente(driver).Click();
                                        Thread.Sleep(sleepTimerFast);

                                        // VALIDAR QUE LA FICHA SE ENCUENTRE EN CANCELADOS

                                        soporte.ObtenerEvidenciaCaso(driver, documento, "SE VALIDA CORRECTO CAMBIO DE ESTATUS A 'CANCELADO'", objetosLogin.CasoPrueba);
                                        elementosKOSWingman.FichaCancelados(driver, objetosKOSWingman.NombreFichaPorConfirmarAsignado).Click();

                                        resultadoKOSWingman = true;
                                    }
                                    catch
                                    {
                                        soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO EL ELEMENTO " + elementosKOSWingman.BotonGuardarDatosCliente(driver) + " FICHA CON ESTATUS DE 'CANCELADA'", objetosLogin.CasoPrueba);
                                        Thread.Sleep(sleepTimerFail);

                                        resultadoKOSWingman = false;

                                        // CERRAR NAVEGADOR
                                        soporte.CerrarDriver(driver);
                                        soporte.CerrarDocumento(documento);
                                    }

                                }
                                catch
                                {

                                    soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO EL ELEMENTO " + elementosKOSWingman.ListaMotivoCancelacion(driver) + " PARA EDITAR DE LA SECCIÓN 'MOTIVO'", objetosLogin.CasoPrueba);
                                    Thread.Sleep(sleepTimerFail);

                                    resultadoKOSWingman = false;

                                    // CERRAR NAVEGADOR
                                    soporte.CerrarDriver(driver);
                                    soporte.CerrarDocumento(documento);
                                }
                            }
                            catch
                            {
                                soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO EL ELEMENTO "+ elementosKOSWingman.ListaEstatus(driver) + " PARA EDITAR DE LA SECCIÓN 'ESTATUS'", objetosLogin.CasoPrueba);
                                Thread.Sleep(sleepTimerFail);

                                resultadoKOSWingman = false;

                                // CERRAR NAVEGADOR
                                soporte.CerrarDriver(driver);
                                soporte.CerrarDocumento(documento);
                            }

                        }
                        catch
                        {
                            soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO EL ELEMENTO A EDITAR DE LA SECCIÓN 'DATOS DEL CLIENTE'", objetosLogin.CasoPrueba);
                            Thread.Sleep(sleepTimerFail);

                            resultadoKOSWingman = false;

                            // CERRAR NAVEGADOR
                            soporte.CerrarDriver(driver);
                            soporte.CerrarDocumento(documento);
                        }
                    }
                    catch
                    {
                        soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO  - ICONO 'EDITAR'", objetosLogin.CasoPrueba);
                        Thread.Sleep(sleepTimerFail);

                        resultadoKOSWingman = false;

                        // CERRAR NAVEGADOR
                        soporte.CerrarDriver(driver);
                        soporte.CerrarDocumento(documento);
                    }
                }

                // FIN DE LA PRUEBA CON RESULTADO EXITOSO
                Thread.Sleep(sleepTimerFast);
                soporte.ObtenerEvidenciaCaso(driver, documento, "FIN DE LA PRUEBA, RESULTADO 'EXITOSO'", objetosLogin.CasoPrueba);
                resultadoKOSWingman = true;

                // CERRAR NAVEGADOR
                soporte.CerrarDriver(driver);
                soporte.CerrarDocumento(documento);
            }
            catch
            {
                soporte.ObtenerEvidenciaCaso(driver, documento, "¡UUPS!, ALGO SALIO MAL, NO SE ENCONTRO UN ELEMENTO", objetosLogin.CasoPrueba);
                Thread.Sleep(sleepTimerFail);

                resultadoKOSWingman = false;

                // CERRAR NAVEGADOR
                soporte.CerrarDriver(driver);
                soporte.CerrarDocumento(documento);
            }
        }


        // OBTENER RESULTADO DEL PROCESO DE WINGMAN
        #region OBTENER RESULTADO DEL PROCESO DE WINGMAN
        public bool ObtenerResultadoresultadoKOSWingman()
        {
            return resultadoKOSWingman;
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
        public List<Objects.KOSWingmanObjects> ListaKOSWingman(string pathDelFicheroExcel)
        {
            var book = new ExcelQueryFactory(Path.GetFullPath("..\\..\\..\\KavakoWebBotTools\\DataPool\\" + pathDelFicheroExcel));
            var resultado = (from row in book.Worksheet("Wingman")
                             let item = new Objects.KOSWingmanObjects
                             {
                                 Buscar = row["Buscar"].Cast<string>(),
                                 ListaCentros = row["ListaCentros"].Cast<string>(),
                                 WingmanAsignadoInspeccion = row["WingmanAsignadoInspeccion"].Cast<string>(),
                                 EditarFicha = row["EditarFicha"].Cast<string>(),
                                 EditarDatosCliente = row["EditarDatosCliente"].Cast<string>(),
                                 NombreCliente = row["NombreCliente"].Cast<string>(),
                                 ApellidoCliente = row["ApellidoCliente"].Cast<string>(),
                                 TelefonoCliente = row["TelefonoCliente"].Cast<string>(),
                                 ClienteOrganico = row["ClienteOrganico"].Cast<string>(),
                                 EditarCalleCliente = row["EditarCalleCliente"].Cast<string>(),
                                 EditarNumeroExterior = row["EditarNumeroExterior"].Cast<string>(),
                                 EditarNumeroInterior = row["EditarNumeroInterior"].Cast<string>(),
                                 EditarColoniaCliente = row["EditarColoniaCliente"].Cast<string>(),
                                 EditarDelegacionCliente = row["EditarDelegacionCliente"].Cast<string>(),
                                 EditarCPCliente = row["EditarCPCliente"].Cast<string>(),
                                 OfertaManual = row["OfertaManual"].Cast<string>(),
                                 ComentariosOfertaManual = row["ComentariosOfertaManual"].Cast<string>(),
                                 ListaMotivoOfertaManual = row["ListaMotivoOfertaManual"].Cast<string>(),
                                 ListaVersionOfertaManual = row["ListaVersionOfertaManual"].Cast<string>(),
                                 KilometrajeOfertaManual = row["KilometrajeOfertaManual"].Cast<string>(),
                                 FechaCalendarioOfertaManual = row["FechaCalendarioOfertaManual"].Cast<string>(),
                                 SubirDocumentoOfertaManual = row["SubirDocumentoOfertaManual"].Cast<string>(),
                                 EditarInspeccion = row["EditarInspeccion"].Cast<string>(),
                                 ListaDireccionInspeccion = row["ListaDireccionInspeccion"].Cast<string>(),
                                 FechaLimiteCalendarioInspeccion = row["FechaLimiteCalendarioInspeccion"].Cast<string>(),
                                 ListaHoraInspeccion = row["ListaHoraInspeccion"].Cast<string>(),
                                 ListaEstatus = row["ListaEstatus"].Cast<string>(),
                                 SubirFactura = row["SubirFactura"].Cast<string>(),
                                 SubirTarjetaCirculacion = row["SubirTarjetaCirculacion"].Cast<string>(),
                                 Guardar = row["Guardar"].Cast<string>(),
                                 ConfirmarNoGuardar = row["ConfirmarNoGuardar"].Cast<string>(),
                                 NombreFichaPorConfirmarAsignado = row["NombreFichaPorConfirmarAsignado"].Cast<string>(),
                                 FichaConfirmado = row["FichaConfirmado"].Cast<string>(),
                                 EditarEstatusFichaConfirmado = row["EditarEstatusFichaConfirmado"].Cast<string>(),
                                 FichaCancelado = row["FichaCancelado"].Cast<string>(),
                                 EditarEstatusFichaCancelado = row["EditarEstatusFichaCancelado"].Cast<string>(),
                                 ListaMotivoCancelacion = row ["ListaMotivoCancelacion"].Cast<string>()
                             }
                             select item).ToList();
            book.Dispose();
            return resultado;
        }
        #endregion
    }
}

//$archivo.PestanhiaNavegacionFunnelAdmin{variable}