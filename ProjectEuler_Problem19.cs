using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



namespace ProjectEuler_01
{
	class Program
	{
		static int day = 1;
		static int date = 1;
		static int month = 1;
		static int year = 1900;
		static int counter = 0;

		static void Main(string[] args)
		{			
			bool go = true;
			while (go)
			{
				Update();
				if (year == 2000 && (date >= 31) && (month == 12))
					go = false;
			}

			System.Console.WriteLine("Number of sundays is " + counter);
			System.Console.ReadKey(true);
		}

		static void Update()
		{
			IncrementDay();
			IncrementDate();

			if (IsSunday() && date == 1 && (year >= 1901 && (date >= 1) && (month >= 1)))
				counter++;
		}

		static bool IsSunday()
		{
			return day == 7;
		}

		static bool IsLeapYear()
		{
			return (year % 4 == 0);
		}

		static void IncrementYear()
		{
			year++;
		}

		static void IncrementDate()
		{
			date++;
			bool newMonth = false;

			if (month == 4 || month == 6 || month == 11 || month == 9)
			{
				if (date == 31)
				{
					date = 1;
					newMonth = true;
				}
			}
			else if (month == 2)
			{
				if (IsLeapYear() && date == 30)
				{
					date = 1;
					newMonth = true;
				}
				else if (date == 29)
				{
					date = 1;
					newMonth = true;
				}
			}
			else
			{
				if (date == 32)
				{
					date = 1;
					newMonth = true;
				}
			}

			if (newMonth)
				incrementMonth();
		}

		static void incrementMonth()
		{
			month++;
			if (month == 13)
			{
				month = 1;
				IncrementYear();
			}
		}

		static void IncrementDay()
		{
			day++;
			if (day == 8)
				day = 1;
		}
	}
}




