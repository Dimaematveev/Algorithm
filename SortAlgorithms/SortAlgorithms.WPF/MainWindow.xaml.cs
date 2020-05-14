using SortAlgorithms.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        AlgorithmsBase<int> Sortes;
        int sleep = 500;
        public MainWindow()
        {
            InitializeComponent();
            AddButon.Click += AddButon_Click;
            FillButton.Click += Fill_Click;


            //Sort.Click += (x, y) => {Task.Run(() => Sort_Click());};

            BubbleSort.Click += (s, e) => { FillAndSort_Click<BubbleSort<int>>(); };
            CocktailSort.Click += (s, e) => { FillAndSort_Click<CocktailSort<int>>(); };


            Time.ValueChanged += Time_ValueChanged;
        }

        private void FillAndSort_Click<T>() where T: AlgorithmsBase<int>,new()
        {
            Sortes = new T();
            Sortes.ItemsEdit += Algorithm_ItemsEdit;
            Sortes.Items = items.Select(x => x.Value).ToList();
            Task.Run(() => Sort_Click());
        }

        private void Time_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sleep = (int)Time.Value;
        }

        private void Sort_Click()
        {
            Sortes.Sort();
            
        }

        private void Algorithm_ItemsEdit(int posA, int posB, bool? isEdit)
        {

            Dispatcher.Invoke((Action)delegate { 
                ProgressBars.Children.Clear();
                var color = Brushes.Blue;
                if (isEdit == true)
                {
                    var temp = items[posA];
                    items[posA] = items[posB];
                    items[posB] = temp;
                    color = Brushes.Red;
                }
                else if (isEdit == false)
                {
                    color = Brushes.Green;
                }
                var cc = ScrollProgress.ViewportWidth;
                double offset = ScrollProgress.ExtentWidth * posA / items.Count - cc/2;
                ScrollProgress.ScrollToHorizontalOffset(offset);
                for (int i = 0; i < items.Count; i++)
                {
                    if (i == posA || i == posB)
                    {
                        items[i].ProgressBar.Foreground = color;
                    }
                    else
                    {
                        items[i].ProgressBar.Foreground = Brushes.Yellow;
                    }
                    ProgressBars.Children.Add(items[i].Grid);
                }

                this.UpdateLayout();
                
            });
            Thread.Sleep(sleep);


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
