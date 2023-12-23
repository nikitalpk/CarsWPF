using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {
        private DataManager dataManager = new DataManager();
        private List<ClientAdapter> clients = new List<ClientAdapter>();

        public Clients()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(SearchTxt.Text, out int clientId))
            {
                dataManager.Delete<ClientAdapter>(clientId, clients, FileStorageHelper.ClientFilePath);
                LoadGrid();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newClient = new ClientAdapter
            {
                Id = GetNewClientId(),
                Name = NameTxt.Text,
                Email = EmailTxt.Text,
                Phone = PhoneTxt.Text,
                Address = AddressTxt.Text
            };

            dataManager.Create(newClient, clients, FileStorageHelper.ClientFilePath);
            LoadGrid();
        }

        public void LoadGrid()
        {
            clients = FileStorageHelper.LoadFromFile<ClientAdapter>(FileStorageHelper.ClientFilePath);
            dataGrid.ItemsSource = clients;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(SearchTxt.Text, out int clientId))
            {
                var updatedClient = new ClientAdapter
                {
                    Id = clientId,
                    Name = NameTxt.Text,
                    Email = EmailTxt.Text,
                    Phone = PhoneTxt.Text,
                    Address = AddressTxt.Text
                };

                dataManager.Update(clientId, updatedClient, clients, FileStorageHelper.ClientFilePath);
                LoadGrid();
            }
        }

        private int GetNewClientId()
        {
            return clients.Count > 0 ? clients.Max(c => c.Id) + 1 : 1;
        }
    }

}
