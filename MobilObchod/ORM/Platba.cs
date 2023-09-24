using System;
using System.Collections.Generic;
using System.Text;

namespace MobilObchod.ORM
{
    public class Platba
    {
        public int Id { get; set; }
        public string Nazev { get; set; }
        public Decimal Cena { get; set; }
        public DateTime? Datum_platby { get; set; }
        public DateTime Datum_zmeny { get; set; }
    }
}
