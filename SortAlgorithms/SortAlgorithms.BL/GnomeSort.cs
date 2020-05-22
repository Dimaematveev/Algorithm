using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.BL
{
    public class GnomeSort<T> : AlgorithmBase<T> where T : IComparable
    {
        protected override void MakeSort()
        {
            var i = 1;
            while (i < Items.Count)
            {
                if (i != 0 && Compare(i - 1, i, 1))
                {
                    Swop(i - 1, i);
                    i--; 
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
