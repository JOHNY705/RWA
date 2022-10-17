using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplikacija_za_administraciju.Models
{
    public class Tim
    {
        public int IDTim { get; set; }
        public string Naziv { get; set; }
        public Djelatnik Voditelj { get; set; }

        public Tim()
        {

        }

        public Tim(string naziv, Djelatnik voditeljTima)
        {
            Naziv = naziv;
            Voditelj = voditeljTima;
        }

        public Tim(int idTim, string naziv, Djelatnik voditeljTima) : this(naziv, voditeljTima)
        {
            IDTim = idTim;
        }

        public override string ToString()
        {
            return $"{Naziv}";
        }
    }
}