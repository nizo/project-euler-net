using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	class Program
	{		
		static int limit = 1000000;
		static bool[] listOfPrimes = new bool[limit];

		static bool ComputeIsPrime(int i)
		{			
			if (i  == 2 || i == 3 || i == 5)
				return true;

			if ((i % 2) == 0 || (i % 3) == 0 || (i % 5) == 0)
				return false;

			int limit = (int)Math.Sqrt(i);

			for (int j = 3; j < limit; j += 2)
				if (i % j == 0)
					return false;

			return true;
		}

		static bool IsPrime(int i)
		{
			if (i > limit)
				return (ComputeIsPrime(i));
			else
				return listOfPrimes[i];
		}

		public static bool IsNumberSuperPrime(int i)
		{			
			int currentNumber = 1;
			string s = "";

			currentNumber = i;
			s = currentNumber.ToString();

			// Checks wheter remains of the truncated number are also primes
			while (s.Length >= 1)
			{
				if (IsPrime(currentNumber))
				{
					if (s.Length == 1)
					{
						s = "";
						continue;
					}
					currentNumber = int.Parse(s.Substring(0, s.Length - 1));
					s = currentNumber.ToString();
				}
				else					
					return false;					
			}
			if (currentNumber == 1) 
				return false;

			currentNumber = i;
			s = currentNumber.ToString();

			// The same from the opposite side
			while (s.Length >= 1)
			{
				if (IsPrime(currentNumber))
				{
					if (s.Length == 1)
					{
						s = "";
						continue;
					}
					currentNumber = int.Parse(s.Substring(1, s.Length - 1));
					s = currentNumber.ToString();
				}
				else
					return false;
			}
			if (currentNumber == 1)
				return false;

			return true;
		}

		static void Main(string[] args)
		{
			int result = 0;
			int numberOfPrimes = 0;
			string s = "";

			// Build our database for faster extraction
			for (int i = 3; i < limit; i+=2)
			{				
				s = i.ToString();
				if (s.Contains("2") || s.Contains("4") || s.Contains("6") || s.Contains("8") || s.Contains("0"))
					continue;			
				
				listOfPrimes[i] = (ComputeIsPrime(i));			
			}
			
			// These are the only nubmers with 2 in them we want to count so we need to set them separately
			listOfPrimes[2] = true;
			listOfPrimes[23] = true;

			// Test primes
			for (int i = 11; i < limit; i++)
			{
				if (listOfPrimes[i] && IsNumberSuperPrime(i))
				{					
					result += i;
					numberOfPrimes++;
					if (numberOfPrimes == 11)
						break;
				}
			}

			System.Console.Out.WriteLine("Sum of these numbers is " + result);
			System.Console.ReadKey(true);
		}
	}
}
