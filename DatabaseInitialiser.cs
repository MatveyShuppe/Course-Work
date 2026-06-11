using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corse_Project
{
    public class DatabaseInitializer
    {
        private const string ConnectionString =
            @"Server=(localdb)\mssqllocaldb;
              Database=CourseDB;
              Integrated Security=True;
              TrustServerCertificate=True;";
        public void CreateTable(string sqlQuery, string TableName)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            using var command = new SqlCommand(sqlQuery, connection);
            command.ExecuteNonQuery();

            Console.WriteLine($"Таблица {TableName} создана! (или уже есть)");
        }
    }
}
