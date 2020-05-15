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
    public class SortTests
    {
        readonly Random rnd = new Random();
        readonly List<int> Items = new List<int>();
        readonly List<int> Sorted = new List<int>();

        [TestInitialize]
        public void Init()
        {
            Items.Clear();
            Sorted.Clear();
        }
        public T FillMass<T>(int number) where T : AlgorithmsBase<int>, new()
        { 
            int[] count = new int[] { 3, 10, 1000, 1084, 10000 };
            int[] minrand = new int[] { 0, 0, 0, 0, 100 };
            int[] maxrand = new int[] { 2, 100, 100000, 10, 10000 };
            for (int i = 0; i < count[number]; i++)
            {
                Items.Add(rnd.Next(minrand[number], maxrand[number]));
            }
            Sorted.AddRange(Items.OrderBy(x => x));

            var sort = new T();
            sort.Items.AddRange(Items);
            return sort;
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void BubbleTest(int number)
        {
            //Arrange
            var sort = FillMass<BubbleSort<int>>(number);
            //ACT
            sort.Sort();

            //Assert
            for (int i = 0; i < Items.Count; i++)
            {
                Assert.AreEqual(Sorted[i], sort.Items[i]);
            }
        }


        [TestMethod]
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void CocktailTest(int number)
        {
            //Arrange
            var sort = FillMass<CocktailSort<int>>(number);
            //ACT
            sort.Sort();

            //Assert
            for (int i = 0; i < Items.Count; i++)
            {
                Assert.AreEqual(Sorted[i], sort.Items[i]);
            }
        }


        [TestMethod]
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void InsectionTest(int number)
        {
            //Arrange
            var sort = FillMass<InsertionSort<int>>(number);
            //ACT
            sort.Sort();

            //Assert
            for (int i = 0; i < Items.Count; i++)
            {
                Assert.AreEqual(Sorted[i], sort.Items[i]);
            }
        }


        //[TestMethod]
        //[DataTestMethod]
        //[DataRow(3, 0, 2)]
        //[DataRow(10, 0, 100)]
        //[DataRow(1000, 0, 100000)]
        //[DataRow(1084, 0, 10)]
        //[DataRow(10000, 100, 10000)]
        //public void BozoTest(int count, int minrand, int maxrand)
        //{
        //    //Arrange
        //    for (int i = 0; i < count; i++)
        //    {

        //        Items.Add(rnd.Next(minrand, maxrand));
        //    }
        //    Sorted.AddRange(Items.OrderBy(x => x));

        //    var sort = new BozoSort<int>();

        //    sort.Items.AddRange(Items);
        //    //ACT
        //    sort.Sort();

        //    //Assert
        //    for (int i = 0; i < Items.Count; i++)
        //    {
        //        Assert.AreEqual(Sorted[i], sort.Items[i]);
        //    }
        //}
    }
}