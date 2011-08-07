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

		static void Main(string[] args)
		{
			StartingProcedures();
			int diagonalNumbersCount = 1;
			int primesCount = 0;
			int currentAdd = 2;
			int currentNumber = 1;

			while (((float)primesCount / (float)diagonalNumbersCount > 0.1f) || currentAdd < 10)
			{
				currentNumber += currentAdd;
				if (IsNumberPrime(currentNumber))
					primesCount++;
				currentNumber += currentAdd;
				if (IsNumberPrime(currentNumber))
					primesCount++;
				currentNumber += currentAdd;
				if (IsNumberPrime(currentNumber))
					primesCount++;
				currentNumber += currentAdd;
				if (IsNumberPrime(currentNumber))
					primesCount++;

				currentAdd += 2;
				diagonalNumbersCount += 4;
			}

			System.Console.WriteLine("Length of such square spiral is " + (currentAdd - 1));
			
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
