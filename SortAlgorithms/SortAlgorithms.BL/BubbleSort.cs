using System;
using System.Reflection;

namespace SortAlgorithms.BL
{
    public class BubbleSort<T> : AlgorithmsBase<T> where T : IComparable
    {
        public override event Action<int, int, bool? > ItemsEdit;
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
                        ItemsEdit?.Invoke(i, i + 1, null);
                        Swop(i, i + 1);
                        ComparisonCount++;
                        ItemsEdit?.Invoke(i, i + 1, true);
                    }
                    else
                    {
                        ItemsEdit?.Invoke(i, i + 1, false);
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
