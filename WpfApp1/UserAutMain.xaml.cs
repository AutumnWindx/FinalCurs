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
    /// Логика взаимодействия для UserAutMain.xaml
    /// </summary>
    public partial class UserAutMain : Window
    {
        public UserAutMain()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new GradeUser().Show();
            this.Close();
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            new ClassUserWine().Show();
            this.Close();
        }

        private void CheckWinesBtn_Click(object sender, RoutedEventArgs e)
        {
            new CheckWines().Show();
            this.Close();
        }
    }
}
