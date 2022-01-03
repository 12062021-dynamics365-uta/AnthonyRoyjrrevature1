using System;

namespace P0_Anthony
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 2 + 2;
            Console.WriteLine(a); // output:4
            Console.WriteLine("\nAgree to terms");
            string agree = Console.ReadLine();
            Console.WriteLine("Welcome To Roy investment group. Where we help you invest in yourself");
            Console.WriteLine("\n please enter business");
            string business = Console.ReadLine();
            Console.WriteLine("\nEnter your First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("\nEnter your Nickname Name");
            string nickname = Console.ReadLine();
            Console.WriteLine("\n Enter Store location");
            string location = Console.ReadLine();
        }
    }
}
