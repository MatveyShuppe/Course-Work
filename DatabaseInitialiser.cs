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

        //помогла нейросеть
        public List<Clients> GetAllClients()
        {
            var result = new List<Clients>();

            using var connection = new SqlConnection(ConnectionString);
            using var command = new SqlCommand("select Id, FullName, PhoneNumber, Birthday, RegistrationDate, Status, Note from Clients",connection);
            connection.Open();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var c = new Clients()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    FullName = reader.GetString(reader.GetOrdinal("FullName")),
                    PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                    BirthDay = reader.IsDBNull(reader.GetOrdinal("Birthday")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Birthday")),
                    RegistrationDate = reader.IsDBNull(reader.GetOrdinal("RegistrationDate")) ? (DateTime?)null :
                    reader.GetDateTime(reader.GetOrdinal("RegistrationDate")),
                    Status = reader.GetString(reader.GetOrdinal("Status")),
                    Note = reader.GetString(reader.GetOrdinal("Note")),
                };
                result.Add(c);
            }
            return result;
        }

        public void AddClient(string fullName, string phoneNumber, DateTime Birthday, DateTime RegistrationDate, string Status, string Note)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            string sql = @"insert into Clients(FullName, PhoneNumber, BirthDay, RegistrationDate, Status, Note)
            values (@fullName, @phoneNumber, @birthDay ,@registrationDate, @status, @note);";

            using var command =  new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@fullName", fullName);
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            if (Birthday == null)
            {
                command.Parameters.AddWithValue("@birthDay", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@birthDay", Birthday);
            }
            if (RegistrationDate == null)
            {
                command.Parameters.AddWithValue("@registrationDate", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@registrationDate", RegistrationDate);
            }
            if (Status == null)
            {
                command.Parameters.AddWithValue("@status", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@status", Status);
            }
            if (Note == null)
            {
                command.Parameters.AddWithValue("@note", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@note", Note);
            }
            
            int rows = command.ExecuteNonQuery();
            Console.WriteLine("Добавлено строк: " + rows);
        }

    }
}
