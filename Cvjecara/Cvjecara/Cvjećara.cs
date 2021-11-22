
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvjecara
{
    public class Cvjećara
    {
        #region Atributi

        List<Cvijet> cvijeće;
        List<Buket> buketi;
        List<Mušterija> mušterije;
        List<Poklon> naručeniPokloni;

        #endregion

        #region Properties

        public List<Cvijet> Cvijeće { get => cvijeće; }
        public List<Poklon> NaručeniPokloni { get => naručeniPokloni; set => naručeniPokloni = value; }
        public List<Mušterija> Mušterije { get => mušterije; set => mušterije = value; }

        #endregion

        #region Konstruktor

        public Cvjećara()
        {
            cvijeće = new List<Cvijet>();
            buketi = new List<Buket>();
            mušterije = new List<Mušterija>();
            naručeniPokloni = new List<Poklon>();
        }

        #endregion

        #region Metode

        public void RadSaCvijećem(Cvijet c, int opcija)
        {
            if (opcija == 0)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće dodati cvijet koji ne postoji!");
                else if (cvijeće.Contains(c))
                    throw new InvalidOperationException("Nemoguće dodati cvijet koji već postoji!");
                else
                    cvijeće.Add(c);
            }
            else if (opcija == 1)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće izmijeniti cvijet koji ne postoji!");
                else if (cvijeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme) == null)
                    throw new InvalidOperationException("Nemoguće izmijeniti cvijet koji ne postoji!");
                else
                {
                    cvijeće.Remove(cvijeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme));
                    cvijeće.Add(c);
                }
            }
            else if (opcija == 2)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće obrisati cvijet koji ne postoji!");
                else if (cvijeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme) == null)
                    throw new InvalidOperationException("Nemoguće obrisati cvijet koji ne postoji!");
                else
                {
                    cvijeće.Remove(cvijeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme));
                }
            }
            else
                throw new InvalidOperationException("Unijeli ste nepoznatu opciju!");
        }

        public void DodajBuket(List<Cvijet> cvijeće, List<string> dodaci, Poklon poklon, double cijena)
        {
            Buket b = new Buket(cijena);
            b.DodajPoklon(poklon);
            foreach (Cvijet c in cvijeće)
                b.DodajCvijet(c);
            foreach (string dodatak in dodaci)
                b.DodajDodatak(dodatak);
            buketi.Add(b);
        }

        public bool ObrišiBuket(Buket b)
        {
            return buketi.Remove(b);
        }

        public List<Buket> DajSveBukete()
        {
            return buketi;
        }

        public void IzvršiNabavku(string godišnjeDoba, string veličinaNarudžbe)
        {
            int kol;
            switch (veličinaNarudžbe)
            {
                case "Velika": kol = 100;
                    break;
                case "Mala": kol = 10;
                    break;
                default: throw new ArgumentException("Ilegalna veličina narudžbe");
            }

            switch (godišnjeDoba)
            {
                case "Proljeće":
                    cvijeće.Clear();
                    buketi.Clear();
                    cvijeće.Add(new Cvijet(Vrsta.Ljiljan, "Lilium bosniacum", "Žuta", DateTime.Now, kol));
                    cvijeće.Add(new Cvijet(Vrsta.Neven, "Lilium bosniacum", "Žuta", DateTime.Now, kol));
                    cvijeće.Add(new Cvijet(Vrsta.Margareta, "Lilium bosniacum", "Žuta", DateTime.Now, kol));
                    break;
                case "Jesen":
                    cvijeće.Clear();
                    buketi.Clear();
                    cvijeće.Add(new Cvijet(Vrsta.Ruža, "Lilium bosniacum", "Žuta", DateTime.Now, kol));
                    cvijeće.Add(new Cvijet(Vrsta.Orhideja, "Lilium bosniacum", "Žuta", DateTime.Now, kol));
                    break;
                default: throw new ArgumentException("Nedozvoljena nabavka ljeti ili zimi");
            }
        }

        public void PregledajCvijeće()
        {
            foreach (Cvijet cvijet in cvijeće)
            {
                cvijet.ProvjeriKrajSezone();
                if (cvijet.OdrediSvježinuCvijeća() < 2)
                    cvijet.Kolicina = 0;
            }

            cvijeće.RemoveAll(cvijet => cvijet.Kolicina == 0);
        }

        public void NaručiCvijeće(Mušterija m, Buket b, Poklon p, Poklon nagrada = null)
        {
            if (!buketi.Contains(b))
                throw new InvalidOperationException("Traženi buket nije na stanju!");

            m.RegistrujKupovinu(b, p);
            naručeniPokloni.Add(p);

            if (nagrada != null)
                m.NagradnaKupovina(p);
        }

        public void ProvjeriLatinskaImenaCvijeća(ILeksikon leksikon)
        {
            List<Cvijet> zaObrisati = new List<Cvijet>();
            foreach (Cvijet c in cvijeće)
            {
                if (!leksikon.ValidnoLatinskoIme(c.LatinskoIme))
                    zaObrisati.Add(c);
            }
            cvijeće.RemoveAll(cvijet => zaObrisati.Contains(cvijet));
        }

        public List<Poklon> DajSveNaručenePoklone(Mušterija m, double popust)
        {
            List<Poklon> pokloni = m.KupljeniPokloni.FindAll(poklon => poklon.PostotakPopusta == popust);
            if (pokloni == null)
                throw new FormatException("Došlo je do greške! Pokušajte ponovo sa drugim parametrima zahtjeva.");

            return pokloni;
        }

        /// <summary>
        /// Metoda koja vraća mušteriju koja je izvršila najveći broj kupovina.
        /// Ukoliko cvjećara nema nijednu mušteriju, potrebno je baciti izuzetak.
        /// U suprotnom, potrebno je pronaći mušteriju koja je ukupno kupila najviše cvijeća
        /// u svim buketima koje je naručila.
        /// Ukoliko postoji više takvih mušterija, potrebno je vratiti onu mušteriju
        /// koja je potrošila veći ukupni iznos novca na sve kupljene bukete.
        /// Ukoliko i u tom slučaju postoji više mušterija, potrebno je baciti izuzetak
        /// jer se najbolja mušterija u tom slučaju ne može tačno odrediti.
        /// </summary>
        /// <returns></returns>
       public Mušterija DajNajboljuMušteriju()
        {
            Mušterija najbolja_musterija = null;
            //radila Medina 
            if (mušterije.Count()==0) {
                throw new NotImplementedException("Cvjecara nema nijednu musteriju!");
            }

            //prvo pronalazim koliko je maksimalan broj cvijeca u buketu
            int max_cvijeca=0;
            int br_cvijeca;
            foreach(Mušterija musterija in mušterije) {
                foreach(Buket buket in musterija.KupljeniBuketi) {
                br_cvijeca=buket.Cvijeće.Count();
                if(br_cvijeca>max_cvijeca)
                    max_cvijeca=br_cvijeca;
                }
            }

            //zatim pronalazim koliko ima musterija sa maksimalnim brojem cvijeca u buketu
            //i dodajem ih u listu najboljih musterija
            int br_musterija=0;
            List<Mušterija> najbolje_musterije = new List<Mušterija>();
            foreach(Mušterija musterija in mušterije) {
                foreach(Buket buket in musterija.KupljeniBuketi) {
                    if(buket.Cvijeće.Count()==max_cvijeca) {
                        br_musterija++;
                        najbolje_musterije.Add(musterija);
                    }
                }
            }

            //vracam jedinu musteriju 
            if(br_musterija==1) {
                najbolja_musterija = najbolje_musterije.ElementAt(0);
            }
            //ako ima vise od jedne musterije sa istim brojem cvijeca onda trazimo onu musteriju
            //koja je potrosila najvise novca na sve kupljene bukete
            else if(br_musterija>1) {
            double max_cijena=0;
                foreach(Mušterija musterija in najbolje_musterije) {
                    double cijena_buketa=0;
                    foreach(Buket buket in musterija.KupljeniBuketi) {
                        cijena_buketa+=buket.Cijena;
                    }
                    if(cijena_buketa>max_cijena)
                        max_cijena=cijena_buketa;
                }
                //ako ima vise musterija koje su platile istu cijenu bacamo izuzetak 
                //a ako nema vracamo tu musteriju koja je najvise platila
                int brojac_musterija=0;
                foreach(Mušterija musterija in najbolje_musterije) {
                double cijena_buketa=0;
                    foreach(Buket buket in musterija.KupljeniBuketi) {
                        cijena_buketa+=buket.Cijena;
                    }
                    if(cijena_buketa==max_cijena) {
                        najbolja_musterija=musterija;
                        brojac_musterija++;
                    } 
                    //ako je brojac_musterija=1 onda imamo najbolju musteriju po kriteriju max cijene
                    //a akoje je brojac_musterija>1 onda ih imamo vise i bacamo izuzetak
                    
                }
                if(brojac_musterija > 1) {
                        throw new NotImplementedException("Ne moze se odrediti najbolja musterija");
                    }
            }
            return najbolja_musterija;
        }

        #endregion
    }
}
