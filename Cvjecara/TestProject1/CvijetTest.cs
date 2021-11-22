using Cvjecara;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class CvijetTest
    {
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
