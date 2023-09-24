using System;
using System.Collections.Generic;
using System.Text;

namespace MobilObchod.ORM
{
    public class HistorieProduktu
    {
        public int Id { get; set; }
        public DateTime Datum_zmeny { get; set; }
        public string Nazev_atributu { get; set; }
        public string Hodnota { get; set; }
        public Produkt Produkt { get; set; }
    }
}
