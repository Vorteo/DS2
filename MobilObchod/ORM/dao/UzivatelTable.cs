using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace MobilObchod.ORM.dao
{
    public class UzivatelTable
    {
        public static string SQL_SELECT_ID = "SELECT * FROM \"Uzivatel\" WHERE id_uzivatel=@id";
        public static string SQL_INSERT = "INSERT INTO \"Uzivatel\" VALUES (@jmeno,@prijmeni,@telefon,@email,@typ_uzivatele,@login,@datum_registrace,@datum_zmeny,@id_adresa,@is_active)";
        public static string SQL_UPDATE = "UPDATE \"Uzivatel\" SET jmeno=@jmeno, prijmeni=@prijmeni, telefon=@telefon, email=@email, typ_uzivatele=@typ_uzivatele, login=@login, datum_registrace=@datum_registrace, datum_zmeny=@datum_zmeny, id_adresa=@id_adresa, is_active=@is_active WHERE id_uzivatel=@id";
       

        // 1.1 
        public static Collection<Uzivatel> Select(Database database = null, string keyword="")
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
            string sql = "SELECT * FROM \"Uzivatel\" WHERE jmeno LIKE '%'+@keyword+'%' OR prijmeni LIKE '%'+@keyword+'%' OR email LIKE '%'+@keyword+'%'";
            SqlCommand command = db.CreateCommand(sql);
            command.Parameters.AddWithValue("@keyword", keyword);
            SqlDataReader reader = db.Select(command);

            Collection<Uzivatel> users = Read(reader);
            reader.Close();

            if (database == null)
            {
                db.Close();
            }

            return users;
        }

        // 1.3 
        public static Collection<Uzivatel> Select(int id, Database database = null)
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
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Uzivatel> users = Read(reader);
            Uzivatel uzivatel = null;
            if (users.Count == 1)
            {
                uzivatel = users[0];
            }
            reader.Close();

            if (database == null)
            {
                db.Close();
            }
            return users;
        }

        // 1.2 
        public static int Insert(Uzivatel uzivatel, Database database = null)
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
            PrepareCommand(command, uzivatel);
            int ret = db.ExecuteNonQuery(command);

            SqlCommand command1 = db.CreateCommand("SELECT CAST(@@IDENTITY AS Int)");
            uzivatel.Id = (int)command1.ExecuteScalar();

            if (database == null)
            {
                db.Close();
            }
            return ret;
        }

        // 1.4 
        public static int Update(Uzivatel uzivatel, Database database = null)
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
            PrepareCommand(command, uzivatel);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }

            return ret;
        }

        // 1.5 
        public static int Delete(Uzivatel uzivatel, Database database = null)
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
            string sql = "UPDATE \"Uzivatel\" SET is_active=0 WHERE id_uzivatel=@id";
            SqlCommand command = db.CreateCommand(sql);
            command.Parameters.AddWithValue("@id", uzivatel.Id);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }

            return ret;
        }

        private static void PrepareCommand(SqlCommand command, Uzivatel uzivatel)
        {
            command.Parameters.AddWithValue("@id", uzivatel.Id);
            command.Parameters.AddWithValue("@jmeno", uzivatel.Jmeno);
            command.Parameters.AddWithValue("@prijmeni", uzivatel.Prijmeni);
            command.Parameters.AddWithValue("@telefon", uzivatel.Telefon);
            command.Parameters.AddWithValue("@email", uzivatel.Email);
            command.Parameters.AddWithValue("@typ_uzivatele", uzivatel.Typ_uzivatele);
            command.Parameters.AddWithValue("@login", uzivatel.Login == null ? DBNull.Value : (object)uzivatel.Login);
            command.Parameters.AddWithValue("@datum_registrace", uzivatel.Datum_registrace == null ? DBNull.Value : (object)uzivatel.Datum_registrace);
            command.Parameters.AddWithValue("@datum_zmeny", uzivatel.Datum_zmeny);
            command.Parameters.AddWithValue("@id_adresa", uzivatel.IdAdresa);
            command.Parameters.AddWithValue("@is_active", uzivatel.Is_active);
        }

        private static Collection<Uzivatel> Read(SqlDataReader reader)
        {

            Collection<Uzivatel> users = new Collection<Uzivatel>();

            while (reader.Read())
            {
                int i = -1;
                Uzivatel uzivatel = new Uzivatel();
                uzivatel.Id = reader.GetInt32(++i);
                uzivatel.Jmeno = reader.GetString(++i);
                uzivatel.Prijmeni = reader.GetString(++i);
                uzivatel.Telefon = reader.GetString(++i);
                uzivatel.Email = reader.GetString(++i);
                uzivatel.Typ_uzivatele = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    uzivatel.Login = reader.GetString(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    uzivatel.Datum_registrace = reader.GetDateTime(i);
                }

                uzivatel.Datum_zmeny = reader.GetDateTime(++i);
                uzivatel.IdAdresa = reader.GetInt32(++i);
                uzivatel.Adresa = new Adresa
                {
                    Id = uzivatel.IdAdresa
                };
                uzivatel.Is_active = reader.GetBoolean(++i);

                users.Add(uzivatel);
            }
            return users;
        }
    }
}
