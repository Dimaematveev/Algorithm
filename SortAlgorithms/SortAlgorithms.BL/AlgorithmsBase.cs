using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortAlgorithms.BL
{
    public class AlgorithmBase<T> where T:IComparable
    {
        public int SwopCount { get; protected set; } = 0;
        public int ComparisonCount { get; protected set; } = 0;

        public virtual event Action<int, int, bool?> ItemsEdit;
        public List<T> Items { get; set; } = new List<T>();

        protected void Swop(int positionA,int positionB)
        {
            if (positionA < Items.Count && positionB < Items.Count)
            {
                SetEvent(positionA, positionB, null);
                var temp = Items[positionA];
                Items[positionA] = Items[positionB];
                Items[positionB] = temp;
                SwopCount++;
                SetEvent(positionA, positionB, true);

            }
        }

        protected Stopwatch Timer = new Stopwatch();
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

        protected int Compare(int indA, int indB)
        {
            ComparisonCount++;
            SetEvent(indA, indB, false);
            return Items[indA].CompareTo(Items[indB]);
        }

        protected void SetEvent(int posA, int posB, bool? b)
        {
            Timer.Stop();
            ItemsEdit?.Invoke(posA, posB, b);
            Timer.Start();
        }
    }
}
