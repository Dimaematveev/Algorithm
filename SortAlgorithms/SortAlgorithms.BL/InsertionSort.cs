﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.BL
{
    public class InsertionSort<T> : AlgorithmBase<T> where T : IComparable
    {
        protected override void MakeSort()
        {
            for (int i = 1; i < Items.Count; i++)
            {
                var j = i;
                while (j > 0) 
                {
                    if (Compare(j, j - 1, -1)) 
                    {
                        Swop(j, j - 1);
                        j--;
                    }
                    else
                    {
                        break;
                    }
                    
                }
            }
        }
    }
}
