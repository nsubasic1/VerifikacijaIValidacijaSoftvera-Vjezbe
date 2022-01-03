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
            for (int i = 0; i < 10000000; i++)
                klasa.Cvijeće.Add(new Cvijet(Vrsta.Ruža, "Rosa", "Crvena", DateTime.Now.AddDays(-1), 1));
            Cvijet c = new Cvijet(Vrsta.Orhideja, "Orchid", "Crvena", DateTime.Now.AddDays(-1), 1);
            //prvi breakpoint prije poziva metode
            int x = 0;
            //prije tuninga
            klasa.RadSaCvijećem(c, 0, 1);
            int y = 0;

            Assert.IsTrue(true);
        }
    }
}
