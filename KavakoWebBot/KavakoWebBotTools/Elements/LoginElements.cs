using OpenQA.Selenium;

namespace KavakoWebBotTools.Elements
{
    public class LoginElements
    {
        // ELEMENTOS DEL LOGIN DE AMERICA MOVIL CHAT BOT SUIT

        // BOTON DE LOG CON GOOGLE
        public IWebElement BotonIngresarConGoogle(IWebDriver driver)
        {
            IWebElement elementoUsuario = driver.FindElement(By.XPath("//button[@id='googleBtn']/span"));
            return elementoUsuario;
        }

        // VENTANA GOOGLE - USUARIO
        public IWebElement ElementoUsuario(IWebDriver driver)
        {
            //IWebElement elementoUsuario = driver.FindElement(By.CssSelector("#identifierId.whsOnd.zHQkBf"));
            IWebElement elementoUsuario = driver.FindElement(By.Id("identifierId"));
            return elementoUsuario;
        }

        // VENTANA GOOGLE - BOTON SIGUIENTE (SECCION DE NOMBRE DE USUARIO O CORREO)
        public IWebElement BotonSiguienteUsuario(IWebDriver driver)
        {
            IWebElement botonSiguienteUsuario = driver.FindElement(By.XPath("//*[@id='identifierNext']/span/span"));
            return botonSiguienteUsuario;
        }

        // BOTON NEXT AL INGRESAR CON EL USUARIO
        public IWebElement BotonNextGoogle(IWebDriver driver)
        {
            IWebElement botonNextGoogle = driver.FindElement(By.Id("next"));
            return botonNextGoogle;
        }

        // VENTANA GOOGLE - Password
        public IWebElement ElementoPassword(IWebDriver driver)
        {
            IWebElement elementoPassword = driver.FindElement(By.Name("password"));
            return elementoPassword;
        }

        // VENTANA GOOGLE - BOTON SIGUIENTE (SECCION DE CONTRASEÑA)
        public IWebElement BotonSiguientePass(IWebDriver driver)
        {
            IWebElement botonSiguientePass = driver.FindElement(By.XPath("//*[@id='passwordNext']/span/span"));
            return botonSiguientePass;
        }

        // VENTANA GOOGLE - CUERPO DE LA VENTANA
        public IWebElement CuerpoVentanaEmergente(IWebDriver driver)
        {
            IWebElement cuerpoVentanaEmergente = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]"));
            return cuerpoVentanaEmergente;
        }
    }
}
