using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunch
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null)
            {
                Console.WriteLine("MISSING REQUIRED PARAMETERS! Stop being a dick lewis...");
                System.Environment.Exit(1);
            }

            Double numPrimes;
            if(!Double.TryParse(args[0], out numPrimes))
            {
                Console.WriteLine("MISSING prime numbers! Stop being a dick lewis...");
                System.Environment.Exit(1);
            }

            string filePath;
            string runName;

            Stopwatch timer = new Stopwatch();

            if (Stopwatch.IsHighResolution)
            {
                Debug.Print("System supports precision of {0} ticks per second", Stopwatch.Frequency);
            }

            timer.Restart();
            CalculatePrimesSum(Double.Parse(args[0]));
            timer.Stop();

            Console.WriteLine("{0} primes takes {1} millis", args[0], timer.Elapsed.TotalMilliseconds);

            Console.Read();
        }

        static void CalculatePrimesSum(Double numPrimes)
        {
            Double primeSum = 0;

            for (int i = 1, primeCounter = 0; primeCounter < numPrimes; i++)
            {
                if (!IsPrime(i))
                {
                    continue;
                }
                else
                {
                    primeCounter++;
                    primeSum += i;
                    Console.Clear();
                    Console.WriteLine(primeSum.ToString());
                }
            }
        }

        static bool IsPrime(Double number)
        {
            if(number == 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            for (int i = 2; i <= (decimal) Math.Ceiling(Math.Sqrt(number)); i++)
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
