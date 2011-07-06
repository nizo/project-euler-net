using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace ConsoleApplication1
{
	class Program
	{
		static long result = 0;		
		static List<int> listOfPrimes  = new List<int>();

		static bool IsNumberPrime(int i)
		{
			if (i == 2 || i == 3 || i == 5)
				return true;
			if (i % 2 == 0 || i % 3 == 0 || i % 5 == 0)
				return false;

			int limit = (int)Math.Sqrt(i);

			for (int j = 7; j < limit; j += 2)
				if (i % j == 0)
					return false;

			return true;
		}

		static bool IsDivisibleByPrime(int primeIndex, long input)
		{
			return (input % listOfPrimes[primeIndex] == 0);
		}

		static void SumAllPandigitalPrimeFractionNumbers(string number)
		{
			if ((number.Length > 0) && number.Substring(0,1) == "0")
				return;

			if (number.Length == 4 && !IsDivisibleByPrime(0, int.Parse(number.ToString().Substring(1, 3))))
				return;
			if (number.Length == 5 && !IsDivisibleByPrime(1, int.Parse(number.ToString().Substring(2, 3))))
				return;
			if (number.Length == 6 && !IsDivisibleByPrime(2, int.Parse(number.ToString().Substring(3, 3))))
				return;
			if (number.Length == 7 && !IsDivisibleByPrime(3, int.Parse(number.ToString().Substring(4, 3))))
				return;
			if (number.Length == 8 && !IsDivisibleByPrime(4, int.Parse(number.ToString().Substring(5, 3))))
				return;
			if (number.Length == 9 && !IsDivisibleByPrime(5, int.Parse(number.ToString().Substring(6, 3))))
				return;
			if (number.Length == 10 && (IsDivisibleByPrime(6, int.Parse(number.ToString().Substring(7, 3)))))
			{
				System.Console.Out.WriteLine(long.Parse(number));
				result += long.Parse(number);
				return;
			}

			// Call all permutation of 1234567890
			for (int i = 0; i <= 9; i++)
				if (!number.Contains(i.ToString()))
					SumAllPandigitalPrimeFractionNumbers(number + i.ToString());
		}

		static void Main(string[] args)
		{
			for (int i = 2; i < 100; i++)			
				if (IsNumberPrime(i))
					listOfPrimes.Add(i);

			SumAllPandigitalPrimeFractionNumbers("");

			System.Console.Out.WriteLine("Sum of these numbers is " + result);
			System.Console.ReadKey(true);
		}
	}
}
