using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

namespace Starter_Project
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string start;
        string end;
        string color;
        string title;

        public Window1()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string[] lines = { title, Picker.Text, start, end , color };
            
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, "EventList.txt"), true))
            {
                foreach (string line in lines)
                {
                    outputFile.WriteLine(line);
                }
            }

            Close();
        }

        private void ComboBox_Start_TimeChanged(object sender, SelectionChangedEventArgs e)
        {
            start = Start_Time.SelectedItem.ToString();
        }

        private void ComboBox_End_TimeChanged(object sender, SelectionChangedEventArgs e)
        {
            end = End_Time.SelectedItem.ToString();
        }

        private void RedRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            color = "Red";
        }

        private void OrangeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            color = "#FFFF7400";
        }

        private void YellowRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            color = "#FFFFB900";
        }

        private void GreenRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            color = "#FF00FF0C";
        }

        private void TurquoiseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            color = "#FF00FFC5";
        }

        private void BlueRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            color = "#FF0097FF";
        }

        private void TitleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Title_Textbox.Text != "Title" && Title_Textbox.Text != null)
            {
                title = Title_Textbox.Text;
            }
        }
    }
}
