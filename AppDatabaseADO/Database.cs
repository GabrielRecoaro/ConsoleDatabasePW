using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDatabaseADO
{
    public class Database : IDisposable
    {
        private readonly MySqlConnection conexao;

        public Database()
        {
            conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString);
            conexao.Open();
        }

        public void ExecuteCommand(string query)
        {
            var command = new MySqlCommand
            {
                CommandText = query,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            command.ExecuteNonQuery();
        }

        public MySqlDataReader ReturnCommand(string query)
        {
            var command = new MySqlCommand(query, conexao);
            return command.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }
    }
}
