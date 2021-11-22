using Cvjecara;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

    }
}
