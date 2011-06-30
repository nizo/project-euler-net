using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{	
			int absoluteSum = 200;
			int counter = 0;

			for (int i = 0; i <= 200; i++)
				for (int j = 0; j <= 100; j++)
					for (int l = 0; l <= 40; l++)
						for (int k = 0; k <= 20; k++)
							for (int b = 0; b <= 10; b++)
								for (int m = 0; m <= 4; m++)
									for (int n = 0; n <= 2; n++)
										for (int a = 0; a <= 1; a++)							
											if (i * 1 + j * 2 + l * 5 + k * 10 + b * 20 + m * 50 + n * 100 + a * 200 == absoluteSum)
												counter++;										

			System.Console.WriteLine(counter);
			System.Console.ReadKey(true);
		}
	}
}