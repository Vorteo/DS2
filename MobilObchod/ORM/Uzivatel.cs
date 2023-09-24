using System;
using System.Collections.Generic;
using System.Text;

namespace MobilObchod.ORM
{
    public class Uzivatel
    {
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Typ_uzivatele { get; set; }
        public string Login { get; set; }
        public DateTime? Datum_registrace { get; set; }
        public DateTime Datum_zmeny { get; set; }
        public int IdAdresa { get; set; }
        public Adresa Adresa { get; set; }
        public Boolean Is_active { get; set; }

    }
}
