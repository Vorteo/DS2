using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace MobilObchod.ORM.dao
{
    public class PlatbaTable
    {
        public static string SQL_SELECT = "SELECT * FROM \"Platba\"";
        public static string SQL_INSERT = "INSERT INTO \"Platba\" VALUES(@nazev,@cena,@datum_zmeny,@datum_platby)";
        public static string SQL_UPDATE = "UPDATE \"Platba\" SET nazev=@nazev,cena=@cena,datum_platby=@datum_platby,datum_zmeny=@datum_zmeny WHERE id_platby=@id ";

        // 6.1
        public static Collection<Platba> Select(Database database = null)
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

            Collection<Platba> payments = Read(reader);
            reader.Close();

            if (database == null)
            {
                db.Close();
            }

            return payments;
        }
        // 6.2
        public static int Insert(Platba payment, Database database = null)
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
            PrepareCommand(command, payment);
            int ret = db.ExecuteNonQuery(command);

            SqlCommand command1 = db.CreateCommand("SELECT CAST(@@IDENTITY AS Int)");
            payment.Id = (int)command1.ExecuteScalar();

            if (database == null)
            {
                db.Close();
            }
            return ret;
        }
        // 6.3
        public static int Update(Platba payment, Database database = null)
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
            PrepareCommand(command, payment);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }

            return ret;
        }

        private static void PrepareCommand(SqlCommand command, Platba payment)
        {
            command.Parameters.AddWithValue("@id", payment.Id);
            command.Parameters.AddWithValue("@nazev", payment.Nazev);
            command.Parameters.AddWithValue("@cena", payment.Cena);
            command.Parameters.AddWithValue("@datum_zmeny", payment.Datum_zmeny);
            command.Parameters.AddWithValue("@datum_platby", payment.Datum_platby == null ? DBNull.Value : (object)payment.Datum_platby);
        }
        private static Collection<Platba> Read(SqlDataReader reader)
        {
            Collection<Platba> payments = new Collection<Platba>();
            while (reader.Read())
            {
                int i = -1;
                Platba payment = new Platba();
                payment.Id = reader.GetInt32(++i);
                payment.Nazev = reader.GetString(++i);
                payment.Cena = reader.GetDecimal(++i);
                payment.Datum_zmeny = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i))
                {
                    payment.Datum_platby = reader.GetDateTime(i);
                }
                payments.Add(payment);
            }
            return payments;
        }
    }
}
