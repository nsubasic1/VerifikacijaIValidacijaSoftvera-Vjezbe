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
            Mušterija mušterija = new("mujo");
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
            Mušterija mušterija = new("mujo");
            Poklon poklon = new Poklon("", 20);
            for (int i = 0; i < 900; i++) mušterija.RegistrujKupovinu(new Buket(2), new Poklon("", 15));
            mušterija.NagradnaKupovina(poklon);
        }
        /// <summary>
        /// Test koji testira da li je iznos svjezine maksimalan kada je proslo manje od 3 dana
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            //Radila Kanita
            Cvijet cvijet = new(Vrsta.Ruža, "Ime ruze", "Crvena", DateTime.Now.AddDays(-2), 10);
            Assert.AreEqual(cvijet.OdrediSvježinuCvijeća(), 5);
        }
        /// <summary>
        /// Test koji testira da li se svjezina cvijeca smanjila za koeficijent ukoliko je ubrano prije tačno 3 dana 
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            //Radila Kanita
            Cvijet ljiljan= new(Vrsta.Ljiljan, "Ime ljiljana", "Bijela", DateTime.Now.AddDays(-3), 200);
            Cvijet margareta = new(Vrsta.Margareta, "Ime margarete", "Žuta", DateTime.Now.AddDays(-3), 100);
            Cvijet neven = new(Vrsta.Neven, "Ime nevena", "Žuta", DateTime.Now.AddDays(-3), 300);
            Cvijet orhideja = new(Vrsta.Orhideja, "Ime orhideje", "Roza", DateTime.Now.AddDays(-3), 250);
            Cvijet ruza = new Cvijet(Vrsta.Ruža, "Ime ruze", "Crvena", DateTime.Now.AddDays(-3), 150);

            Assert.AreEqual(ljiljan.OdrediSvježinuCvijeća(), 4.4);
            Assert.AreEqual(margareta.OdrediSvježinuCvijeća(), 4.6);
            Assert.AreEqual(neven.OdrediSvježinuCvijeća(), 4.7);
            Assert.AreEqual(orhideja.OdrediSvježinuCvijeća(), 4.5);
            Assert.AreEqual(ruza.OdrediSvježinuCvijeća(), 4.8);
        }
    }
}
