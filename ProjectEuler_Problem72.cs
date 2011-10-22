using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler_01
{
	class Program
	{
		class Factor
		{
			public int baseNumber = 0;
			public int exponent = 1;

			public Factor(int i)
			{
				baseNumber = i;
			}			
		}
		
		public static int limit = 1000000;
		public static List<int> primes = new List<int>();
		public static bool[] countedNumbers = new bool[limit + 1];

		static List<Factor> GetFactors(int i)
		{
			List<Factor> result = new List<Factor>();

			int currentFactor = 2;
			bool doIt = true;

			while (doIt)
			{
				if (i == 1)
				{
					doIt = false;
					continue;
				}

				if (i % currentFactor == 0)
				{
					i /= currentFactor;

					bool incremented = false;

					for (int j = 0; j < result.Count; j++)
					{
						if (result[j].baseNumber == currentFactor)
						{
							result[j].exponent++;
							incremented = true;
						}
					}

					if (!incremented)					
						result.Add(new Factor(currentFactor));

					currentFactor = 2;
					continue;
				}

				currentFactor++;
			}

			return result;
		}


		static bool IsNumberPrime(int i)
		{
			if (i == 2 || i == 3 || i == 5 || i == 7)
				return true;
			
			if (i % 2 == 0 || i % 3 == 0 || i % 5 == 0 || i % 7 == 0)
				return false;

			int limit = (int)Math.Sqrt(i);

			for (int j = 9; j <= limit; j += 2)
				if (i % j == 0) return false;

			return true;
		}

		static void Main(string[] args)
		{
			long result = -1; // for 0/1 and 1/1 fractions
			long totientValue = 0;			
			
			for (int i = 2; i <= limit; i++)
			{
				countedNumbers[i] = false;

				if (IsNumberPrime(i))
				{
					countedNumbers[i] = true;
					primes.Add(i);
					result += i - 1;					
				}
			}
			
			for (int i = 0; i < primes.Count; i++)
				for (int j = i; j < primes.Count; j++)
				{
					long sum = (long)primes[i] * (long)primes[j];

					if (sum > limit)
						break;

					if (!(countedNumbers[sum]))
					{
						if (primes[i] == primes[j])
							result += ((primes[i] - 1) * primes[i]);
						else
							result += ((primes[i] - 1) * (primes[j] - 1));

						countedNumbers[sum] = true;						
					}
				}

			for (int i = 1; i <= limit; i++)
			{				
				if (countedNumbers[i])
					continue;

				List<Factor> currentFactors = GetFactors(i);

				totientValue = i;

				for (int j = 0; j < currentFactors.Count; j++)				
					totientValue = totientValue * (currentFactors[j].baseNumber - 1) / currentFactors[j].baseNumber;				

				result += totientValue;				
				countedNumbers[i] = true;				
			}			

			Console.WriteLine("There are " + result + " such fractions!");			
			Console.ReadLine();
		}
	}
}
