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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Globalization;
using System.Windows.Threading;



namespace Starter_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int day;
        int year;
        int month;
        DateTime timer = DateTime.Now;

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.Time.Text = DateTime.Now.ToString("h:mm:ss:tt");
            },
            this.Dispatcher);

        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button1_Click_1(object sender, RoutedEventArgs e)
        {
            String filename = textbox1.Text;
            if (File.Exists(filename))
            {
                BitmapImage theImage = new BitmapImage
            (new Uri(filename, UriKind.Relative));

                ImageBrush myImageBrush = new ImageBrush(theImage);
                Calender1.Background = myImageBrush;
            }
            else
            {
                MessageBox.Show("File path does not exist");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Calender1.Background = Brushes.White;
        }

        private void confirmevent_Click(object sender, RoutedEventArgs e)
        {
            int i, j;
            int count = 0;
            DateTime[] events = new DateTime[200];
            Calender1.BlackoutDates.Add(new CalendarDateRange(new DateTime(year, month, day)));
            for (i = 0; i < Calender1.BlackoutDates.Count(); i++)
            {

                events[i] = new DateTime(year, month, day);
            }

            if (Calender1.BlackoutDates.Contains(timer))
            {
                MessageBox.Show("Your event is now");
                for (j = 0; j < i; j++) {
                    if(events[j] != timer)
                    {
                        count++;
                    }
                }
                Calender1.BlackoutDates.RemoveAt(count - 1);
            }
        }

        private void day_Click(object sender, RoutedEventArgs e)
        {
            day = Convert.ToInt32(textbox2.Text);
        }

        private void ButtonMonth_Click(object sender, RoutedEventArgs e)
        {
            month = Convert.ToInt32(textbox2.Text);
        }

        private void Buttonyear_Click(object sender, RoutedEventArgs e)
        {
            year = Convert.ToInt32(textbox2.Text);
        }
        private void Event()
        {
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

