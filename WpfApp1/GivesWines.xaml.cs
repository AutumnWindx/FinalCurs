using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для GivesWines.xaml
    /// </summary>
    public partial class GivesWines : Window
    {
        public GivesWines()
        {
            InitializeComponent();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            new AdminAut().Show();
            this.Close();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Name = WineTBox.Text.Trim();
                string Grade = GradeTBox.Text.Trim();

                string Price = PriceTBox.Text.Trim();
                int Price1 = Convert.ToInt32(PriceTBox.Text.Trim());


                string Country = ManufactoryTBox.Text.Trim();


                string Year_of_aqing = YearTBox.Text.Trim();
                DateTime dateGame;
                if (DateTime.TryParse(Year_of_aqing, DateTimeFormatInfo.CurrentInfo, DateTimeStyles.None, out dateGame))
                {
                };

                string Volume = VolumeTBox.Text.Trim();
                double Volume1 = Convert.ToDouble(VolumeTBox.Text.Trim());

                string Estimation = EstimationTBox.Text.Trim();
                double Estimation1 = Convert.ToDouble(EstimationTBox.Text.Trim());


                if (Name.Length < 3)
                {
                    WineTBox.ToolTip = "Название введенно не правильно!";
                    WineTBox.Background = Brushes.DarkGoldenrod;
                }
                else if (Grade.Length < 3)
                {
                    GradeTBox.ToolTip = "Сорт введен не правильно!";
                    GradeTBox.Background = Brushes.DarkGoldenrod;
                }
                else if (Price.Length < 3)
                {
                    PriceTBox.ToolTip = "Цена введена не правильно!";
                    PriceTBox.Background = Brushes.DarkGoldenrod;
                }
                else if (Country.Length < 3)
                {
                    ManufactoryTBox.ToolTip = "Страна введена не правильно!";
                    ManufactoryTBox.Background = Brushes.DarkGoldenrod;
                }
                else if (Volume.Length < 3)
                {
                    VolumeTBox.ToolTip = "Объём введен не правильно";
                    VolumeTBox.Background = Brushes.DarkGoldenrod;
                }
                else if (Estimation.Length < 3)
                {
                    EstimationTBox.ToolTip = "Рейтинг введен не правильно";
                    EstimationTBox.Background = Brushes.DarkGoldenrod;
                }
                else
                {
                    WineTBox.ToolTip = "";
                    WineTBox.Background = Brushes.Transparent;

                    GradeTBox.ToolTip = "";
                    GradeTBox.Background = Brushes.Transparent;

                    PriceTBox.ToolTip = "";
                    PriceTBox.Background = Brushes.Transparent;

                    ManufactoryTBox.ToolTip = "";
                    ManufactoryTBox.Background = Brushes.Transparent;

                    YearTBox.ToolTip = "";
                    YearTBox.Background = Brushes.Transparent;

                    VolumeTBox.ToolTip = "";
                    VolumeTBox.Background = Brushes.Transparent;

                    EstimationTBox.ToolTip = "";
                    EstimationTBox.Background = Brushes.Transparent;

                    MessageBox.Show("Добавление прошло успешно!");

                    Wine wine = new Wine()
                    {
                        Title = Name,
                        Grade = Grade,
                        Price = Price1,
                        Country = Country,
                        YearOfAqing = dateGame,
                        Volume = Volume1,
                        Estimation = Estimation1,


                    };

                    Helper.db.Wines.Add(wine);
                    Helper.db.SaveChanges();

                    GivesWines cool = new GivesWines();
                    cool.Show();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Неверно введены данные","Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            
        }
    }
}
