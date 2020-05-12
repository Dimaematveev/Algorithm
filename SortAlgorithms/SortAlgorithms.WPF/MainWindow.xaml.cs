using SortAlgorithms.BL;
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

namespace SortAlgorithms.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<SortedItem> items = new List<SortedItem>();
        public MainWindow()
        {
            InitializeComponent();
            AddButon.Click += AddButon_Click;
            FillButton.Click += Fill_Click;
            //algorithm.ItemsEdit += Algorithm_ItemsEdit;
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(FillTextBox.Text, out int value))
            {
                var rnd = new Random();
                for (int i = 0; i < value; i++)
                {
                    var item = new SortedItem(rnd.Next(0,100));
                    items.Add(item);
                    ProgressBars.Children.Add(item.Grid);
                }
                
            }
            FillTextBox.Text = "";
        }

        private void AddButon_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AddTextBox.Text, out int value))
            {
                var item = new SortedItem(value);
                items.Add(item);
                ProgressBars.Children.Add(item.Grid);
            }
            AddTextBox.Text = "";
        }





        //private void Algorithm_ItemsEdit()
        //{
        //    textbox3.Text += "\n" + MassToString(algorithm.Items);
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (int.TryParse(texbox1.Text, out int value))
        //    {
        //        algorithm.Items.Add(value);
        //        label1.Content += " " + value.ToString();
        //    }
        //}

        //private void Button_Click1(object sender, RoutedEventArgs e)
        //{
            
        //    textbox3.Text += "\n" + MassToString(algorithm.Items);
        //    algorithm.Sort();
        //    label2.Content += MassToString(algorithm.Items);
        //}



        private string MassToString(List<int> list, char separator =' ')
        {
            string ret = "";
            foreach (var item in list)
            {
                ret += $"{item }{separator}";
            }
            return ret;
        }
    }
}
