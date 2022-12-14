using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplikacija_za_administraciju.Models
{
    public class Projekt
    {
        public int IDProjekt { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumOtvaranja { get; set; }
        public Djelatnik Voditelj { get; set; }
        public Klijent Klijent { get; set; }
        public string OpisProjekta { get; set; }

        public Projekt(string naziv, DateTime datumOtvaranja, Djelatnik voditelj, Klijent klijent, string opisProjekta)
        {
            Naziv = naziv;
            DatumOtvaranja = datumOtvaranja;
            Voditelj = voditelj;
            Klijent = klijent;
            OpisProjekta = opisProjekta;
        }

        public Projekt(int idProjekt, string naziv, DateTime datumOtvaranja, Djelatnik voditelj, Klijent klijent, string opisProjekta) : this(naziv, datumOtvaranja, voditelj, klijent, opisProjekta)
        {
            IDProjekt = idProjekt;
        }

        public override string ToString()
        {
            return $"{Naziv}";
        }

        public override bool Equals(object obj)
        {
            return obj is Projekt other && other.IDProjekt.Equals(IDProjekt);
        }

        public override int GetHashCode()
        {
            return IDProjekt.GetHashCode();
        }
    }
}