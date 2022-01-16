using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver webDriver;
        private static IEnumerable<object[]> IzletiTestni
        {
            get
            {
                return new[]
                {
                    new object[] {"Kozara", "1"},
                    new object[] { "Bjelašnica", null},
                    new object[] { "Igman", "0.1" },
                    new object[] { "Igman", "2" }
                };
            }
        }

        [TestMethod]
        [DynamicData("IzletiTestni")] //DDT
        public void validiranjeTestnihSlucajeva(string planina, string vrijeme)
        {
            webDriver = new ChromeDriver();
            string url = "https://localhost:5001/Grupa2/Create";
            webDriver.Navigate().GoToUrl(url);

            //unos podatka o nazivu planine
            IWebElement inputPlanina = webDriver.FindElement(By.Id("lokacija"));
            inputPlanina.SendKeys(planina);
            Thread.Sleep(100);

            //unos podataka o vremenu sa provjerom na null (vrijeme nije uneseno)
            if(vrijeme!=null)
            {
                IWebElement inputVrijeme = webDriver.FindElement(By.Id("trajanje"));
                inputVrijeme.SendKeys(vrijeme);
                Thread.Sleep(100);
            }

            //provjera unesenih podataka
            IWebElement buttonProvjeri = webDriver.FindElement(By.Id("BtnProvjeri"));
            buttonProvjeri.Click();
            Thread.Sleep(100);
            var alertProzor = webDriver.SwitchTo().Alert();
            string porukaAlertProzora = alertProzor.Text;
            alertProzor.Accept();

            //testiranje
            string[] planineSarajeva = { "Bjelašnica", "Igman", "Trebević", "Jahorina", "Treskavica" };
            //unesena planina nije u nizu planina Sarajeva
            if (!planineSarajeva.Contains(planina))
            {
                string tekstGreske1 = "Podržane su samo lokacije izleta na okolnim sarajevskim planinama!";
                Assert.AreEqual(porukaAlertProzora, tekstGreske1);
            }

            //trajanje nije uneseno
            else if(vrijeme==null)
            {
                string tekstGreske2 = "Za provjeru lokacije morate unijeti vrijeme trajanja...";
                Assert.AreEqual(porukaAlertProzora, tekstGreske2);
            }

            //specijala slucaj planine Igman
            else if(float.Parse(vrijeme)<0.2  && planina=="Igman")
            {
                string tekstGreske3 = "Na Igmanu se mora provesti više od dvije minute!";
                Assert.AreEqual(porukaAlertProzora, tekstGreske3);
            }

            //svi podaci su ispravni
            else
            {
                string ispravniPodaci = "Lokacija odgovara vremenu trajanja!";
                Assert.AreEqual(porukaAlertProzora, ispravniPodaci);
            }


        }
    }
}
