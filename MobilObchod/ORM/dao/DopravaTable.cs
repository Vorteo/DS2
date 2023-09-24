using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace MobilObchod.ORM.dao
{
    public class DopravaTable
    {
        public static string SQL_SELECT = "SELECT * FROM \"Doprava\"";
        public static string SQL_INSERT = "INSERT INTO \"Doprava\" VALUES(@nazev,@cena,@popis,@datum_zmeny)";
        public static string SQL_UPDATE = "UPDATE \"Doprava\" SET nazev=@nazev,cena=@cena,popis=@popis,datum_zmeny=@datum_zmeny WHERE id_doprava=@id";
        public static string SQL_DELETE = "DELETE FROM \"Doprava\" WHERE id_doprava=@id";

        // 7.1
        public static Collection<Doprava> Select(Database database = null)
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
            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Doprava> transports = Read(reader);
            reader.Close();

            if (database == null)
            {
                db.Close();
            }

            return transports;
        }

        // 7.2
        public static int Insert(Doprava doprava, Database database = null)
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
            PrepareCommand(command, doprava);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }
            return ret;
        }

        // 7.3
        public static int Update(Doprava doprava, Database database = null)
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
            PrepareCommand(command, doprava);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }

            return ret;
        }

        // 7.4
        public static int Delete(int id, Database database = null)
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
            string sql = "SELECT * FROM \"Doprava\" JOIN \"Objednavka\" ON Doprava.id_doprava = Objednavka.id_doprava WHERE Doprava.id_doprava = @id";
            SqlCommand command = db.CreateCommand(sql);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);
            var ret = DopravaTable.Read(reader);

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

        private static void PrepareCommand(SqlCommand command, Doprava doprava)
        {
            command.Parameters.AddWithValue("@id", doprava.Id);
            command.Parameters.AddWithValue("@nazev", doprava.Nazev);
            command.Parameters.AddWithValue("@cena", doprava.Cena);
            command.Parameters.AddWithValue("@popis", doprava.Popis == null ? DBNull.Value : (object)doprava.Popis);
            command.Parameters.AddWithValue("@datum_zmeny", doprava.Datum_zmeny);
        }

        private static Collection<Doprava> Read(SqlDataReader reader)
        {
            Collection<Doprava> transports = new Collection<Doprava>();

            while (reader.Read())
            {
                int i = -1;
                Doprava doprava = new Doprava();
                doprava.Id = reader.GetInt32(++i);
                doprava.Nazev = reader.GetString(++i);
                doprava.Cena = reader.GetDecimal(++i);
                if(!reader.IsDBNull(++i))
                {
                    doprava.Popis = reader.GetString(i);
                }
                doprava.Datum_zmeny = reader.GetDateTime(++i);


                transports.Add(doprava);
            }
            return transports;
        }
    }
    
}
