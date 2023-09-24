using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MobilObchod.ORM
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Nazev { get; set; }
        public string Vyrobce { get; set; }
        public string Image { get; set; } // Image jak uchovat - binarka?
        public string Popis { get; set; }
        public string Barva { get; set; }
        public int Hmotnost { get; set; }
        public Decimal Cena { get; set; }
        public int Pocet_kusu { get; set; }
        public DateTime Datum_pridani { get; set; }
        public DateTime Datum_zmeny { get; set; }
        public Boolean isActive { get; set; }

        public override string ToString() 
        {
            return Nazev;
        }

    }

    public class ListProdukt
    {
        public Produkt Produkt { get; set; }
        public string KatNazev { get; set; }
        public int Sum { get; set; }

    }
}
