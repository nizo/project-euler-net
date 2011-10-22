using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler_01
{
	class Program
	{
		static void GetMinimalizedValues(List<int> list, out BigInteger nominator, out BigInteger denominator)
		{
			nominator = 1;

			if ((list.Count + 1) % 2 == 0)
			{
				int limit = list.Count;
				list.Add(list[0] * 2);

				for (int i = 1; i < limit; i++)
					list.Add(list[i]);
			}

			denominator = list[list.Count - 1];

			for (int i = list.Count - 2; i >= 0; i--)
			{
				nominator = nominator + list[i] * denominator;

				if (i != 0)
				{
					BigInteger tmp = denominator;
					denominator = nominator;
					nominator = tmp;
				}
			}
		}

		static void OptimizeValues(long inputNominator, long inputDenominator, out long nominator, out long denominator)
		{
			long index = 2;
			nominator = inputNominator;
			denominator = inputDenominator;

			while (index <= Math.Max(nominator, denominator))
			{
				if (denominator % index == 0 && nominator % index == 0)
				{
					denominator /= index;
					nominator /= index;

					index = 2;
				}
				else index++;
			}
		}

		static List<int> GetFractionValues(int d)
		{
			float nominator = 0f;
			float denominator = 0f;
			float root = (float)Math.Sqrt(d);
			int floor = 0;
			int tmp = 0;

			List<int> result = new List<int>();

			floor = (int)Math.Floor(Math.Sqrt(d));
			result.Add(floor);

			nominator = floor; // In numerator we have stored only integer value. There is always sqrt(d) in addition
			denominator = d - floor * floor;

			while (denominator != 1)
			{
				// Add current continuous fraction value
				floor = (int)Math.Floor((root + nominator) / denominator);
				result.Add(floor);

				// Subtract fraction value from nominator
				nominator -= floor * denominator;

				// Switch values
				tmp = (int)nominator;
				nominator = denominator;
				denominator = tmp;

				//nominator = floor;
				denominator = d - (Math.Abs(denominator) * Math.Abs(denominator));

				long tmpNomin;
				long tmpDenomin;

				OptimizeValues((long)nominator, (long)denominator, out tmpNomin, out tmpDenomin);

				denominator = tmpDenomin;
				nominator = Math.Abs(tmp);
			}

			return result;
		}

		static void Main(string[] args)
		{
			int maximumD = 0;
			BigInteger maximumXValue = 0;
			BigInteger currentXValue = 0;
			BigInteger currentYValue = 0;
			List<int> fractionValues = new List<int>();

			for (int currrentD = 3; currrentD <= 1000; currrentD++)
			{
				if (Math.Sqrt(currrentD) % 1 == 0)
					continue;

				fractionValues = GetFractionValues(currrentD);
				GetMinimalizedValues(fractionValues, out currentXValue, out currentYValue);

				if (currentXValue > maximumXValue)
				{
					Console.WriteLine("Value updated with D == " + currrentD + " and value " + currentXValue);
					maximumXValue = currentXValue;
					maximumD = currrentD;
				}
			}

			Console.WriteLine("Maximum value of D is " + maximumD);
			Console.ReadLine();
		}
	}
}
