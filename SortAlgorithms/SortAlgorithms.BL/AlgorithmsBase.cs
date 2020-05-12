﻿using System;
using System.Collections.Generic;

namespace SortAlgorithms.BL
{
    public class AlgorithmsBase<T> where T:IComparable
    {
        public event Action ItemsEdit;
        public List<T> Items { get; set; } = new List<T>();

        protected void Swop(int positionA,int positionB)
        {
            if (positionA < Items.Count && positionB < Items.Count)
            {
                
                var temp = Items[positionA];
                Items[positionA] = Items[positionB];
                Items[positionB] = temp;
                ItemsEdit?.Invoke();
            }
        }

       

        public virtual void Sort()
        {
            Items.Sort();
        }
    }
}