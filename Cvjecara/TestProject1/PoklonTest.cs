using Cvjecara;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class PoklonTest
    {

    /// <summary>
    /// Test provjere postotka
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestMethod1()
    {
        //Radila Medina
        Poklon poklončić = new("Loptica", 0);
    }
    }
}
