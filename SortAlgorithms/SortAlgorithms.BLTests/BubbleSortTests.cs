using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAlgorithms.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.BL.Tests
{
    [TestClass()]
    public class BubbleSortTests
    {
        [DataTestMethod]
        [DataRow(10,0,100)]
        [DataRow(1000,0,100000)]
        [DataRow(10000,100,10000)]
        [DataRow(3,0,2)]
        [DataRow(1084,0,10)]
        public void SortTest(int count, int minrand, int maxrand)
        {
            //Arrange
            var buble = new BubbleSort<int>();
            var rnd = new Random();
            var items = new List<int>();
            for (int i = 0; i < count; i++)
            {
                
                items.Add(rnd.Next(minrand, maxrand));
            }
            buble.Items.AddRange(items);
            items.Sort();

            //ACT
            buble.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], buble.Items[i]);
            }
            
        }
    }
}