using System;
using System.Collections.Generic;
using System.Text;

namespace MobilObchod.ORM
{
    public class Objednavka
    {
        public int Id { get; set; }
        public DateTime Datum_vytvoreni { get; set; }
        public string Stav { get; set; }
        public Decimal Celkova_cena { get; set; }
        public int zId { get; set; }
        public int? pId { get; set; }
        public int dId { get; set; }
        public string druh_platby { get; set; }
        public string druh_dopravy { get; set; }
        public DateTime Datum_zmeny { get; set; }


    }
    public class ObjednavkaStatistika
    {
        public int Period { get; set; }
        public Decimal Sum { get; set; }
        public int CountObj { get; set; }
        public int CountUzivatel { get; set; }
    }
}
