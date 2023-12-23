using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;
using System.Runtime.Remoting.Contexts;

namespace CarsWPF
{
    /// <summary>
    /// Логика взаимодействия для Reservations.xaml
    /// </summary>
    public partial class Reservations : Window
    {
        private DataManager dataManager = new DataManager();
        private List<ReservationAdapter> reservations = new List<ReservationAdapter>();

        public Reservations()
        {
            InitializeComponent();
            LoadGrid();
        }

        public void LoadGrid()
        {
            reservations = FileStorageHelper.LoadFromFile<ReservationAdapter>(FileStorageHelper.ReservationFilePath);
            dataGrid.ItemsSource = reservations;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newReservation = new ReservationAdapter
            {
                Id = GetNewReservationId(),
                CarID = int.Parse(CarTxt.Text),
                ClientID = int.Parse(ClientTxt.Text),
                StartDate = DateTime.Parse(StartTxt.Text),
                EndDate = DateTime.Parse(EndTxt.Text)
            };

            dataManager.Create(newReservation, reservations, FileStorageHelper.ReservationFilePath);
            LoadGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(SearchTxt.Text, out int reservationId))
            {
                dataManager.Delete<ReservationAdapter>(reservationId, reservations, FileStorageHelper.ReservationFilePath);
                LoadGrid();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(SearchTxt.Text, out int reservationId))
            {
                var updatedReservation = new ReservationAdapter
                {
                    Id = reservationId,
                    CarID = int.Parse(CarTxt.Text),
                    ClientID = int.Parse(ClientTxt.Text),
                    StartDate = DateTime.Parse(StartTxt.Text),
                    EndDate = DateTime.Parse(EndTxt.Text)
                };

                dataManager.Update(reservationId, updatedReservation, reservations, FileStorageHelper.ReservationFilePath);
                LoadGrid();
            }
        }

        private int GetNewReservationId()
        {
            return reservations.Count > 0 ? reservations.Max(r => r.Id) + 1 : 1;
        }
    }

}
