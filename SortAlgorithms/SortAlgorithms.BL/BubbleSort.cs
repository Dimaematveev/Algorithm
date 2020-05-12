using System;

namespace SortAlgorithms.BL
{
    public class BubbleSort<T> : AlgorithmsBase<T> where T:IComparable
    {
        protected override void MakeSort()
        {
            var count = Items.Count;

            while (count > 1)
            {
               var  sc = SwopCount;

                for (int i = 0; i < count - 1; i++)
                {
                    var a = Items[i];
                    var b = Items[i + 1];

                    if (a.CompareTo(b) == 1)
                    {
                        Swop(i, i + 1);
                        ComparisonCount++;
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
