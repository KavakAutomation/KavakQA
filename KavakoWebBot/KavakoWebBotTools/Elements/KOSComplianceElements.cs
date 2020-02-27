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
            IWebElement funnel_Bandeja = driver.FindElement(By.XPath($"//div[@id='click-info-card']/ul/li[2]/span[contains(text(),'{nombre}')]"));
            return funnel_Bandeja;
        }

        // SECCIÓN "VIN" - INVESTIGACIÓN 
        #region SECCIÓN "VIN" - INVESTIGACIÓN

        // ELEMENTO BANDEJA DE RESULTADOS "BANDEJA DE RESULTADOS" SECCIÓN INVESTIGACIÓN
        public IWebElement Investigacion_VIN_IconoVin(IWebDriver driver)
        {
            IWebElement funnel_Bandeja = driver.FindElement(By.XPath("//*[@id='main-content']/div/div[2]/div/div/app-stepper/div/span[1]/div"));
            return funnel_Bandeja;
        }

        // ELEMENTO TEXTO DEL CAMPO "ESCRIBE EL NUMERO DE VIN"
        public IWebElement Investigacion_VIN_EscribeNumeroVIN(IWebDriver driver)
        {
            IWebElement investigacion_VIN_EscribeNumeroVIN = driver.FindElement(By.XPath("//div[@id='main-content']/div/app-step-one/div/div[2]/app-question-form/form/div/div/app-input-copy-btn/label/input"));
            return investigacion_VIN_EscribeNumeroVIN;
        }

        // ELEMENTO RADIO BUTTON "SI" - ¿EL VIN DE CARNET DE SERVICIO COINCIDE CON EL VIN DE CHASIS?
        public IWebElement Investigacion_VIN_CoincideConChasis_Si(IWebDriver driver)
        {
            IWebElement investigacion_VIN_CoincideConChasisRadioBotonSi = driver.FindElement(By.XPath("//*[@id='mat-radio-2']/label/div[2]"));
            return investigacion_VIN_CoincideConChasisRadioBotonSi;
        }

        // ELEMENTO RADIO BUTTON "NO" - ¿EL VIN DE CARNET DE SERVICIO COINCIDE CON EL VIN DE CHASIS?
        public IWebElement Investigacion_VIN_CoincideConChasis_No(IWebDriver driver)
        {
            IWebElement investigacion_VIN_CoincideConChasis_No = driver.FindElement(By.XPath("//*[@id='mat-radio-3']/label/div[2]"));
            return investigacion_VIN_CoincideConChasis_No;
        }

        // ELEMENTO CHECK BOX "SIN CHASIS" / "SIN CARNET" - ¿EL VIN DE CARNET DE SERVICIO COINCIDE CON EL VIN DE CHASIS?
        public IWebElement Investigacion_VIN_CoincideConChasis_SinChasisSinCarnet(IWebDriver driver, string opcion)
        {
            IWebElement investigacion_VIN_ = driver.FindElement(By.XPath("//span[contains(text(),'" + opcion + "')]"));
            return investigacion_VIN_;
        }

        // ELEMENTO CHECK BOX "LINK NO ABRE" - REPUVE
        public IWebElement Investigacion_VIN_REPUVE_LinkNoAbre(IWebDriver driver)
        {
            IWebElement investigacion_VIN_REPUVE_LinkNoAbre = driver.FindElement(By.XPath("//*[@id='check-question-two-not-open']/label/span[contains(text(),'LINK NO ABRE')]"));
            return investigacion_VIN_REPUVE_LinkNoAbre;
        }

        // ELEMENTO RADIO BOTON "SI" ¿TIENE REPORTE DE ROBO ILÍCITO? - REPUVE
        public IWebElement Investigacion_VIN__REPUVE_TieneReporteRoboIlicito_Si(IWebDriver driver)
        {
            IWebElement investigacion_VIN_REPUVE_TieneReporteRoboIlicito_Si = driver.FindElement(By.XPath("//*[@id='mat-radio-44']/label/div[2]"));
            return investigacion_VIN_REPUVE_TieneReporteRoboIlicito_Si;
        }

        // ELEMENTO RADIO BOTON "NO" ¿TIENE REPORTE DE ROBO ILÍCITO? - REPUVE
        public IWebElement Investigacion_VIN_REPUVE_TieneReporteRoboIlicito_No(IWebDriver driver)
        {
            IWebElement investigacion_VIN_REPUVE_TieneReporteRoboIlicito_No = driver.FindElement(By.XPath("//*[@id='mat-radio-45']/label/div[2]"));
            return investigacion_VIN_REPUVE_TieneReporteRoboIlicito_No;
        }

        // ELEMENTO RADIO BOTON "SI" ¿EXISTE UNA PLACA REGISTRADA? - REPUVE
        public IWebElement Investigacion_VIN_REPUVE_ExistePlacaRegistrada_Si(IWebDriver driver)
        {
            IWebElement investigacion_VIN_REPUVE_ExistePlacaRegistrada_Si = driver.FindElement(By.XPath("//*[@id='mat-radio-47']/label/div[2]"));
            return investigacion_VIN_REPUVE_ExistePlacaRegistrada_Si;
        }

        // ELEMENTO RADIO BOTON "NO" ¿EXISTE UNA PLACA REGISTRADA? - REPUVE
        public IWebElement Investigacion_VIN_REPUVE_ExistePlacaRegistrada_No(IWebDriver driver)
        {
            IWebElement investigacion_VIN_REPUVE_ExistePlacaRegistrada_No = driver.FindElement(By.XPath("//*[@id='mat-radio-48']/label/div[2]"));
            return investigacion_VIN_REPUVE_ExistePlacaRegistrada_No;
        }

        // ELEMENTO RADIO BOTON "SI" ¿EL MODELO, LA VERSIÓN Y EL AÑO COTIZADO COINCIDE CON EL DE REPUVE? - REPUVE
        public IWebElement Investigacion_VIN_REPUVE_ModeloCoincideConREPUVE_Si(IWebDriver driver)
        {
            IWebElement investigacion_VIN_REPUVE_CoincideConREPUVE_Si = driver.FindElement(By.XPath("//*[@id='mat-radio-50']/label/div[2]"));
            return investigacion_VIN_REPUVE_CoincideConREPUVE_Si;
        }

        // ELEMENTO RADIO BOTON "NO" ¿EL MODELO, LA VERSIÓN Y EL AÑO COTIZADO COINCIDE CON EL DE REPUVE? - REPUVE
        public IWebElement Investigacion_VIN_REPUVE_ModeloCoincideConREPUVE_No(IWebDriver driver)
        {
            IWebElement investigacion_VIN_REPUVE_CoincideConREPUVE_No = driver.FindElement(By.XPath("//*[@id='mat-radio-51']/label/div[2]"));
            return investigacion_VIN_REPUVE_CoincideConREPUVE_No;
        }

        // ELEMENTO 
        public IWebElement Investigacion_VIN_(IWebDriver driver)
        {
            IWebElement investigacion_VIN_ = driver.FindElement(By.XPath(""));
            return investigacion_VIN_;
        }

        // ELEMENTO 
        public IWebElement Investigacion_VIN_(IWebDriver driver)
        {
            IWebElement investigacion_VIN_ = driver.FindElement(By.XPath(""));
            return investigacion_VIN_;
        }

        // ELEMENTO 
        public IWebElement Investigacion_VIN_(IWebDriver driver)
        {
            IWebElement investigacion_VIN_ = driver.FindElement(By.XPath(""));
            return investigacion_VIN_;
        }

        // ELEMENTO 
        public IWebElement Investigacion_VIN_(IWebDriver driver)
        {
            IWebElement investigacion_VIN_ = driver.FindElement(By.XPath(""));
            return investigacion_VIN_;
        }

        // ELEMENTO 
        public IWebElement Investigacion_VIN_(IWebDriver driver)
        {
            IWebElement investigacion_VIN_ = driver.FindElement(By.XPath(""));
            return investigacion_VIN_;
        }

        // ELEMENTO 
        public IWebElement Investigacion_VIN_(IWebDriver driver)
        {
            IWebElement investigacion_VIN_ = driver.FindElement(By.XPath(""));
            return investigacion_VIN_;
        }

        // ELEMENTO 
        public IWebElement Investigacion_VIN_(IWebDriver driver)
        {
            IWebElement investigacion_VIN_ = driver.FindElement(By.XPath(""));
            return investigacion_VIN_;
        }

        // ELEMENTO 
        public IWebElement Investigacion_VIN_(IWebDriver driver)
        {
            IWebElement investigacion_VIN_ = driver.FindElement(By.XPath(""));
            return investigacion_VIN_;
        }

        // ELEMENTO 
        public IWebElement Investigacion_VIN_(IWebDriver driver)
        {
            IWebElement investigacion_VIN_ = driver.FindElement(By.XPath(""));
            return investigacion_VIN_;
        }


        #endregion // FIN DE SECCIÓN "VIN" - INVESTIGACIÓN 

        #endregion // FIN DE LA SECCIÓN "INVESTIGACIÓN"
    }
}
