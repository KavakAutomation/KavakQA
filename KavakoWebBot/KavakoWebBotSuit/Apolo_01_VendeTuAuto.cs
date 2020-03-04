using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KavakoWebBotSuit
{
    /// <summary>
    /// Descripción resumida de Apolo_01_VendeTuAuto
    /// </summary>
    [TestClass]
    public class Apolo_01_VendeTuAuto
    {

        [TestMethod]
        public void Apolo_01_HP_VentaDeAuto()
        {
            KavakoWebBotTools.Process.ApoloVendeAutoProcess procesoApoloVendeAuto = new KavakoWebBotTools.Process.ApoloVendeAutoProcess();
            string pathDataPool = "Apolo_VendeAuto.xlsx";

            var listaUsuarios = procesoApoloVendeAuto.ListaUsuarios(pathDataPool);
            var listaVendeAuto = procesoApoloVendeAuto.ListaVendeAuto(pathDataPool);
            procesoApoloVendeAuto.Apolo_01_VenderAuto_HP(listaUsuarios[0], listaVendeAuto[0], "Apolo_01_HP_VentaDeAuto");
            var resultado = procesoApoloVendeAuto.ObtenerResultadoVendeAuto();
            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void Apolo_02_HP_VentaDeAuto()
        {
            KavakoWebBotTools.Process.ApoloVendeAutoProcess procesoApoloVendeAuto = new KavakoWebBotTools.Process.ApoloVendeAutoProcess();
            string pathDataPool = "Apolo_VendeAuto.xlsx";

            var listaUsuarios = procesoApoloVendeAuto.ListaUsuarios(pathDataPool);
            var listaVendeAuto = procesoApoloVendeAuto.ListaVendeAuto(pathDataPool);
            procesoApoloVendeAuto.Apolo_01_VenderAuto_HP(listaUsuarios[1], listaVendeAuto[1], "Apolo_01_HP_VentaDeAuto");
            var resultado = procesoApoloVendeAuto.ObtenerResultadoVendeAuto();
            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void Apolo_03_HP_VentaDeAuto()
        {
            KavakoWebBotTools.Process.ApoloVendeAutoProcess procesoApoloVendeAuto = new KavakoWebBotTools.Process.ApoloVendeAutoProcess();
            string pathDataPool = "Apolo_VendeAuto.xlsx";

            var listaUsuarios = procesoApoloVendeAuto.ListaUsuarios(pathDataPool);
            var listaVendeAuto = procesoApoloVendeAuto.ListaVendeAuto(pathDataPool);
            procesoApoloVendeAuto.Apolo_01_VenderAuto_HP(listaUsuarios[2], listaVendeAuto[2], "Apolo_01_HP_VentaDeAuto");
            var resultado = procesoApoloVendeAuto.ObtenerResultadoVendeAuto();
            Assert.AreEqual(true, resultado);
        }
    }
}
