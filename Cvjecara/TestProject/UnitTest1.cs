using System;
using Cvjecara;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
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
    }
}
