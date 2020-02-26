using OpenQA.Selenium;

namespace KavakoWebBotTools.Elements
{
    public class KOSHomeElements
    {
        // ICONO KAVAK
        public IWebElement ElementoIconoKavak(IWebDriver driver)
        {
            IWebElement elementoIconoKavak = driver.FindElement(By.Id("logo-main-nav-kavak"));
            return elementoIconoKavak;
        }

        // MENU HAMBURGUESA
        public IWebElement MenuHamburguesa(IWebDriver driver)
        {
            IWebElement menuHamburguesa = driver.FindElement(By.XPath("//mat-icon[@id='icon-main-nav-menu']"));
            return menuHamburguesa;
        }

        // OPCIONES DE HOME MENU
        public IWebElement Menu(IWebDriver driver, string Opcion)
        {
            IWebElement menu = driver.FindElement(By.XPath("//a[contains(text(),'" + Opcion + "')]"));
            return menu;
        }

        // OPCIONES DE HOME SUBMENU
        public IWebElement SubMenu(IWebDriver driver, string Opcion)
        {
            IWebElement subMenu = driver.FindElement(By.XPath("//div/a[" + Opcion + "]/div"));
            //IWebElement subMenu = driver.FindElement(By.XPath("//mat-accordion[2]/mat-expansion-panel/div/div/a[" + Opcion + "]/div"));
            return subMenu;
        }

        // OPCIONES PRINCIPALES
        public IWebElement OpcionPrincipal(IWebDriver driver, string Opcion)
        {
            IWebElement opcionPrincipal = driver.FindElement(By.XPath("//h1[contains(text(),'" + Opcion + "')]"));
            return opcionPrincipal;
        }

        // OPCIONES DE HOME SECCIÓN "SUPPLY"
        public IWebElement OpcionSupply(IWebDriver driver, string Opcion)
        {
            IWebElement opcionSupply = driver.FindElement(By.XPath("//h5[contains(text(),'" + Opcion + "')]"));
            return opcionSupply;
        }

    }
}
