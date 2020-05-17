using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.BL
{
    public class SelectionSort<T> : AlgorithmBase<T> where T : IComparable
    {
        public override event Action<int, int, bool?> ItemsEdit;

        protected override void MakeSort()
        {

            for (int i = 0; i < Items.Count-1; i++)
            {
                var minInd = i;
                
                for (int j = i+1; j < Items.Count; j++)
                {
                    
                    if (Compare(minInd, j) == 1)
                    {
                        ItemsEdit?.Invoke(j, minInd, null);
                        minInd = j;
                    }
                    else
                    {
                        ItemsEdit?.Invoke(j, minInd, false);
                    }
                }
                if (i != minInd) 
                {
                    ItemsEdit?.Invoke(minInd, i, null);
                    Swop(i, minInd);
                    ItemsEdit?.Invoke(minInd, i, true);
                }
            }
           
        }
    }
}
