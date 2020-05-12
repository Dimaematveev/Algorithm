using System.Collections.Generic;

namespace SortAlgorithms.BL
{
    public class AlgorithmsBase<T>
    {
        public List<T> Items { get; set; } = new List<T>();

        public void Swop(int positionA,int positionB)
        {
            if (positionA<Items.Count && positionB<Items.Count)
            {
                var temp = Items[positionA];
                Items[positionA] = Items[positionB];
                Items[positionB] = temp;
            }
        }
    }
}
