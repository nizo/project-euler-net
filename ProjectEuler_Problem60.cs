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
		public static Dictionary<long, long> primesDictionary = new Dictionary<long, long>();
		public static List<int> primesList = new List<int>();
		public static List<int> BestResult = new List<int>();
		public static List<int> CurrentBestResult = new List<int>();
		private static int currentBest = 99999999;
		private static int limit = 1500;

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

		static bool IsNumberPrime(long i)
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

		static bool CheckBestResult()
		{
			int current = 0;
			int best = 0;

			for (int i = 0; i < BestResult.Count; i++)
			{
				current += CurrentBestResult[i];
				best += BestResult[i];
			}

			if (current < best)
			{
				BestResult = CurrentBestResult;
				for (int i = 0; i < BestResult.Count; i++)
					System.Console.WriteLine("Current best prime member " + i + " is " + BestResult[i]);
					
				System.Console.WriteLine("Sum is " + current);

				currentBest = current;
				return true;
			}
			else return false;
		}

		static bool IsCollectionValid(int newPrime)
		{
			if (CurrentBestResult.Contains(newPrime))
				return false;

			if (CurrentBestResult.Count == 0)
				return true;

			for (int i = 0; i < CurrentBestResult.Count; i++)
				if ((!IsNumberPrime(long.Parse(CurrentBestResult[i].ToString() + newPrime.ToString())))
			   || (!IsNumberPrime(long.Parse(newPrime.ToString() + CurrentBestResult[i].ToString()))))
					return false;

			return true;
		}

		static void SearchForSet()
		{
			for (int i = 0; i < limit; i++)
				if (IsCollectionValid(primesList[i]))
				{
					CurrentBestResult.Add(primesList[i]);
					for (int j = i; j < limit; j++)
						if (IsCollectionValid(primesList[j]))
						{
							CurrentBestResult.Add(primesList[j]);
							for (int k = j; k < limit; k++)
								if (IsCollectionValid(primesList[k]))
								{
									CurrentBestResult.Add(primesList[k]);
									for (int a = k; a < limit; a++)
										if (IsCollectionValid(primesList[a]))
										{
											if (primesList[i] + primesList[j] + primesList[k] + primesList[a] > currentBest)
												return;

											CurrentBestResult.Add(primesList[a]);
											for (int b = a; b < limit; b++)
											{
												if (IsCollectionValid(primesList[b]))
												{
													CurrentBestResult.Add(primesList[b]);
													CheckBestResult();
													CurrentBestResult.RemoveAt(4);
												}
											}
											CurrentBestResult.RemoveAt(3);
										}
									CurrentBestResult.RemoveAt(2);
								}
							CurrentBestResult.RemoveAt(1);
						}
					CurrentBestResult.RemoveAt(0);
				}	
		}
		static void Main(string[] args)
		{
			StartingProcedures();

			for (int i = 2; i <= 100000; i++)
				if (IsNumberPrime(i))
				{
					primesList.Add(i);
					if (primesList.Count > limit)
						break;
				}

			for (int i = 0; i < 5; i++)
				BestResult.Add(999999);

			SearchForSet();	
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
