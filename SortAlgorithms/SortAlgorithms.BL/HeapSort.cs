using SortAlgorithms.BL.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.BL
{
    public class HeapSort<T> : AlgorithmBase<T> where T : IComparable
    {

        protected override void MakeSort()
        {
            var heap = new Heap<T>();
            heap.SetItems(Items);
            Items=heap.Order();
        }
    }
}
