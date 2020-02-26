using OpenQA.Selenium;

namespace KavakoWebBotTools.Validations
{
    public class ApoloVendeAutoValidations
    {
        // DECLARAR INSTANCIAS
        Elements.ApoloVendeAutoElements elementosApoloVendeAuto = new Elements.ApoloVendeAutoElements();
        Objects.ApoloVendeAutoObjects objetosApoloVendeAuto = new Objects.ApoloVendeAutoObjects();

        // VALIDACION DE EXISTENCIA DEL BOTON VENDE TU AUTO
        public bool ValidarBotonVendeTuAuto(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valBotonVendeTuAuto;
            
            try
            {
                valBotonVendeTuAuto = elementosApoloVendeAuto.BotonVendeTuAuto(driver).Displayed;
            }
            catch
            {
                valBotonVendeTuAuto = false;
            }
            if (valBotonVendeTuAuto == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        // VALIDAR QUE EXISTA EL BOTON DE COTIZA TU AUTO
        public bool ValidarBotonCotizarMiAuto(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valBotonCotizarMiAuto;

            try
            {
                valBotonCotizarMiAuto = elementosApoloVendeAuto.BotonCotizarMiAuto(driver).Displayed;
            }
            catch
            {
                valBotonCotizarMiAuto = false;
            }
            if (valBotonCotizarMiAuto == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        // VALIDAR QUE EXISTA LA OPCION DE AÑO PARA SELECCIONAR
        public bool ValidarAnioAuto(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valAnioAuto;

            try
            {
                valAnioAuto = elementosApoloVendeAuto.AnioAuto(driver, objetosApoloVendeAuto.Anio).Displayed;
            }
            catch
            {
                valAnioAuto = false;
            }
            if (valAnioAuto == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        // VALIDAR QUE EXISTA LA OPCION DE LA MARCA DEL AUTO A SELECCIONAR
        public bool ValidarMarcaAuto(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valMarcaAuto;

            try
            {
                valMarcaAuto = elementosApoloVendeAuto.MarcaAuto(driver, objetosApoloVendeAuto.Marca).Displayed;
            }
            catch
            {
                valMarcaAuto = false;
            }
            if (valMarcaAuto == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        // VALIDAR QUE EXISTA LA OPCION DE LA MODELO DEL AUTO A SELECCIONAR
        public bool ValidarModeloAuto(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valModeloAuto;

            try
            {
                valModeloAuto = elementosApoloVendeAuto.ModeloAuto(driver, objetosApoloVendeAuto.Modelo).Displayed;
            }
            catch
            {
                valModeloAuto = false;
            }
            if (valModeloAuto == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        // VALIDAR QUE EXISTA LA VERSION DEL AUTO
        public bool ValidarVersionAuto(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valVersionAuto;

            try
            {
                valVersionAuto = elementosApoloVendeAuto.TituloVersionAuto(driver).Displayed;
            }
            catch
            {
                valVersionAuto = false;
            }
            if (valVersionAuto == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        // VALIDAR QUE EXISTAN LISTA DE COLORES Y EL COLOR QUE SE SELECCIONO
        public bool ValidarColorAuto(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valColorAuto;

            try
            {
                valColorAuto = elementosApoloVendeAuto.TituloColorAuto(driver).Displayed;
            }
            catch
            {
                valColorAuto = false;
            }
            if (valColorAuto == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        // VALIDAR QUE SE VISUALICE EL CAMPO DE KILOMETRAJE
        public bool ValidarKilometrajeAuto(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valKilometrajeAuto;

            try
            {
                valKilometrajeAuto = elementosApoloVendeAuto.TituloKilometrajeAuto(driver).Displayed;
            }
            catch
            {
                valKilometrajeAuto = false;
            }
            if (valKilometrajeAuto == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        // VALIDAR QUE SE VISUALICE EL CAMPO DE UBICACION DEL AUTO
        public bool ValidarUbicacionCP(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valUbicacionCP;

            try
            {
                valUbicacionCP = elementosApoloVendeAuto.CodigoPostal(driver).Displayed;
            }
            catch
            {
                valUbicacionCP = false;
            }
            if (valUbicacionCP == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        // VALIDAR LOS CAMPOS DE LA INFORMACION DEL PROPIETARIO DEL AUTO
        public bool ValidarDatosPropietario(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valNombre;
            bool valEmail;
            bool valTelefono;
            bool valTerminosYCondiciones;

            try
            {
                valNombre = elementosApoloVendeAuto.NombrePropietario(driver).Displayed;
            }
            catch
            {
                valNombre = false;
            }
            try
            {
                valEmail = elementosApoloVendeAuto.EmailPropietario(driver).Displayed;
            }
            catch
            {
                valEmail = false;
            }
            try
            {
                valTelefono = elementosApoloVendeAuto.TelefonoPropietario(driver).Displayed;
            }
            catch
            {
                valTelefono = false;
            }
            try
            {
                valTerminosYCondiciones = elementosApoloVendeAuto.AceptarTeminosCondiciones(driver).Displayed;
            }
            catch
            {
                valTerminosYCondiciones = false;
            }
            if (valNombre == true && valEmail == true && valTelefono == true && valTerminosYCondiciones == true )
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        // VALIDA LA LISTA DE OFERTA KAVAK
        public bool ValidarOfertaKavak(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valOfertaKavak;

            try
            {
                valOfertaKavak = elementosApoloVendeAuto.TituloOfertaKavak(driver).Displayed;
            }
            catch
            {
                valOfertaKavak = false;
            }
            if (valOfertaKavak == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        // VALIDAR SITIO DE INPECCION DEL AUTO
        public bool ValidarLugarDeInspeccionAuto(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valLugarDeInspeccionAuto;

            try
            {
                valLugarDeInspeccionAuto = elementosApoloVendeAuto.TituloLugarInspeccionAuto(driver).Displayed;
            }
            catch
            {
                valLugarDeInspeccionAuto = false;
            }
            if (valLugarDeInspeccionAuto == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        // VALIDAR ELEMENTOS DE FECHA Y HORA
        public bool ValidarCitaFechaHora(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valCitaFecha;
            bool valCitaHora;
            bool valTitulo;

            try
            {
                valCitaFecha = elementosApoloVendeAuto.CitaFecha(driver, objetosApoloVendeAuto.CitaFecha).Displayed;
            }
            catch
            {
                valCitaFecha = false;
            }
            try
            {
                valCitaHora = elementosApoloVendeAuto.CitaHora(driver, objetosApoloVendeAuto.CitaHora).Displayed;
            }
            catch
            {
                valCitaHora = false;
            }
            try
            {
                valTitulo = elementosApoloVendeAuto.TituloCitaFechaHora(driver).Displayed;
            }
            catch
            {
                valTitulo = false;
            }
            if (valCitaFecha == true || valCitaHora == true || valTitulo == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        // VALIDAR QUE ESXISTAN LOS ELEMENTOS DE ADJUNTAR ARCHIVOS
        public bool ValidarArchivosAdjuntos(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valArchivosAdjuntos;

            try
            {
                valArchivosAdjuntos = elementosApoloVendeAuto.BotonSiguienteAdjuntado(driver).Displayed;
            }
            catch
            {
                valArchivosAdjuntos = false;
            }
            if (valArchivosAdjuntos == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        // VALIDAR QUE EXISTAN INFORMACIÓN FINAL
        public bool ValidarInformacionFinal(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valVerDocumentos;
            bool valMiOferta;
            bool valVerResumenInspeccion;
            bool valComentariosFinales;

            try
            {
                valVerDocumentos = elementosApoloVendeAuto.VerDetalleDocumentos(driver).Displayed;
            }
            catch
            {
                valVerDocumentos = false;
            }
            try
            {
                valMiOferta = elementosApoloVendeAuto.VerMiOferta(driver).Displayed;
            }
            catch
            {
                valMiOferta = false;
            }
            try
            {
                valVerResumenInspeccion = elementosApoloVendeAuto.VerResumenInspeccion(driver).Displayed;
            }
            catch
            {
                valVerResumenInspeccion = false;
            }
            try
            {
                valComentariosFinales = elementosApoloVendeAuto.ComentariosFinales(driver).Displayed;
            }
            catch
            {
                valComentariosFinales = false;
            }
            if (valVerDocumentos == true || valMiOferta == true || valVerResumenInspeccion == true || valComentariosFinales)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }
            return resultadoValidacion;
        }

        

    }
}
