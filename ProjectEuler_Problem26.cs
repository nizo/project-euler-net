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

		static int[] numberArray = new int[10];

		static int Factorial(int i)
		{
			if (i <= 1)
				return 1;
			else
				return i * (Factorial(i - 1));
		}

		static bool IsNumberPrime(int i)
		{
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

		static bool IsNumberPrimitiveRoot(long prime)
		{
			List<long> factors = GetFactors(prime - 1);

			for (int i = 1; i < factors.Count; i++)
			{
				long localResult = (long)Math.Pow(10, (prime - 1) / factors[i]);
				if (localResult % prime == 0)
					return true;
			}
			return true;
		}

		static List<long> GetFactors(long i)
		{
			List<long> result = new List<long>();
			int currentFactor = 2;
			bool doIt = true;

			while (doIt)
			{
				if (i == 1)
				{
					doIt = false;
					continue;
				};

				if (i % currentFactor == 0)
				{
					i /= currentFactor;
					result.Add(currentFactor);
					currentFactor = 2;
					continue;
				}

				currentFactor++;
			}

			return result;
		}

		static void LongestRecurringCycle(int i)
		{
			for (int j = 3; j < i; j += 2)
				if (IsNumberPrime(j) && IsNumberPrimitiveRoot(j))
					System.Console.WriteLine("Prime with root factor 10 is " + j);
		}

		static void Main(string[] args)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();

			LongestRecurringCycle(1000);

			//Console.WriteLine(IsNumberPrimitiveRoot(29));

			sw.Stop();
			Console.WriteLine(sw.Elapsed);
			Console.ReadLine();

		}
	}
}