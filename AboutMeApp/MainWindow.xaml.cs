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
using IOPath = System.IO.Path;
using System.Windows.Markup;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;

namespace AboutMeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {


            string name = File.ReadLines("../../../AboutMeApp/data/UserData.txt").First();
            string hobby = File.ReadLines("../../../AboutMeApp/data/UserData.txt").Skip(1).First();
            string favColor = File.ReadLines("../../../AboutMeApp/data/UserData.txt").Skip(2).First();

            NameTextBox.Text = name;
            HobbyTextBox.Text = hobby;
            FavColorTextBox.Text = favColor;

        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.ToString();
            string hobby = HobbyTextBox.Text.ToString();
            string favColor = FavColorTextBox.Text.ToString();

            lineChanger(name, "../../../AboutMeApp/data/UserData.txt", 1);
            lineChanger(hobby, "../../../AboutMeApp/data/UserData.txt", 2);
            lineChanger(favColor, "../../../AboutMeApp/data/UserData.txt", 3);

            GetData();
        }
    }
}