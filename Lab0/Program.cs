using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj zakres!");
            int number = int.Parse(Console.ReadLine());

            //Console.WriteLine(number);

            FizzBuzz fizzBuzz = new FizzBuzz(number);
            fizzBuzz.Print();

        }
    }

    internal class FizzBuzz
    {
        private int max;
        public FizzBuzz(int max)
        {
            this.max = max;
        }

        public void Print()
        {
            for (int i = 1; i < max; i++)
            {
                Console.WriteLine(i % 15 == 0 ? "FizzBuzz" :
                                   i % 3 == 0 ? "Fizz" :
                                   i % 5 == 0 ? "Buzz" :
                                   i.ToString()
                                   );
            }
        }
    }
}