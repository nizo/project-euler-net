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


		static int GetSumOfDigits(string s)
		{
			int result = 0;

			for (int i = 0; i < s.Length; i++)
				result += int.Parse(s.Substring(i, 1));

			return result;
		}

		static BigInteger Power(int i, int j)
		{
			BigInteger result = i;

			for (int t = 0; t < j-1; t++)
				result *= i;

			return result;
		}

		static void Main(string[] args)
		{
			StartingProcedures();
			int maximum = 0;
			int interResult = 0;

			
			for (int i = 1; i < 100; i++)
				for (int j = 1; j < 100; j++)
				{
					interResult = GetSumOfDigits(Power(i, j).ToString());
					if (interResult > maximum)
						maximum = interResult;		
				}	

			System.Console.WriteLine("Maximum sum is " + maximum.ToString());
			
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
