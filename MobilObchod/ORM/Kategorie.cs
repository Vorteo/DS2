using System;
using System.Collections.Generic;
using System.Text;

namespace MobilObchod.ORM
{
    public class Kategorie
    {
        public int Id { get; set; }
        public string Nazev { get; set; }
        public DateTime Datum_zmeny { get; set; }
        public string Popis { get; set; }




        public override string ToString()
        {
            return Nazev;
        }
    }
}
