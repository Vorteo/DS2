using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MobilObchod.ORM;
using MobilObchod.ORM.dao;
                /*Zjistil jsem, ze v dokumentaci analyzy se objevuji spatne ocislovane seznamy funkci napr.(stejne cislo u vice funkci).
                 * Takze tady jsem to snad konecne ocisloval spravne.*/
namespace MobilObchod
{
    class Program
    {
        static void Main()
        {

            Database db = new Database();
            db.Connect();
            
            Uzivatel u = new Uzivatel();
            u.Jmeno = "Martin";
            u.Prijmeni = "Kaleta";
            u.Telefon = "722123456";
            u.Email = "martin.kaleta.st@vsb.cz";
            u.Typ_uzivatele = "Neregistrovany zakaznik";
            u.Login = null;
            u.Datum_registrace = null;
            u.Datum_zmeny = DateTime.Now;
            u.IdAdresa = 1;
            u.Is_active = true;
            
             int count1 = UzivatelTable.Select(db).Count;
             // 1.2
             UzivatelTable.Insert(u, db);
             int count2 = UzivatelTable.Select(db).Count;

             Console.WriteLine("1.2:");
             Console.WriteLine("Before Insert:" + count1);
             Console.WriteLine("After Insert:" + count2);
             Console.WriteLine();



            u.Id = 13;
            u.Jmeno = "Miroslav";
            u.Telefon = "+420888333111";

            // 1.4
            UzivatelTable.Update(u, db);

            // 1.5
            UzivatelTable.Delete(u, db);

            // 1.2
            Console.WriteLine("1.2:");
            Collection<Uzivatel> us = UzivatelTable.Select(12, db);
            Console.WriteLine(us[0].Id + " " + us[0].Jmeno + " " + us[0].Prijmeni + " " + us[0].Telefon + " " + us[0].Is_active);
            Console.WriteLine();

            // 1.1
            Console.WriteLine("1.1:");
            Collection<Uzivatel> u1 = UzivatelTable.Select(db, "Martin");
            foreach (Uzivatel uu in u1)
            {
                Console.WriteLine(uu.Id + "  " + uu.Jmeno + "  " + uu.Prijmeni + "  " + uu.Telefon +"  "+ uu.Email);
            }
            Console.WriteLine();

            Adresa a = new Adresa();
            a.Mesto = "Brno";
            a.Psc = "73931";
            a.Ulice = "Lucni 402";
            a.Zeme = "Czech";
            a.Datum_zmeny = DateTime.Now;

            // 2.1
            AdresaTable.Insert(a, db);

            a.Id = 9;
            a.Ulice = "Nova ulice 25";

            // 2.2
            AdresaTable.Update(a, db);

            // 5.1
            Console.WriteLine("5.1:");
            Collection<Kategorie> kategories = KategorieTable.Select(db);
            foreach (Kategorie kat in kategories)
            {
                Console.WriteLine(kat.Id + "  " + kat.Nazev + "  " + kat.Popis + "  " + kat.Datum_zmeny);
            }
            Console.WriteLine();

            Console.WriteLine("5.2:");
            Console.WriteLine("Before Insert:" + KategorieTable.Select(db).Count);

            Kategorie k = new Kategorie();
            k.Nazev = "NovaKategorie";
            k.Popis = "Toto je nova kategorie";
            k.Datum_zmeny = DateTime.Now;

            // 5.2
            KategorieTable.Insert(k, db);
            
            Console.WriteLine("After insert:" + KategorieTable.Select(db).Count);
            Console.WriteLine();

            k.Id = 24;
            k.Nazev = "Zmena Kategorie";

            // 5.3
            KategorieTable.Update(k, db);

            // 5.4
            KategorieTable.Delete(16, db);

            Console.WriteLine("5.4:");
            Console.WriteLine("After delete:" + KategorieTable.Select(db).Count);
            Console.WriteLine();

            // 7.1  
            Console.WriteLine("7.1:");
            Collection<Doprava> dopravas = DopravaTable.Select(db);
            foreach (Doprava dop in dopravas)
            {
                Console.WriteLine(dop.Id + "  " + dop.Nazev + "  " + dop.Popis + "  " + dop.Datum_zmeny + " " + dop.Cena);
            }
            Console.WriteLine();

            Doprava doprava = new Doprava();
            doprava.Nazev = "Osobne";
            doprava.Cena = 100;
            doprava.Popis = "Popis pro dopravu.";
            doprava.Datum_zmeny = DateTime.Now;

            // 7.2
            Console.WriteLine("7.2:");
            Console.WriteLine("Before insert:" + DopravaTable.Select(db).Count);
            DopravaTable.Insert(doprava, db);
            Console.WriteLine("After insert:" + DopravaTable.Select(db).Count);
            Console.WriteLine();

            // 7.3
            doprava.Id = 7;
            doprava.Popis = "Zmeneny popis.";
            DopravaTable.Update(doprava,db);
            
            // 7.4
            DopravaTable.Delete(5,db);


            // 6.1
            Console.WriteLine("6.1:");
            Collection<Platba> platbas = PlatbaTable.Select(db);
            foreach (Platba pla in platbas)
            {
                Console.WriteLine(pla.Id + "  " + pla.Nazev + "  " + pla.Cena + "  " + pla.Datum_zmeny + " " + pla.Datum_platby);
            }
            Console.WriteLine();

            Platba platba = new Platba();
            platba.Nazev = "Kartou";
            platba.Cena = 10;
            platba.Datum_zmeny = DateTime.Now;


            // 6.2
            Console.WriteLine("6.2:");
            Console.WriteLine("Before insert:" + PlatbaTable.Select(db).Count);
            PlatbaTable.Insert(platba,db);
            Console.WriteLine("After insert:" + PlatbaTable.Select(db).Count);
            Console.WriteLine();

            // 6.3
            platba.Id = 6;
            platba.Datum_platby = DateTime.Now;
            platba.Cena = 500;
            PlatbaTable.Update(platba, db);
            
            string keyword = "Iphone";
            string category_name = "iOS";
            int orderAttr = 2;
            char orderby = 'D';

            // 3.1
            Console.WriteLine("3.1:");
            Collection<ListProdukt> listProdukts = ProduktTable.SelectAll(keyword,category_name,orderAttr,orderby,db);       
            foreach (ListProdukt pla in listProdukts)
            {
                Console.WriteLine(pla.Produkt.Nazev + "     " + pla.Produkt.Pocet_kusu + " " + pla.Produkt.Cena + "      " + pla.KatNazev + "     " + pla.Sum);
            }
            Console.WriteLine();

            Produkt produkt = new Produkt();
            produkt.Nazev = "Novy telefon";
            produkt.Hmotnost = 125;
            produkt.Barva = "Strbrna";
            produkt.Cena = 9999;
            produkt.Datum_pridani = DateTime.Now;
            produkt.Datum_zmeny = DateTime.Now;
            produkt.Pocet_kusu = 10;
            produkt.Vyrobce = "Novy vyrobce";
            produkt.Popis = "Nove vytvoreny produkt";
            produkt.isActive = true;
            // 3.2
            ProduktTable.Insert(produkt, db);

            // 3.3    
            Console.WriteLine("3.3:");
            Collection<Produkt> pr = ProduktTable.SelectOne(6, db);
            Console.WriteLine(pr[0].Id + " " + pr[0].Nazev + " " + pr[0].Vyrobce + " " + pr[0].Popis + " " + pr[0].Barva + " " + pr[0].Hmotnost + " " + pr[0].Pocet_kusu + " " + pr[0].Cena);
            Console.WriteLine();

            // 3.4
            produkt.Pocet_kusu = 100;
            produkt.Id = 11;
            produkt.Cena = 1;
            ProduktTable.Update(produkt, db);
            
            // 3.5
            ProduktTable.Delete(produkt, db);

            // 4.1
            Console.WriteLine("4.1:");
            Collection<Objednavka> objednavkas = ObjednavkaTable.Select(10, db);
            foreach (Objednavka o in objednavkas)
            {
                Console.WriteLine(o.Id + " " + o.Datum_vytvoreni + " " + o.Stav + " " + o.Celkova_cena + " " + o.zId + " " + o.pId + " " + o.dId + " " + o.Datum_zmeny);
            }
            Console.WriteLine();

            // 4.3
            Console.WriteLine("4.3:");
            Collection<Objednavka> obj = ObjednavkaTable.SelectOne(12, db);
            Console.WriteLine(obj[0].Id + " " + obj[0].Datum_vytvoreni + " " + obj[0].Stav + " " + obj[0].Celkova_cena);
            Console.WriteLine();

            // 4.5
            Objednavka o1 = new Objednavka();
            o1.Id = 16;
            ObjednavkaTable.Delete(o1, db);

            
            Objednavka o2 = new Objednavka();
            o2.Id = 14;
            o2.Stav = "Prijata";
            o2.Celkova_cena = 1111;
            o2.Datum_zmeny = DateTime.Now;
            o2.Datum_vytvoreni = DateTime.Now;
            o2.zId = 7;
            o2.pId = 3;
            o2.dId = 2;

            // 4.4
            ObjednavkaTable.Update(o2,db);


            // 4.6
            Console.WriteLine("4.6:");
            string param = "MONTH";
            Collection<ObjednavkaStatistika> listStats = ObjednavkaTable.SelectStats(2021,param,db);
            foreach (ObjednavkaStatistika stat in listStats)
            {
                Console.WriteLine(stat.Period + " " + stat.Sum + " "+ stat.CountObj + " " + stat.CountUzivatel);
            }
            Console.WriteLine();

            // 4.8    
            ObjednavkaTable.Notify(db);

            // 4.9
            ObjednavkaTable.State(db);

            // 3.6
            Console.WriteLine("3.6:");
            Collection<HistorieProduktu> x = ProduktTable.PriceHistory(2,db);
            foreach (HistorieProduktu h in x)
            {
                Console.WriteLine(h.Hodnota);
            }
            Console.WriteLine();
            

            Objednavka obj1 = new Objednavka();
            obj1.Datum_vytvoreni = DateTime.Now;
            obj1.Stav = "Prijata";
            obj1.Celkova_cena = 10000;
            obj1.zId = 5;
            obj1.dId = 1;
            obj1.pId = 3;
            obj1.Datum_zmeny = DateTime.Now;

            List<PolozkaObjednavky> polozkaObjednavky = new List<PolozkaObjednavky>();
            PolozkaObjednavky po1 = new PolozkaObjednavky()
            {
                pId = 2,
                Mnozstvi = 2


            };
            polozkaObjednavky.Add(po1);

            // 4.2 + 4.7
            int result = ObjednavkaTable.Insert(obj1, polozkaObjednavky, db);
            Console.WriteLine("4.2 + 4.7:");
            Console.WriteLine("Provedlo se vytvoreni objednavky:" + result);
            Console.WriteLine();
          
            if (result == 1)
            {
                Collection<Objednavka> obje = ObjednavkaTable.SelectLast(db);
                Console.WriteLine("cislo objednavky:" + obje[0].Id);
                po1.oId = obje[0].Id;
                PolozkaObjednavkyTable.Insert(po1,db);


            }
            db.Close();
            
        }
    }
}
