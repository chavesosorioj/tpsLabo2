using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Testea se lance la excepcion pasajeRepetidoException
        /// </summary>
        [TestMethod]
        public void PasajeRepetidoExceptionTest()
        {
            Pasajero pasajero1 = new Pasajero("luna", "lunera", 4, 8888);
            Pasaje p1 = new Pasaje(pasajero1, Pasaje.EProvincia.Jujuy);
            Pasaje p2 = new Pasaje(pasajero1, Pasaje.EProvincia.Jujuy);
            Aeropuerto auxAero = new Aeropuerto();

            try
            {
                auxAero += p1;
                auxAero += p2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(PasajeRepetido));
            }
        }

        /// <summary>
        /// Testea se instancie un pasajero
        /// </summary>
        [TestMethod]
        public void instanciarPasajeroTest()
        {
            Pasajero pasajero1 = new Pasajero("Draco", "draquin", 4, 8888);
            Assert.IsNotNull(pasajero1);
        }
    }
}
