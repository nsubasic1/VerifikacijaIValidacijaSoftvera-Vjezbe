using Cvjecara;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class CvjećaraTest
    {

        #region Atributi
        List<Mušterija> mušterije;
        Cvjećara cvjećara;
        #endregion

        #region Metode
        [TestInitialize]
        public void SetUp()
        {
            Mušterija m1 = new Mušterija("m1");
            Buket b = new Buket(20);
            b.DodajCvijet(new Cvijet(Vrsta.Ruža, "test", "Žuta", DateTime.Now.AddDays(-1), 1));
            m1.RegistrujKupovinu(b, new Poklon("", 20));
            Buket b1 = new Buket(10);
            b1.DodajCvijet(new Cvijet(Vrsta.Neven, "test", "Žuta", DateTime.Now.AddDays(-1), 1));
            b1.DodajCvijet(new Cvijet(Vrsta.Neven, "test", "Žuta", DateTime.Now.AddDays(-1), 1));
            Mušterija m2 = new Mušterija("m2");
            m2.RegistrujKupovinu(b1, new Poklon("", 10));
            mušterije = new List<Mušterija> { m1, m2 };
            cvjećara = new Cvjećara();
        }
        [TestMethod]
        public void NajviseCvijeca()
        {
            //Radila Nejla
            cvjećara.Mušterije = mušterije;
            Assert.AreEqual(cvjećara.DajNajboljuMušteriju(), mušterije[1]);
        }

        [TestMethod]
        public void NajvisaCijena()
        {
            //Radila Nejla
            Buket b1 = new Buket(20);
            b1.DodajCvijet(new Cvijet(Vrsta.Neven, "test", "Žuta", DateTime.Now.AddDays(-1), 1));
            b1.DodajCvijet(new Cvijet(Vrsta.Neven, "test", "Žuta", DateTime.Now.AddDays(-1), 1));
            Mušterija m = new Mušterija("m");
            m.RegistrujKupovinu(b1, new Poklon("", 10));
            mušterije.Add(m);
            cvjećara.Mušterije = mušterije;
            Assert.AreEqual(cvjećara.DajNajboljuMušteriju(), mušterije[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DodavanjeCvijecaIzuzetakNull()
        {
            //Radila Nejla
            //Ocekujemo da ce se baciti izuzetak jer ne mozemo dodati cvijet koji je null
            cvjećara.RadSaCvijećem(null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DodavanjeCvijetaKojiJeVecDodan()
        {
            //Radila Nejla
            Cvijet c = new Cvijet(Vrsta.Neven, "test", "Žuta", DateTime.Now.AddDays(-1), 1);
            cvjećara.RadSaCvijećem(c, 0);
            cvjećara.RadSaCvijećem(c, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void IzmjenaCvijecaIzuzetakNull()
        {
            //Radila Nejla
            //Ocekujemo da ce se baciti izuzetak jer ne mozemo izmijeniti cvijet koji je null
            cvjećara.RadSaCvijećem(null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IzmijenaCvijetaKojiNijeDodan()
        {
            //Radila Nejla
            Cvijet c = new Cvijet(Vrsta.Neven, "test", "Žuta", DateTime.Now.AddDays(-1), 1);
            cvjećara.RadSaCvijećem(c, 1);
        }

        [TestMethod]
        public void uspjesnaIzmjenaCvijeta()
        {
            //Radila Nejla
            Cvijet c = new Cvijet(Vrsta.Neven, "test", "Žuta", DateTime.Now.AddDays(-1), 1);
            cvjećara.RadSaCvijećem(c, 0);
            Cvijet c1 = new Cvijet(Vrsta.Neven, "test", "Žuta", DateTime.Now.AddDays(-1), 10);
            cvjećara.RadSaCvijećem(c1, 1);
            Assert.AreEqual(cvjećara.Cvijeće[0].Kolicina, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void BrisanjeCvijetaIzuzetakNull()
        {
            //Radila Nejla
            //Nemoguće brisanje cvijeta koji je null
            cvjećara.RadSaCvijećem(null, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BrisanjeCvijetaKojiNijeDodan()
        {
            //Radila Nejla
            //Nemoguce brisanje cvijeta koji nije dodan
            Cvijet c = new Cvijet(Vrsta.Neven, "test", "Žuta", DateTime.Now.AddDays(-1), 1);
            cvjećara.RadSaCvijećem(c, 2);
        }

        [TestMethod]
        public void uspjesnoBrisanjeCvijeta()
        {
            //Radila Nejla
            Cvijet c = new Cvijet(Vrsta.Neven, "test", "Žuta", DateTime.Now.AddDays(-1), 1);
            cvjećara.RadSaCvijećem(c, 0);
            cvjećara.RadSaCvijećem(c, 2);
            Assert.AreEqual(cvjećara.Cvijeće.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IlegalnaOpcijaRadSaCvijecem()
        {
            //Radila Nejla
            cvjećara.RadSaCvijećem(null, 3);
        }


        [TestMethod]
        public void DajNarucenePokloneTest()
        {
            Assert.AreEqual(1, cvjećara.DajSveNaručenePoklone(mušterije[1], 10).Count);
        }

        [TestMethod]
        public void DodajBuketTest()
        {
            cvjećara.DodajBuket(new List<Cvijet> { new Cvijet(Vrsta.Neven, "test", "Žuta", DateTime.Now.AddDays(-1), 1) }, new List<string> { "Slama" }, new Poklon("", 20), 20);
            Assert.AreEqual(20, cvjećara.DajSveBukete()[0].Cijena);
        }
    }
    #endregion
}
