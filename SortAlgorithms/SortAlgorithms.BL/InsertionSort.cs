using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.BL
{
    public class InsertionSort<T> : AlgorithmsBase<T> where T : IComparable
    {
        public override event Action<int, int, bool?> ItemsEdit;
        protected override void MakeSort()
        {
            ComparisonCount = 0;
            for (int i = 1; i < Items.Count; i++)
            {
                var temp = Items[i];
                var j = i;
                while (j > 0) 
                {
                    ComparisonCount++;
                    if (temp.CompareTo(Items[j - 1]) == -1)
                    {
                        ItemsEdit?.Invoke(j, j - 1, null);
                        Swop(j, j - 1);
                        ItemsEdit?.Invoke(j, j - 1, true);
                        
                        j--;
                    }
                    else
                    {
                        ItemsEdit?.Invoke(j, j - 1, false);
                        break;
                    }
                    
                }
            }
        }
    }
}
