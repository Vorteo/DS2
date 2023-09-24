using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MobilObchod.ORM.dao
{
    public class ProduktKategorieTable
    {
        public static int Insert(ProduktKategorie produktKategorie, Database database = null)
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

            SqlCommand command = db.CreateCommand("INSERT INTO \"produkt_kategorie\" VALUES(@id_produkt,@id_kategorie)");
            PrepareCommand(command,  produktKategorie);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }
            return ret;
        }

        private static void PrepareCommand(SqlCommand command, ProduktKategorie kategorie)
        {
            command.Parameters.AddWithValue("@id_produkt", kategorie.Produkt.Id);
            command.Parameters.AddWithValue("@id_kategorie", kategorie.Kategorie.Id);
        }
    }
}
