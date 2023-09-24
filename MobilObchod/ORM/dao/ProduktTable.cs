using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MobilObchod.ORM.dao
{
    public class ProduktTable
    {
        public static Collection<Produkt> SelectProducts(Database database = null)
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
            string sql = "SELECT * FROM  \"Produkt\"";
            SqlCommand command = db.CreateCommand(sql);

            SqlDataReader reader = db.Select(command);

            Collection<Produkt> produkts = Read(reader);
            reader.Close();

            if (database == null)
            {
                db.Close();
            }
            return produkts;
        }
        // 3.1
        public static Collection<ListProdukt> SelectAll(string keyword, string kategorie, int orderAttr, char orderby, Database database = null)
        {
            Database db;
            string sql="";
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
                sql = "SELECT Produkt.id_produkt, Produkt.nazev,Produkt.vyrobce, Produkt.popis, Produkt.pocet_kusu_skladem, Produkt.cena, Kategorie.nazev," +
                   " (SELECT CONVERT(int,SUM(p_o.mnozstvi)) FROM Polozka_Objednavky p_o WHERE p_o.id_produkt = Produkt.id_produkt)" +
                   " FROM Produkt JOIN produkt_kategorie p_k ON Produkt.id_produkt = p_k.id_produkt JOIN Kategorie ON p_k.id_kategorie = Kategorie.id_kategorie" +
                   " WHERE Kategorie.nazev=@kategorie" +
                   " ORDER BY CASE WHEN @orderattr=1 AND @orderby='A' THEN Produkt.nazev END ASC," +
                   " CASE WHEN @orderattr=1 AND @orderby='D' THEN Produkt.nazev END DESC," +
                   " CASE WHEN @orderattr=2 AND @orderby='A' THEN Produkt.cena END ASC," +
                   " CASE WHEN @orderattr=2 AND @orderby='D' THEN Produkt.cena END DESC," +
                   " CASE WHEN @orderattr=3 AND @orderby='A' THEN Produkt.pocet_kusu_skladem END ASC," +
                   " CASE WHEN @orderattr=3 AND @orderby='D' THEN Produkt.pocet_kusu_skladem END DESC";

                    command = db.CreateCommand(sql);
                    command.Parameters.AddWithValue("@kategorie", kategorie);
                    command.Parameters.AddWithValue("@orderattr", orderAttr);
                    command.Parameters.AddWithValue("@orderby", orderby);
            }
            else
            {
                sql = "SELECT Produkt.id_produkt, Produkt.nazev, Produkt.vyrobce, Produkt.popis, Produkt.pocet_kusu_skladem, Produkt.cena, Kategorie.nazev," +
                    " (SELECT CONVERT(int,SUM(p_o.mnozstvi)) FROM Polozka_Objednavky p_o WHERE p_o.id_produkt = Produkt.id_produkt)" +
                    " FROM Produkt JOIN produkt_kategorie p_k ON Produkt.id_produkt = p_k.id_produkt JOIN Kategorie ON p_k.id_kategorie = Kategorie.id_kategorie" +
                    " WHERE (Produkt.nazev LIKE \'%\'+@keyword+\'%\' OR Produkt.popis LIKE \'%\'+@keyword+\'%\') AND Kategorie.nazev=@kategorie" +
                    " ORDER BY CASE WHEN @orderattr=1 AND @orderby='A' THEN Produkt.nazev END ASC," +
                    " CASE WHEN @orderattr=1 AND @orderby='D' THEN Produkt.nazev END DESC," +
                    " CASE WHEN @orderattr=2 AND @orderby='A' THEN Produkt.cena END ASC," +
                    " CASE WHEN @orderattr=2 AND @orderby='D' THEN Produkt.cena END DESC," +
                    " CASE WHEN @orderattr=3 AND @orderby='A' THEN Produkt.pocet_kusu_skladem END ASC," +
                    " CASE WHEN @orderattr=3 AND @orderby='D' THEN Produkt.pocet_kusu_skladem END DESC";

                    command = db.CreateCommand(sql);
                    command.Parameters.AddWithValue("@keyword", keyword);
                    command.Parameters.AddWithValue("@kategorie", kategorie);
                    command.Parameters.AddWithValue("@orderattr", orderAttr);
                    command.Parameters.AddWithValue("@orderby", orderby);
            }

           
            SqlDataReader reader = db.Select(command);

            Collection<ListProdukt> listProdukts = ReadStats(reader);
            reader.Close();

            if (database == null)
            {
                db.Close();
            }

            return listProdukts;
        }

        private static Collection<ListProdukt> ReadStats(SqlDataReader reader)
        {
            Collection<ListProdukt> listProdukts = new Collection<ListProdukt>();

            while (reader.Read())
            {
                int i = -1;
                ListProdukt listProdukt = new ListProdukt();
                listProdukt.Produkt = new Produkt();
                listProdukt.Produkt.Id = reader.GetInt32(++i);
                listProdukt.Produkt.Nazev = reader.GetString(++i);
                listProdukt.Produkt.Vyrobce = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    listProdukt.Produkt.Popis = reader.GetString(i);
                }
                listProdukt.Produkt.Pocet_kusu = reader.GetInt32(++i);
                listProdukt.Produkt.Cena = reader.GetDecimal(++i);
                listProdukt.KatNazev = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    listProdukt.Sum = reader.GetInt32(i);
                }
                listProdukts.Add(listProdukt);
            }
            return listProdukts;
        }

        // 3.2
        public static int Insert(Produkt produkt, Database database = null)
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
            string sql = "INSERT INTO \"Produkt\" VALUES(@nazev,@vyrobce,@fotografie,@popis,@barva,@hmotnost,@cena,@pocet_kusu_skladem,@datum_pridani,@datum_zmeny,@is_active)";

            SqlCommand command = db.CreateCommand(sql);
            PrepareCommand(command, produkt);

            int ret = db.ExecuteNonQuery(command);

            SqlCommand command1 = db.CreateCommand("SELECT CAST(@@IDENTITY AS Int)");
            produkt.Id = (int)command1.ExecuteScalar();

            if (database == null)
            {
                db.Close();
            }
            return ret;
        }

        // 3.3
        public static Collection<Produkt> SelectOne(int id, Database database = null)
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
            string sql = "SELECT * FROM  \"Produkt\" WHERE id_produkt=@id";
            SqlCommand command = db.CreateCommand(sql);

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Produkt> produkts = Read(reader);
            Produkt produkt = null;
            if (produkts.Count == 1)
            {
                produkt = produkts[0];
            }
            reader.Close();

            if (database == null)
            {
                db.Close();
            }
            return produkts;
        }

        // 3.4
        public static int Update(Produkt produkt, Database database = null)
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

            string sql = "UPDATE \"Produkt\" SET nazev=@nazev,vyrobce=@vyrobce,fotografie=@fotografie,popis=@popis,barva=@barva,hmotnost=@hmotnost,cena=@cena," +
                        " pocet_kusu_skladem=@pocet_kusu_skladem,datum_pridani=@datum_pridani,datum_zmeny=@datum_zmeny,is_active=@is_active WHERE id_produkt=@id";

            SqlCommand command = db.CreateCommand(sql);
            PrepareCommand(command, produkt);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }

            return ret;
        }

        private static Collection<Produkt> Read(SqlDataReader reader)
        {
            Collection<Produkt> produkts = new Collection<Produkt>();

            while (reader.Read())
            {
                int i = -1;
                Produkt produkt = new Produkt();
                produkt.Id = reader.GetInt32(++i);
                produkt.Nazev = reader.GetString(++i);
                produkt.Vyrobce = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    produkt.Image = reader.GetString(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    produkt.Popis = reader.GetString(i);
                }
                produkt.Barva = reader.GetString(++i);
                produkt.Hmotnost = reader.GetInt32(++i);
                produkt.Cena = reader.GetDecimal(++i);
                produkt.Pocet_kusu = reader.GetInt32(++i);
                produkt.Datum_pridani = reader.GetDateTime(++i);
                produkt.Datum_zmeny = reader.GetDateTime(++i);
                produkt.isActive = reader.GetBoolean(++i);

                produkts.Add(produkt);
            }
            return produkts;
        }

        private static void PrepareCommand(SqlCommand command, Produkt produkt)
        {
            command.Parameters.AddWithValue("@id", produkt.Id);
            command.Parameters.AddWithValue("@nazev", produkt.Nazev);
            command.Parameters.AddWithValue("@vyrobce", produkt.Vyrobce);
            //command.Parameters.AddWithValue("@fotografie", produkt.Image == null ? DBNull.Value : (object)produkt.Image);

            SqlParameter imageParameter = new SqlParameter("@fotografie", SqlDbType.Image);
            imageParameter.Value = DBNull.Value;
            command.Parameters.Add(imageParameter);

            command.Parameters.AddWithValue("@popis", produkt.Popis == null ? DBNull.Value : (object)produkt.Popis);
            command.Parameters.AddWithValue("@barva", produkt.Barva);
            command.Parameters.AddWithValue("@hmotnost", produkt.Hmotnost);
            command.Parameters.AddWithValue("@cena", produkt.Cena);
            command.Parameters.AddWithValue("@pocet_kusu_skladem", produkt.Pocet_kusu);
            command.Parameters.AddWithValue("@datum_pridani", produkt.Datum_pridani);
            command.Parameters.AddWithValue("@datum_zmeny", produkt.Datum_zmeny);
            command.Parameters.AddWithValue("@is_active", produkt.isActive);

        }

        // 3.5
        public static int Delete(Produkt produkt, Database database = null)
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
            string sql = "UPDATE \"Produkt\" SET is_active=0 WHERE id_produkt=@id";
            SqlCommand command = db.CreateCommand(sql);
            command.Parameters.AddWithValue("@id", produkt.Id);
            int ret = db.ExecuteNonQuery(command);

            if (database == null)
            {
                db.Close();
            }

            return ret;
        }

        // 3.6
        public static Collection<HistorieProduktu> PriceHistory(int id, Database database=null)
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
            string sql = "SELECT * FROM  \"Historie_Produktu\" WHERE id_produkt=@id AND nazev_zmeneho_atributu='cena'";
            SqlCommand command = db.CreateCommand(sql);
            command.Parameters.AddWithValue("@id",id);

            SqlDataReader reader = db.Select(command);
            Collection<HistorieProduktu> historie = ReadHistory(reader);

            reader.Close();

            if (database == null)
            {
                db.Close();
            }

            return historie;

        }
        private static Collection<HistorieProduktu> ReadHistory(SqlDataReader reader)
        {
            Collection<HistorieProduktu> his = new Collection<HistorieProduktu>();
            while (reader.Read())
            {
                int i = -1;
                HistorieProduktu historieProduktu = new HistorieProduktu();
                historieProduktu.Produkt = new Produkt();
                historieProduktu.Id = reader.GetInt32(++i);
                historieProduktu.Datum_zmeny = reader.GetDateTime(++i);
                historieProduktu.Nazev_atributu = reader.GetString(++i);
                historieProduktu.Hodnota = reader.GetString(++i);
                historieProduktu.Produkt.Id = reader.GetInt32(++i);

                his.Add(historieProduktu);
            }
            return his;
        }
    }
}
