using System;
namespace C4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jagged_array = new int[5][];
            jagged_array[0] = new int[] { 1, 5, 4, 3, 2 };
            jagged_array[1] = new int[] { 67, 34, 11 };
            jagged_array[2] = new int[] { 44, 22, 66, 10 };
            jagged_array[3] = new int[] { 99, 22, 44, 11, 55 };
            jagged_array[4] = new int[] { 55, 22, 77, 44, 11, 55, 66 };
            for (int i = 0; i < 5; i++)
            {
                    Array.Sort(jagged_array[i]);
                    Console.WriteLine("After Sorting [" + i + "] th array");
                    for (int j = 0; j < jagged_array[i].Length; j++)
                    {
                        Console.WriteLine(jagged_array[i][j]);
                    }
            }
            Console.ReadKey();
        }
    }
}
