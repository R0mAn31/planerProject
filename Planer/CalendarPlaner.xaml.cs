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

namespace Planer
{
    /// <summary>
    /// Interaction logic for CalendarPlaner.xaml
    /// </summary>
    public partial class CalendarPlaner : Window
    {
        public CalendarPlaner()
        {
            InitializeComponent();
            calendar.DisplayDate = DateTime.Today;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuItem = new MenuWindow();
            this.Close();
            menuItem.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            calendar.DisplayMode = CalendarMode.Month;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            calendar.DisplayMode = CalendarMode.Year;
        }
    }
}
