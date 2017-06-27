using System;
using System.Collections.Generic;
using System.Linq;
namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzzer fizzBuzzer = new FizzBuzzer();

            //Console.WriteLine(fizzBuzzer.FizzBuzzRange(8, 16));

            Console.WriteLine(fizzBuzzer.FizzBuzzRange(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()))); //Win for readability!! But yeah.. we both know you're not interested in this class

        }
    }
}
