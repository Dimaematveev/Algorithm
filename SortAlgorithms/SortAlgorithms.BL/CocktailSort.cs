using System;

namespace SortAlgorithms.BL
{
    public class CocktailSort<T> : AlgorithmsBase<T> where T : IComparable
    {
        public override event Action<int, int, bool?> ItemsEdit;
        protected override void MakeSort()
        {
            int left = 0;
            int right = Items.Count - 1;

            while (left < right)
            {
                var sc = SwopCount;
                for (int i = left; i < right; i++)
                {
                    if (Items[i].CompareTo(Items[i + 1])==1) 
                    {
                        ItemsEdit?.Invoke(i, i + 1, null);
                        Swop(i, i + 1);
                        ItemsEdit?.Invoke(i, i + 1, true);
                        ComparisonCount++;
                    }
                    else
                    {
                        ItemsEdit?.Invoke(i, i + 1, false);
                    }
                }
                right--;

                if (sc == SwopCount)
                {
                    break;
                }

                for (int i = right; i > left; i--)
                {
                    if (Items[i].CompareTo(Items[i - 1]) == -1) 
                    {
                        ItemsEdit?.Invoke(i, i - 1, null);
                        Swop(i - 1, i);
                        ItemsEdit?.Invoke(i, i - 1, true);
                        ComparisonCount++;
                    }
                    else
                    {
                        ItemsEdit?.Invoke(i, i - 1, false);
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
