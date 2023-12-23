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

namespace CarsWPF
{
    /// <summary>
    /// Логика взаимодействия для Rent.xaml
    /// </summary>
    public partial class Rent : Window
    {
        private DataManager dataManager = new DataManager();
        private List<RentAdapter> rents = new List<RentAdapter>();

        public Rent()
        {
            InitializeComponent();
            LoadGrid();
        }

        public void LoadGrid()
        {
            rents = FileStorageHelper.LoadFromFile<RentAdapter>(FileStorageHelper.RentFilePath);
            dataGrid.ItemsSource = rents;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newRent = new RentAdapter
            {
                Id = GetNewRentId(),
                CarID = int.Parse(CarTxt.Text),
                ClientID = int.Parse(ClientTxt.Text),
                StartDate = DateTime.Parse(StartTxt.Text),
                EndDate = DateTime.Parse(EndTxt.Text),
                TotalCost = int.Parse(CostTxt.Text)
            };

            dataManager.Create(newRent, rents, FileStorageHelper.RentFilePath);
            LoadGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(SearchTxt.Text, out int rentId))
            {
                dataManager.Delete<RentAdapter>(rentId, rents, FileStorageHelper.RentFilePath);
                LoadGrid();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(SearchTxt.Text, out int rentId))
            {
                var updatedRent = new RentAdapter
                {
                    Id = rentId,
                    CarID = int.Parse(CarTxt.Text),
                    ClientID = int.Parse(ClientTxt.Text),
                    StartDate = DateTime.Parse(StartTxt.Text),
                    EndDate = DateTime.Parse(EndTxt.Text),
                    TotalCost = int.Parse(CostTxt.Text)
                };

                dataManager.Update(rentId, updatedRent, rents, FileStorageHelper.RentFilePath);
                LoadGrid();
            }
        }

        private int GetNewRentId()
        {
            return rents.Count > 0 ? rents.Max(r => r.Id) + 1 : 1;
        }
    }

}
