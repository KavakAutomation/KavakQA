using OpenQA.Selenium;

namespace KavakoWebBotTools.Elements
{
    public class KOSComplianceElements
    {
        // ELEMENTO PESTAÑA DE NAVEGACION "FUNNEL ADMIN"
        public IWebElement PestanhiaNavegacionFunnelAdmin(IWebDriver driver)
        {
            IWebElement pestanhiaNavegacionFunnelAdmin = driver.FindElement(By.XPath("//div/span[1]"));
            return pestanhiaNavegacionFunnelAdmin;
        }

        // ELEMENTO PESTAÑA DE NAVEGACION "FUNNEL"
        public IWebElement PestanhiaNavegacionFunnel(IWebDriver driver)
        {
            IWebElement pestanhiaNavegacionFunnel = driver.FindElement(By.XPath("//div/span[2]"));
            return pestanhiaNavegacionFunnel;
        }

        // ELEMENTO PESTAÑA DE NAVEGACION "INVESTIGACIÓN"
        public IWebElement PestanhiaNavegacionInvestigacion(IWebDriver driver)
        {
            IWebElement pestanhiaNavegacionInvestigacion = driver.FindElement(By.XPath("//div/span[3]"));
            return pestanhiaNavegacionInvestigacion;
        }

        // ELEMENTO PESTAÑA DE NAVEGACION "DOCUMENTOS"
        public IWebElement PestanhiaNavegacionDocumentos(IWebDriver driver)
        {
            IWebElement pestanhiaNavegacionDocumentos = driver.FindElement(By.XPath("//div/span[4]"));
            return pestanhiaNavegacionDocumentos;
        }

        // SECCIÓN DE "FUNNEL ADMIN"
        #region SECCIÓN DE "FUNNEL ADMIN"

        // ELEMENTO LISTA "BUSCAR POR" SECCIÓN FUNNEL ADMIN
        public IWebElement FunnelAdmin_ListaBuscarPor(IWebDriver driver)
        {
            IWebElement funnelAdmin_ListaBuscarPor = driver.FindElement(By.XPath("//select"));
            return funnelAdmin_ListaBuscarPor;
        }

        // ELEMENTO LISTA "BUSCAR" SECCIÓN FUNNEL ADMIN
        public IWebElement FunnelAdmin_Buscar(IWebDriver driver)
        {
            IWebElement funnelAdmin_Buscar = driver.FindElement(By.XPath("//input[@type='search']"));
            return funnelAdmin_Buscar;
        }

        // ELEMENTO BANDEJA DE RESULTADOS "BANDEJA DE RESULTADOS" SECCIÓN FUNNEL ADMIN
        public IWebElement FunnelAdmin_BandejaResultados(IWebDriver driver, string nombre)
        {
            IWebElement funnelAdmin_BandejaResultados = driver.FindElement(By.XPath("//div[@id='click-info-card']/ul/div/p[contains(text(),'" + nombre + "')]"));
            return funnelAdmin_BandejaResultados;
        }

        // DATOS DE LA FICHA
        #region DATOS DE LA FICHA

        // ELEMENTO LISTA "INVESTIGADOR" SECCIÓN FICHA
        public IWebElement FunnelAdmin_Ficha_Investigador(IWebDriver driver)
        {
            IWebElement funnelAdmin_Ficha_Investigador = driver.FindElement(By.XPath("//div/div/label/select"));
            return funnelAdmin_Ficha_Investigador;
        }

        // ELEMENTO BOTON "GUARDAR CAMBIOS" SECCIÓN FICHA
        public IWebElement FunnelAdmin_Ficha_GuardarCambios(IWebDriver driver)
        {
            IWebElement funnelAdmin_Ficha_GuardarCambios = driver.FindElement(By.XPath("//div/button"));
            return funnelAdmin_Ficha_GuardarCambios;
        }

        // ELEMENTO BOTON ICONO "CERRAR" SECCIÓN FICHA
        public IWebElement FunnelAdmin_Ficha_IconoCerrar(IWebDriver driver)
        {
            IWebElement funnelAdmin_Ficha_IconoCerrar = driver.FindElement(By.XPath("//header/mat-icon"));
            return funnelAdmin_Ficha_IconoCerrar;
        }

        #endregion // FIN DE LA REGION "DATOS DE LA FICHA"

        #endregion // FIN DE LA SECCION "FUNNEL ADMIN"

        // SECCION "FUNNEL"
        #region SECCIÓN "FUNNEL"

        // ELEMENTO BANDEJA DE RESULTADOS "BANDEJA DE RESULTADOS" SECCIÓN FUNNEL
        public IWebElement Funnel_Bandeja(IWebDriver driver, string nombre)
        {
            IWebElement funnel_Bandeja = driver.FindElement(By.XPath("//div[@id='click-info-card']/ul/div/p[contains(text(),'" + nombre + "')]"));
            return funnel_Bandeja;
        }

        // DATOS DE LA FICHA DE LA PESTAÑA "FUNNEL"
        #region DATOS DE LA FICHA DE LA PESTAÑA "FUNNEL"

        // ELEMENTO BOTON "GUARDAR CAMBIOS" SECCIÓN FICHA
        public IWebElement Funnel_Ficha_GuardarCambios(IWebDriver driver)
        {
            IWebElement funnel_Ficha_GuardarCambios = driver.FindElement(By.XPath("//div/button"));
            return funnel_Ficha_GuardarCambios;
        }

        // ELEMENTO BOTON ICONO "CERRAR" SECCIÓN FICHA
        public IWebElement Funnel_Ficha_IconoCerrar(IWebDriver driver)
        {
            IWebElement funnel_Ficha_GuardarCambios = driver.FindElement(By.XPath("//header/mat-icon"));
            return funnel_Ficha_GuardarCambios;
        }

        #endregion  // FIN DE LOS DATOS DE LA FICHA DE LA PESTAÑA "FUNNEL"

        #endregion // FIN DE LA SECCIÓN "FUNNEL"

        // SECCIÓN "INVESTIGACIÓN"
        #region SECCIÓN "INVESTIGACIÓN"

        // ELEMENTO BANDEJA DE RESULTADOS "BANDEJA DE RESULTADOS" SECCIÓN INVESTIGACIÓN
        public IWebElement Investigacion_Bandeja(IWebDriver driver, string nombre)
        {
            IWebElement funnel_Bandeja = driver.FindElement(By.XPath("//div[@id='click-info-card']/ul/li[2]/span[contains(text(),'" + nombre + "')]"));
            return funnel_Bandeja;
        }

        // SECCIÓN "VIN" - INVESTIGACIÓN 
        #region SECCIÓN "VIN" - INVESTIGACIÓN

        // ELEMENTO BANDEJA DE RESULTADOS "BANDEJA DE RESULTADOS" SECCIÓN INVESTIGACIÓN
        public IWebElement Investigacion_Bandeja(IWebDriver driver, string nombre)
        {
            IWebElement funnel_Bandeja = driver.FindElement(By.XPath("//div[@id='click-info-card']/ul/li[2]/span[contains(text(),'" + nombre + "')]"));
            return funnel_Bandeja;
        }

        #endregion // FIN DE SECCIÓN "VIN" - INVESTIGACIÓN 

        #endregion // FIN DE LA SECCIÓN "INVESTIGACIÓN"
    }
}
