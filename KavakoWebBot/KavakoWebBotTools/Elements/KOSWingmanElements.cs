using OpenQA.Selenium;

namespace KavakoWebBotTools.Elements
{
    public class KOSWingmanElements
    {
        // ELEMENTO BUSQUEDA
        public IWebElement CampoBusqueda(IWebDriver driver)
        {
            IWebElement campoBusqueda = driver.FindElement(By.Id("input-sidenav-confirmed-search"));
            return campoBusqueda;
        }

        // ELEMENTO LISTA  DE CENTROS KAVAK
        public IWebElement ListaCentros(IWebDriver driver)
        {
            IWebElement campoBusqueda = driver.FindElement(By.Id("sel-sidenav-confirmed-center"));
            return campoBusqueda;
        }

        // ELEMENTO BANDEJA DE INSPECCIONES AGENDADAS 
        public IWebElement BandejaInspeccionesAgendadas(IWebDriver driver, string Opcion)
        {
            IWebElement bandejaInspeccionesAgendadas = driver.FindElement(By.XPath("//div[@id='click-info-card']/ul/li[2]/span[contains(text(),'" + Opcion + "')]"));
            //IWebElement bandejaInspeccionesAgendadas = driver.FindElement(By.Id("//li[2]/span[contains(text(),'" + Opcion + "')]"));
            return bandejaInspeccionesAgendadas;
        }

        // ELEMENTO ICONO "FLECHA HACIA DELANTE" DE LA FICHA
        public IWebElement IconoFlechaHaciaDelante(IWebDriver driver)
        {
            IWebElement bandejaInspeccionesAgendadas = driver.FindElement(By.XPath("//button[@id='btn-sidenavtbc-infocardarrow-0']/span/mat-icon"));
            return bandejaInspeccionesAgendadas;
        }

        #region DATOS DEL CLIENTE

        // LISTA DE PERSONAS PARA ASIGNACION DE INSPECCIÓN AGENDADA
        public IWebElement WingmanAsignadoInspeccion(IWebDriver driver)
        {
            IWebElement wingmanAsignadoInspeccion = driver.FindElement(By.Id("sel-wingman-workspace"));
            return wingmanAsignadoInspeccion;
        }

        #region EDITAR DATOS DEL CLIENTE

        // ICONO EDITAR DATOS DEL CLIENTE
        public IWebElement IconoEditarDatosCliente(IWebDriver driver)
        {
            IWebElement iconoEditarDatosCliente = driver.FindElement(By.XPath("//button[@id='btn-shared-profile-card-edit']/span/mat-icon"));
            return iconoEditarDatosCliente;
        }

        // CAMPO "NOMBRE" EDITAR NOMBRE DEL CLIENTE
        public IWebElement EditarNombreCliente(IWebDriver driver)
        {
            IWebElement editarNombreCliente = driver.FindElement(By.XPath("//input[@placeholder='NOMBRE']"));
            return editarNombreCliente;
        }

        // CAMPO "APELLIDO" EDITAR APELLIDO DEL CLIENTE
        public IWebElement EditarApellidoCliente(IWebDriver driver)
        {
            IWebElement editarApellidoCliente = driver.FindElement(By.XPath("//input[@placeholder='APELLIDO']"));
            return editarApellidoCliente;
        }

        // CAMPO "TELÉFONO" EDITAR TELÉFONO DEL CLIENTE
        public IWebElement EditarTelefonoCliente(IWebDriver driver)
        {
            IWebElement editarTelefonoCliente = driver.FindElement(By.XPath("//input[@placeholder='TELÉFONO']"));
            return editarTelefonoCliente;
        }

        // CHECKBOX "CLIENTE ORGÁNICO"
        public IWebElement EditarCheckBoxClienteOrganico(IWebDriver driver)
        {
            IWebElement editarCheckBoxClienteOrganico = driver.FindElement(By.XPath("//input[@placeholder='TELÉFONO']"));
            return editarCheckBoxClienteOrganico;
        }

