using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.BL
{
    public class ShellSort<T> : AlgorithmBase<T> where T : IComparable
    {
        public override event Action<int, int, bool?> ItemsEdit;
        protected override void MakeSort()
        {
            var step = Items.Count / 2;

            while (step > 0)
            {

                for (int i = step; i < Items.Count; i++)
                {
                    int j = i;
                    while ((j>=step))
                    {
                        if (Items[j - step].CompareTo(Items[j]) == 1)
                        {
                            ItemsEdit?.Invoke(j - step, j, null);
                            Swop(j - step, j);
                            j -= step;
                            ItemsEdit?.Invoke(j, j + step, true);
                        }
                        else
                        {
                            ItemsEdit?.Invoke(j - step, j, false);
                            break;
                        }
                        
                    }
                }
                step /= 2;
            }



            base.MakeSort();
        }
    }
}
