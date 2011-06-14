using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ProjectEuler_01
{
    class Program
	{	
		static void Main(string[] args)
		{
			int[] number = new int[1000];
			int remainder = 0;
			int localResult = 0;
			int result = 0;


			//initialize array of 1000 cells, each represents one digit
			for (int i = 0; i < 1000; i++)			
				number[i] = -1;

			// set the value of our "number" to one
			number[0] = 1;

			// Compute
			for (int j = 0; j < 1000; j++) // Power to number of 2 one thousand times!!!
			{
				for (int i = 0; i < 1000; i++) // And double every digit in our array
				{
					if (number[i] == -1)
					{
						if (remainder != 0) // No need to go further, we have reached end of our number
						{
							number[i] = remainder;
							remainder = 0;
						}
						break;
					}

					localResult = number[i] * 2 + remainder;

					if (localResult > 9)
					{
						remainder = int.Parse(localResult.ToString().Substring(0, 1));
						number[i] = int.Parse(localResult.ToString().Substring(1, 1));
					}
					else
					{
						remainder = 0;
						number[i] = int.Parse(localResult.ToString().Substring(0, 1));
					}

				}
				
			}

			// Sum every digit
			for (int i = 0; i < 1000; i++)
				if (number[i] == -1)
					break;
				result += number[i];


			System.Console.WriteLine(result);			
			System.Console.ReadKey(true);			
		}		
    }
}



