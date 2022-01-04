
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        public void RadSaCvijećem(Cvijet c, int opcija, int minKoličina)
        {
            if (opcija == 0)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće dodati cvijet koji ne postoji!");
                else
                {
                    Cvijet postojeći = null;
                    foreach (Cvijet cvijet in cvijeće)
                    {
                        if (cvijet.LatinskoIme == c.LatinskoIme)
                        {
                            if (cvijet.Kolicina < minKoličina * 1000)
                                continue;
                            else
                                postojeći = cvijet;
                        }
                    }

                    if (postojeći != null)
                        throw new InvalidOperationException("Nemoguće dodati cvijet koji već postoji!");
                    else
                        cvijeće.Add(c);
                }
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

        //Radila Medina
        public void RadSaCvijećemTuning1(Cvijet c, int opcija, int minKoličina)
        {
            if (opcija == 0)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće dodati cvijet koji ne postoji!");
                else
                {
                    foreach (Cvijet cvijet in cvijeće)
                    {
                        if (cvijet.LatinskoIme == c.LatinskoIme)
                        {
                            if (cvijet.Kolicina < minKoličina * 1000)
                                continue;
                            else
                                throw new InvalidOperationException("Nemoguće dodati cvijet koji već postoji!");
                        }
                    }
                    //Nije doslo do izuzetka znaci da cvijet c ne postoji u listi cvijeca pa ga mozemo dodati
                    cvijeće.Add(c);
                }
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

        //Radila Nejla
        public void RadSaCvijećemTuning2(Cvijet c, int opcija, int minKoličina)
        {
            if (opcija == 0)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće dodati cvijet koji ne postoji!");
                else
                {
                    foreach (Cvijet cvijet in cvijeće)
                    {
                        string datoIme = c.LatinskoIme;
                        string pronadjenoIme = cvijet.LatinskoIme;
                        if (datoIme == pronadjenoIme)
                        {
                            int kolicina = cvijet.Kolicina;
                            int min = minKoličina * 1000;
                            if (kolicina < min)
                                continue;
                            else
                                throw new InvalidOperationException("Nemoguće dodati cvijet koji već postoji!");
                        }
                    }
                    cvijeće.Add(c);
                }
            }
            else if (opcija == 1)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće izmijeniti cvijet koji ne postoji!");
                else if (cvijeće.Find(cvijet => {
                        string datoIme = c.LatinskoIme;
                        string pronadjenoIme = cvijet.LatinskoIme;
                    return datoIme == pronadjenoIme;
                }) == null)
                    throw new InvalidOperationException("Nemoguće izmijeniti cvijet koji ne postoji!");
                else
                {
                    cvijeće.Remove(cvijeće.Find(cvijet => {
                        string datoIme = c.LatinskoIme;
                        string pronadjenoIme = cvijet.LatinskoIme;
                        return datoIme == pronadjenoIme;
                    }));
                    cvijeće.Add(c);
                }
            }
            else if (opcija == 2)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće obrisati cvijet koji ne postoji!");
                else if (cvijeće.Find(cvijet => {
                        string datoIme = c.LatinskoIme;
                        string pronadjenoIme = cvijet.LatinskoIme;
                    return datoIme == pronadjenoIme;
                }) == null)
                    throw new InvalidOperationException("Nemoguće obrisati cvijet koji ne postoji!");
                else
                {
                    cvijeće.Remove(cvijeće.Find(cvijet => {
                        string datoIme = c.LatinskoIme;
                        string pronadjenoIme = cvijet.LatinskoIme;
                        return datoIme == pronadjenoIme;
                    }));
                }
            }
            else
                throw new InvalidOperationException("Unijeli ste nepoznatu opciju!");
        }

        //Radila Kanita
        public void RadSaCvijećemTuning3(Cvijet c, int opcija, int minKoličina)
        {
            if (opcija == 0)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće dodati cvijet koji ne postoji!");
                else
                {
                    foreach (Cvijet cvijet in cvijeće)
                    {
                        string datoIme = c.LatinskoIme;
                        string pronadjenoIme = cvijet.LatinskoIme;
                        if (datoIme == pronadjenoIme)
                        {
                            int kolicina = cvijet.Kolicina;
                            int min = 0;
                            for (int i = 0; i < 1000; i++)
                            {
                                min += minKoličina; 
                            }

                            if (kolicina < min)
                                continue;
                            else
                                throw new InvalidOperationException("Nemoguće dodati cvijet koji već postoji!");
                        }
                    }
                    cvijeće.Add(c);
                }
            }
            else if (opcija == 1)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće izmijeniti cvijet koji ne postoji!");
                else if (cvijeće.Find(cvijet => {
                    string datoIme = c.LatinskoIme;
                    string pronadjenoIme = cvijet.LatinskoIme;
                    return datoIme == pronadjenoIme;
                }) == null)
                    throw new InvalidOperationException("Nemoguće izmijeniti cvijet koji ne postoji!");
                else
                {
                    cvijeće.Remove(cvijeće.Find(cvijet => {
                        string datoIme = c.LatinskoIme;
                        string pronadjenoIme = cvijet.LatinskoIme;
                        return datoIme == pronadjenoIme;
                    }));
                    cvijeće.Add(c);
                }
            }
            else if (opcija == 2)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće obrisati cvijet koji ne postoji!");
                else if (cvijeće.Find(cvijet => {
                    string datoIme = c.LatinskoIme;
                    string pronadjenoIme = cvijet.LatinskoIme;
                    return datoIme == pronadjenoIme;
                }) == null)
                    throw new InvalidOperationException("Nemoguće obrisati cvijet koji ne postoji!");
                else
                {
                    cvijeće.Remove(cvijeće.Find(cvijet => {
                        string datoIme = c.LatinskoIme;
                        string pronadjenoIme = cvijet.LatinskoIme;
                        return datoIme == pronadjenoIme;
                    }));
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

        public void PregledajCvijeće()
        {
            foreach (Cvijet cvijet in cvijeće)
            {
                cvijet.ProvjeriKrajSezone();
                if (cvijet.DatumBranja.AddDays(7) <= DateTime.Now)
                    cvijet.Kolicina = 0;
            }

            cvijeće.RemoveAll(cvijet => cvijet.Kolicina == 0);
        }

        //Radila Kanita
        public void PregledajCvijećeRefaktoring()
        {
            cvijeće.RemoveAll(cvijet => { cvijet.ProvjeriKrajSezone(); return cvijet.Kolicina == 0 || cvijet.DatumBranja.AddDays(7) <= DateTime.Now;  });
        }

        public void NaručiCvijeće(Mušterija m, Buket b, Poklon p)
        {
            if (!buketi.Contains(b))
                throw new InvalidOperationException("Traženi buket nije na stanju!");

            m.RegistrujKupovinu(b, p);
            naručeniPokloni.Add(p);
        }

        public void ProvjeriLatinskaImenaCvijeća()
        {
            List<Cvijet> zaObrisati = new List<Cvijet>();
            for (int i = 0; i < cvijeće.Count; i++)
            {
                if (cvijeće[i].Vrsta == Vrsta.Ruža && cvijeće[i].LatinskoIme != "Rosa")
                    zaObrisati.Add(cvijeće[i]);
                else if (cvijeće[i].LatinskoIme != "Lilium" && cvijeće[i].LatinskoIme != "Calendula" &&
                         cvijeće[i].LatinskoIme != "Orchidacea" && cvijeće[i].LatinskoIme != "Leucanthemum")
                    zaObrisati.Add(cvijeće[i]);
            }
            cvijeće.RemoveAll(cvijet => zaObrisati.Contains(cvijet));

            if (cvijeće.Count == 0)
                throw new ArgumentException("Obrisano je svo cvijeće iz kolekcije!");
            else
                return;
        }
        
        //radila Medina
        public void ProvjeriLatinskaImenaCvijećaRefaktoring()
        {
            List<Cvijet> zaObrisati = cvijeće.FindAll(cvijet => cvijet.Vrsta == Vrsta.Ruža && cvijet.LatinskoIme != "Rosa"
            || cvijet.LatinskoIme != "Lilium" && cvijet.LatinskoIme != "Calendula" &&
               cvijet.LatinskoIme != "Orchidacea" && cvijet.LatinskoIme != "Leucanthemum");  
            
            cvijeće.RemoveAll(cvijet => zaObrisati.Contains(cvijet));

            if (cvijeće.Count == 0)
                throw new ArgumentException("Obrisano je svo cvijeće iz kolekcije!");
        }

        public List<Poklon> DajSveNaručenePoklone(Mušterija m, double popust)
        {
            List<Poklon> pokloni = m.KupljeniPokloni.FindAll(poklon => poklon.PostotakPopusta == popust);
            if (pokloni == null)
                throw new FormatException("Došlo je do greške! Pokušajte ponovo sa drugim parametrima zahtjeva.");

            return pokloni;
        }

        #endregion
    }
}
