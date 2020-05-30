using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.BL
{
    public class LSDRedixSort : AlgorithmBase<int>
    {
        protected override void MakeSort()
        {
            var groups = new List<List<int>>();

            for (int i = 0; i < 10; i++)
            {
                groups.Add(new List<int>());
            }

            var length = GetMaxLength();



            for (int step = 0; step < length; step++)
            {
                //Распределение элементов в корзины
                foreach (var item in Items)
                {
                    var value = item % (int)Math.Pow(10,step+1) / (int)Math.Pow(10, step);
                    groups[value].Add(item);
                }

                //Одновление Items и очистка group
                Items.Clear();
                foreach (var group in groups)
                {
                    foreach (var item in group)
                    {
                        Items.Add(item);
                    }

                    group.Clear();
                }

            }

        }



        private int GetMaxLength()
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
                    l = Convert.ToInt32(Math.Log10(item) + 1);
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
