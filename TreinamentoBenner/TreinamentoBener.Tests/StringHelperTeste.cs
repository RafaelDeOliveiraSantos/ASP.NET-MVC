using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreinamentoBenner.Core.Helpers;

namespace TreinamentoBener.Tests
{
    [TestClass]
    public class StringHelperTeste
    {
        [TestMethod]
        public void DeveRetornarAPalavraComSNoFinal()
        {
            Assert.AreEqual("abacaxis", "abacaxi".ToPlural());
        }

        [TestMethod]
        public void DeveRetornarAPalavraCasoSejaDoisTresSeisOuDez()
        {
            var palavra = "dois";
            Assert.AreEqual(palavra, palavra.ToPlural());
            palavra = "tres";
            Assert.AreEqual(palavra, palavra.ToPlural());
            palavra = "seis";
            Assert.AreEqual(palavra, palavra.ToPlural());
            palavra = "dez";
            Assert.AreEqual(palavra, palavra.ToPlural());

        }

        [TestMethod]
        public void DeveSubstituirAUltimaLetraPorIsSeAPalabraTerminarComAlouUl()
        {
            Assert.AreEqual("azuis", "azul".ToPlural());
            Assert.AreEqual("banais", "banal".ToPlural());
        }

        [TestMethod]
        public void DeveAdicionarEsQuandoTerminarComZOuR()
        {
            Assert.AreEqual("atrozes", "atroz".ToPlural());
            Assert.AreEqual("vapores", "vapor".ToPlural());
        }

        [TestMethod]
        public void DeveTrocarAUltimaLetraPorNsSeTerminarComM()
        {
            Assert.AreEqual("tons", "tom".ToPlural());
            Assert.AreEqual("sons", "som".ToPlural());
        }

        [TestMethod]
        public void Excecoes()
        {
            Assert.AreEqual("males", "mal".ToPlural());
            Assert.AreEqual("cônsules", "cônsul".ToPlural());
            Assert.AreEqual("féis", "fel".ToPlural());
            Assert.AreEqual("cais", "cal".ToPlural());
            Assert.AreEqual("avais", "aval".ToPlural());
            Assert.AreEqual("móis", "mol".ToPlural());
            Assert.AreEqual("existem", "existe".ToPlural());
            Assert.AreEqual("anões", "anão".ToPlural());
        }

        [TestMethod]
        public void TrocarAoPorOesSeAPalavraTerminarComCaoOuIao()
        {
            Assert.AreEqual("marcações", "marcação".ToPlural());
            Assert.AreEqual("aviões", "avião".ToPlural());
        }

        [TestMethod]
        public void TrocalElPorEisSeAPalavraTerminarComEl()
        {
            Assert.AreEqual("anéis", "anel".ToPlural());
        }


    }

}
