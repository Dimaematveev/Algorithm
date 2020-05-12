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
        AlgorithmsBase<int> algorithm = new AlgorithmsBase<int>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(texbox1.Text, out int value))
            {
                algorithm.Items.Add(value);
                label1.Content += " " + value.ToString();
            }
            

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            algorithm.Sort();

            foreach (var item in algorithm.Items)
            {
                label2.Content += " " + item.ToString();
            }
        }
    }
}
