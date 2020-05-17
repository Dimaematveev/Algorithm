using System;

namespace SortAlgorithms.BL
{
    public class CocktailSort<T> : AlgorithmBase<T> where T : IComparable
    {
        protected override void MakeSort()
        {
            int left = 0;
            int right = Items.Count - 1;

            while (left < right)
            {
                var sc = SwopCount;
                for (int i = left; i < right; i++)
                {
                    if (Compare(i, i + 1) == 1) 
                    {
                        Swop(i, i + 1);
                    }
                }
                right--;

                if (sc == SwopCount)
                {
                    break;
                }

                for (int i = right; i > left; i--)
                {
                    if (Compare(i, i - 1) == -1) 
                    {
                        Swop(i - 1, i);
                    }
                }
                left++;

                if (sc == SwopCount) 
                {
                    break;
                }
            }
        }
    }
}
