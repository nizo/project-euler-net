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
		public static Stopwatch sw;

		public static BigInteger Power(int i, int j)
		{
			BigInteger result = i;

			for (int k = 1; k < j; k++)
				result = result * i;

			return result;
		}


		static string GetHashOfPermutation(BigInteger i)
		{
			List<int> numberDigits = new List<int>();
			string s = i.ToString();			

			for (int a = 0; a < s.Length; a++)
				numberDigits.Add(System.Convert.ToInt16(s.Substring(a, 1)));

			numberDigits.Sort();
			s = "";
			
			foreach (int j in numberDigits)
				s += j.ToString();


			// Hash is the number sorted from lowest to highest value
			return s;
		}


		static void Main(string[] args)
		{
			StartingProcedures();
			
			bool resultFound = false;
			int currentNumber = 1;		
			BigInteger currentResult = 1;
			BigInteger currentLimit = 100000;
			string currentHash = "";
			Dictionary<string, List<BigInteger>> setOfNumbers = new Dictionary<string, List<BigInteger>>();

			// Initialization, we start lookng from number 10000
			while (Power(currentNumber, 3) < currentLimit / 10)
				currentNumber++;

			currentResult = Power(currentNumber, 3);

			while (!resultFound)
			{
				while (currentResult < currentLimit)
				{
					List<BigInteger> myList = new List<BigInteger>();
					
					if (setOfNumbers.ContainsKey(currentHash))
					{
						// current number is permutation of another number already computed, increase number of permutations for this set of numbers!
						myList = setOfNumbers[currentHash];
						myList.Add(currentResult);
						setOfNumbers[currentHash] = myList;

						if (myList.Count == 5)
						{
							// SUCCESS
							foreach (BigInteger i in myList)
								System.Console.WriteLine(i);

							resultFound = true;
							break;
						}
					}
					else
					{
						// New permutation of numbers, create set for them
						myList.Add(currentResult);
						setOfNumbers.Add(currentHash, myList);
					}

					// Iterate
					currentNumber++;
					currentResult = Power(currentNumber, 3);
					currentHash = GetHashOfPermutation(currentResult);
				}

				// We have reached the limit without success, increase limit and clear our set of permutations
				currentLimit *= 10;
				setOfNumbers.Clear();
			}			

			ClosingProcedures();
		}

		#region HelpMethods

		static void StartingProcedures()
		{
			sw = new Stopwatch();
			sw.Start();
		}

		static void ClosingProcedures()
		{
			sw.Stop();
			Console.WriteLine(sw.Elapsed);
			Console.ReadLine();
		}

		#endregion

	}
}
