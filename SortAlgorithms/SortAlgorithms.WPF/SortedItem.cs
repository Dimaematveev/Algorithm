using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SortAlgorithms.WPF
{
    public class SortedItem
    {
        readonly double Width = 30;
        public ProgressBar ProgressBar { get; private set; }
        public Label Label { get; private set; }

        public int Value { get; set; }

        public Grid Grid { get; private set; }

        public SortedItem(int value)
        {
            Value = value;
            ProgressBar = new ProgressBar
            {
                Orientation = Orientation.Vertical,
                Minimum = -10,
                Maximum = 100,
                Value = Value,
                Foreground = Brushes.Yellow
            };

            Label = new Label
            {
                Content = Value.ToString()
            };


            Grid = new Grid();
            Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1,GridUnitType.Star) });
            Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(25) });
            Grid.Width = Width;



            Grid.SetRow(ProgressBar,0);
            Grid.Children.Add(ProgressBar);
            Grid.SetRow(Label, 1);
            Grid.Children.Add(Label);


        }
    }
}
