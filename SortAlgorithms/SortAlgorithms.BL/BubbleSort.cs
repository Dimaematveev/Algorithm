using System;
using System.Reflection;

namespace SortAlgorithms.BL
{
    public class BubbleSort<T> : AlgorithmBase<T> where T : IComparable
    {
        protected override void MakeSort()
        {
            var count = Items.Count;

            while (count > 1)
            {
               var  sc = SwopCount;
                
                for (int i = 0; i < count - 1; i++)
                {
                    if (Compare(i, i+1) == 1)
                    {
                        Swop(i, i + 1);
                    }
                    
                }
                count--;

                if (sc == SwopCount)
                {
                    break;
                }
            }
        }


    }
}
