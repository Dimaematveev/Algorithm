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
        readonly List<SortedItem> items = new List<SortedItem>();
        AlgorithmBase<int> Sortes;
        int sleep = 0;
        public MainWindow()
        {
            InitializeComponent();
            AddButon.Click += AddButon_Click;
            FillButton.Click += Fill_Click;
            Clear.Click += Clear_Click;

            //Sort.Click += (x, y) => {Task.Run(() => Sort_Click());};

            BubbleSort.Click += (s, e) => { FillAndSort_Click<BubbleSort<int>>(); };
            CocktailSort.Click += (s, e) => { FillAndSort_Click<CocktailSort<int>>(); };
            BozoSort.Click += (s, e) => { FillAndSort_Click<BozoSort<int>>(); };
            InsertionSort.Click += (s, e) => { FillAndSort_Click<InsertionSort<int>>(); };
            ShellSort.Click += (s, e) => { FillAndSort_Click<ShellSort<int>>(); };
            SelectionSort.Click += (s, e) => { FillAndSort_Click<SelectionSort<int>>(); };

            

            Time.ValueChanged += Time_ValueChanged;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            items.Clear();
            ProgressBars.Children.Clear();
        }

        private void FillAndSort_Click<T>() where T: AlgorithmBase<int>,new()
        {
            Sortes = new T();
            Sortes.ItemsEdit += Algorithm_ItemsEdit;
            Sortes.Items = items.Select(x => x.Value).ToList();
            Task.Run(() => Sort_Click());
        }

        private void Time_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sleep =  (int)Time.Value;
        }

        private void Sort_Click()
        {
            Sortes.Sort();
            
        }

        private void Algorithm_ItemsEdit(int posA, int posB, bool? isEdit)
        {
            {
                int temp = Math.Min(posA, posB);
                posB = Math.Max(posA, posB);
                posA = temp;
            }
            Dispatcher.Invoke((Action)delegate {
                var cc = ScrollProgress.ViewportWidth;
                double offset = ScrollProgress.ExtentWidth * posA / items.Count - cc / 2;
                ScrollProgress.ScrollToHorizontalOffset(offset);
                var color = Brushes.Blue;
                Information.Text = $"Перестановок = {Sortes.SwopCount}; Проверок ={Sortes.ComparisonCount}.";
                if (isEdit == true)
                {
                    var temp1 = items[posA];
                    items[posA] = items[posB];
                    items[posB] = temp1;

                    ProgressBars.Children.RemoveAt(posB);
                    ProgressBars.Children.RemoveAt(posA);
                    ProgressBars.Children.Insert(posA, items[posA].Grid);
                    ProgressBars.Children.Insert(posB, items[posB].Grid);

                    color = Brushes.Red;
                }
                else if (isEdit == false)
                {
                    color = Brushes.Green;
                }

                items[posA].ProgressBar.Foreground = color;
                items[posB].ProgressBar.Foreground = color;
            });
            Thread.Sleep((int)(Math.Pow(2,sleep)* 1000));
            Dispatcher.Invoke((Action)delegate
            {
                var color = Brushes.Yellow;
                items[posA].ProgressBar.Foreground = color;
                items[posB].ProgressBar.Foreground = color;
            });

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
    }
}
