using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApplication1
{
	class Program
	{
		static long GetDigit(long n)
		{
			int currentNumber = 1;
			int currentDigit = 1;
			int shifter = 1;
			int addConstant = System.Convert.ToInt16(shifter.ToString().Length);
			int index = 1;
			int decrement = 0;

			// Trivial case
			if (n < 10)
				return n;

			// We have two variables which we increment in each cycle
			// We do not iterate through all numbers, but only through tens, hundres, thousand, ten thousands...
			// Each time index == 9 we increase this level
			while (currentDigit < n)
			{
				if (index == 9)
				{					
					addConstant++;
					shifter *= 10;
					index = 0;				
				}
				else
				{
					currentDigit += addConstant * shifter;
					currentNumber += shifter;
					index++;
				}
			}

			// After we are either behind our number or exactly on it
			while (currentDigit != n)
			{
				// We are behind the number, substract current number and decrease it from currentDigit till the result:)
				decrement = System.Convert.ToInt16(currentNumber.ToString().Length);
				if (currentDigit - decrement >= n)
				{
					currentDigit -= decrement;
					currentNumber--;
				}
				else
				{
					string s = currentNumber.ToString();
					return int.Parse(s.Substring(s.Length - currentDigit + (int)n - 1, 1));
				}
			}

			// We hit the number, return last digit of currentNumber
			string possibleResult = currentNumber.ToString();
			return int.Parse(possibleResult.Substring(possibleResult.Length - 1, 1));			
		}

		static void Main(string[] args)
		{
			long result = 1;
			result = GetDigit(1) * GetDigit(10) * GetDigit(100) * GetDigit(1000) * GetDigit(10000) * GetDigit(100000) * GetDigit(1000000);
						
			System.Console.Out.WriteLine("Correct sequence is " + result);			
			System.Console.ReadKey(true);
		}
	}
}
