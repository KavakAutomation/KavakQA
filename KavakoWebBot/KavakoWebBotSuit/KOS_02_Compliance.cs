using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KavakoWebBotTools.Process;
namespace KavakoWebBotSuit
{
    
    [TestClass]
    public class KOS_02_Compliance
    {

        // INSTANCIA DE OBJETOS 
        KOSComplianceProcess procesoKOSCompliance = new KOSComplianceProcess();

        [TestMethod]
        public void KOS_02_Compliance_Investigacion()
        {
            string pathDataPool = "KOS_Compliance.xlsx";

            var listaUsuarios = procesoKOSCompliance.ListaUsuarios(pathDataPool);
            var listaKOSWingman = procesoKOSCompliance.ListaKOSCompliance(pathDataPool);
            procesoKOSCompliance.KOS_01_ConfirnarInspeccion_HP(listaUsuarios[0], listaKOSWingman[0], "");
            var resultado = procesoKOSCompliance.ObtenerResultadoresultadoKOSCompliance();
            Assert.AreEqual(true, resultado);
        }
    }
}
