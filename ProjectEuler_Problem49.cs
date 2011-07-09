using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace ConsoleApplication1
{
	class Program
	{
		static int limit = 10000;
		static List<int> primeNumbers = new List<int>();
		static List<int> currentPermutationList = new List<int>();
		static List<int> blackList = new List<int>();

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

		static bool AreNumbersPermutations(int i, int j)
		{			
			string originalNumber = i.ToString();
			string comparingNumber = j.ToString();

			j = i = 0;

			for (int k = 0; k < originalNumber.Length; k++)
			{
				if (!originalNumber.Contains(comparingNumber.Substring(k, 1)) || !comparingNumber.Contains(originalNumber.Substring(k, 1)))
					return false;

				i += int.Parse(originalNumber.Substring(k, 1));
				j += int.Parse(comparingNumber.Substring(k, 1));
			}

			return i == j;			
		}		

		static void Main(string[] args)
		{
			int difference = 0;		

			// Set our prime list
			for (int i = 1000; i < limit; i++)
				if (IsNumberPrime(i))
					primeNumbers.Add(i);


			for (int i = 0; i < primeNumbers.Count - 1; i++)
			{
				// Reset our permutation list
				currentPermutationList.Clear();
				currentPermutationList.Add(primeNumbers[i]);

				// For every prime get its permutations and push them into our list
				for (int j = i + 1; j < primeNumbers.Count; j++)
					if (!blackList.Contains(primeNumbers[j]) && AreNumbersPermutations(primeNumbers[i], primeNumbers[j]))
					{
						blackList.Add(primeNumbers[j]);
						currentPermutationList.Add(primeNumbers[j]);
					}
				
				// Compare differences within values in our list
				if (currentPermutationList.Count > 2)
					for (int a = 0; a < currentPermutationList.Count - 2; a++)
						for (int b = a + 1; b < currentPermutationList.Count - 1; b++)
						{
							difference = currentPermutationList[b] - currentPermutationList[a];
							
							for (int c = b + 1; c < currentPermutationList.Count; c++)
								if (difference == Math.Abs(currentPermutationList[c] - currentPermutationList[b]))
									System.Console.WriteLine(currentPermutationList[a] + " " + currentPermutationList[b] + " " + currentPermutationList[c]);
						}
					}				
		
			System.Console.ReadKey(true);
		}						
	}
}
