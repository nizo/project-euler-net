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
		static int Factorial(int i)
		{
			if (i == 0 || i == 1)
				return 1;
			
			return i * Factorial(i - 1);
		}

		static bool IsNumberSumOfFactorials(int i)
		{
			int innerResult = 0;
			string s = i.ToString();

			for (int j = 0; j < s.Length; j++)
			{
				innerResult += Factorial(int.Parse(s.Substring(j, 1)));
				if (innerResult > i)
					return false;
			}
			return (innerResult == i);
		}

		static void Main(string[] args)
		{
			// Sum of factorials of 9 cant go any higher
			int limit = 2540160;			
			int result = 0;

			for (int i = 3; i <= limit; i++)
				if (IsNumberSumOfFactorials(i))				
					result += i;									

			Console.WriteLine("Total sum is " + result);
			Console.ReadLine();
		}		
	}
}