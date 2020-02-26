using System;


namespace KavakoWebBotTools.Objects
{
    public class LoginObjects
    {
        #region Miembros
        private string casoPrueba;
        private string sistema;
        private string nombreUsuario;
        private string passwordUsuario;
        private string urlTest;
        private string resultadoEsperado;
        private string browser;
        private string opcionIngreso;
        private string menu;
        private string submenu;
        private string opcionesPrincipales;
        private string opcionesSecundarias;

        #endregion

        #region Propiedades

        public string CasoPrueba
        {
            get
            {
                return this.casoPrueba;
            }
            set
            {
                if (value == null)
                {
                    this.casoPrueba = "";
                }
                else
                {
                    this.casoPrueba = value;
                }
            }
        }

        public string Sistema
        {
            get
            {
                return this.sistema;
            }
            set
            {
                if (value == null)
                {
                    this.sistema = "";
                }
                else
                {
                    this.sistema = value;
                }
            }
        }

        public string NombreUsuario
        {
            get
            {
                return this.nombreUsuario;
            }
            set
            {
                if (value == null)
                {
                    this.nombreUsuario = "";
                }
                else
                {
                    this.nombreUsuario = value;
                }
            }
        }

        public string PasswordUsuario
        {
            get
            {
                return this.passwordUsuario;
            }
            set
            {
                if (value == null)
                {
                    this.passwordUsuario = "";
                }
                else
                {
                    this.passwordUsuario = value;
                }
            }
        }

        public string UrlTest
        {
            get
            {
                return this.urlTest;
            }
            set
            {
                if (value == null)
                {
                    this.urlTest = "";
                }
                else
                {
                    this.urlTest = value;
                }
            }
        }

        public string ResultadoEsperado
        {
            get
            {
                return this.resultadoEsperado;
            }
            set
            {
                if (value == null)
                {
                    this.resultadoEsperado = "";
                }
                else
                {
                    this.resultadoEsperado = value;
                }
            }
        }

        public string Browser
        {
            get
            {
                return this.browser;
            }
            set
            {
                if (value == null)
                {
                    this.browser = "";
                }
                else
                {
                    this.browser = value;
                }
            }
        }

        public string OpcionIngreso
        {
            get
            {
                return this.opcionIngreso;
            }
            set
            {
                if (value == null)
                {
                    this.opcionIngreso = "";
                }
                else
                {
                    this.opcionIngreso = value;
                }
            }
        }

        public string Menu
        {
            get
            {
                return this.menu;
            }
            set
            {
                if (value == null)
                {
                    this.menu = "";
                }
                else
                {
                    this.menu = value;
                }
            }
        }

        public string SubMenu
        {
            get
            {
                return this.submenu;
            }
            set
            {
                if (value == null)
                {
                    this.submenu = "";
                }
                else
                {
                    this.submenu = value;
                }
            }
        }

        public string OpcionesPrincipales
        {
            get
            {
                return this.opcionesPrincipales;
            }
            set
            {
                if(value == null)
                {
                    this.opcionesPrincipales = "";
                }
                else
                {
                    this.opcionesPrincipales = value;
                }
            }
        }

        public string OpcionesSecundarias
        {
            get
            {
                return this.opcionesSecundarias;
            }
            set
            {
                if(value == null)
                {
                    this.opcionesSecundarias = "";
                }
                else
                {
                    this.opcionesSecundarias = value;
                }
            }
        }
        
        #endregion
    }
}
