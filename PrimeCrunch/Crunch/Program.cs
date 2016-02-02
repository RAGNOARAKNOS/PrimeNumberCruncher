using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunch
{
    class Program
    {
        static void Main(string[] args)
        {
            // ARGS 
            // 0 - Num of primes (guideline 800000 for ~ 5mins)
            // 1 - CSV filename to write to (it will place in the current dir)
            // 2 - Name to tag this run with to correlate data

            if (args == null)
            {
                Console.WriteLine("MISSING REQUIRED PARAMETERS! Stop being a dick lewis...");
                System.Environment.Exit(1);
            }

            Double numPrimes;  //Suggest 800000 for ~ 5mins

            if(!Double.TryParse(args[0], out numPrimes))
            {
                Console.WriteLine("MISSING prime numbers! Stop being a dick lewis...");
                System.Environment.Exit(1);
            }

            string filePath = AppDomain.CurrentDomain.BaseDirectory + args[1];
            string runName = args[2];

            Stopwatch timer = new Stopwatch();

            if (Stopwatch.IsHighResolution)
            {
                Debug.Print("System supports precision of {0} ticks per second", Stopwatch.Frequency);
            }

            timer.Restart();
            CalculatePrimesSum(Double.Parse(args[0]));
            timer.Stop();

            Console.WriteLine("{0} primes takes {1} millis", args[0], timer.Elapsed.TotalMilliseconds);
            String fileOutput = string.Format("\n{0},{1},{2}", runName, numPrimes, timer.Elapsed.TotalMilliseconds);
            File.AppendAllText(filePath, fileOutput);
        }

        static void CalculatePrimesSum(Double numPrimes)
        {
            Double primeSum = 0;

            for (int i = 1, primeCounter = 0; primeCounter < numPrimes; i++)
            {
                if (IsPrime(i))
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
