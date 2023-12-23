using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarsWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EnsureDataFilesExist();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clients clients = new Clients();
            this.Hide();
            clients.ShowDialog();
            this.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Car cars = new Car();
            this.Hide();
            cars.ShowDialog();
            this.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Rent rent = new Rent();
            this.Hide();
            rent.ShowDialog();
            this.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Reservations reservations = new Reservations();
            this.Hide();
            reservations.ShowDialog();
            this.Show();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Inspections inspections = new Inspections();
            this.Hide();
            inspections.ShowDialog();
            this.Show();
        }

        private void EnsureDataFilesExist()
        {
            EnsureFileExists<CarAdapter>(FileStorageHelper.CarFilePath, GetSampleCars());
            EnsureFileExists<ClientAdapter>(FileStorageHelper.ClientFilePath, GetSampleClients());
            EnsureFileExists<InspectionAdapter>(FileStorageHelper.InspectionFilePath, GetSampleInspections());
            EnsureFileExists<RentAdapter>(FileStorageHelper.RentFilePath, GetSampleRents());
            EnsureFileExists<ReservationAdapter>(FileStorageHelper.ReservationFilePath, GetSampleReservations());
        }

        private void EnsureFileExists<T>(string filePath, List<T> sampleData)
        {
            if (!File.Exists(filePath))
            {
                FileStorageHelper.SaveToFile(sampleData, filePath);
            }
        }


        private List<CarAdapter> GetSampleCars()
        {
            return new List<CarAdapter>
    {
        new CarAdapter { Id = 1, Mark = "Toyota", Model = "Corolla", Year = "2020", Status = "Available" },
        new CarAdapter { Id = 2, Mark = "Honda", Model = "Civic", Year = "2019", Status = "Unavailable" },
        new CarAdapter { Id = 3, Mark = "Ford", Model = "Focus", Year = "2018", Status = "Available" },
        new CarAdapter { Id = 4, Mark = "Chevrolet", Model = "Cruze", Year = "2017", Status = "Repairing" }
    };
        }

        private List<ClientAdapter> GetSampleClients()
        {
            return new List<ClientAdapter>
    {
        new ClientAdapter { Id = 1, Name = "John Doe", Email = "johndoe@example.com", Phone = "123-456-7890", Address = "123 Main St" },
        new ClientAdapter { Id = 2, Name = "Jane Smith", Email = "janesmith@example.com", Phone = "098-765-4321", Address = "456 Elm St" },
        new ClientAdapter { Id = 3, Name = "Mike Johnson", Email = "mikejohnson@example.com", Phone = "555-555-5555", Address = "789 Oak St" },
        new ClientAdapter { Id = 4, Name = "Emily Davis", Email = "emilydavis@example.com", Phone = "444-444-4444", Address = "321 Pine St" }
    };
        }

        private List<InspectionAdapter> GetSampleInspections()
        {
            return new List<InspectionAdapter>
    {
        new InspectionAdapter { Id = 1, CarID = 1, Date = DateTime.Now, Result = "Passed" },
        new InspectionAdapter { Id = 2, CarID = 2, Date = DateTime.Now.AddDays(-1), Result = "Failed" },
        new InspectionAdapter { Id = 3, CarID = 3, Date = DateTime.Now.AddDays(-2), Result = "Passed" },
        new InspectionAdapter { Id = 4, CarID = 4, Date = DateTime.Now.AddDays(-3), Result = "Failed" }
    };
        }

        private List<RentAdapter> GetSampleRents()
        {
            return new List<RentAdapter>
    {
        new RentAdapter { Id = 1, CarID = 1, ClientID = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7), TotalCost = 500 },
        new RentAdapter { Id = 2, CarID = 2, ClientID = 2, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(3), TotalCost = 300 },
        new RentAdapter { Id = 3, CarID = 3, ClientID = 3, StartDate = DateTime.Now.AddDays(-5), EndDate = DateTime.Now.AddDays(2), TotalCost = 450 },
        new RentAdapter { Id = 4, CarID = 4, ClientID = 4, StartDate = DateTime.Now.AddDays(-7), EndDate = DateTime.Now.AddDays(0), TotalCost = 350 }
    };
        }

        private List<ReservationAdapter> GetSampleReservations()
        {
            return new List<ReservationAdapter>
    {
        new ReservationAdapter { Id = 1, CarID = 1, ClientID = 1, StartDate = DateTime.Now.AddDays(10), EndDate = DateTime.Now.AddDays(17) },
        new ReservationAdapter { Id = 2, CarID = 2, ClientID = 2, StartDate = DateTime.Now.AddDays(5), EndDate = DateTime.Now.AddDays(12) },
        new ReservationAdapter { Id = 3, CarID = 3, ClientID = 3, StartDate = DateTime.Now.AddDays(15), EndDate = DateTime.Now.AddDays(22) },
        new ReservationAdapter { Id = 4, CarID = 4, ClientID = 4, StartDate = DateTime.Now.AddDays(20), EndDate = DateTime.Now.AddDays(27) }
    };
        }


    }
}
