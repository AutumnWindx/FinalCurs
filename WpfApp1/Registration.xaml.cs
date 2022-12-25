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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true; // если пробел, отклоняем ввод
            }
        }

        //

        private void PassBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true; // если пробел, отклоняем ввод                
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = FirstTBox.Text.Trim();
            string SecondName = SecondTBox.Text.Trim();
            string LastName = LastTBox.Text.Trim();
            string Login = LoginTBox.Text.Trim();
            string Password = PasswordPBox.Password.Trim();
            int Role = 1;

            if (LoginTBox.Text == "" || PasswordPBox.Password == "" || FirstTBox.Text == "" || SecondTBox.Text == "" || LastTBox.Text == "")
            {
                MessageBox.Show("Заполните необходимые поля");
            }
            else if (Login.Length < 3)
            {
                LoginTBox.ToolTip = "Логин введен не правильно!";
                LoginTBox.Background = Brushes.DarkGoldenrod;
            }
            else if (Password.Length < 3)
            {
                PasswordPBox.ToolTip = "Пароль введен не правильно!";
                PasswordPBox.Background = Brushes.DarkGoldenrod;
            }
            else if (FirstName.Length < 3)
            {
                FirstTBox.ToolTip = "Имя введено не правильно!";
                FirstTBox.Background = Brushes.DarkGoldenrod;
            }
            else if (SecondName.Length < 3)
            {
                SecondTBox.ToolTip = "Фамилия введена не правильно!";
                SecondTBox.Background = Brushes.DarkGoldenrod;
            }
            else if (LastName.Length < 3)
            {
                LastTBox.ToolTip = "Отчество введено не правильно!";
                LastTBox.Background = Brushes.DarkGoldenrod;
            }

            else
            {
                FirstTBox.ToolTip = "";
                FirstTBox.Background = Brushes.Transparent;

                SecondTBox.ToolTip = "";
                SecondTBox.Background = Brushes.Transparent;

                LastTBox.ToolTip = "";
                LastTBox.Background = Brushes.Transparent;

                LoginTBox.ToolTip = "";
                LoginTBox.Background = Brushes.Transparent;

                PasswordPBox.ToolTip = "";
                PasswordPBox.Background = Brushes.Transparent;


                MessageBox.Show("Регистрация прошла успешно!");

                User user = new User()
                {
                    Login = Login,
                    Password = Password,
                    FirstName = FirstName,
                    SecondName = SecondName,
                    LastName = LastName,
                    Role = Role,
                };

                Helper.db.Users.Add(user);
                Helper.db.SaveChanges();

                Autorization cool = new Autorization();
                cool.Show();
                this.Close();
            }
        }
    }
}
