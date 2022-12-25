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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }
        private void AutBTN_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                MessageBox.Show("Нельзя использовать Пробел");
                e.Handled = true; // если пробел, отклоняем ввод
            }
        }

        //

        private void PassBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                MessageBox.Show("Нельзя использовать Пробел");
                e.Handled = true; // если пробел, отклоняем ввод                
            }
        }


        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {

            if (LoginTBox.Text == "" || PasswordPBox.Password == "")
            {

                MessageBox.Show("Введите логин и пароль");
            }
            else
            {
                User user = Helper.db.Users.FirstOrDefault(q => q.Login == LoginTBox.Text && q.Password == PasswordPBox.Password);
                if (user.Role == 1)
                {

                    Helper.db.SaveChanges();
                    MessageBox.Show("Вы успешно вошли");
                    new UserAutMain().Show();
                    this.Close();
                }
                else if (user.Role == 2)
                {

                    Helper.db.SaveChanges();
                    MessageBox.Show("Вы успешно вошли");
                    new AdminAut().Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильно введён логин или пароль");
                }
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            new Registration().Show();
            this.Close();
        }
    }
}
