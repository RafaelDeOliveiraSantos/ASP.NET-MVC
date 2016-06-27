using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreinamentoBener.Tests
{
    [TestClass]
    public class FibonacciTeste
    {
        [TestMethod]
        public void OPrimeiroElementoDaSequenciaDeveSer0()
        {
            Assert.AreEqual(0, Fibonacci.Elemento(0));
        }

        [TestMethod]
        public void OSegundaElementoDaSequenciaDeveSer1()
        {
            Assert.AreEqual(1, Fibonacci.Elemento(1));
        }

        [TestMethod]
        public void OTerceiroElementoDaSequenciaDeveSer1()
        {
            Assert.AreEqual(1, Fibonacci.Elemento(2));
        }

        [TestMethod]
        public void OQuartoElementoDaSequenciaDeveSer2()
        {
            Assert.AreEqual(2, Fibonacci.Elemento(3));
        }

        [TestMethod]
        public void OQuitoElementoDaSequenciaDeveSer3()
        {
            Assert.AreEqual(3, Fibonacci.Elemento(4));
        }

        [TestMethod]
        public void OSextoElementoDaSequenciaDeveSer5()
        {
            Assert.AreEqual(5, Fibonacci.Elemento(5));
        }
    }

}
