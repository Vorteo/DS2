using System;
using System.Collections.Generic;
using System.Text;

namespace MobilObchod.ORM
{
    public class ProduktKategorie
    {
        public Produkt Produkt { get; set; }
        public Kategorie Kategorie { get; set; }
    }
}
