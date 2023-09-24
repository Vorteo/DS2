using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace MobilObchod.ORM.dao
{
    public class AdresaTable
    {
        public static string SQL_INSERT = "INSERT INTO \"Adresa\" VALUES(@mesto,@ulice,@zeme,@psc,@datum_zmeny)";
        public static string SQL_UPDATE = "UPDATE \"Adresa\" SET mesto=@mesto,ulice=@ulice,zeme=@zeme,psc=@psc,datum_zmeny=@datum_zmeny WHERE id_adresa=@id";

        public static Collection<Adresa> Select(int id,Database database=null)
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
            SqlCommand command = db.CreateCommand("SELECT * FROM  \"Adresa\" WHERE id_adresa = @id ");

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Adresa> adresas = Read(reader);
            Adresa ads = null;
            if (adresas.Count == 1)
            {
                ads = adresas[0];
            }
            reader.Close();

            if (database == null)
            {
                db.Close();
            }
            return adresas;
        }

        private static Collection<Adresa> Read(SqlDataReader reader)
        {
            Collection<Adresa> adresas = new Collection<Adresa>();

            while (reader.Read())
            {
                int i = -1;
                Adresa uzivatel = new Adresa();
                uzivatel.Id = reader.GetInt32(++i);
                uzivatel.Mesto = reader.GetString(++i);
                uzivatel.Ulice = reader.GetString(++i);
                uzivatel.Zeme = reader.GetString(++i);
                uzivatel.Psc = reader.GetInt32(++i).ToString();
                uzivatel.Datum_zmeny = reader.GetDateTime(++i);

                adresas.Add(uzivatel);
            }
            
            return adresas;
        }

        // 2.1

        public static int Insert(Adresa adresa, Database database = null)
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

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, adresa);
            int ret = db.ExecuteNonQuery(command);

            SqlCommand command1 = db.CreateCommand("SELECT CAST(@@IDENTITY AS Int)");
            adresa.Id = (int)command1.ExecuteScalar();

            if (database == null)
            {
                db.Close();
            }
            return ret;
        }

        // 2.2
        public static int Update(Adresa adresa, Database database = null)
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
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, adresa);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }

            return ret;
        }

        private static void PrepareCommand(SqlCommand command, Adresa adresa)
        {
            command.Parameters.AddWithValue("@id", adresa.Id);
            command.Parameters.AddWithValue("@mesto", adresa.Mesto);
            command.Parameters.AddWithValue("@ulice", adresa.Ulice);
            command.Parameters.AddWithValue("@zeme", adresa.Zeme);
            command.Parameters.AddWithValue("@psc", adresa.Psc == null ? DBNull.Value : (object)adresa.Psc);
            command.Parameters.AddWithValue("@datum_zmeny", adresa.Datum_zmeny);
        }
    }
}
