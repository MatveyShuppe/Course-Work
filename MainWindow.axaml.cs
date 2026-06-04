using Avalonia.Controls;
using Microsoft.Data.SqlClient;
namespace Corse_Project
{
    
    public class DatabaseInitializer
    {
        public void CreateTable(string sqlQuery, string TableName)
        {

        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const string ConnectionString =
            @"Server=(localdb)\mssqllocaldb;
              Database=UniversityDB;
              Integrated Security=True;
              TrustServerCertificate=True;";
        #region SQL Queries
        public string sql = @"
            CREATE TABLE IF NOT EXISTS Genre 
            (Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL UNIQUE);";
        public string sql2 = @"CREATE TABLE IF NOT EXISTS Author 
        (Id INTEGER PRIMARY KEY AUTOINCREMENT, 
        FirstName TEXT NOT NULL, 
        LastName TEXT NOT NULL );";
        public string sql3 = @"CREATE TABLE IF NOT EXISTS Book 
        (Id INTEGER PRIMARY KEY AUTOINCREMENT, 
        Title TEXT NOT NULL, 
        AuthorId INTEGER NOT NULL REFERENCES Author(Id),
        GenreId  INTEGER NOT NULL REFERENCES Genre(Id),
        Year INTEGER,
        Pages INTEGER, Status TEXT NOT NULL DEFAULT 'NotRead',
        Notes TEXT);";
        #endregion

    }
}