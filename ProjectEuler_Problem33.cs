using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	class Program
	{
		static public float CancelNumbers(float i, float j)
		{
			string i_string = i.ToString();
			string j_string = j.ToString();

			if (i == j)
				return -1;
			if (i_string.Contains("0") || j_string.Contains("0"))
				return -1;

			if (i_string[0] == j_string[0])
			{
				i = int.Parse(i_string[1].ToString());
				j = int.Parse(j_string[1].ToString());
			}
			else
				if (i_string[1] == j_string[1])
				{
					i = int.Parse(i_string[0].ToString());
					j = int.Parse(j_string[0].ToString());
				}
				else if (i_string[0] == j_string[1])
				{
					i = int.Parse(i_string[1].ToString());
					j = int.Parse(j_string[0].ToString());
				}
				else if (i_string[1] == j_string[0])
				{
					i = int.Parse(i_string[0].ToString());
					j = int.Parse(j_string[1].ToString());
				}
				else
					return -1;

			return i / j;
		}


		static void Main(string[] args)
		{
			float result = 1;			

			for (int i = 10; i < 100; i++)
				for (int j = i + 1; j < 100; j++)
				{
					float correctNumber = (float)i / (float)j;
					if (correctNumber == CancelNumbers(i, j))
					{
						System.Console.Out.WriteLine(i + " " + j + " = " + correctNumber);
						result *= correctNumber;
					}
				}
			System.Console.Out.WriteLine(result);
			System.Console.ReadKey(true);
		}
	}
}
