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
			long result = 0;

			int hundred = 7;
			int and = 3;

			int one = 3;
			int two = 3;
			int three = 5;
			int four = 4;
			int five = 4;
			int six = 3;
			int seven = 5;
			int eight = 5;
			int nine = 4;
			
			int ten = 3;
			int eleven = 6;
			int twelve = 6;
			int thirteen = 8;
			int fourteen = 8;
			int fifteen = 7;
			int sixteen = 7;
			int seventeen = 9;
			int eighteen = 8;
			int nineteen = 8;

			int rest = 46;
		
			result += 11; //one thousand
			
			result += (100+9*10) * (one + two + three+ four + five + six + seven + eight + nine);

			result += 10 * (ten + eleven + twelve + thirteen + fourteen + fifteen + + sixteen + seventeen + eighteen + nineteen);
			result += 10 * rest + 10 * 9 * rest;

			result += 900 * hundred;
			result += 9 * 99 * and;


			System.Console.WriteLine(result);
			System.Console.ReadKey(true);			
		}		
    }
}


