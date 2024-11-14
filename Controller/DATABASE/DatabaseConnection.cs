using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakoTea.Controller.DATABASE
{

    public class DatabaseConnection
    {
        private static readonly Lazy<DatabaseConnection> _instance =
            new Lazy<DatabaseConnection>(() => new DatabaseConnection());

        private SqlConnection _connection;

        private DatabaseConnection()
        {
            _connection = new SqlConnection("Data Source=DESKTOP-BJ889Q2\\" +
        "SQLEXPRESS;Initial Catalog=TakoTea;Integrated Security=True;");

        }

        public static DatabaseConnection Instance => _instance.Value;

        public SqlConnection GetConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

    }
}
