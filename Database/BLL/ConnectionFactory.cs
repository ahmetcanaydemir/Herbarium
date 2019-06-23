using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herbarium
{
    class ConnectionFactory
    {
        SqlConnection sqlCon;
        const string CONNECTION_STRING = @"data source=.\SQLEXPRESS;initial catalog=herbarium;integrated security=True;";
        public ConnectionFactory()
        {
            sqlCon = new SqlConnection(CONNECTION_STRING);
        }
        public SqlConnection getSqlConnection()
        {
            return sqlCon;
        }
        public void Open()
        {
            if(sqlCon.State == System.Data.ConnectionState.Closed)
                sqlCon.Open();
        }
        public void Close()
        {
            if (sqlCon.State == System.Data.ConnectionState.Open)
                sqlCon.Close();
        }
    }
}
