using System;

namespace SortAlgorithms.BL
{
    public class BubbleSort<T> : AlgorithmsBase<T> where T:IComparable
    {
        public override void Sort()
        {
            var count = Items.Count;

            while (count > 1)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    var a = Items[i];
                    var b = Items[i + 1];

                    if (a.CompareTo(b) == 1)
                    {
                        Swop(i, i + 1);
                    }
                }
                count--;
            }
        }


    }
}
