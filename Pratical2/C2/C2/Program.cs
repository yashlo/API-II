using System;

namespace C2
{
    class Calculator
    {
        static double pi = 3.14;
        public double Area(int n)
        {
            return pi * n * n;
        }
        public double Area(int h,int w)
        {
            return h * w;
        }
        public double Area(int a, int b, int c)
        {
            return (a + b + c) / 3;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculator c1 = new Calculator();
            Console.WriteLine("Enter the radious of the circle");
            int r = Convert.ToInt32(Console.ReadLine());
            double ans = c1.Area(r);
            Console.WriteLine("Enter the height of the Square");
            int h = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the width of the Square");
            int w = Convert.ToInt32(Console.ReadLine());
            double ans1 = c1.Area(h, w);
            Console.WriteLine("Enter the value of a for the triangle");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the value of b for the triangle");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the value of c for the triangle");
            int c = Convert.ToInt32(Console.ReadLine());
            double ans2 = c1.Area(a, b, c);
            Console.WriteLine("if radious is " + r + "then the area of the circle is " + ans);
            Console.WriteLine("if height is " + h + " and the width is " + w + " Then the area of square  is " + ans1);
            Console.WriteLine("if the value of a= "+a+" value of b = "+b+"value of c = "+c+" then the area of triangle is "+ans2);
        }
    }
}
