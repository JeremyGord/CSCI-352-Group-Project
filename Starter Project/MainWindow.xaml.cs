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

namespace Starter_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int MyValue { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
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

        private void Add_Event_Click(object sender, RoutedEventArgs e)
        {
            Window1 secondWindow = new Window1();
            secondWindow.Show();
        }
    }
}
