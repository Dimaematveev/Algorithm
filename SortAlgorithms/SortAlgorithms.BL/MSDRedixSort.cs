using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.BL
{
    public class MSDRedixSort : AlgorithmBase<int>
    {
        protected override void MakeSort()
        {
            var length = GetMaxLength(Items);
            Items = SortCollection(Items, length-1);
        }

        private List<int> SortCollection(List<int> collection,int step)
        {
            var result  =new List<int>();
            var groups = new List<List<int>>();
            for (int i = 0; i < 10; i++)
            {
                groups.Add(new List<int>());
            }

            //Распределение элементов в корзины
            foreach (var item in collection)
            {
                var value = item  % (int)Math.Pow(10, step + 1) / (int)Math.Pow(10, step);
                groups[value].Add(item);
            }

            //Одновление Items 
            foreach (var group in groups)
            {
                if (group.Count > 1 && step > 0)
                {
                    result.AddRange(SortCollection(group, step - 1));
                    continue;
                }
                result.AddRange(group);
                
            }
            return result;
        }

        private int GetMaxLength(List<int> collection)
        {
            var length = 0;

            foreach (var item in Items)
            {
                if (item < 0)
                {
                    throw new ArgumentException("Поразрядная сортировка использует только целые числа >=0!");
                }
                int l = 1;
                if (item != 0)
                {
                    l = (int)(Math.Log10(item)) + 1;
                }
                
               
                if (l > length)
                {
                    length = l;
                }
            }
            return length;
        }
    }
}
