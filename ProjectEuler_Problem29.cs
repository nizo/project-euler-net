using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	class Program
	{			
		public static BigInteger Power(BigInteger i, BigInteger j)
		{
			BigInteger result = i;
			
			for (BigInteger k = 1; k < j; k++)
				result = result * i;			

			return result;
		}

		static void Main(string[] args)
		{			
			List<BigInteger> bigNumbers = new List<BigInteger>();

			BigInteger bigNumber = 1;
			for (int i = 2; i <= 100; i++)
				for (int j = 2; j <= 100; j++)
				{
					bigNumber = Power(i, j);
					if (!bigNumbers.Contains(bigNumber))					
						bigNumbers.Add(bigNumber);					
				}

			
			System.Console.Out.WriteLine(bigNumbers.Count);
			System.Console.ReadKey(true);
		}
	}
}
