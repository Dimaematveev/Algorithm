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

        const string N1 = "Number=3";
        const string N2 = "Number=15";
        const string N3 = "Number=141";
        const string N4 = "Number=1258";
        const string N5 = "Number=5821";
        const string N6 = "Number=1200";
        const string N7 = "Number=1510";
        readonly int[] count = new int[]
        {
            Convert.ToInt32(N1.Substring(7)),
            Convert.ToInt32(N2.Substring(7)),
            Convert.ToInt32(N3.Substring(7)),
            Convert.ToInt32(N4.Substring(7)),
            Convert.ToInt32(N5.Substring(7)),
            Convert.ToInt32(N6.Substring(7)),
            Convert.ToInt32(N7.Substring(7)),
        };

        [TestInitialize]
        public void Init()
        {
            int number;
            string path = @"C:\Users\Дмитрий\Source\Repos\Algorithm\SortAlgorithms\SortAlgorithms.BLTests\number.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                number = Convert.ToInt32(sr.ReadLine());
            }

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.Write($"{(number + 1) % count.Length}");
            }
            Items.Clear();
            Sorted.Clear();
            
            
            for (int i = 0; i < count[number]; i++)
            {
                Items.Add(rnd.Next(0, 1000));
            }
            Sorted.AddRange(Items.OrderBy(x => x));


        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(N1)]
        [DataRow(N2)]
        [DataRow(N3)]
        [DataRow(N4)]
        [DataRow(N5)]
        [DataRow(N6)]
        [DataRow(N7)]
        public void BaseSortTest(string _1)
        {
            //Arrange
            var sort = new AlgorithmBase<int>();
            sort.Items.AddRange(Items);
            //ACT
            sort.Sort();

            //Assert
            AssertSorted(sort);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(N1)]
        [DataRow(N2)]
        [DataRow(N3)]
        [DataRow(N4)]
        [DataRow(N5)]
        [DataRow(N6)]
        [DataRow(N7)]
        public void BubbleTest(string _1)
        {
            //Arrange
            var sort = new BubbleSort<int>();
            sort.Items.AddRange(Items);
            //ACT
            sort.Sort();

            //Assert
            AssertSorted(sort);
        }


        [TestMethod]
        [DataTestMethod]
        [DataRow(N1)]
        [DataRow(N2)]
        [DataRow(N3)]
        [DataRow(N4)]
        [DataRow(N5)]
        [DataRow(N6)]
        [DataRow(N7)]
        public void CocktailTest(string _1)
        {
            //Arrange
            var sort = new CocktailSort<int>();
            sort.Items.AddRange(Items);
            //ACT
            sort.Sort();

            //Assert
            AssertSorted(sort);
        }


        [TestMethod]
        [DataTestMethod]
        [DataRow(N1)]
        [DataRow(N2)]
        [DataRow(N3)]
        [DataRow(N4)]
        [DataRow(N5)]
        [DataRow(N6)]
        [DataRow(N7)]
        public void InsectionTest(string _1)
        {
            //Arrange
            var sort = new InsertionSort<int>();
            sort.Items.AddRange(Items);
            //ACT
            sort.Sort();

            //Assert
            AssertSorted(sort);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(N1)]
        [DataRow(N2)]
        [DataRow(N3)]
        [DataRow(N4)]
        [DataRow(N5)]
        [DataRow(N6)]
        [DataRow(N7)]
        public void ShellTest(string _1)
        {
            //Arrange
            var sort = new ShellSort<int>();
            sort.Items.AddRange(Items);
            //ACT
            sort.Sort();

            //Assert
            AssertSorted(sort);
        }


        [TestMethod]
        [DataTestMethod]
        [DataRow(N1)]
        [DataRow(N2)]
        [DataRow(N3)]
        [DataRow(N4)]
        [DataRow(N5)]
        [DataRow(N6)]
        [DataRow(N7)]
        public void SelectionTest(string _1)
        {
            //Arrange
            var sort = new SelectionSort<int>();
            sort.Items.AddRange(Items);
            //ACT
            sort.Sort();

            //Assert
            AssertSorted(sort);
        }

        


        [TestMethod]
        [DataTestMethod]
        [DataRow(N1)]
        [DataRow(N2)]
        [DataRow(N3)]
        [DataRow(N4)]
        [DataRow(N5)]
        [DataRow(N6)]
        [DataRow(N7)]
        public void TreeSortTest(string _1)
        {
            //Arrange
            var sort = new TreeSort<int>();
            sort.Items.AddRange(Items);
            //ACT
            sort.Sort();

            //Assert
            AssertSorted(sort);
        }


        [TestMethod]
        [DataTestMethod]
        [DataRow(N1)]
        [DataRow(N2)]
        [DataRow(N3)]
        [DataRow(N4)]
        [DataRow(N5)]
        [DataRow(N6)]
        [DataRow(N7)]
        public void HeapTest(string _1)
        {
            //Arrange
            var sort = new HeapSort<int>();
            sort.SetItems(Items);
            //ACT
            sort.Sort();

            //Assert
            AssertSorted(sort);
        }


        [TestMethod]
        [DataTestMethod]
        [DataRow(N1)]
        [DataRow(N2)]
        [DataRow(N3)]
        [DataRow(N4)]
        [DataRow(N5)]
        [DataRow(N6)]
        [DataRow(N7)]
        public void GnomeTest(string _1)
        {
            //Arrange
            var sort = new GnomeSort<int>();
            sort.SetItems(Items);
            //ACT
            sort.Sort();

            //Assert
            AssertSorted(sort);
        }

        private void AssertSorted<T>(T sort) where T:AlgorithmBase<int>
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Assert.AreEqual(Sorted[i], sort.Items[i]);
            }
        }
    }
}