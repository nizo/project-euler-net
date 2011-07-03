using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace ConsoleApplication1
{
	class Program
	{
		static int GetPandigitalValue(int i)
		{
			int n = 1;
			string concatenatedNumber = "";
			bool searching = true;

			while (searching)
			{
				concatenatedNumber += (i * n).ToString();
				if (concatenatedNumber.Length > 9)
					return -1;
				else if (concatenatedNumber.Length == 9)
					searching = false;
				n++;
			}

			for (int j = 1; j < 10; j++)
			{
				if (!concatenatedNumber.Contains(j.ToString()))
					return -1;
			}

			return int.Parse(concatenatedNumber);
		}

		static void Main(string[] args)
		{
			int maximum = -1;
			int result = -1;

			for (int i = 1; i < 10000; i++)
			{
				result = GetPandigitalValue(i);
				if (result > maximum)									
					maximum = result;				
			}

			System.Console.Out.WriteLine("Maximum such number is " + maximum);
			System.Console.ReadKey(true);
		}
	}
}
