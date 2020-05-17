using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.BL
{
    public class BozoSort<T> : AlgorithmBase<T> where T : IComparable
    {
        private readonly Random rnd = new Random();
        public override event Action<int, int, bool?> ItemsEdit;
        protected override void MakeSort()
        {
            bool isEnd = false;
            while (!isEnd)
            {
                int posA = rnd.Next(0, Items.Count);
                int posB;
                do
                {
                    posB = rnd.Next(0, Items.Count);
                } while (posA == posB);

                ItemsEdit?.Invoke(posA, posB, null);
                Swop(posA, posB);
                ItemsEdit?.Invoke(posA, posB, true);

                isEnd = true;
                for (int i = 1; i < Items.Count; i++)
                {
                    ItemsEdit?.Invoke(i-1, i, false);
                    if (Compare(i - 1, i) == 1)
                    {
                        ItemsEdit?.Invoke(i - 1, i, null);
                        isEnd = false;
                        break;
                    }
                    
                }
            }
        }
    }
}
