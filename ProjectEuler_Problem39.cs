using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApplication1
{
	class Program
	{
		static int GetNumberOfTriplets(int p)
		{
			List<int> list = new List<int>();

			int a = 0;
			int b = 0;
			int c = 0;

			int limit = (int)Math.Sqrt(p);

			for (int m = 1; m <= limit; m++)				
				for (int n = 1; n < m; n++)
					for (int k = 1; k < limit; k++)
					{
						a = k * (int)(Math.Pow(m, 2) - Math.Pow(n, 2));
						b = k * 2 * m * n;
						c = k * (int)(Math.Pow(m, 2) + Math.Pow(n, 2));

						if ((a + b + c == p) && (!list.Contains(a + b)))						
							list.Add(a + b);						
					}				

			return list.Count;
		}

		static void Main(string[] args)
		{
			int result = 0;
			int maximizedI = 0;
			
			for (int i = 1; i <= 1000; i++)
			{
				int numberOfTriplets = GetNumberOfTriplets(i);
				if (numberOfTriplets > result)
				{
					result = numberOfTriplets;
					maximizedI = i;
				}
			}
		
			System.Console.Out.WriteLine("Maximized value is " + maximizedI);
			System.Console.ReadKey(true);
		}
	}
}
