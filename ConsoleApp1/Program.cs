using System;
using EmployeeDirectory.Database;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeDb.Initize();
            Console.WriteLine("Hello World!");
        }
    }
}
