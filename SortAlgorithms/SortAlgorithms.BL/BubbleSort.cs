using System;
using System.Reflection;

namespace SortAlgorithms.BL
{
    public class BubbleSort<T> : AlgorithmBase<T> where T : IComparable
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
                    if (Compare(i, i+1) == 1)
                    {
                        ItemsEdit?.Invoke(i, i + 1, null);
                        Swop(i, i + 1);
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
