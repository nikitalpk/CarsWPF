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
    /// Логика взаимодействия для Car.xaml
    /// </summary>
    public partial class Car : Window
    {
        private DataManager dataManager = new DataManager();
        private List<CarAdapter> cars = new List<CarAdapter>();

        public Car()
        {
            InitializeComponent();
            LoadGrid();
        }



        public void LoadGrid()
        {
            cars = FileStorageHelper.LoadFromFile<CarAdapter>(FileStorageHelper.CarFilePath);
            dataGrid.ItemsSource = cars;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newCar = new CarAdapter
            {
                Id = GetNewCarId(),
                Mark = MarkTxt.Text,
                Model = ModelTxt.Text,
                Year = YearTxt.Text,
                Status = StatusTxt.Text
            };

            dataManager.Create(newCar, cars, FileStorageHelper.CarFilePath);
            LoadGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(SearchTxt.Text, out int carId))
            {
                dataManager.Delete<CarAdapter>(carId, cars, FileStorageHelper.CarFilePath);
                LoadGrid();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(SearchTxt.Text, out int carId))
            {
                var updatedCar = new CarAdapter
                {
                    Id = carId,
                    Mark = MarkTxt.Text,
                    Model = ModelTxt.Text,
                    Year = YearTxt.Text,
                    Status = StatusTxt.Text
                };

                dataManager.Update(carId, updatedCar, cars, FileStorageHelper.CarFilePath);
                LoadGrid();
            }
        }

        private int GetNewCarId()
        {
            return cars.Count > 0 ? cars.Max(c => c.Id) + 1 : 1;
        }
    }
}
