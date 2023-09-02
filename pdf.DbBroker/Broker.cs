using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using pdf.Domain;
using pdf.Common;

namespace pdf.DbBroker
{
    public class Broker
    {
        private SqlConnection conn;
        private SqlTransaction tran;

        public Broker()
        {
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pdf_lib_test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public void Open()
        {
            if(!IsReady())
                conn.Open();
        }
        public void Close()
        {
            if (IsReady())
                conn.Close();
        }
        public void Commit()
        {
            tran.Commit();
        }
        public void Rollback()
        {
            tran.Rollback();
        }
        public bool IsReady()
        {
            return conn != null && conn.State != ConnectionState.Closed;
        }
        public SqlCommand CreateCommand(string sql = "")
        {
            //tran = conn.BeginTransaction();
            return new SqlCommand(sql, conn, tran);
        }

        public void BeginTransaction()
        {
            tran = conn.BeginTransaction();
        }

        public SqlConnection returnConnection() { return conn; }
        public SqlTransaction returnTransaction() { return tran; }
    }
}
