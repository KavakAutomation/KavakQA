using OpenQA.Selenium;

namespace KavakoWebBotTools.Validations
{
    public class KOSHomeValidations
    {
        // DECLARAR INSTANCIAS
        Elements.KOSHomeElements elementosKOSHome = new Elements.KOSHomeElements();
        Objects.LoginObjects objetosLogin = new Objects.LoginObjects();


        // VALIDAR MENU HAMBURGUESA
        public bool ValidarMenuHamburguesa(IWebDriver driver)
        {
            bool resultadoValidacion;
            bool valMenuHamburguesa;

            try
            {
                valMenuHamburguesa = elementosKOSHome.MenuHamburguesa(driver).Displayed;
            }
            catch
            {
                valMenuHamburguesa = false;
            }
            if (valMenuHamburguesa == true)
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
