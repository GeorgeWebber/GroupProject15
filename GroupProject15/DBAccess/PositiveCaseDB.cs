using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject15.DBAccess
{
    public class PositiveCaseDB : IDisposable
    {

        public MySqlConnection Connection { get; }

        public PositiveCaseDB(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            Console.WriteLine(connectionString);
           
        }

        public void Dispose() => Connection.Dispose();
    }
}

