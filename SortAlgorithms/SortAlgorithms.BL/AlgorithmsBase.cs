﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Media;

namespace SortAlgorithms.BL
{
    public class AlgorithmBase<T> where T:IComparable
    {
        public int SwopCount { get; private set; } = 0;
        public int ComparisonCount { get; private set; } = 0;

        public event Action<int, int, bool, SolidColorBrush> ItemsEdit;
        public List<T> Items { get; set; } = new List<T>();
        private Stopwatch Timer = new Stopwatch();

        public virtual void SetItems(IEnumerable<T> items) 
        {
            Items = items.ToList(); 
        }
        protected void Swop(int positionA,int positionB)
        {
            if (positionA == positionB) 
            {
                return;
            }
            if (positionA < Items.Count && positionB < Items.Count)
            {
                SetEvent(positionA, positionB, false, Brushes.Orange);
                var temp = Items[positionA];
                Items[positionA] = Items[positionB];
                Items[positionB] = temp;
                SwopCount++;
                SetEvent(positionA, positionB, true, Brushes.Blue);

            }
        }

        
        public TimeSpan Sort()
        {
            Timer = new Stopwatch();
            SwopCount = 0;
            ComparisonCount = 0;
            Timer.Start();
            MakeSort();
            Timer.Stop();

            return Timer.Elapsed;
        }
        protected virtual void MakeSort()
        {
            Items.Sort();
        }

        protected bool Compare(int indA, int indB, int result)
        {
            ComparisonCount++;
            var b = Items[indA].CompareTo(Items[indB]);
            if (b!=result)
            {
                SetEvent(indA, indB, false, Brushes.Green);
            }
            else
            {
                SetEvent(indA, indB, false, Brushes.Red);
            }
            
            return b == result;
        }
        protected bool Compare(T elementA, T elementB, int result)
        {
            ComparisonCount++;
            var b = elementA.CompareTo(elementB);
            //if (b != result)
            //{
            //    SetEvent(elementA, elementB, false, Brushes.Green);
            //}
            //else
            //{
            //    SetEvent(elementA, elementB, false, Brushes.Red);
            //}

            return b == result;
        }
        private void SetEvent(int posA, int posB, bool b, SolidColorBrush color )
        {
            Timer.Stop();
            ItemsEdit?.Invoke(posA, posB, b, color);
            Timer.Start();
        }
    }
}
