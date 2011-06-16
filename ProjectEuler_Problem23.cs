using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ProjectEuler_01
{
	class Program
	{		
		static int result = 0;
		static int upperLimit = 28123;
		static bool[] abundantNumbersArray = new bool[upperLimit];
		static bool[] abundantNumbersSumArray = new bool[upperLimit];

		static bool IsNumberAbundant(int i)
		{
			int limit = (int)Math.Sqrt(i);
			int partiallSum = 0;

			for (int j = 2; j <= limit; j++)
			{
				if (i % j == 0)
				{
					partiallSum += j;

					// If divisor is sqrt of original number, do not add its pair divisor
					if (j * j == i)
						continue;

					partiallSum += i / j;
				}
			}

			return (i < partiallSum + 1);
		}

		static void Main(string[] args)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			// Mark all abundant numbers in our array
			for (int i = 1; i < upperLimit; i++)  
				abundantNumbersArray[i] = IsNumberAbundant(i);

			// Mark all numbers that cannot be created by sum of two abundant numbers
			for (int i = 1; i < upperLimit; i++)
				for (int j = i; j < upperLimit; j++)
				{
					if (abundantNumbersArray[i] && abundantNumbersArray[j])
					{
						if (i+j < upperLimit)
							abundantNumbersSumArray[i + j] = true;
					}
			}
			
			// Sum these numbers
			for (int i = 1; i < upperLimit; i++)
				if (!abundantNumbersSumArray[i])
					result += i;

			System.Console.WriteLine("Sum is " + result);
			
			stopwatch.Stop();
			System.Console.WriteLine("Calculation lasted for " + stopwatch.Elapsed);
			System.Console.ReadKey(true);
		}
	}
}






