using System;
using MySql.Data.MySqlClient;

namespace TRANSITPROFIT_v1
{
    public class Connector
    {
        private readonly string connectionString = "Server=localhost;Database=LADOTRANSCO;User ID=root;Password=;SslMode=none;";

        public MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Connection Error: " + ex.Message);
                return null;
            }
        }
    }
}
