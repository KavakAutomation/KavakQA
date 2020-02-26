using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KavakoWebBotTools.Elements
{
    public class ApoloVendeAutoElements
    {
        // ELEMENTOS DEL SISTEMA APOLO
        
        // BOTON "VENDE TU AUTO"
        public IWebElement BotonVendeTuAuto(IWebDriver driver)
        {
            IWebElement botonVendeTuAuto = driver.FindElement(By.XPath("(//a[contains(text(),'Vende tu auto')])[2]"));
            return botonVendeTuAuto;
        }

        // BOTON "COTIZAR MI AUTO"
        public IWebElement BotonCotizarMiAuto(IWebDriver driver)
        {
            //IWebElement botonCotizarMiAuto = driver.FindElement(By.XPath("//a[contains(text(),'Cotizar mi auto')]"));
            IWebElement botonCotizarMiAuto = driver.FindElement(By.LinkText("Cotizar mi auto"));
            //IWebElement botonCotizarMiAuto = driver.FindElement(By.XPath("(//a[contains(text(),'Cotizar mi auto')])[2]"));
            return botonCotizarMiAuto;
        }

        #region DATOS DEL AUTO
        // ELEMENTO DE TITULO "¿Qué año es tu auto?"
        public IWebElement TituloAnioAuto(IWebDriver driver)
        {
            IWebElement tituloAnioAuto = driver.FindElement(By.XPath("//h2[@class='text-black-1 font-weight-bold fs-9 m-0']"));
            return tituloAnioAuto;
        }

        // BOTONES PARA SELECCIONAR "AÑO DEL AUTO"
        public IWebElement AnioAuto(IWebDriver driver, string Anio)
        {
            IWebElement anioAuto = driver.FindElement(By.XPath("//button[contains(text(),'" + Anio + "')]"));
            //IWebElement anioAuto = driver.FindElement(By.XPath("//div[@id='year-buttons']/div/div[" + Anio + "]/div/button"));
            return anioAuto;
        }

        // ELEMENTO DE TITULO "Selecciona la marca."
        public IWebElement TituloMarcaAuto(IWebDriver driver)
        {
            IWebElement tituloMarcaAuto = driver.FindElement(By.XPath("//*[@id='site-content']/app-make-sell/app-desktop/section/div/div/div[1]/app-fine-title-bar/div/div/div[2]/div[2]/h2"));
            return tituloMarcaAuto;
        }

        // LISTA DE "MARCAS" DE AUTOS PARA SELECCIONAR
        public IWebElement MarcaAuto(IWebDriver driver, string Marca)
        {
            IWebElement marcaAuto = driver.FindElement(By.XPath("//button/div/span[contains(text(),'" + Marca + "')]"));
            //IWebElement marcaAuto = driver.FindElement(By.XPath("//*[@id='site-content']/app-make-sell/app-desktop/section/div/div/div[2]/div/app-select-make/div/div/div/button[" + Marca + "]/div/span"));
            return marcaAuto;
        }

        // ELEMENTO DE TITULO "Selecciona el modelo."
        public IWebElement TituloModeloAuto(IWebDriver driver)
        {
            IWebElement tituloModeloAuto = driver.FindElement(By.XPath("//*[@id='site-content']/app-model/app-desktop/section/div/div/div[1]/app-fine-title-bar/div/div/div[2]/div[2]/h2"));
            return tituloModeloAuto;
        }

        //  LISTA DE "MODELOS" DE LA MARCA DEL AUTO
        public IWebElement ModeloAuto(IWebDriver driver, string Modelo)
        {
            //IWebElement modeloAuto = driver.FindElement(By.XPath("//*[@id='site-content']/app-model/app-desktop/section/div/div/div[2]/div/app-select-model/div/div/div/button[3]/div/span[contains(text(),'" + Modelo + "')]"));
            IWebElement modeloAuto = driver.FindElement(By.XPath("//button/div/span[contains(text(),'" + Modelo + "')]"));
            return modeloAuto;
        }

        // ELEMENTO DE TITULO "Selecciona la versión."
        public IWebElement TituloVersionAuto(IWebDriver driver)
        {
            IWebElement tituloVersionAuto = driver.FindElement(By.XPath("//*[@id='site-content']/app-version/app-desktop/section/div/div/div[1]/app-fine-title-bar/div/div/div[2]/div[2]/h2"));
            return tituloVersionAuto;
        }

        // LISTA DE "VERSIÓN" DEL AUTO 
        public IWebElement VersionAuto(IWebDriver driver, string Version)
        {
            //IWebElement versionAuto = driver.FindElement(By.XPath("(//P[@_ngcontent-serverapp-c77=''][text()='Limited'][text()='" + Version + "'])[1]"));
            IWebElement versionAuto = driver.FindElement(By.XPath("//button[" + Version + "]/div/div/p"));
            return versionAuto;
        }

        // ELEMENTO DE TITULO "Selecciona el color."
        public IWebElement TituloColorAuto(IWebDriver driver)
        {
            IWebElement tituloColorAuto = driver.FindElement(By.XPath("//*[@id='site-content']/app-color/app-desktop/section/div/div/div[1]/app-fine-title-bar/div/div/div[2]/div[2]/h2"));
            return tituloColorAuto;
        }

        // LISTA DE "COLOR" DEL AUTO
        public IWebElement ColorAuto(IWebDriver driver, string Color)
        {
            IWebElement colorAuto = driver.FindElement(By.XPath("//p[contains(text(),'" + Color + "')]"));
            //IWebElement colorAuto = driver.FindElement(By.XPath("//*[@id='color-items']/div/div[" + Color + "]/div/div/p"));
            return colorAuto;
        }

        // ELEMENTO DE TITULO "¿Cuál es el kilometraje de tu auto?"
        public IWebElement TituloKilometrajeAuto(IWebDriver driver)
        {
            IWebElement tituloKilometrajeAuto = driver.FindElement(By.XPath("//*[@id='site-content']/app-km-sell/app-desktop/section/div/div/div/app-fine-title-bar/div/div/div[2]/div[2]/h2"));
            return tituloKilometrajeAuto;
        }

        // CAMPO DE "KILOMETRAJE"
        public IWebElement KilometrajeAuto(IWebDriver driver)
        {
            IWebElement kilometrajeAuto = driver.FindElement(By.XPath("(//input[@type='tel'])[2]"));
            return kilometrajeAuto;
        }

        #endregion

        // BOTON "ATRAS"
        public IWebElement BotonAtras(IWebDriver driver)
        {
            IWebElement botonAtras = driver.FindElement(By.XPath("//button[@type='button'])[3]"));
            return botonAtras;
        }

        // BOTON "SIGUIENTE"
        public IWebElement BotonSiguiente(IWebDriver driver)
        {
            IWebElement botonSiguiente = driver.FindElement(By.XPath("(//button[@type='button'])[4]"));
            return botonSiguiente;
        }


        // ELEMENTO DE TITULO "¿Dónde esta ubicado tu auto?"
        public IWebElement TituloUbicacionAuto(IWebDriver driver)
        {
            IWebElement tituloUbicacionAuto = driver.FindElement(By.XPath(""));
            return tituloUbicacionAuto;
        }

        // CAMPO "CODIGO POSTAL"
        public IWebElement CodigoPostal(IWebDriver driver)
        {
            IWebElement codigoPostal = driver.FindElement(By.XPath("(//input[@type='tel'])[2]"));
            return codigoPostal;
        }

        // CAMPO "NOMBRE"
        public IWebElement NombrePropietario(IWebDriver driver)
        {
            IWebElement nombrePropietario = driver.FindElement(By.XPath("(//input[@id='name'])[2]"));
            return nombrePropietario;
        }

        // CAMPO "CORREO ELECTRONICO"
        public IWebElement EmailPropietario(IWebDriver driver)
        {
            IWebElement emailPropietario = driver.FindElement(By.XPath("(//input[@id='email'])[2]"));
            return emailPropietario;
        }

        // CAMPO "TELEFONO"
        public IWebElement TelefonoPropietario(IWebDriver driver)
        {
            IWebElement telefonoPropietario = driver.FindElement(By.XPath("(//input[@id='phone'])[2]"));
            return telefonoPropietario;
        }

        // SELECCIONAR "TEMINOS Y CONDICIONES"
        public IWebElement AceptarTeminosCondiciones(IWebDriver driver)
        {
            IWebElement aceptarTeminosCondiciones = driver.FindElement(By.XPath("//form[@id='user-login-form']/div[2]/div/label"));
            return aceptarTeminosCondiciones;
        }

        // BOTON "VER MI OFERTA"
        public IWebElement BotonVerMiOferta(IWebDriver driver)
        {
            IWebElement botonVerMiOferta = driver.FindElement(By.Id("btn-vender-oferta"));
            return botonVerMiOferta;
        }

        // TITULO "OFERTA KAVAK"
        public IWebElement TituloOfertaKavak(IWebDriver driver)
        {
            IWebElement tituloOfertaKavak = driver.FindElement(By.XPath("//h1[@class='text-black-1']"));
            return tituloOfertaKavak;
        }

        // LISTA PARA SELECCIONAR "OFERTA"
        public IWebElement OfertaKavak(IWebDriver driver, string Oferta)
        {
            //IWebElement ofertaKavak = driver.FindElement(By.XPath("//li[" + Oferta + "]/a/div/div/div/div/div"));
            IWebElement ofertaKavak = driver.FindElement(By.XPath("//span[contains(text(),'" + Oferta + "')]"));
            return ofertaKavak;
        }

        // BOTON "SIGUIENTE" ACEPTAR OFERTA
        public IWebElement BotonAceptarOfertaSiguiente(IWebDriver driver)
        {
            IWebElement botonAceptarOfertaSiguiente = driver.FindElement(By.XPath("(//button[@type='submit'])[2]"));
            return botonAceptarOfertaSiguiente;
        }

        // TITULO "INSPECCIÓN" DEL AUTO
        public IWebElement TituloLugarInspeccionAuto(IWebDriver driver)
        {
            //IWebElement lugarInspeccionAuto = driver.FindElement(By.XPath("//li[" + Inspeccion + "]/a/div/div/div[2]/div/div/h5"));
            IWebElement tituloLugarInspeccionAuto = driver.FindElement(By.XPath("//h1[@class='text-black-1']"));
            return tituloLugarInspeccionAuto;
        }

        // SELECCIONAR "INSPECCIÓN" DEL AUTO
        public IWebElement LugarInspeccionAuto(IWebDriver driver, string Inspeccion)
        {
            //IWebElement lugarInspeccionAuto = driver.FindElement(By.XPath("//li[" + Inspeccion + "]/a/div/div/div[2]/div/div/h5"));
            IWebElement lugarInspeccionAuto = driver.FindElement(By.XPath("//h5[contains(text(),'" + Inspeccion + "')]"));
            return lugarInspeccionAuto;
        }

        #region INSPECCION DEL AUTO A DOMICILO
        // CAPTURAR CAMPO "CALLE" - INSPECCION A DOMICILIO
        public IWebElement InspeccionCalle(IWebDriver driver)
        {
            IWebElement inspeccionCalle = driver.FindElement(By.Id("street"));
            return inspeccionCalle;
        }

        // CAPTURAR CAMPO "NUMERO EXTERIOR" - INSPECCION A DOMICILIO
        public IWebElement InspeccionNoExterior(IWebDriver driver)
        {
            IWebElement inspeccionNoExterior = driver.FindElement(By.XPath("(//input[@type='text'])[3]"));
            return inspeccionNoExterior;
        }

        // CAPTURAR CAMPO "NUMERO INTERIOR" - INSPECCION A DOMICILIO
        public IWebElement InspeccionNoInterior(IWebDriver driver)
        {
            IWebElement inspeccionNoInterior = driver.FindElement(By.XPath("(//input[@type='text'])[4]"));
            return inspeccionNoInterior;
        }

        // CAPTURAR CAMPO "CODIGO POSTAL" - INSPECCION A DOMICILIO
        public IWebElement InspeccionCodigoPostal(IWebDriver driver)
        {
            IWebElement inspeccionCodigoPostal = driver.FindElement(By.XPath("(//input[@type='tel'])[2]"));
            return inspeccionCodigoPostal;
        }

        // CAPTURAR CAMPO "COLONIAS" - INSPECCION A DOMICILIO
        public IWebElement InspeccionColonias(IWebDriver driver)
        {
            IWebElement x = driver.FindElement(By.XPath("//SELECT[@id='sellCarColonies']"));
            return x;
        }

        // BOTON "SIGUIENTE" - INSPECCION A DOMICILIO
        public IWebElement InspeccionBotonSiguiente(IWebDriver driver)
        {
            IWebElement inspeccionBotonSiguiente = driver.FindElement(By.Id("next-btn"));
            return inspeccionBotonSiguiente;
        }
        #endregion

        // BOTON "SIGUIENTE" - UNA VEZ SELECCIONADO EL CENTRO KAVAK
        public IWebElement BotonSiguienteCentroKavak(IWebDriver driver)
        {
            IWebElement botonSiguienteCentroKavak = driver.FindElement(By.XPath("//app-ag-map/div/button"));
            return botonSiguienteCentroKavak;
        }

        // TITULO "DIA Y HORA" DEL AUTO
        public IWebElement TituloCitaFechaHora(IWebDriver driver)
        {
            //IWebElement lugarInspeccionAuto = driver.FindElement(By.XPath("//li[" + Inspeccion + "]/a/div/div/div[2]/div/div/h5"));
            IWebElement tituloCitaFechaHora = driver.FindElement(By.XPath("//h1[@class='text-black-1']"));
            return tituloCitaFechaHora;
        }

        // LISTA SELECCION "FECHA" - CITA
        public IWebElement CitaFecha(IWebDriver driver, string Fecha)
        {
            //IWebElement citaFecha = driver.FindElement(By.XPath("//li[" + Fecha + "]/a/div/div/div[2]/div/span"));
            IWebElement citaFecha = driver.FindElement(By.XPath("//span[contains(text(),'" + Fecha + "')]"));
            return citaFecha;
        }

        // LISTA SELECCION "HORA" - CITA
        public IWebElement CitaHora(IWebDriver driver, string Hora)
        {
            //IWebElement citaHora = driver.FindElement(By.XPath("//div/div/div[" + Hora + "]/button"));
            IWebElement citaHora = driver.FindElement(By.XPath("//button[contains(text(),'" + Hora + "')]"));
            return citaHora;
        }

        // SELECCIONAR HORA DISPONIBLE
        public IWebElement CitaHoraDisponible(IWebDriver driver)
        {
            //IWebElement citaHora = driver.FindElement(By.XPath("//div/div/div[" + Hora + "]/button"));
            IWebElement citaHora = driver.FindElement(By.XPath("//section[@id='site-content']/app-inspection-date/app-desktop/section/div[2]/div/div/div[2]/app-schedule-block/div/div/div/div/button"));
            return citaHora;
        }

        // BOTON "SIGUIENTE" - CITA
        public IWebElement BotonSiguienteCita(IWebDriver driver)
        {
            IWebElement botonSiguienteCita = driver.FindElement(By.XPath("//button[@class='py-2 w-50 fs-6 mx-auto btn-kavak-2']"));
            //section[@id='site-content']/app-inspection-date/app-desktop/section/div[2]/div/div/div[2]/app-schedule-block/div/div/div/div[10]/div/div/button
            return botonSiguienteCita;
        }

        // OPCIONES "SUBIR FOTO TARJETA DE CIRCULACION"
        public IWebElement AdjuntarFoto1(IWebDriver driver)
        {
            IWebElement adjuntarFoto1 = driver.FindElement(By.Id("id=file-2"));
            return adjuntarFoto1;
        }

        // OPCIONES "SUBIR FOTO FACTURA DEL AUTO"
        public IWebElement AdjuntarFoto2(IWebDriver driver)
        {
            IWebElement adjuntarFoto2 = driver.FindElement(By.Id("id=file"));
            return adjuntarFoto2;
        }

        // BOTON "SIGUIENTE" DESPUES DE ADJUNTAR IMAGENES
        public IWebElement BotonSiguienteAdjuntado(IWebDriver driver)
        {
            IWebElement botonSiguienteAdjuntado = driver.FindElement(By.XPath("//button[@id='btn-next']"));
            return botonSiguienteAdjuntado;
        }

        // DESPLEGAR DETALLE "TIPO DE DOCUMENTACIÓN"
        public IWebElement VerDetalleDocumentos(IWebDriver driver)
        {
            IWebElement verDetalleDocumentos = driver.FindElement(By.XPath("(//button[@type='button'])[3]"));
            return verDetalleDocumentos;
        }

        // DESPLEGAR DETALLE "MI OFERTA"
        public IWebElement VerMiOferta(IWebDriver driver)
        {
            IWebElement verMiOferta = driver.FindElement(By.XPath("(//button[@type='button'])[4]"));
            return verMiOferta;
        }

        // DESPLEGAR DETALLE "RESUMEN DE INSPECCIÓN"
        public IWebElement VerResumenInspeccion(IWebDriver driver)
        {
            IWebElement verResumenInspeccion = driver.FindElement(By.XPath("(//button[@type='button'])[5]"));
            return verResumenInspeccion;
        }

        // CAPTURAR CAMPO "COMENTARIO"
        public IWebElement ComentariosFinales(IWebDriver driver)
        {
            IWebElement comentariosFinales = driver.FindElement(By.XPath("//textarea"));
            return comentariosFinales;
        }

        // BOTON "ENVIAR" COMENTRARIOS
        public IWebElement BotonEnviarComentariosFinales(IWebDriver driver)
        {
            IWebElement botonEnviarComentariosFinales = driver.FindElement(By.XPath("(//button[@type='button'])[6]"));
            return botonEnviarComentariosFinales;
        }

        // 
        public IWebElement X(IWebDriver driver)
        {
            IWebElement x = driver.FindElement(By.XPath(""));
            return x;
        }


    }
}
