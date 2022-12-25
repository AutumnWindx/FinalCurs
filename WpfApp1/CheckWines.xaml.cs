using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для CheckWines.xaml
    /// </summary>
    public partial class CheckWines : Window
    {
        public CheckWines()
        {
            InitializeComponent();
            LoadData();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            new UserAutMain().Show();
            this.Close();
        }
        private void LoadData()
        {
            Wines.ItemsSource = Helper.db.Wines.ToList();//
        }
    }
}
