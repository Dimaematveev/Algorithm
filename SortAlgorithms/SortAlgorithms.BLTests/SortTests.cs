using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAlgorithms.BL;
using System;
using System.Collections.Generic;
using System.IO;
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
            List<string> simb;
            string path = @"C:\Users\Дмитрий\Source\Repos\Algorithm\SortAlgorithms\SortAlgorithms.BLTests\number.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                simb = sr.ReadLine().Split(';').Where(x=>!string.IsNullOrWhiteSpace(x)).ToList();
            }
            int number = Convert.ToInt32(simb[0]);
            var temp = simb[0];
            simb.RemoveAt(0);
            simb.Add(temp);
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (var item in simb)
                {
                    sw.Write($"{item};");
                }
            }
            Items.Clear();
            Sorted.Clear();
            
            int[] count = new int[] { 3, 10, 1000, 1084, 10000 };
            int[] minrand = new int[] { 0, 0, 0, 0, 100 };
            int[] maxrand = new int[] { 2, 100, 100000, 10, 10000 };
            for (int i = 0; i < count[number]; i++)
            {
                Items.Add(rnd.Next(minrand[number], maxrand[number]));
            }
            Sorted.AddRange(Items.OrderBy(x => x));


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
            var sort = new BubbleSort<int>();
            sort.Items.AddRange(Items);
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
            var sort = new CocktailSort<int>();
            sort.Items.AddRange(Items);
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
            var sort = new InsertionSort<int>();
            sort.Items.AddRange(Items);
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
        public void ShellTest(int number)
        {
            //Arrange
            var sort = new ShellSort<int>();
            sort.Items.AddRange(Items);
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
        public void BaseSortTest(int number)
        {
            //Arrange
            var sort = new AlgorithmBase<int>();
            sort.Items.AddRange(Items);
            //ACT
            sort.Sort();

            //Assert
            for (int i = 0; i < Items.Count; i++)
            {
                Assert.AreEqual(Sorted[i], sort.Items[i]);
            }
        }
    }
}