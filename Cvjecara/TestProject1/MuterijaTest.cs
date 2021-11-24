using Cvjecara;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class MuterijaTest
    {
        /// <summary>
        /// Test sa legalnim parametrima koji provjerava dodavanje i vracanje true iz metode
        /// </summary>
        #region Atributi
        Mušterija mušterija = new("mujo");
        #endregion

        [TestInitialize]
        public void NovaMusterija()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            //Radila Nejla
            Poklon poklon = new Poklon("", 20);
            for (int i = 0; i < 1000; i++) mušterija.RegistrujKupovinu(new Buket(2), new Poklon("", 15));
            Assert.IsTrue(mušterija.NagradnaKupovina(poklon));
            Assert.IsTrue(mušterija.KupljeniPokloni.Contains(poklon));
        }

        /// <summary>
        /// Test izuzetka kada ukupan broj kupovina nije stepen 10
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMethod2()
        {
            //Radila Nejla
            Poklon poklon = new Poklon("", 20);
            for (int i = 0; i < 900; i++) mušterija.RegistrujKupovinu(new Buket(2), new Poklon("", 15));
            mušterija.NagradnaKupovina(poklon);
        }

        /// <summary>
        /// Test izuzetka kada je ukupan broj kupovina manji od 100
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMethod3()
        {
            //Radila Medina
            Mušterija mušterijica = new("Medina");
            Poklon poklončić = new("Lopta", 10);
            mušterijica.NagradnaKupovina(poklončić);
        }

        /// <summary>
        /// Test izuzetka kada poklon nije poslan
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestMethod4()
        {
            //Radila Medina
            Mušterija mušterijica = new("Medina");
            Poklon poklončić = new("Lopta", 10);
            mušterijica.NagradnaKupovina(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void registrujKupovinuIzuzetak() {
            //Radila Kanita
            Mušterija mušterija = new("Kanita");
            mušterija.RegistrujKupovinu(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void setterImePrezimeIzuzetak1()
        {
            //Radila Kanita
            Mušterija mušterija = new Mušterija(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void setterImePrezimeIzuzetak2()
        {
            //Radila Kanita
            Mušterija mušterija = new Mušterija("");
        }
    }
}