        // CAMPO "CALLE" EDITAR CALLE DEL CLIENTE
        public IWebElement EditarCalleCliente(IWebDriver driver)
        {
            IWebElement editarCalleCliente = driver.FindElement(By.XPath("//input[@placeholder='CALLE']"));
            return editarCalleCliente;
        }

        // CAMPO "NÚMERO EXTERIOR" EDITAR NÚMERO EXTERIOR DEL CLIENTE
        public IWebElement EditarNumeroExteriorCliente(IWebDriver driver)
        {
            IWebElement editarNumeroExteriorCliente = driver.FindElement(By.XPath("//input[@placeholder='NÚMERO EXTERIOR']"));
            return editarNumeroExteriorCliente;
        }

        // CAMPO "NÚMERO INTERIOR" EDITAR NÚMERO INTERIOR DEL CLIENTE
        public IWebElement EditarNumeroInteriorCliente(IWebDriver driver)
        {
            IWebElement editarNumeroInteriorCliente = driver.FindElement(By.XPath("//input[@placeholder='NÚMERO INTERIOR']"));
            return editarNumeroInteriorCliente;
        }

        // CAMPO "COLONIA" EDITAR COLONIA DEL CLIENTE
        public IWebElement EditarColoniaCliente(IWebDriver driver)
        {
            IWebElement editarColoniaCliente = driver.FindElement(By.XPath("//input[@placeholder='COLONIA']"));
            return editarColoniaCliente;
        }

        // CAMPO "DELEGACIÓN" EDITAR DELEGACION DEL CLIENTE
        public IWebElement EditarDelegacionCliente(IWebDriver driver)
        {
            IWebElement editarDelegacionCliente = driver.FindElement(By.XPath("//input[@placeholder='DELEGACIÓN']"));
            return editarDelegacionCliente;
        }

        // CAMPO "CP" EDITAR CP DEL CLIENTE
        public IWebElement EditarCPCliente(IWebDriver driver)
        {
            IWebElement editarCPCliente = driver.FindElement(By.XPath("//input[@placeholder='CP']"));
            return editarCPCliente;
        }
        #endregion

        #region OFERTA MANUAL

        // OPCION CHECKBOX "OFERTA MANUAL"
        public IWebElement CheckOfertaManual(IWebDriver driver)
        {
            IWebElement checkOfertaManual = driver.FindElement(By.XPath("//app-offer-manual-offer/div/mat-checkbox/label/div"));
            return checkOfertaManual;
        }

        // CAMPO "COMENTARIOS" CAPTURA COMENTARIOS SOBRE LA OFERTA MANUAL
        public IWebElement ComentariosOfertaManual(IWebDriver driver)
        {
            IWebElement comentariosOfertaManual = driver.FindElement(By.XPath("//app-offer-manual-offer/div[2]/label/input"));
            return comentariosOfertaManual;
        }

        // LISTA "MOTIVO" SELECCIONA MOTIVO SOBRE LA OFERTA MANUAL
        public IWebElement ListaMotivoOfertaManual(IWebDriver driver)
        {
            IWebElement listaMotivoOfertaManual = driver.FindElement(By.XPath("//div[3]/div/label/select"));
            return listaMotivoOfertaManual;
        }

        // LISTA "VERSIÓN" SELECCIONA VERSION SOBRE LA OFERTA MANUAL
        public IWebElement ListaVersionOfertaManual(IWebDriver driver)
        {
            IWebElement listaVersionOfertaManual = driver.FindElement(By.XPath("//div[3]/div[2]/label/select"));
            return listaVersionOfertaManual;
        }

        // CAMPO "KILOMETRAJE" CAPTURA KILOMETRAJE SOBRE LA OFERTA MANUAL
        public IWebElement KilometrajeOfertaManual(IWebDriver driver)
        {
            IWebElement kilometrajeOfertaManual = driver.FindElement(By.XPath("//div[4]/label/input"));
            return kilometrajeOfertaManual;
        }

