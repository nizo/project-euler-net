using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
	class Program
	{
		static int limit = 500000;
		static bool[] primesList = new bool[limit];
		static int[] primesValues = new int[limit];

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

		static bool IsPrime(int i)
		{
			if (i < primesList.Count())
				return (primesList[i]);
			else
				return IsNumberPrime(i);
		}

		static void Main(string[] args)
		{
			int desiredCountOfFactors = 4;

			int originalNumber = 1000;
			int currentNumber = 0;
			int numbersChecked = 0;
			int primeIndex = 0;

			List<int> TotalFactorsOfSeries = new List<int>();
			List<int> FactorsOfCurrentNumber = new List<int>();
			List<int> SquaredFactors = new List<int>();
			
			for (int i = 2; i < limit; i++)
				if (IsNumberPrime(i))
				{
					primesList[i] = true;
					primesValues[primeIndex] = i;
					primeIndex++;
				}

			currentNumber = originalNumber;
			primeIndex = 0;

			while (originalNumber < limit)
			{
				if (numbersChecked == desiredCountOfFactors)
				{
					System.Console.WriteLine("Sequence from " + originalNumber + " to " + currentNumber);					
					break;				
				}

				primeIndex = 0;
				FactorsOfCurrentNumber.Clear();
				SquaredFactors.Clear();

				// Move all factors of current nubmer to actualFactorsOfNubmer list
				while (currentNumber != 1)
				{
					if ((float)currentNumber / primesValues[primeIndex] % 1 == 0)
					{
						currentNumber /= primesValues[primeIndex];
						FactorsOfCurrentNumber.Add(primesValues[primeIndex]);
						primeIndex = 0;
					}
					else primeIndex++;
				}

				// Merge same values in our list
				int countOfNumbers = 0;
				int localLimit = (originalNumber + desiredCountOfFactors) / 2;

				for (int j = 0; j <= localLimit; j++)
				{
					for (int i = 0; i < FactorsOfCurrentNumber.Count; i++)
					{
						if (FactorsOfCurrentNumber[i] == primesValues[j])
							countOfNumbers++;
					}
					if (countOfNumbers != 0)
					{
						SquaredFactors.Add((int)Math.Pow(primesValues[j], countOfNumbers));
						countOfNumbers = 0;
					}
				}

				// Check whether count of factors is suitable
				if (SquaredFactors.Count != desiredCountOfFactors)
				{
					originalNumber++;
					currentNumber = originalNumber;
					numbersChecked = 0;

					TotalFactorsOfSeries.Clear();					
					continue;
				}

				// Merge with our full list
				foreach (int i in SquaredFactors)
					if (!TotalFactorsOfSeries.Contains(i))
						TotalFactorsOfSeries.Add(i);
					else
					{
						TotalFactorsOfSeries.Clear();						
						originalNumber++;
						currentNumber = originalNumber;
						numbersChecked = 0;
						continue;
					}
					
				currentNumber = originalNumber + numbersChecked + 1;
				numbersChecked++;												
				}
			
			System.Console.ReadKey(true);
		}						
	}
}
