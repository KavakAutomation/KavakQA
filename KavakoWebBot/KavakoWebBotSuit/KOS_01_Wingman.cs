using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KavakoWebBotSuit
{

    [TestClass]
    public class KOS_01_Wingman
    {
        //INSTANCIAS DE OJETOS
        KavakoWebBotTools.Process.KOSWingmanProcess procesoKOSWingman = new KavakoWebBotTools.Process.KOSWingmanProcess();
        
        [TestMethod]
        public void KOS_01_HP_Wingman_PorConfirmarAsignado() // SELECCIONAR DE LOS INDICES [0] Y [0,1,2]
        {
            string pathDataPool = "KOS_Wingman.xlsx";

            var listaUsuarios = procesoKOSWingman.ListaUsuarios(pathDataPool);
            var listaKOSWingman = procesoKOSWingman.ListaKOSWingman(pathDataPool);
            procesoKOSWingman.KOS_01_ConfirnarInspeccion_HP(listaUsuarios[0], listaKOSWingman[0], "");
            var resultado = procesoKOSWingman.ObtenerResultadoresultadoKOSWingman();
            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void KOS_02_HP_Wingman_Confirmados() // SELECCIONAR DE LOS INDICES [1] Y [3,4,5]
        {
            string pathDataPool = "KOS_Wingman.xlsx";

            var listaUsuarios = procesoKOSWingman.ListaUsuarios(pathDataPool);
            var listaKOSWingman = procesoKOSWingman.ListaKOSWingman(pathDataPool);
            procesoKOSWingman.KOS_01_ConfirnarInspeccion_HP(listaUsuarios[1], listaKOSWingman[3], "");
            var resultado = procesoKOSWingman.ObtenerResultadoresultadoKOSWingman();
            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void KOS_03_HP_Wingman_Cancelados() // SELECCIONAR DE LOS INDICES [2] Y [6,7,8]
        {
            string pathDataPool = "KOS_Wingman.xlsx";

            var listaUsuarios = procesoKOSWingman.ListaUsuarios(pathDataPool);
            var listaKOSWingman = procesoKOSWingman.ListaKOSWingman(pathDataPool);
            procesoKOSWingman.KOS_01_ConfirnarInspeccion_HP(listaUsuarios[2], listaKOSWingman[6], "");
            var resultado = procesoKOSWingman.ObtenerResultadoresultadoKOSWingman();
            Assert.AreEqual(true, resultado);
        }
    }
}
