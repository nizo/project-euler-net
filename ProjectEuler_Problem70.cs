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
		public static long limit = 10000000;
		public static bool[] primesGrid = new bool[limit];
		public static long[] semiprimesTotientNumbers = new long[limit];				

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
	
		static void SetSemiprimesTotientValues()
		{
			for (long i = start; i < limit; i++)
				for (long j = i; j < limit; j++)
				{
					if (i * j > limit) break;

					if (primesGrid[i] && primesGrid[j])
					{						
						if (i == j)						
							semiprimesTotientNumbers[i * j] = i  * (j - 1);						
						else					
							semiprimesTotientNumbers[i * j] = (i - 1) * (j - 1);						
					}
				}
		}

		static bool AreNumbersPermutation(string i, string j)
		{
			if (i.Length != j.Length)
				return false;

			int sum1 = 0;
			int sum2 = 0;

			for (int current = 0; current < i.Length; current++)
			{
				if (i.Contains(j.Substring(current, 1)))
					sum1 += (int)Math.Pow(int.Parse(i.Substring(current, 1)), 2);
				else
					return false;

				if (j.Contains(i.Substring(current, 1)))
					sum2 += (int)Math.Pow(int.Parse(j.Substring(current, 1)), 2);
				else
					return false;				
			}			

			return sum1 == sum2;
		}

		static void Main(string[] args)
		{
			StartingProcedures();

			int result = 0;
			float localMinimum = int.MaxValue;

			// Initialize
			for (int i = start; i < limit; i++)
			{
				if (IsNumberPrime(i))
					primesGrid[i] = true;

				semiprimesTotientNumbers[i] = -1;
			}

			// Set totient values, just for semiprimes, these will have lowest ratio
			SetSemiprimesTotientValues();

			// Find permutations of number and its totient value, check whether the ratio is minimal
			for (int i = 2; i < limit; i++)
			{
				if (semiprimesTotientNumbers[i] != -1 && AreNumbersPermutation(i.ToString(), semiprimesTotientNumbers[i].ToString()))
				{
					float currentRatio = (float)i / (float)semiprimesTotientNumbers[i];
					if (currentRatio < localMinimum)
					{
						System.Console.WriteLine(i + " with " + semiprimesTotientNumbers[i] + " has ratio of " + currentRatio);
						localMinimum = currentRatio;
						result = i;
					}
				}
			}
			
			// Win

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
