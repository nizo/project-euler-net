using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler_01
{
	class Program
	{
		static int GetNthNumber(int n)
		{
			if (n == 1) return 2;
			if (n % 3 == 0)
				return (n - n / 3);
			return 1;
		}


		static void Main(string[] args)
		{			
			int counter = 100;
			BigInteger nominator = 1;
			BigInteger denominator = 1;
			BigInteger tmp = 0;
			BigInteger currentNumber = 0;

			denominator = GetNthNumber(counter);
			counter--;

			while (counter > 0)
			{
				currentNumber = GetNthNumber(counter);
				nominator += currentNumber * denominator;				
				
				tmp = nominator;
				nominator = denominator;
				denominator = tmp;
								
				counter--;
			}			

			string s = denominator.ToString(); // actually there is nominator in denominator because of switch in while cycle

			int result = 0;
			for (int i = 0; i < s.Length; i++)
				result += int.Parse(s.Substring(i, 1));

			Console.WriteLine("Sum of digits is " + result);			
			Console.ReadLine();
		}
	}
}
