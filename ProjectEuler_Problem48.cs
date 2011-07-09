using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
	class Program
	{
		static long Pow(int i, int j)
		{
			long result = i;
			string s = "";

			for (int a = 0; a < j - 1; a++)
			{
				result *= i;
				s = result.ToString();
				if (s.Length > 10)
				{
					s = s.Substring(s.Length - 10, 10);
					result = long.Parse(s);
				}
			}

			return result;
		}

		static void Main(string[] args)
		{
			long result = 0;
			int to = 11;
			string s = "";

			for (int i = 1; i <= 1000; i++)
			{
				result += Pow(i, i);
				s = result.ToString();
				if (s.Length > 10)
					result = long.Parse(s.Substring(s.Length - 10, 10));
			}

			System.Console.WriteLine(result);
			System.Console.ReadKey(true);
		}						
	}
}
