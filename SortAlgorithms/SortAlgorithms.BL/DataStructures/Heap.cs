using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.BL.DataStructures
{
    public class Heap<T> : AlgorithmBase<T> where T:IComparable
    {
        public AlgorithmBase<T> AlgorithmBase;
        public int Count => Items.Count;

        public T Peek()
        {
            if (Count > 0)
            {
                return Items[0];
            }
            else
            {
                throw new ArgumentNullException(nameof(Items),"Куча пуста");
            }
        }

        public Heap() { }

        public Heap(IEnumerable<T> items)
        {
            SetItems(items);
        }
        public override void SetItems(IEnumerable<T> items)
        {
            Items = new List<T>();
            Items.AddRange(items);
            for (int i = Count; i >= 0; i--)
            {
                Sort(i);
            }
        }

        public void Add(T item)
        {
            Items.Add(item);

            var currentIndex = Count - 1;
            var parentIndex = GetParentIndex(currentIndex);

            while (currentIndex > 0 && Compare(parentIndex, currentIndex, -1)) 
            {
                Swop(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }

        public T GetMax()
        {
            var result = Items[0];
            Items[0] = Items[Count - 1];
            Items.RemoveAt(Count - 1);
            Sort(0);
            return result;
        }

        private void Sort(int curentIndex)
        {
            int maxIndex = curentIndex;
            int leftIndex;
            int rightIndex;

            while (curentIndex < Count)
            {
                leftIndex = 2 * curentIndex + 1;
                rightIndex = 2 * curentIndex + 2;

                if (leftIndex < Count && Compare(leftIndex, maxIndex, -1)) 
                {
                    maxIndex = leftIndex;
                }

                if (rightIndex < Count && Compare(rightIndex, maxIndex, -1)) 
                {
                    maxIndex = rightIndex;
                }

                if (maxIndex == curentIndex)
                {
                    break;
                }

                Swop(curentIndex, maxIndex);
                curentIndex = maxIndex;
            }
        }

        
        private int GetParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

        public List<T> Order()
        {
            var result = new List<T>();
            while (Count > 0)
            {
                result.Add(GetMax());
            }
            return result;
        }

        
    }
}
