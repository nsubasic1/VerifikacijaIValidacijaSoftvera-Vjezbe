using Cvjecara;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test sa legalnim parametrima koji provjerava dodavanje i vracanje true iz metode
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            //Radila Nejla
            Mu�terija mu�terija = new("mujo");
            Poklon poklon = new Poklon("", 20);
            for (int i = 0; i < 1000; i++) mu�terija.RegistrujKupovinu(new Buket(2), new Poklon("", 15));
            Assert.IsTrue(mu�terija.NagradnaKupovina(poklon));
            Assert.IsTrue(mu�terija.KupljeniPokloni.Contains(poklon));
        }

        /// <summary>
        /// Test izuzetka kada ukupan broj kupovina nije stepen 10
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMethod2()
        {
            //Radila Nejla
            Mu�terija mu�terija = new("mujo");
            Poklon poklon = new Poklon("", 20);
            for (int i = 0; i < 900; i++) mu�terija.RegistrujKupovinu(new Buket(2), new Poklon("", 15));
            mu�terija.NagradnaKupovina(poklon);
        }


    }
}
