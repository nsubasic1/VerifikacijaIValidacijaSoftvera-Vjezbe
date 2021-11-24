using Cvjecara;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class BuketTest
    {
        /// <summary>
        /// Test izuzetka
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestMethod1()
        {
            //Radila Medina
            Buket buketic= new(0.0003);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void SetterDodaciIzuzetakTest()
        {
            Buket buket = new Buket(1);
            List<string> dodaci = new List<string> { "Lišće", "Slama", "Trava", "Lisce" };
            buket.Dodaci = dodaci;
        }
    }
}
