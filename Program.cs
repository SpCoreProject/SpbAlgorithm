using System;
using System.Runtime.CompilerServices;

namespace SpbAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool runApp = true;
            while (runApp)
            {
                Console.WriteLine("Please Enter Hash Mode Number");
                Console.WriteLine("Number : 1 >>  128");
                Console.WriteLine("Number : 2 >>  192");
                Console.WriteLine("Number : 3 >>  256");
                Console.WriteLine("Number : 4 >>  288");
                Console.WriteLine("Number : 5 >>  384");
                Console.WriteLine("Number : 6 >>  512");
                string HashMode = Console.ReadLine();

                Console.WriteLine("Please Enter Word: ");
                string Words = Console.ReadLine();
                switch (HashMode)
                {
                    case "1":
                        Console.WriteLine(SPB128.Hash(Words));
                        break;
                    case "2":
                        Console.WriteLine(SPB192.Hash(Words)); break;
                    case "3":
                        Console.WriteLine(SPB256.Hash(Words)); break;
                    case "4":
                        Console.WriteLine(SPB288.Hash(Words)); break;
                    case "5":
                        Console.WriteLine(SPB384.Hash(Words)); break;
                    case "6":
                        Console.WriteLine(SPB512.Hash(Words)); break;
                    case "9":
                        runApp = false;
                        break;
                    default:
                        Console.WriteLine("The input is invalid !!! ");
                        Console.WriteLine("Please Try Again /r/n"); break;
                }

            }
        }
    }
}