        // CAMPO "CALENDARIO" CAPTURA FECHA SOBRE LA OFERTA MANUAL
        public IWebElement FechaCalendario1OfertaManual(IWebDriver driver)
        {
            IWebElement fechaCalendario1OfertaManual = driver.FindElement(By.XPath("//input[@id='mat-input-3']"));
            //IWebElement fechaCalendario1OfertaManual = driver.FindElement(By.Xpath("//mat-icon[@class='color-primary mat-icon notranslate material-icons mat-icon-no-color']"));
            return fechaCalendario1OfertaManual;
        }

        // CAMPO "CALENDARIO" CAPTURA FECHA SOBRE LA OFERTA MANUAL
        public IWebElement FechaCalendario2OfertaManual(IWebDriver driver, string dia)
        {
            //IWebElement fechaCalendario2OfertaManual = driver.FindElement(By.XPath("//tr[5]/td[4]/span[contains(text(),'" + dia + "')]"));
            IWebElement fechaCalendario2OfertaManual = driver.FindElement(By.XPath("//span[@class='owl-dt-calendar-cell-content'][contains(text(),'" + dia + "')]"));
            return fechaCalendario2OfertaManual;
        }

        // CAMPO "KILOMETRAJE" CAPTURA KILOMETRAJE SOBRE LA OFERTA MANUAL
        public IWebElement SubirDocumentoOfertaManual(IWebDriver driver)
        {
            IWebElement subirDocumentoOfertaManual = driver.FindElement(By.XPath("//input[@type='file']"));
            return subirDocumentoOfertaManual;
        }

        #endregion

        // LISTA DEL CAMPO "DIRECCIÓN DE LA INSPECCIÓN"
        public IWebElement ListaDireccionInspeccion(IWebDriver driver)
        {
            IWebElement listaDireccionInspeccion = driver.FindElement(By.Id("sel-inspectionSite-form-center"));
            return listaDireccionInspeccion;
        }

        // OPCION CALENDARIO "FECHA LIMITE" PARTE 1
        public IWebElement FechaLimiteCalendario1(IWebDriver driver)
        {
            IWebElement fechaLimiteCalendario1 = driver.FindElement(By.XPath("//mat-icon[@id='icon-inspection-date']"));
            return fechaLimiteCalendario1;
        }

        // OPCION CALENDARIO "FECHA LIMITE" PARTE 2
        public IWebElement FechaLimiteCalendario2(IWebDriver driver, string dia)
        {
            IWebElement fechaLimiteCalendario2 = driver.FindElement(By.XPath("//span[@class='owl-dt-calendar-cell-content'][contains(text(),'" + dia + "')]"));
            return fechaLimiteCalendario2;
        }

        // LISTA DEL CAMPO "HORA"
        public IWebElement ListaHora(IWebDriver driver)
        {
            IWebElement listaHora = driver.FindElement(By.Id("sel-inspectionSite-form-hour"));
            return listaHora;
        }

        // LISTA DEL CAMPO "ESTATUS"
        public IWebElement ListaEstatus(IWebDriver driver)
        {
            IWebElement listaEstatus = driver.FindElement(By.XPath("//select[@id='sel-wingman-workspace-status']"));
            //IWebElement listaEstatus = driver.FindElement(By.Id("sel-wingman-workspace-status"));
            return listaEstatus;
        }

        // SUBIR "FACTURA" DEL AUTO EN IMAGEN
        public IWebElement SubirFactura(IWebDriver driver)
        {
            IWebElement subirFactura = driver.FindElement(By.XPath("(//input[@type='file'])[2]"));
            return subirFactura;
        }

