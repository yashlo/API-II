using System;

namespace C1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the total number value");
            int n = Convert.ToInt32(Console.ReadLine());
            String[] ar = new String[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter the the " + i + "th string");
                ar[i] = Console.ReadLine();
            }
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    if (ar[i] == ar[j])
                    {
                        Console.WriteLine("Dublicate String is ar[i]"+ar[i]);
                        c = c + 1;
                    }
                }
            }
            Console.WriteLine("Total number of dublicated value is" + c);

        }
    }
}
