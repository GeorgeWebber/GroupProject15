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
            Db = db;
        }
        public async Task AddRecord()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `tablename` (`Forename`, `Lastname`) VALUES (@forename, @lastname);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

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
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@lastname",
                DbType = DbType.String,
                Value = LastName,
            });
        }
    }
}


}
