using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.BL
{
    public class QuickSort<T> : AlgorithmBase<T> where T : IComparable
    {

        protected override void MakeSort()
        {
            Qsort(0, Items.Count-1);
        }

        private void Qsort(int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            var pivot = Sorting(left, right);

            Qsort(left, pivot - 1);
            Qsort(pivot + 1, right);
        }

        private int Sorting(int left, int right)
        {
            var pointer = left;

            //опорный элемент под right
            for (int i = left; i < right; i++)
            {
                if (Compare(i, right, -1)) 
                {
                    Swop(pointer, i);
                    pointer++;
                }
            }
            Swop(pointer, right);
            return pointer;
        }
    }
}
