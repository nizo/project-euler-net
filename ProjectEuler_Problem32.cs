using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	class Program
	{
		static bool IsTermPandigital(int i, int j)
		{
			long product = i * j;
			string s = product.ToString() + i + j;

			if (s.Length < 9 || s.Contains(0.ToString())) return false;

			for (int k = 1; k <= s.Length; k++)
			{
				if (!s.Contains(k.ToString()))
					return false;
			}

			return true;
		}

		static void Main(string[] args)
		{			
			long result = 0;
			int limit = 3000;
			List<int> usedNumbers = new List<int>();
			
			for (int i = 0; i < limit; i++)
				for (int j = i; j < limit; j++)
					if (IsTermPandigital(i, j) && (!usedNumbers.Contains(i*j)))
					{
						usedNumbers.Add(i * j);
						result += i * j;						
					}					

			System.Console.WriteLine("Sum of these terms is " + result);
			System.Console.ReadKey(true);
		}
	}
}