using SortAlgorithms.BL.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.BL
{
    public class TreeSort<T> : AlgorithmBase<T> where T : IComparable
    {
        public override event Action<int, int, bool?> ItemsEdit;

        protected override void MakeSort()
        {
            var tree = new Tree<T>(Items);

            var sorted = tree.Inorder();

            Items = sorted;
        }
    }
}
