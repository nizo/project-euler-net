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
		static string result = "";
		static int[] numberArray = new int[10];		
		
		static int Factorial(int i)
		{
			if (i <= 1)
				return 1;
			else
				return i * (Factorial(i - 1));
		}

		static void FindPermutationAtElement(int[] numbers, int p)
		{
			int index = 0;
			int minimumPermutationCount = 0;
			int localDigit = -1;

			while (index < numbers.Length)
			{
				int currentPermutationCount = Factorial(numbers.Length - 1 - index);
				while (minimumPermutationCount <= p)
				{					
					minimumPermutationCount += currentPermutationCount;
					localDigit++;

					while (result.Contains((localDigit).ToString()))
						localDigit++;					
				}

				minimumPermutationCount -= currentPermutationCount;

				result += localDigit;
				localDigit = -1;
				index++;
			}
		}		

		static void Main(string[] args)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			FindPermutationAtElement(numbers, 999999);
			Console.WriteLine(result);			

			sw.Stop();
			Console.WriteLine(sw.Elapsed);
			Console.ReadLine();

		}		
	}
}






