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
		static int[] table = new int[10000];

		static int GetProperDivisorsSum(int i)
		{
			int limit = (int)Math.Sqrt(i);			
			int result = 1;

			for (int j = 2; j <= limit; j++)
			{
				if (i % j == 0)
				{
					result += j;
					result += i / j;
				}
			}			
			return result;
		}

		static void Main(string[] args)
		{
			int result = 0;
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			for (int i = 0; i < 10000; i++)
				table[i] = -1;

			for (int i = 0; i < 10000; i++)
			{
				for (int j = i; j < 10000; j++)
				{
					if (table[i] == -1)
						table[i] = GetProperDivisorsSum(i);
					if (table[j] == -1)
						table[j] = GetProperDivisorsSum(j);
						
					if (i != j && table[i] == j && table[j] == i)
					{
						result += table[i];
						result += table[j];
					}
				}
			}

			System.Console.WriteLine("Total sum is: " + result);
			stopwatch.Stop();			
			System.Console.WriteLine("Calculation took: " + stopwatch.Elapsed);			
			System.Console.ReadKey(true);
		}
	}
}





