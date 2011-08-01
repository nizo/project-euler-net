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
		public static Stopwatch sw;
		public static List<BigInteger> resultsList = null;

		static BigInteger Factorial(BigInteger i, int limit)
		{
			if (i == 1 || i == limit)
				return 1;
			else
				return i * Factorial(i - 1, limit);
		}

		static BigInteger GetCombinationCount(int i, int j)
		{
			BigInteger result = Factorial(i, i - j);			
			result /= Factorial(j, 1);

			return result;
		}

		static void Main(string[] args)
		{
			StartingProcedures();
			int result = 0;

			for (int i = 1; i <= 100; i++)
			{
				for (int j = 1; j <= 100; j++)
				{
					BigInteger count = GetCombinationCount(i, j);
					if (count > 1000000)
						result++;										
				}
			}
			
			System.Console.WriteLine("There are " + result.ToString() + " such numbers!");
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
