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

		public static int start = 2;
		public static long limit = 10000;
		public static bool[] primesGrid = new bool[limit];
		public static List<int> primesSet = new List<int>();

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

		/*
			static void SetTotientNumbers()
			{
				for (long i = start; i < limit; i++)
					for (long j = i; j < limit; j++)
					{
						if (primesGrid[i] && primesGrid[j])
						{
							totientNumbers[i] = i-1;
							totientNumbers[j] = j-1;
							if (i * j < limit)
							{
								if (i == j)
									totientNumbers[i * j] = (i - 1) * i;
								else
									totientNumbers[i * j] = (i - 1) * (j - 1);
							}						
						}
					}


				for (long i = start; i < limit; i++)
				{
					if (primesGrid[i])
					{
						totientNumbers[i] = i - 1;
						for (long j = start; j < i; j++)
						{
							if (i * j > limit) break;
							if (totientNumbers[j] != -1)
								totientNumbers[i * j] = totientNumbers[i] * totientNumbers[j];				
						}
					}
				}
				for (long i = start; i < limit; i++)
				{
					if (totientNumbers[i] == -1)
					{
						int currentValue = 1;
						List<Factor> currentFactors = GetFactors(i);
					}
				}
			}

			static List<int> GetFactors(long i)
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
				return new List<int>();
			}
		 *  */

		static void Main(string[] args)
		{
			StartingProcedures();			

			// Initialize
			for (int i = start; i < limit; i++)			
				if (IsNumberPrime(i))
				{
					primesGrid[i] = true;
					primesSet.Add(i);					
				}			

			int currentNumber = 1;
			int index = 0;
			int indexCount = 0;

			while (currentNumber * primesSet[index] < 1000000)
			{
				currentNumber *= primesSet[index];
				index++;
			}			

			System.Console.WriteLine("Value is " + currentNumber);


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
