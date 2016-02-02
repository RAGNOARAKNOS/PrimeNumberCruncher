using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunch
{
    class Program
    {
        static void Main(string[] args)
        {
            int primeSum = 0;

            for (int i = 1, primeCounter = 0; primeCounter < 1000; i++)
            {
                if(!IsPrime(i))
                {
                    continue;
                }
                else
                {
                    primeCounter++;
                    primeSum += i;
                }
            }

            Console.WriteLine(primeSum);
            Console.Read();
        }

        static bool IsPrime(int number)
        {
            if(number == 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
