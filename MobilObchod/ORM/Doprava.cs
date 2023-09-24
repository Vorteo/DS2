using System;
using System.Collections.Generic;
using System.Text;

namespace MobilObchod.ORM
{
    public class Doprava
    {
        public int Id { get; set; }
        public string Nazev { get; set; }
        public Decimal Cena { get; set; }
        public string Popis { get; set; }
        public DateTime Datum_zmeny { get; set; }
    }
}
