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
    /// Логика взаимодействия для Inspections.xaml
    /// </summary>
    public partial class Inspections : Window
    {
        private DataManager dataManager = new DataManager();
        private List<InspectionAdapter> inspections = new List<InspectionAdapter>();

        public Inspections()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newInspection = new InspectionAdapter
            {
                Id = GetNewInspectionId(),
                CarID = int.Parse(CarTxt.Text),
                Date = DateTime.Parse(DateTxt.Text),
                Result = ResultTxt.Text
            };

            dataManager.Create(newInspection, inspections, FileStorageHelper.InspectionFilePath);
            LoadGrid();
        }

        public void LoadGrid()
        {
            inspections = FileStorageHelper.LoadFromFile<InspectionAdapter>(FileStorageHelper.InspectionFilePath);
            dataGrid.ItemsSource = inspections;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(SearchTxt.Text, out int inspectionId))
            {
                dataManager.Delete<InspectionAdapter>(inspectionId, inspections, FileStorageHelper.InspectionFilePath);
                LoadGrid();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(SearchTxt.Text, out int inspectionId))
            {
                var updatedInspection = new InspectionAdapter
                {
                    Id = inspectionId,
                    CarID = int.Parse(CarTxt.Text),
                    Date = DateTime.Parse(DateTxt.Text),
                    Result = ResultTxt.Text
                };

                dataManager.Update(inspectionId, updatedInspection, inspections, FileStorageHelper.InspectionFilePath);
                LoadGrid();
            }
        }

        private int GetNewInspectionId()
        {
            return inspections.Count > 0 ? inspections.Max(i => i.Id) + 1 : 1;
        }
    }

}
