using Planer;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace Planer
{
    /// <summary>
    /// Interaction logic for CalendarPlaner.xaml
    /// </summary>
    public partial class CalendarPlaner : Window
    {
        Dictionary<string, string> planerDictionary = new Dictionary<string, string>(); 

        public CalendarPlaner()
        {
            InitializeComponent();
            calendar.DisplayDate = DateTime.Today;
            //calendar.Background = Brushes.LightBlue;
            calendar.BlackoutDates.AddDatesInPast();
            
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
        private void selected_date_changes(object sender, RoutedEventArgs e)
        {
            myPLans.Text = "";
            planText.Text = "";

            var first = calendar.SelectedDates.First().ToString("d");
            var last = calendar.SelectedDates.Last().ToString("d");
            if (first != last)
            {
                SelectedDateTextBox.Text = first + "-" + last;
                checkDate(first + "-" + last);
            }
            else
            {
                SelectedDateTextBox.Text = first;
                checkDate(first);
            }

            

        }


        public void checkDate(string data) {
            XmlDocument document = new XmlDocument();
            document.Load("../../data.xml");//при першому запуску потрібно згенерувати файл data а потім тут поміняти на data.xml
            XmlNodeList myNodes = document.SelectNodes("//date");
            if (myNodes!=null)
            {
                foreach (XmlNode item in myNodes)
                {
                    if (item.InnerText == data && item != null)
                    {
                        XmlNode myPlans = item.NextSibling;
                        myPLans.Text = myPlans.InnerText;
                        return;
                    }
                }
            }
                
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string richText = planText.Text;
            var keyDate = SelectedDateTextBox.Text;

            XmlDocument document = new XmlDocument();
            document.Load("../../data.xml");//при першому запуску потрібно згенерувати файл data а потім тут поміняти на data.xml
            XmlNode user = document.SelectSingleNode("//user");
            XmlNode password = document.SelectSingleNode("//password");




            XmlNode xmlDataNode = document.CreateNode(XmlNodeType.Element, "data", null);
            user.InsertAfter(xmlDataNode, password);


            //додаю дату 
            XmlNode xmlDateNode = document.CreateNode(XmlNodeType.Element, "date", null);
            xmlDateNode.InnerText = keyDate;
            xmlDataNode.AppendChild(xmlDateNode);


            //додаю дані 
            XmlNode xmlPlanNode = document.CreateNode(XmlNodeType.Element, "plan", null);
            xmlPlanNode.InnerText = richText;
            xmlDataNode.AppendChild(xmlPlanNode);

            XmlNodeList myNodes = document.SelectNodes("//date");
            if (myNodes != null)
            {
                foreach (XmlNode item in myNodes)
                {
                    if (item.InnerText == keyDate && item != null)
                    {
                        return;
                    }
                }
            }
            

            document.Save("../../data.xml");
        }
    }
}


// початковий xml
/*<? xml version = "1.0" encoding = "utf-8" ?>
< users >|

    < user >

        < login > Roman </ login >

        < password > 1234 </ password >

    </ user >
</ users >*/