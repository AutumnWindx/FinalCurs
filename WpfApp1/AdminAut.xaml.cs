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
    /// Логика взаимодействия для AdminAut.xaml
    /// </summary>
    public partial class AdminAut : Window
    {
        public AdminAut()
        {
            InitializeComponent();
            DGridWines.ItemsSource = Helper.db.Wines.ToList();
        }       

        private void GiveWineBTN_Click(object sender, RoutedEventArgs e)
        {
            new GivesWines().Show();
            this.Close();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)// redact
        {
            new GivesWines().Show();
            this.Close();
        }       

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Helper.db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }

        private void RemoveWineBTN_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить данное вино?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var admin = DGridWines.SelectedItem as Wine;
               try
                {
                    Helper.db.Wines.Remove(admin);
                    Helper.db.SaveChanges();

                    DGridWines.ItemsSource = Helper.db.Wines.ToList();
                    MessageBox.Show("Удалено");
                }
                catch
                {
                    MessageBox.Show("Не удалось удалить запись", "Ошибка удаления записи", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                
            }
        }
    }
}
