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
    public class CocktailSortTests
    {
        [DataTestMethod]
        [DataRow(10, 0, 100)]
        [DataRow(1000, 0, 100000)]
        [DataRow(10000, 100, 10000)]
        [DataRow(3, 0, 2)]
        [DataRow(1084, 0, 10)]
        public void SortTest(int count, int minrand, int maxrand)
        {
            //Arrange
            var cocktail = new CocktailSort<int>();
            var rnd = new Random();
            var items = new List<int>();
            for (int i = 0; i < count; i++)
            {

                items.Add(rnd.Next(minrand, maxrand));
            }
            cocktail.Items.AddRange(items);
            var sorted = items.OrderBy(x=>x).ToArray();

            //ACT
            cocktail.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], cocktail.Items[i]);
            }

        }
    }
}