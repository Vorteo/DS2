using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace MobilObchod.ORM.dao
{
    public class KategorieTable
    {
        public static string SQL_DELETE = "DELETE FROM \"Kategorie\" WHERE id_kategorie=@id";

        // 5.1
        public static Collection<Kategorie> Select(Database database=null)
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
            string sql = "SELECT * FROM  \"Kategorie\"";

            SqlCommand command = db.CreateCommand(sql);
            SqlDataReader reader = db.Select(command);
            Collection<Kategorie> kategorie = Read(reader);
            reader.Close();

            if (database == null)
            {
                db.Close();
            }
           
            return kategorie;
        }

        // 5.2
        public static int Insert(Kategorie kategorie, Database database=null)
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
            string sql = " INSERT INTO  \"Kategorie\" VALUES(@nazev,@datum_zmeny,@popis)";
            SqlCommand command = db.CreateCommand(sql);
            PrepareCommand(command, kategorie);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }
            return ret;
        }

        // 5.3
        public static int Update(Kategorie kategorie, Database database=null)
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
            string sql = "UPDATE \"Kategorie\" SET nazev=@nazev, datum_zmeny=@datum_zmeny, popis=@popis WHERE id_kategorie=@id";
            SqlCommand command = db.CreateCommand(sql);
            PrepareCommand(command, kategorie);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }

            return ret;
        }

        // 5.4
        public static int Delete(int id, Database database=null)
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
            string sql = "SELECT * FROM \"produkt_kategorie\" WHERE id_kategorie=@id";
            SqlCommand command = db.CreateCommand(sql);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);
            var ret = KategorieTable.Read(reader);
           
            if (ret.Count > 0)
            {
                if (database == null)
                {
                    db.Close();
                }
                return 0;
            }
            else
            {
               
                SqlCommand command1 = db.CreateCommand(SQL_DELETE);
                command1.Parameters.AddWithValue("@id", id);
                int res = db.ExecuteNonQuery(command1);

                if (database == null)
                {
                    db.Close();
                }
                return res;
            }
        }

        private static void PrepareCommand(SqlCommand command, Kategorie kategorie)
        {
            command.Parameters.AddWithValue("@id", kategorie.Id);
            command.Parameters.AddWithValue("@nazev", kategorie.Nazev);
            command.Parameters.AddWithValue("@datum_zmeny", kategorie.Datum_zmeny);
            command.Parameters.AddWithValue("@popis", kategorie.Popis == null ? DBNull.Value : (object)kategorie.Popis);
        }

        private static Collection<Kategorie> Read(SqlDataReader reader)
        {
            Collection<Kategorie> categories = new Collection<Kategorie>();
            while (reader.Read())
            {
                int i = -1;
                Kategorie kategorie = new Kategorie();
                kategorie.Id = reader.GetInt32(++i);
                kategorie.Nazev = reader.GetString(++i);
                kategorie.Datum_zmeny = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i))
                {
                    kategorie.Popis = reader.GetString(i);
                }
               
                categories.Add(kategorie);
            }
            return categories;
        }
    }
}
