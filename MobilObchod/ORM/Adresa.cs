using System;
using System.Collections.Generic;
using System.Text;

namespace MobilObchod.ORM
{
    public class Adresa
    {
        public int Id { get; set; }
        public string Mesto { get; set; }
        public string Ulice { get; set; }
        public string Zeme { get; set; }
        public string Psc { get; set; }
        public DateTime Datum_zmeny { get; set; }
    }
}
