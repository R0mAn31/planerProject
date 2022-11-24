using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using System.Xml;
using System.Xml.Linq;

namespace Planer
{
    /// <summary>  
    /// Interaction logic for MainWindow.xaml  
    /// </summary>   
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument document = new XmlDocument();
                document.Load("../../XMLFile1.xml");
            XmlNodeList userNames = document.SelectNodes("//login");

            foreach (XmlNode userName in userNames)
            {
                if (document != null && usernameTextBlock.Text == userName.InnerText)
                {
                    if (passwordTextBlock.Password.ToString() == userName.NextSibling.InnerText)
                    {
                        CalendarPlaner mainWindow = new CalendarPlaner();
                        Close();
                        mainWindow.Show();
                    }
                    else
                    {
                        MainWindow mainWindow = new MainWindow();
                        Close();
                        mainWindow.Show();
                    }
                }
            }

            if (passwordTextBlock.Password.Length <= 1)
            {
                MainWindow mainWindow = new MainWindow();
                this.Close(); 
                mainWindow.Show();
            }
            
        }
    }
}