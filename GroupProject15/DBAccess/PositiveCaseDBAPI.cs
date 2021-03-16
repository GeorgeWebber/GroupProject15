using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject15.DBAccess
{
    public class PositiveCaseDBAPI
    {

        public int Id { get; set; }
        public string Forename { get; set; }
        public string LastName { get; set; }

        internal PositiveCaseDB Db { get; set; }

        public PositiveCaseDBAPI()
        {
        }

        internal PositiveCaseDBAPI(PositiveCaseDB db)
        {

            Console.WriteLine("making positive case dbapi internally");
            Db = db;
        }
        public async Task AddRecord()
        {
            Console.WriteLine("showing database instance");
            Console.WriteLine(Db);
            using var cmd = Db.Connection.CreateCommand();
            Db.Connection.Open();
            //cmd.CommandText = @"INSERT INTO `tablename` (`Forename`, `Lastname`) VALUES (@forename, @lastname);";
            cmd.CommandText = @"INSERT INTO `table1` (`forename`) VALUES (@forename);";
            BindParams(cmd);
            Console.WriteLine("Trying to execute command" + cmd.CommandText);
            await cmd.ExecuteNonQueryAsync();
            Db.Connection.Close();
            Id = (int)cmd.LastInsertedId;
        }

        // a method left over from a tutorial - will leave here until clearup or it is used
        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Id,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@forename",
                DbType = DbType.String,
                Value = Forename,
            });
            /* cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@lastname",
                DbType = DbType.String,
                Value = LastName,
            });
            */
        }
    }
}

