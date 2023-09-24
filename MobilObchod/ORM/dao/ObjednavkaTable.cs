using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MobilObchod.ORM.dao
{
    public class ObjednavkaTable
    {
        // 4.1
        public static Collection<Objednavka> Select(int? keyword=null, Database database = null)
        {
            Database db;
            string sql ="";
            SqlCommand command;
            if (database == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)database;
            }
            if (keyword == null)
            {

                sql = "SELECT id_objednavka, datum_vytvoreni, stav, celkova_cena, id_uzivatel, Platba.id_platby, Doprava.id_doprava, Objednavka.datum_zmeny, Platba.nazev as druh_platby, Doprava.nazev as druh_dopravy  FROM \"Objednavka\"" +
                           " LEFT JOIN \"Platba\" ON Platba.id_platby = Objednavka.id_platby JOIN \"Doprava\" ON Doprava.id_doprava = Objednavka.id_doprava";

                command = db.CreateCommand(sql);
            }
            else
            {
                 sql = "SELECT id_objednavka, datum_vytvoreni, stav, celkova_cena, id_uzivatel, Platba.id_platby, Doprava.id_doprava, Objednavka.datum_zmeny, Platba.nazev as druh_platby, Doprava.nazev as druh_dopravy  FROM \"Objednavka\"" +
                             " LEFT JOIN \"Platba\" ON Platba.id_platby = Objednavka.id_platby JOIN \"Doprava\" ON Doprava.id_doprava = Objednavka.id_doprava WHERE id_objednavka = @keyword";
                command = db.CreateCommand(sql);
                command.Parameters.AddWithValue("@keyword", keyword);
            }
          
            SqlDataReader reader = db.Select(command);

            Collection<Objednavka> objs = Read(reader);
            reader.Close();

            if (database == null)
            {
                db.Close();
            }

            return objs;
        }

        // 4.2
        public static int Insert(Objednavka objednavka, List<PolozkaObjednavky> polozkaObjednavky, Database database = null)
        {
            Database db;
            if (database == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)database;
            }
            int ret = 0;
            if (CheckProduct(polozkaObjednavky, database) == 1)
            {

                string sql = "INSERT INTO \"Objednavka\" VALUES(@datum_vytvoreni,@stav,@celkova_cena,@id_uzivatel,@id_platby,@id_doprava,@datum_zmeny)";

                SqlCommand command = db.CreateCommand(sql);
                PrepareCommand(command, objednavka);
                ret = db.ExecuteNonQuery(command);

                SqlCommand command1 = db.CreateCommand("SELECT CAST(@@IDENTITY AS Int)");
                objednavka.Id = (int)command1.ExecuteScalar();
            }

            if (database == null)
            {
                db.Close();
            }

            return ret;
        }

        // 4.3
        public static Collection<Objednavka> SelectOne(int id, Database database = null)
        {
            Database db;
            if (database == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)database;
            }
            string sql = "SELECT * FROM \"Objednavka\" WHERE id_objednavka=@id";

            SqlCommand command = db.CreateCommand(sql);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Objednavka> objs = Read(reader);
            Objednavka objednavka = null;
            if (objs.Count == 1)
            {
                objednavka = objs[0];
            }
            reader.Close();

            if (database == null)
            {
                db.Close();
            }
            return objs;
        }

        // 4.4
        public static int Update(Objednavka objednavka, Database database = null)
        {
            Database db;
            if (database == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)database;
            }

            string sql = "UPDATE \"Objednavka\" SET datum_vytvoreni=@datum_vytvoreni, stav=@stav,celkova_cena=@celkova_cena, id_uzivatel=@id_uzivatel," +
                " id_platby=@id_platby,id_doprava=@id_doprava, datum_zmeny=@datum_zmeny WHERE id_objednavka=@id";

            SqlCommand command = db.CreateCommand(sql);
            PrepareCommand(command, objednavka);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }

            return ret;
        }

        // 4.5
        public static int Delete(Objednavka objednavka, Database database = null)
        {
            Database db;
            if (database == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)database;
            }
            string sql = "UPDATE \"Objednavka\" SET stav='Storno' WHERE id_objednavka=@id";
            SqlCommand command = db.CreateCommand(sql);
            command.Parameters.AddWithValue("@id", objednavka.Id);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }

            return ret;
        }

        // 4.7
        public static int CheckProduct(List<PolozkaObjednavky> polozkaObjednavky, Database database = null)
        {
            Database db;
            if (database == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)database;
            }

            for (int i = 0; i < polozkaObjednavky.Count; i++)
            {
                try
                {
                    SqlCommand command1 = db.CreateCommand("dbo.CheckOrderProduct");
                    command1.CommandType = System.Data.CommandType.StoredProcedure;
                    command1.Parameters.Add("@p_pocet_kusu", SqlDbType.Int).Value = polozkaObjednavky[i].Mnozstvi;
                    command1.Parameters.Add("@p_id_produktu", SqlDbType.Int).Value = polozkaObjednavky[i].pId;
                    command1.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (database == null)
                    {
                        db.Close();
                    }
                    return 0;
                }
            }


            if (database == null)
            {
                db.Close();
            }
            return 1;

        }

        // 4.8
        public static void Notify(Database database = null)
        {
            Database db;

            if (database == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)database;
            }

            SqlCommand command = db.CreateCommand("dbo.notifyUser");
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.ExecuteNonQuery();


            if (database == null)
            {
                db.Close();
            }
        }

        // 4.9
        public static void State(Database database = null)
        {
            Database db;
            if (database == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)database;
            }
            SqlCommand command = db.CreateCommand("dbo.ChangeState");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            if (database == null)
            {
                db.Close();
            }
        }

        public static Collection<Objednavka> SelectLast(Database database=null)
        {
            Database db;
            if (database == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)database;
            }
            string sql = "SELECT TOP 1 * FROM \"Objednavka\" ORDER BY id_objednavka DESC";

            SqlCommand command = db.CreateCommand(sql);
            SqlDataReader reader = db.Select(command);

            Collection<Objednavka> objs = Read(reader);
            Objednavka objednavka = null;
            if (objs.Count == 1)
            {
                objednavka = objs[0];
            }
            reader.Close();

            if (database == null)
            {
                db.Close();
            }
            return objs;
        }

        private static void PrepareCommand(SqlCommand command, Objednavka objednavka)
        {
            command.Parameters.AddWithValue("@id", objednavka.Id);
            command.Parameters.AddWithValue("@datum_vytvoreni", objednavka.Datum_vytvoreni);
            command.Parameters.AddWithValue("@stav", objednavka.Stav);
            command.Parameters.AddWithValue("@celkova_cena", objednavka.Celkova_cena);
            command.Parameters.AddWithValue("@id_uzivatel", objednavka.zId);
            command.Parameters.AddWithValue("@id_platby", objednavka.pId == null ? DBNull.Value : (object)objednavka.pId);
            command.Parameters.AddWithValue("@id_doprava", objednavka.dId);
            command.Parameters.AddWithValue("@datum_zmeny", objednavka.Datum_zmeny);
           
        }

        // 4.6
        public static Collection<ObjednavkaStatistika> SelectStats(int year, string param="MONTH",Database database = null)
        {
            Database db;
            if (database == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)database;
            }

            string sql="";

            if (param == "MONTH")
            {
                 sql = "SELECT MONTH(datum_vytvoreni), SUM(celkova_cena), CONVERT(int,COUNT(Objednavka.id_objednavka)), CONVERT(int, COUNT(id_uzivatel)) FROM \"Objednavka\" JOIN" +
                    " \"Polozka_Objednavky\" ON Objednavka.id_objednavka=Polozka_objednavky.id_objednavka WHERE YEAR(datum_vytvoreni) = @year AND stav = 'Dokonceno' " +
                    " GROUP BY MONTH(datum_vytvoreni)";
            }

            if (param == "YEAR")
            {
                sql = "SELECT YEAR(datum_vytvoreni), SUM(celkova_cena), CONVERT(int,COUNT(Objednavka.id_objednavka)), CONVERT(int, COUNT(id_uzivatel)) FROM \"Objednavka\" JOIN" +
                   " \"Polozka_objednavky\" ON Objednavka.id_objednavka=Polozka_objednavky.id_objednavka WHERE YEAR(datum_vytvoreni) = @year AND stav = 'Dokonceno' " +
                   " GROUP BY YEAR(datum_vytvoreni)";
            }
            SqlCommand command = db.CreateCommand(sql);
            command.Parameters.AddWithValue("@year", year);
            SqlDataReader reader = db.Select(command);

            Collection<ObjednavkaStatistika> objstats = ReadStats(reader);
            reader.Close();

            if (database == null)
            {
                db.Close();
            }

            return objstats;
        }
        
        private static Collection<Objednavka> Read(SqlDataReader reader)
        {
            Collection<Objednavka> obj = new Collection<Objednavka>();

            while (reader.Read())
            {
                int i = -1;
                Objednavka objednavka = new Objednavka();


                objednavka.Id = reader.GetInt32(++i);
                objednavka.Datum_vytvoreni = reader.GetDateTime(++i);
                objednavka.Stav = reader.GetString(++i);
                objednavka.Celkova_cena = reader.GetDecimal(++i);
                objednavka.zId = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    objednavka.pId = reader.GetInt32(i);
                }
                objednavka.dId = reader.GetInt32(++i);
                objednavka.Datum_zmeny = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i))
                {
                    objednavka.druh_platby = reader.GetString(i);
                }
                objednavka.druh_dopravy = reader.GetString(++i);
               
                obj.Add(objednavka);
            }
            return obj;
        }
        private static Collection<ObjednavkaStatistika> ReadStats(SqlDataReader reader)
        {
            Collection<ObjednavkaStatistika> stats = new Collection<ObjednavkaStatistika>();

            while (reader.Read())
            {
                int i = -1;
                ObjednavkaStatistika statistika = new ObjednavkaStatistika();
                statistika.Period = reader.GetInt32(++i);
                statistika.Sum = reader.GetDecimal(++i);
                statistika.CountObj = reader.GetInt32(++i);
                statistika.CountUzivatel = reader.GetInt32(++i);   
                
                stats.Add(statistika);
            }
            return stats;
        }
    }

}
