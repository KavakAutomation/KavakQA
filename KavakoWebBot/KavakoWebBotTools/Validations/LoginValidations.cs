using OpenQA.Selenium;

namespace KavakoWebBotTools.Validations
{
    public class LoginValidations
    {
        // INSTANCIAR OBJETOS A USAR
        Elements.LoginElements elementosLogin = new Elements.LoginElements();

        // VALIDACION DE LA EXISTENCIA DEL BOTON INICIAL DE LOGIN
        #region ValidaElementosInicialesKOS 
        public bool ValidaElementosInicialesKOS (IWebDriver driver)
        {
            bool valIniciarSesion;
            bool resultadoValidacion;

            // VALIDACION DE EXISTENCIA DEL ELEMENTO INICIAR SESION CON GOOGLE
            try
            {
                valIniciarSesion = elementosLogin.BotonIngresarConGoogle(driver).Displayed;
            }
            catch
            {
                valIniciarSesion = false;
            }

            //VALIDACION DE EXISTENCIA DE TODOS LOS ELEMENTOS NECESARIOS PARA INICAR LA PRUEBA DE LOGIN
            if (valIniciarSesion == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }

            return resultadoValidacion;
        }
        #endregion

        // VALIDACION DE CAMPOS DE CAPTURA PARA USUARIO
        #region ValidaElementosLoginUsuarioGoogle
        public bool ValidaElementosLoginUsuarioGoogle(IWebDriver driver)
        {
            bool valUsuario;
            bool valSigiente;
            bool resultadoValidacion;

            //VALIDACION DE EXISTENCIA DEL ELEMENTO USUARIO DEL MODULO DE LOGIN
            try
            {
                valUsuario = elementosLogin.ElementoUsuario(driver).Displayed;
            }
            catch
            {
                valUsuario = false;
            }

            //VALIDACION DE EXISTENCIA DEL BOTON SIGUIENTE
            try
            {
                valSigiente = elementosLogin.BotonSiguienteUsuario(driver).Displayed;
            }
            catch
            {
                valSigiente = false;
            }

            // VALIDACION DE EXISTENCIA DE TODOS LOS ELEMENTOS
            if (valUsuario == true && valSigiente == true )
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }

            return resultadoValidacion;
        }
        #endregion

        // VALIDACION DE PASSWORD DE LA VENTANA EMERGENTE DE GOOGLE
        #region ValidaElementosLoginPassword0Google
        public bool ValidaElementosLoginPassword0Google(IWebDriver driver)
        {
            bool valPassword;
            bool valSigiente;
            bool resultadoValidacion;

            //VALIDACION DE EXISTENCIA DEL ELEMENTO PASSWORD DEL MODULO DE LOGIN
            try
            {
                valPassword = elementosLogin.ElementoPassword(driver).Displayed;
            }
            catch
            {
                valPassword = false;
            }

            //VALIDACION DE EXISTENCIA DEL ELEMENTO INICIAR SESION DEL MODULO DE LOGIN
            try
            {
                valSigiente = elementosLogin.BotonSiguientePass(driver).Displayed;
            }
            catch
            {
                valSigiente = false;
            }

            //VALIDACION DE EXISTENCIA DE TODOS LOS ELEMENTOS NECESARIOS PARA INICAR LA PRUEBA DE LOGIN
            if (valSigiente == true && valPassword == true)
            {
                resultadoValidacion = true;
            }
            else
            {
                resultadoValidacion = false;
            }

            return resultadoValidacion;
        }
        #endregion

    }
}
