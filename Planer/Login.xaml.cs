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
            XmlNode myNode = document.SelectSingleNode("//password");
            string password = myNode.InnerText;
            if (document != null && passwordBox1.Password == password)
            {
                CalendarPlaner mainWindow = new CalendarPlaner();
                this.Close();
                mainWindow.Show();
            }
            

            if (passwordBox1.Password.Length <= 1)
            {
                this.Close(); 
            }
            
        }
        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}