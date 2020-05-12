using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
   /// <summary>
   /// Сортировка пузырьком
   /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] mass = new int[] { 8, 4,5,5, 7, 1, 2 };
            ConsoleMass(mass);
            int len = mass.Length;
            while (len>0)
            {
                for (int i = 0; i < len-1; i++)
                {
                    if (mass[i]>mass[i+1])
                    {
                        int k = mass[i];
                        mass[i] = mass[i + 1];
                        mass[i + 1] = k;

                    }
                }
                len--;
            }
            ConsoleMass(mass);
            Console.WriteLine();
            Console.ReadKey();

        }

        private static void ConsoleMass(int[] mas)
        {
            Console.WriteLine();
            foreach (var item in mas)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine();
        }
    }
}
