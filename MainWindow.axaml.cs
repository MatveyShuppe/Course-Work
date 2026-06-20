using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
namespace Corse_Project
{

    public partial class MainWindow : Window
    {
        //поле можно присвоить только при объявлении или в конструкторе; после конструктора изменять нельзя
        private readonly HomePage _homePage = new HomePage();
        private readonly ClientsPage _clientsPage = new ClientsPage();
        private readonly Memberships _membershipsPage = new Memberships();
        private readonly MembershipTypesPage _membershipTypesPage = new MembershipTypesPage();
        private readonly ReportsPage _reportsPage = new ReportsPage();
        private readonly VisitsPage _visitsPage = new VisitsPage();
        private readonly PaymentsPage _paymentsPage = new PaymentsPage();
        private readonly UsersPage _usersPage = new UsersPage();
        public MainWindow()
        {
            InitializeComponent();
            DatabaseInitializer dbInitializer = new DatabaseInitializer();
            /*dbInitializer.CreateTable(sql, "Clients");
            dbInitializer.CreateTable(sql2, "MembershipTypes");
            dbInitializer.CreateTable(sql3, "Memberships");
            dbInitializer.CreateTable(sql0, "Users");
            dbInitializer.CreateTable(sql4, "Visits");
            dbInitializer.CreateTable(sql5, "Payments");*/
            MainContentControl.Content = _homePage;
        }
        public void OpenHome_Click(object? sender, RoutedEventArgs e)
        {
            MainContentControl.Content = _homePage;
        }

        public void OpenClients_Click(object? sender, RoutedEventArgs e)
        {
            MainContentControl.Content = _clientsPage;
        }

        public void OpenMemberships_Click(object? sender, RoutedEventArgs e)
        {
            MainContentControl.Content = _membershipsPage;
        }

        public void OpenMembershipsTypes_Click(object? sender, RoutedEventArgs e)
        {
            MainContentControl.Content = _membershipTypesPage;
        }

        public void OpenPayments_Click(object? sender, RoutedEventArgs e)
        {
            MainContentControl.Content= _paymentsPage;
        }
        public void OpenReports_Click(object? sender, RoutedEventArgs e)
        {
            MainContentControl.Content = _reportsPage;
        }
        public void OpenVisits_Click(object? sender, RoutedEventArgs e)
        {
            MainContentControl.Content = _visitsPage;
        }
        public void OpenUsers_Click(object? sender, RoutedEventArgs e)
        {
            MainContentControl.Content = _usersPage;
        }

        #region SQL Queries
        //помогала составлять нейронка

        public string sql = @"
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Clients')
            CREATE TABLE Clients 
            (Id INTEGER PRIMARY KEY IDENTITY(1,1),
            FullName NVARCHAR(150) NOT NULL,
            PhoneNumber NVARCHAR(20) NOT NULL,
            BirthDay DATE CHECK (BirthDay <= CURRENT_TIMESTAMP),    //СТРОКА 31: ПРОВЕРКА, ЧТОБЫ НЕ ВВЕСТИ ЗАПИСЬ ИЗ БУДУЩЕГО
            RegistrationDate DATE DEFAULT CURRENT_TIMESTAMP,
            Status NVARCHAR(50),
            Note NVARCHAR(MAX));";   
        //вид абонементов
        public string sql2 = @"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MembershipTypes')
        CREATE TABLE MembershipTypes 
        (Id INTEGER PRIMARY KEY IDENTITY(1,1), 
        Name NVARCHAR(150) NOT NULL,
        Cost INT NOT NULL,
        Duration INT NOT NULL,
        VisitsLimit INT);";
        //абонементы
        public string sql3 = @"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Memberships')
        CREATE TABLE Memberships 
        (Id INTEGER PRIMARY KEY IDENTITY(1,1),
        ClientId INTEGER NOT NULL,
        TypeId INTEGER NOT NULL,
        StartDate DATE NOT NULL,
        EndDate DATE NOT NULL,
        TotalVisits INTEGER,      -- Сколько всего было заложено посещений
        RemainingVisits INTEGER,  -- Сколько осталось (уменьшается при входе)
        Status NVARCHAR(50) DEFAULT 'Активен', -- 'Активен', 'Закончился', 'Заморожен'
        
        FOREIGN KEY (ClientId) REFERENCES Clients(Id),
        FOREIGN KEY (TypeId) REFERENCES MembershipTypes(Id));";
        //те,кто используют
        public string sql0 = @"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
        CREATE TABLE Users(
        Id INTEGER PRIMARY KEY IDENTITY(1,1),
        Login NVARCHAR(50) NOT NULL,
        Password NVARCHAR(50) NOT NULL, 
        FullName NVARCHAR(100) NOT NULL,
        Role NVARCHAR(MAX) NOT NULL DEFAULT 'Администратор' -- 'Администратор' или 'Руководитель'
        );";
        //количество посещений
        public string sql4  = @"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Visits')
        CREATE TABLE Visits(
        Id INTEGER PRIMARY KEY IDENTITY(1,1),
        MembershipId INTEGER NOT NULL,
        VisitDate DATE DEFAULT CURRENT_TIMESTAMP,
    
        FOREIGN KEY (MembershipId) REFERENCES Memberships(Id));";
        //таблица оплат
        public string sql5 = @"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Payments')
        CREATE TABLE Payments(
        Id INTEGER PRIMARY KEY IDENTITY(1,1),
        ClientId INTEGER NOT NULL,
        MembershipId INTEGER NOT NULL,
        Amount INTEGER NOT NULL,
        PaymentDate DATE DEFAULT CURRENT_TIMESTAMP,
        PaymentMethod nvarchar(100) NOT NULL, -- 'Наличные', 'Карта', 'Перевод'

        FOREIGN KEY(ClientId) REFERENCES Clients(Id),
        FOREIGN KEY(MembershipId) REFERENCES Memberships(Id));";
        
        #endregion
        


    }
}