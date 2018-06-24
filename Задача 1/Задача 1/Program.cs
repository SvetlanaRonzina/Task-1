using System;
using System.Collections.Generic;

namespace Задача_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Int32.Parse(Console.ReadLine());

            int[,] arr = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                string[] numbers = Console.ReadLine().Split(' ');
                for (int j = 0; j < N; j++)
                    arr[i, j] = int.Parse(numbers[j]);
            }
            Console.WriteLine();
            List<Tuple<int, int>> list = SearchForNonZero(arr, N);
            int[,] arr2 = Exchange(arr, list, N);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write("{0} ", arr2[i, j]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        public static List<Tuple<int, int>> SearchForNonZero(int[,] arr, int N)
        {
            List<Tuple<int, int>> list = new List<Tuple<int, int>>();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (!(arr[i, j] == 0))
                    {
                        Tuple<int, int> pos = new Tuple<int, int>(i, j);
                        list.Add(pos);
                    }
            return list;
        }
        public static int[,] Exchange(int[,] arr, List<Tuple<int, int>> list, int N)
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (arr[i, j] == 0)
                    {
                        int min = -1;
                        int ch = 0;
                        foreach (var e in list)
                        {
                            if (min == -1)
                            {
                                min = Math.Abs(i + 1 - e.Item1 - 1) + Math.Abs(j + 1 - e.Item2 - 1);
                                ch = arr[e.Item1, e.Item2];
                            }
                            else
                            if (min == Math.Abs(i + 1 - e.Item1 - 1) + Math.Abs(j + 1 - e.Item2 - 1)) ch = 0;
                            else
                                if (Math.Abs(i + 1 - e.Item1 - 1) + Math.Abs(j + 1 - e.Item2 - 1) < min)
                            {
                                min = Math.Abs(i + 1 - e.Item1 - 1) + Math.Abs(j + 1 - e.Item2 - 1);
                                ch = arr[e.Item1, e.Item2];
                            }
                        }

                        arr[i, j] = ch;

                    }
            return arr;
        }
    }
}
