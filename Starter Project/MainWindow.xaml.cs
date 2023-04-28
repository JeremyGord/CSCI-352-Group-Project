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
            textbox1.GotFocus += Textbox1_GotFocus;
            textbox1.LostFocus += Textbox1_LostFocus;
        }

        private void Textbox1_LostFocus(object sender, RoutedEventArgs e)
        {
            if(textbox1.Text == "")
            {
                textbox1.Text = "File path";
            }
        }

        private void Textbox1_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox1.GotFocus -= Textbox1_GotFocus;
            textbox1.Clear();
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

        private void ConfirmEvent_Click_1(object sender, RoutedEventArgs e)
        {
            int num1;
            bool canConvert = int.TryParse(textbox2.Text, out num1);
            if(canConvert == true)
            {
                day = Convert.ToInt32(textbox2.Text);
            }
            else
            {
                MessageBox.Show("Please enter valid day");
                return;
            }

            canConvert = int.TryParse(textbox3.Text, out num1);
            if (canConvert == true)
            {
                month = Convert.ToInt32(textbox3.Text);
            }
            else
            {
                MessageBox.Show("Please enter valid month");
                return;
            }

            canConvert = int.TryParse(textbox4.Text, out num1);
            if (canConvert == true)
            {
                year = Convert.ToInt32(textbox4.Text);
            }
            else
            {
                MessageBox.Show("Please enter valid year");
                return;
            }

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
                MessageBox.Show("Your event is Today!");
                for (j = 0; j < i; j++) {
                    if(events[j] != timer)
                    {
                        count++;
                    }
                }
                Calender1.BlackoutDates.RemoveAt(count - 1);
            }
        }

        private void textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            textbox2.GotFocus += textbox2_GotFocus;
            textbox2.LostFocus += textbox2_LostFocus;
        }

        private void textbox2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textbox2.Text == "")
            {
                textbox2.Text = "DD";
            }
        }

        private void textbox2_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox2.GotFocus -= textbox2_GotFocus;
            textbox2.Clear();
        }

        private void textbox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            textbox3.GotFocus += textbox3_GotFocus;
            textbox3.LostFocus += textbox3_LostFocus;
        }

        private void textbox3_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textbox3.Text == "")
            {
                textbox3.Text = "MM";
            }
        }

        private void textbox3_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox3.GotFocus -= textbox3_GotFocus;
            textbox3.Clear();
        }
        private void textbox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            textbox4.GotFocus += textbox4_GotFocus;
            textbox4.LostFocus += textbox4_LostFocus;
        }

        private void textbox4_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textbox4.Text == "")
            {
                textbox4.Text = "YYYY";
            }
        }

        private void textbox4_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox4.GotFocus -= textbox4_GotFocus;
            textbox4.Clear();
        }
    }
}