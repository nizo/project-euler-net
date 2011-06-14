using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numeric;

namespace ProjectEuler_01
{
	class Program
	{
		static BigInteger Factorial(BigInteger input)
		{
			if (input == 1)
				return 1;
			else 
				return input * Factorial(input-1);
		}

		static void Main(string[] args)
		{
			// We used BigInteger class from http://www.codeproject.com/KB/cs/biginteger.aspx
			BigInteger bigNumber = Factorial(100);
			string s = bigNumber.ToString();
			int result = 0;

			for (int i = 0; i < s.Length; i++)
				result += int.Parse(s.Substring(i, 1));

			Console.Out.WriteLine(result);
			Console.ReadKey(true);
		}
	}
}

