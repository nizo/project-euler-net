using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using Oyster.Math;

namespace ProjectEuler_01
{
	class Program
	{
		static bool[] primesList = new bool[10000];

		static bool IsNumberPrime(int i)
		{
			if (i < 1)
				return false;

			int limit = (int)Math.Sqrt(i);

			if (i == 2 || i == 3 || i == 5)
				return true;

			if (i % 2 == 0 || i % 3 == 0 || i % 5 == 0)
				return false;

			for (int j = 3; j <= limit; j += 2)
			{
				if (i % j == 0)
					return false;
			}
			return true;
		}

		static int GetNumberOfConsecutivePrimes(int a, int b)
		{
			int counter = 0;
			int innerResult = 0;

			for (int i = 0; i < 10000; i++)
			{
				// Equation from even numbers cant be a prime
				if (i % 2 == 0 && a % 2 == 0 || b % 2 == 0)
					break;

				innerResult = (i * i + a * i + b);

				// If result is in range of our PrimeList check this first

				if (innerResult >= 0 && innerResult < primesList.Length)
				{
					if (primesList[innerResult])
						counter++;
					else
						break;
				}
				// Otherwise compute whether result is prime
				else if (IsNumberPrime(innerResult))
					counter++;
				else
					break;
			}
			return counter;
		}

		static void Main(string[] args)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();

			int innerResult = 0;
			int longestStroll = 0;
			int result = 0;

			// Initialize our PrimeList
			for (int i = 0; i < primesList.Length; i++)
			{
				if (IsNumberPrime(i))
					primesList[i] = true;
				else
					primesList[i] = false;
			}
			
			for (int a = -999; a < 1000; a++)
			{			
				for (int b = -999; b < 1000; b++)
				{
					// Parameter b must be a prime, otherwise quit
					if (b > 0 && !primesList[b])
						continue;

					// Get prime streak for this number
					innerResult = GetNumberOfConsecutivePrimes(a, b);

					// Set new maximum value
					if (innerResult > longestStroll)
					{
						longestStroll = innerResult;
						result = a * b;
					}
				}
			}

			Console.WriteLine("Product of best parameters is " + result);

			sw.Stop();
			Console.WriteLine(sw.Elapsed);
			Console.ReadLine();

		}		
	}
}