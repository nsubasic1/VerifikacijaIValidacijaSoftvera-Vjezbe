﻿using Cvjecara;
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
    }
}
