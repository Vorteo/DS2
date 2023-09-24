using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace MobilObchod.ORM.dao
{
    public class Database
    {
        public SqlConnection Connection { get; set; }
        private SqlTransaction SqlTransaction { get; set; }
        public string Language { get; set; }


        public Database()
        {
            Connection = new SqlConnection();
            Language = "en";
        }

        public bool Connect(string coString)
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.ConnectionString = coString;
                Connection.Open();
                
            }
            return true;
        }

        public bool Connect()
        {
            bool ret = true;
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                ret = Connect(@"server=dbsys.cs.vsb.cz\STUDENT;database=kal0266;user=kal0266;password=GStLFT4WpD;MultipleActiveResultSets=true;");
            }
            return ret;
        }

        public void Close()
        {
            Connection.Close();
        }

        public void BeginTransaction()
        {
            SqlTransaction = Connection.BeginTransaction(System.Data.IsolationLevel.Serializable);
        }

        public void EndTransaction()
        {
            SqlTransaction.Commit();
            Close();
        }

        public void Rollback()
        {
            SqlTransaction.Rollback();
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            int rowNum = 0;
            try
            {
                rowNum = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            return rowNum;
        }

        public SqlCommand CreateCommand(string strCommand)
        {
            SqlCommand command = new SqlCommand(strCommand, Connection);
            if (SqlTransaction != null)
            {
                command.Transaction = SqlTransaction;
            }
            return command;
        }

        public SqlDataReader Select(SqlCommand command)
        {
            SqlDataReader sqlDataReader = command.ExecuteReader();
            return sqlDataReader;
        }
    }
}
