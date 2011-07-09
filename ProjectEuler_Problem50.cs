using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ConsoleApplication1
{
	class Program
	{		
		static List<int> primeNumbers = new List<int>();

		static bool IsNumberPrime(int i)
		{
			if (i == 2 || i == 3 || i == 5)
				return true;
			if (i % 2 == 0 || i % 3 == 0 || i % 5 == 0)
				return false;

			int limit = (int)Math.Sqrt(i);

			for (int j = 7; j <= limit; j += 2)
				if (i % j == 0)
					return false;

			return true;
		}

		static void Main(string[] args)
		{
			int limit = 1000;
			int localResult = 0;
			int result = 0;
			int maximum = 0;
			int startingPrimeIndex = 0;
			int primeIndex = 0;
			int currentIndex = 0;
			int currentNumber = 0;

			Stopwatch timer = new Stopwatch();
			timer.Start();

			// Set our prime list
			primeNumbers.Add(2);
			for (int i = 3; i < limit; i+=2)
				if (IsNumberPrime(i))
					primeNumbers.Add(i);
			

			while (currentIndex < limit)
			{
				if (currentIndex < primeNumbers.Count)
				{
					currentNumber = primeNumbers[currentIndex];
					while (primeNumbers[primeIndex] < currentNumber)
					{
						if (localResult == currentNumber && maximum < primeIndex - startingPrimeIndex)
						{							
							maximum = primeIndex - startingPrimeIndex;
							result = localResult;

							startingPrimeIndex++;
							primeIndex = startingPrimeIndex;
							localResult = 0;
						}
						else if (localResult > currentNumber)
						{
							startingPrimeIndex++;
							primeIndex = startingPrimeIndex;
							localResult = 0;
						}
						else
						{
							localResult += primeNumbers[primeIndex];
							primeIndex++;
						}
					}
				}

				startingPrimeIndex = primeIndex = 0;				
				localResult = 0;
				currentIndex++;
			}			
			
			System.Console.WriteLine("Within " + limit + " the prime " + result + " is sum of " + maximum + " primes");

			timer.Stop();
			System.Console.WriteLine(timer.Elapsed);
			System.Console.ReadKey(true);
		}						
	}
}
