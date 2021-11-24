using CsvHelper;
using Cvjecara;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;

namespace TestProject1
{
    [TestClass]
    public class CvijetTest
    {
        static IEnumerable<object[]> CvijetoviNeispravniPodaciCSV
        {
            get
            {
                return UčitajPodatkeNeispravneCSV();
            }
        }
        static IEnumerable<object[]> CvijetoviIspravniPodaciCSV
        {
            get
            {
                return UčitajPodatkeIspravneCSV();
            }
        }

        public static IEnumerable<object[]> UčitajPodatkeIspravneCSV()
        {
            using (var reader = new StreamReader("CvijetoviNeispravniPodaci.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1], elements[2], DateTime.Parse(elements[3]), elements[4] };
                }
            }
        }
        public static IEnumerable<object[]> UčitajPodatkeNeispravneCSV()
        {
            using (var reader = new StreamReader("CvijetoviNeispravniPodaci.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1], elements[2] ,DateTime.Parse(elements[3]), elements[4]};
                }
            }
        }

        [TestMethod]
        [DynamicData("CvijetoviNeispravniPodaciCSV")]
        [ExpectedException(typeof(FormatException))]
        public void testKonstruktoraNeispravniPodaci(string vrsta, string ime, string boja, DateTime datumBranja, string kol)
        {
            //Radila Kanita
            Cvijet cvijet = new Cvijet(Enum.Parse<Vrsta>(vrsta), ime, boja, datumBranja, Int32.Parse(kol));
        }

        [TestMethod]
        [DynamicData("CvijetoviIspravniPodaciCSV")]
        [ExpectedException(typeof(FormatException))]
        public void testKonstruktoraIspravniPodaci(string vrsta, string ime, string boja, DateTime datumBranja, string kol)
        {
            //Radila Kanita
            Cvijet cvijet = new Cvijet(Enum.Parse<Vrsta>(vrsta), ime, boja, datumBranja, Int32.Parse(kol));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void testSeteraLatinskoImePromijena()
        {
            //Radila Kanita
            Cvijet cvijet = new Cvijet(Vrsta.Ruža, "Ruža1", "Crvena", DateTime.Now, 10);
            cvijet.LatinskoIme = "Ruža latinsko ime";
        }

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

        // <summary>
        /// Testiranje ukoliko je svjezina cvijeca manja od 0
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            //Radila Medina
            Cvijet ljiljan= new(Vrsta.Ljiljan, "Ime ljiljana", "Bijela", DateTime.Now.AddDays(-10), 100);
            Cvijet margareta = new(Vrsta.Margareta, "Ime margarete", "Žuta", DateTime.Now.AddDays(-10), 200);
            Cvijet neven = new(Vrsta.Neven, "Ime nevena", "Žuta", DateTime.Now.AddDays(-10), 210);
            Cvijet orhideja = new(Vrsta.Orhideja, "Ime orhideje", "Roza", DateTime.Now.AddDays(-10), 50);
            Cvijet ruza = new Cvijet(Vrsta.Ruža, "Ime ruze", "Crvena", DateTime.Now.AddDays(-10), 70);

            Assert.AreEqual(ljiljan.OdrediSvježinuCvijeća(), 0);
            Assert.AreEqual(margareta.OdrediSvježinuCvijeća(), 0);
            Assert.AreEqual(neven.OdrediSvježinuCvijeća(), 0);
            Assert.AreEqual(orhideja.OdrediSvježinuCvijeća(), 0);
            Assert.AreEqual(ruza.OdrediSvježinuCvijeća(), 0);
        }

        /// <summary>
        /// Test provjere kraja sezone
        /// </summary>
        [TestMethod]
        public void TestMethod7()
        {
            //Radila Medina
            Cvijet cvjetic = new(Vrsta.Ruža, "Ruza", "Crvena", DateTime.Now, 5);
            cvjetic.ProvjeriKrajSezone();
            Assert.AreEqual(cvjetic.Sezonsko, false);
        }
    }
}