        // SUBIR "TARJETA DE CIRCULACIÓN" DEL AUTO EN IMAGEN
        public IWebElement SubirTarjetaCirculacion(IWebDriver driver)
        {
            IWebElement subirTarjetaCirculacion = driver.FindElement(By.XPath("(//input[@type='file'])[3]"));
            return subirTarjetaCirculacion;
        }

        // BOTON "GUARDAR"
        public IWebElement BotonGuardarDatosCliente(IWebDriver driver)
        {
            IWebElement botonGuardarDatosCliente = driver.FindElement(By.Id("btn-wingman-workspace-save"));
            return botonGuardarDatosCliente;
        }

        // BOTON "CERRAR"
        public IWebElement BotonCerrarDatosCliente(IWebDriver driver)
        {
            IWebElement botonCerrarDatosCliente = driver.FindElement(By.XPath("//mat-icon[@id='icon-wingman-workspace-close']"));
            //IWebElement botonCerrarDatosCliente = driver.FindElement(By.XPath("//button[@id='btn-shared-profile-card-edit']/span/mat-icon"));
            return botonCerrarDatosCliente;
        }

        // BOTON "ACEPTAR" EL CERRAR VENTANA
        public IWebElement BotonAceptarCerrarDatosCliente(IWebDriver driver)
        {
            IWebElement botonAceptarCerrarDatosCliente = driver.FindElement(By.XPath("//button[2]"));
            return botonAceptarCerrarDatosCliente;
        }

        // BOTON "CANCELAR" EL CERRAR VENTANA
        public IWebElement BotonCancelarCerrarDatosCliente(IWebDriver driver)
        {
            IWebElement botonCancelarCerrarDatosCliente = driver.FindElement(By.XPath("//footer/div/button"));
            return botonCancelarCerrarDatosCliente;
        }

        #endregion

        #region TABLERO DE ESTADOS

        // ELEMENTO DE LA COLUMNA "POR CONFIRMAR ASIGNADO"
        public IWebElement FichaPorConfirmarAsignado(IWebDriver driver, string nombre)
        {
            IWebElement fichaPorConfirmarAsignado = driver.FindElement(By.XPath("//span[contains(text(),'" + nombre + "')]"));
            return fichaPorConfirmarAsignado;
        }

        // ELEMENTO DE LA COLUMNA "CANCELADOS"
        public IWebElement FichaCancelados(IWebDriver driver, string nombre)
        {
            IWebElement fichaCancelados = driver.FindElement(By.XPath("//app-info-card[@id='card-funnel-col3-0']//span[@class='mr-2 font-weight-bolder text-link ng-star-inserted'][contains(text(),'" + nombre + "')]"));
            return fichaCancelados;
        }

        // ELEMENTO  DE LA COLUMNA "CONFIRMADOS"
        public IWebElement FichaConfirmados(IWebDriver driver, string nombre)
        {
            IWebElement fichaConfirmados = driver.FindElement(By.XPath("//app-info-card[@id='card-funnel-col4-0']//span[@class='mr-2 font-weight-bolder text-link ng-star-inserted'][contains(text(),'" + nombre + "')]"));
            return fichaConfirmados;
        }

        // ELEMNTO LISTA DE SELECCION "MOTIVO"
        public IWebElement ListaMotivoCancelacion(IWebDriver driver)
        {
            IWebElement listaMotivoCancelacion = driver.FindElement(By.XPath("//div[6]/div/div[2]/div/label/select"));
            //IWebElement listaMotivoCancelacion = driver.FindElement(By.XPath("//mat-dialog-container[@id='mat-dialog-3']/app-workspace-dialog/mat-drawer-container/mat-drawer-content/section/div[6]/div/div[2]/div/label/select"));
                                                                                //mat-dialog-container[@id='mat-dialog-3']/app-workspace-dialog/mat-drawer-container/mat-drawer-content/section/div[6]/div/div[2]/div/label/select
            return listaMotivoCancelacion;
        }

        #endregion

    }
}
