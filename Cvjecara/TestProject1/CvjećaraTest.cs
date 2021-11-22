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
        }
        [TestMethod]
        public void NajviseCvijeca()
        {
            //Radila Nejla
            Cvjećara cvjećara = new Cvjećara();
            cvjećara.Mušterije = mušterije;
            Assert.AreEqual(cvjećara.DajNajboljuMušteriju(), mušterije[1]);
        }

        [TestMethod]
        public void NajvisaCijena()
        {
            //Radila Nejla
            Cvjećara cvjećara = new Cvjećara();
            Buket b1 = new Buket(20);
            b1.DodajCvijet(new Cvijet(Vrsta.Neven, "test", "Žuta", DateTime.Now.AddDays(-1), 1));
            b1.DodajCvijet(new Cvijet(Vrsta.Neven, "test", "Žuta", DateTime.Now.AddDays(-1), 1));
            Mušterija m = new Mušterija("m");
            m.RegistrujKupovinu(b1, new Poklon("", 10));
            mušterije.Add(m);
            cvjećara.Mušterije = mušterije;
            Assert.AreEqual(cvjećara.DajNajboljuMušteriju(), mušterije[2]);
        }
    }
    #endregion
}
