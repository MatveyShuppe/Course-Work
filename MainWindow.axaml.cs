using Avalonia.Controls;

namespace Corse_Project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static string ConnectionString =
            @"Server=(localdb)\mssqllocaldb;
              Database=UniversityDB;
              Integrated Security=True;
              TrustServerCertificate=True;";

    }
}