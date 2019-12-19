using System;
namespace C3
{
    class Program
    {
        public static void getMinMax(int[] a, int b)
        {
            int min, max;
            min = a[0];
            max = a[0];
            for (int i = 1; i < b; i++)
            {
                if (min >= a[i])
                {
                    min=a[i];
                }
                if(max<= a[i])
                {
                    max = a[i];
                }
            }
                Console.WriteLine("Minimum number into array is "+min);
                Console.WriteLine("Maximum number into array is " + max);


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of element of an array");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ar = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Entered the ar [" + i + "] th index value");
                ar[i] = Convert.ToInt32(Console.ReadLine());

            }
           
            Console.WriteLine("You entered array are as follow");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Value of ar ["+i+"]==>>"+ar[i]);
            }
            getMinMax(ar, n);
            Console.ReadKey();


        }
    }
}
