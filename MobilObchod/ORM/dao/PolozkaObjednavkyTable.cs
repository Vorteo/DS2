using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace MobilObchod.ORM.dao
{
    public class PolozkaObjednavkyTable
    {
        public static Collection<PolozkaObjednavky> Select(int id, Database database=null)
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
            SqlCommand command = db.CreateCommand("SELECT mnozstvi, id_objednavka, Produkt.id_produkt, Produkt.nazev AS nazev_produktu  FROM  \"Polozka_Objednavky\" JOIN \"Produkt\" ON Polozka_Objednavky.id_produkt = Produkt.id_produkt WHERE id_objednavka = @id ");

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Collection<PolozkaObjednavky> adresas = Read(reader);  
            reader.Close();

            if (database == null)
            {
                db.Close();
            }
            return adresas;
        }

        private static Collection<PolozkaObjednavky> Read(SqlDataReader reader)
        {
            Collection<PolozkaObjednavky> adresas = new Collection<PolozkaObjednavky>();

            while (reader.Read())
            {
                int i = -1;
                PolozkaObjednavky uzivatel = new PolozkaObjednavky();
                uzivatel.Mnozstvi = reader.GetInt32(++i);
                uzivatel.oId = reader.GetInt32(++i);
                uzivatel.pId = reader.GetInt32(++i);
                uzivatel.NazevProduktu = reader.GetString(++i);
                adresas.Add(uzivatel);
            }

            return adresas;
        }

        public static int Insert(PolozkaObjednavky polozkaObjednavky, Database database = null)
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
            string sql = "INSERT INTO \"Polozka_Objednavky\" VALUES(@mnozstvi,@id_objednavka,@id_produkt)";
            SqlCommand command = db.CreateCommand(sql);
            PrepareCommand(command, polozkaObjednavky);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }
            return ret;
        }

        public static int Delete(int id, Database database=null )
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
            string sql = "DELETE \"Polozka_Objednavky\" WHERE id_objednavka=@id";
            SqlCommand command = db.CreateCommand(sql);
            command.Parameters.AddWithValue("@id", id);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }

            return ret;
        }

        private static void PrepareCommand(SqlCommand command, PolozkaObjednavky polozkaObjednavky)
        {
            command.Parameters.AddWithValue("@mnozstvi", polozkaObjednavky.Mnozstvi);
            command.Parameters.AddWithValue("@id_objednavka", polozkaObjednavky.oId);
            command.Parameters.AddWithValue("@id_produkt", polozkaObjednavky.pId);
        }
    }
}
