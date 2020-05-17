using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.BL
{
    public class SelectionSort<T> : AlgorithmBase<T> where T : IComparable
    {

        protected override void MakeSort()
        {

            for (int i = 0; i < Items.Count-1; i++)
            {
                var minInd = i;
                
                for (int j = i+1; j < Items.Count; j++)
                {
                    
                    if (Compare(minInd, j) == 1)
                    {
                        minInd = j;
                    }
                }
                if (i != minInd) 
                {
                    Swop(i, minInd);
                }
            }
           
        }
    }
}
