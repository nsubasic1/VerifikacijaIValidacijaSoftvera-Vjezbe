﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvjecara
{
    public class Poklon
    {
        #region Atributi

        string šifra, opis;
        double postotakPopusta;
        int brojač = 10000;

        #endregion

        #region Properties

        public string Šifra { get => šifra; }
        public string Opis { get => opis; set => opis = value; }
        public double PostotakPopusta { get => postotakPopusta; }

        #endregion

        #region Konstruktor

        public Poklon(string opis, double postotak)
        {
            šifra = brojač.ToString();
            brojač++;
            Opis = opis;
            if (postotak < 0.1)
                throw new InvalidOperationException("Nemoguće dodati postotak manji od 0.1!");
            postotakPopusta = postotak;
        }

        #endregion
    }
}
