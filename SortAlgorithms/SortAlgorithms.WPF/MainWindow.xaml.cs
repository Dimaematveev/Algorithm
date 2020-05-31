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

            BubbleSortMenu.Click += (s, e) => { FillAndSort_Click<BubbleSort<int>>(); };
            CocktailSortMenu.Click += (s, e) => { FillAndSort_Click<CocktailSort<int>>(); };
            //BozoSortMenu.Click += (s, e) => { FillAndSort_Click<BozoSort<int>>(); };
            InsertionSortMenu.Click += (s, e) => { FillAndSort_Click<InsertionSort<int>>(); };
            ShellSortMenu.Click += (s, e) => { FillAndSort_Click<ShellSort<int>>(); };
            SelectionSortMenu.Click += (s, e) => { FillAndSort_Click<SelectionSort<int>>(); };
            //TODO: Для всех алгоритмов, наверное следует сделать отдельно при нажатии окно с поданными элементами, что получилось, вывод сортировки
            //HeapSortMenu.Click += (s, e) => { FillAndSort_Click<HeapSort<int>>(); };
            GnomeSortMenu.Click += (s, e) => { FillAndSort_Click<GnomeSort<int>>(); };
            //RedixSortMenu.Click += (s, e) => { FillAndSort_Click<LSDRedixSort>(); };
            MergeSortMenu.Click += (s, e) => { FillAndSort_Click<MergeSort<int>>(); };
            QuickSortMenu.Click += (s, e) => { FillAndSort_Click<QuickSort<int>>(); };



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
            Sortes.SetItems(items.Select(x=>x.Value));
            Sortes.ItemsEdit += Algorithm_ItemsEdit;
            Task.Run(() => Sort_Click());
        }

        private void Time_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sleep =  (int)Time.Value;
        }

        private void Sort_Click()
        {
            var time = Sortes.Sort();

            Dispatcher.Invoke((Action)delegate
            {
                Information.Text += $" Время = {time.TotalMilliseconds}ms.";
            });
        }

        private void Algorithm_ItemsEdit(int posA, int posB, bool isEdit, SolidColorBrush color)
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
                Information.Text = $"Перестановок = {Sortes.SwopCount}; Проверок ={Sortes.ComparisonCount}.";
                if (isEdit)
                {
                    var temp1 = items[posA];
                    items[posA] = items[posB];
                    items[posB] = temp1;

                    ProgressBars.Children.RemoveAt(posB);
                    ProgressBars.Children.RemoveAt(posA);
                    ProgressBars.Children.Insert(posA, items[posA].Grid);
                    ProgressBars.Children.Insert(posB, items[posB].Grid);

                }

                items[posA].ProgressBar.Foreground = color;
                items[posB].ProgressBar.Foreground = color;
            });
            
            Thread.Sleep((int)(Math.Pow(2,sleep)* 1000));
            
            Dispatcher.Invoke((Action)delegate
            {
                color = Brushes.Yellow;
                items[posA].ProgressBar.Foreground =color;
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
