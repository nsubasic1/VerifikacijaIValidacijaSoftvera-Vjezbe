using System;
using Cvjecara;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class CvjecaraTest
    {
        [TestMethod]
        public void TestTuning()
        {
            Cvjećara klasa = new Cvjećara();
            for (int i = 0; i < 1000000; i++)
                klasa.Cvijeće.Add(new Cvijet(Vrsta.Ruža, "Rosa", "Crvena", DateTime.Now.AddDays(-1), 1));
            //prvi breakpoint prije poziva metode
            int x = 0;
            //prije tuninga
            for (int i = 0; i < 100; i++)
            {
                Cvijet c = new Cvijet(Vrsta.Orhideja, "Orchid", "Crvena", DateTime.Now.AddDays(-1), 1);
                klasa.RadSaCvijećemTuning3(c, 0, 1);
                klasa.RadSaCvijećemTuning3(c, 2, 1);
            }
            int y = 0;

            Assert.IsTrue(true);
        }
        #region Kanitini testovi
        //Testovi vezani za obuhvat odluka
        //Radila Kanita

        //Testni slucaj kod kojeg lista cvijece ima elemente takve da je prvi if uslov for petlje ispunjen
        //Baca se izuzetak
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProvjeriLatinskaImenaCvijecaTest1() {
            Cvjećara cvjećara = new Cvjećara();

            for (int i = 0; i < 3; i++)
                cvjećara.Cvijeće.Add(new Cvijet(Vrsta.Ruža, "LatinskoImeRosa", "Crvena", DateTime.Now, 10));

            cvjećara.ProvjeriLatinskaImenaCvijeća();
        }

        //Testni slucaj kod kojeg lista cvijece ima elemente takve da prvi if uslov for petlje nije ispunjen, else if uslov je ispunjen
        //Baca se izuzetak
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProvjeriLatinskaImenaCvijecaTest2()
        {
            Cvjećara cvjećara = new Cvjećara();

            for (int i = 0; i < 3; i++)
                cvjećara.Cvijeće.Add(new Cvijet(Vrsta.Ljiljan, "LatinskoImeLilium", "Žuta", DateTime.Now, 10));
            for (int i = 0; i < 3; i++)
                cvjećara.Cvijeće.Add(new Cvijet(Vrsta.Neven, "LatinskoImeCalendula", "Žuta", DateTime.Now, 10));

            cvjećara.ProvjeriLatinskaImenaCvijeća();
        }

        //Testni slucaj kod kojeg lista cvijece ima elemente takve da prvi if uslov for petlje nije ispunjen i else if uslov nije ispunjen
        //Ne baca se izuzetak jer nije izbacen nijedan element, odnosno ostalo je elemenata u listi cvijeće
        [TestMethod]
        public void ProvjeriLatinskaImenaCvijecaTest3()
        {
            Cvjećara cvjećara = new Cvjećara();

            for (int i = 0; i < 3; i++)
                cvjećara.Cvijeće.Add(new Cvijet(Vrsta.Ljiljan, "Lilium", "Žuta", DateTime.Now, 10));
            for (int i = 0; i < 3; i++)
                cvjećara.Cvijeće.Add(new Cvijet(Vrsta.Neven, "Calendula", "Žuta", DateTime.Now, 10));

            cvjećara.ProvjeriLatinskaImenaCvijeća();

            Assert.IsTrue(cvjećara.Cvijeće.Count != 0);
        }
        #endregion

        #region NejliniTestovi

        //Testovi obuhvata petlji

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPetlji1()
        {
            Cvjećara cvjećara = new Cvjećara();
            cvjećara.ProvjeriLatinskaImenaCvijeća();
        }
        
        [TestMethod]
        public void TestPetlji2()
        {
            Cvjećara cvjećara = new Cvjećara();
            cvjećara.Cvijeće.Add(new Cvijet(Vrsta.Ljiljan, "Lilium", "Crvena", DateTime.Now.AddDays(-1), 1));
            cvjećara.ProvjeriLatinskaImenaCvijeća();
            Assert.AreEqual(1, cvjećara.Cvijeće.Count);
        }

        [TestMethod]
        public void TestPetlji3()
        {
            Cvjećara cvjećara = new Cvjećara();
            cvjećara.Cvijeće.Add(new Cvijet(Vrsta.Ljiljan, "Lilium", "Crvena", DateTime.Now.AddDays(-1), 1));
            cvjećara.Cvijeće.Add(new Cvijet(Vrsta.Ljiljan, "Lilium", "Crvena", DateTime.Now.AddDays(-1), 1));
            cvjećara.ProvjeriLatinskaImenaCvijeća();
            Assert.AreEqual(2, cvjećara.Cvijeće.Count);
        }

        [TestMethod]
        public void TestPetlji4()
        {
            Cvjećara cvjećara = new Cvjećara();
            cvjećara.Cvijeće.Add(new Cvijet(Vrsta.Ljiljan, "Lilium", "Crvena", DateTime.Now.AddDays(-1), 1));
            cvjećara.Cvijeće.Add(new Cvijet(Vrsta.Ljiljan, "Lilium", "Crvena", DateTime.Now.AddDays(-1), 1));
            cvjećara.Cvijeće.Add(new Cvijet(Vrsta.Ljiljan, "Lilium", "Crvena", DateTime.Now.AddDays(-1), 1));
            cvjećara.Cvijeće.Add(new Cvijet(Vrsta.Ljiljan, "Lilium", "Crvena", DateTime.Now.AddDays(-1), 1));
            cvjećara.ProvjeriLatinskaImenaCvijeća();
            Assert.AreEqual(4, cvjećara.Cvijeće.Count);
        }
        #endregion 
    }
}
