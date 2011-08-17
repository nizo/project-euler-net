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


		public static BigInteger Power(BigInteger i, BigInteger j)
		{
			BigInteger result = i;

			for (BigInteger k = 1; k < j; k++)
				result = result * i;

			return result;
		}

		static void Main(string[] args)
		{
			StartingProcedures();
			long countOfNumbers = 0;
			int currentNumber = 1;
			int currentPower = 1;
			BigInteger currentResult = 1;

			while (currentPower < 80)
			{				
				while (currentNumber < 10)
				{
					int length = 0;
					currentResult = Power(currentNumber, currentPower);
					length = currentResult.ToString().Length;

					if (length == currentPower)					
						countOfNumbers++;

					currentNumber++;
				}
				
				currentPower++;
				currentNumber = 1;
			}			

			System.Console.WriteLine("There are " + countOfNumbers + " such numbers!");


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
