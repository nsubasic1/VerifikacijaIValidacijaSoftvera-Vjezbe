using Cvjecara;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestNagradnaKupovina()
        {
            Mu�terija mu�terija = new("mujo");
            Poklon poklon = new("test", 20);
            for(int i=0; i < 10000; i++)
            {
                mu�terija.RegistrujKupovinu(new Buket(2.0), new Poklon("", 10));
            }
            Assert.IsTrue(mu�terija.NagradnaKupovina(poklon));
        }


    }
}
