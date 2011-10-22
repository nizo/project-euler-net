using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler_01
{
	class Program
	{		
		static List<List<int>> controllerList = new List<List<int>>();
		static List<bool> numberTypeIncluded = new List<bool>();
		static bool keepLooking = true;
		

		#region Generators

		static int GetTriangleNumber(int i)
		{
			return i * (i + 1) / 2;			
		}

		static int GetSquareNumber(int i)
		{
			return i * i;
		}

		static int GetPentagonalNumber(int i)
		{
			return i * (3 * i - 1) / 2;
		}

		static int GetHexagonalNumber(int i)
		{
			return i * (2 * i - 1);
		}
		static int GetHeptagonalNumber(int i)
		{
			return i * (5 * i - 3) / 2;
		}

		static int GetOctagonalNumber(int i)
		{
			return i * ( 3 * i - 2);
		}

		#endregion

		static bool CheckLength(int i)
		{
			return i < 10000;
		}

		static void FillLists()
		{
			int index = 1;
			int currentNumber = 0;

			for (int i = 0; i < 6; i++)
				controllerList.Add(new List<int>());

			while (true)
			{
				if (!numberTypeIncluded[0])
				{
					currentNumber = GetTriangleNumber(index);
					if (currentNumber > 999)
					{
						if (CheckLength(currentNumber))
							controllerList[0].Add(currentNumber);
						else
							break;
					}
				}

				if (!numberTypeIncluded[1])
				{
					currentNumber = GetSquareNumber(index);
					if (currentNumber > 999)
					{
						if (CheckLength(currentNumber))
							controllerList[1].Add(currentNumber);
						else
							numberTypeIncluded[1] = true;
					}
				}

				if (!numberTypeIncluded[2])
				{
					currentNumber = GetPentagonalNumber(index);
					if (currentNumber > 999)
					{
						if (CheckLength(currentNumber))
							controllerList[2].Add(currentNumber);
						else
							numberTypeIncluded[2] = true;
					}
				}

				if (!numberTypeIncluded[3])
				{
					currentNumber = GetHexagonalNumber(index);
					if (currentNumber > 999)
					{
						if (CheckLength(currentNumber))
							controllerList[3].Add(currentNumber);
						else
							numberTypeIncluded[3] = true;
					}
				}

				if (!numberTypeIncluded[4])
				{
					currentNumber = GetHeptagonalNumber(index);
					if (currentNumber > 999)
					{
						if (CheckLength(currentNumber))
							controllerList[4].Add(currentNumber);
						else
							numberTypeIncluded[4] = true;
					}
				}

				if (!numberTypeIncluded[5])
				{
					currentNumber = GetOctagonalNumber(index);
					if (currentNumber > 999)
					{
						if (CheckLength(currentNumber))
							controllerList[5].Add(currentNumber);
						else
							numberTypeIncluded[5] = true;
					}
				}

				index++;
			}			
		}

		static List<int> FindSequence(List<int> currentState, List<bool> checkedLists)
		{
			if (!keepLooking)
				return null;

			bool passed = true;

			if (currentState.Count > 6)
			{
			}

			for (int i = 0; i < 6; i++)
			{				
				if (!checkedLists[i])
				{
					passed = false;

					foreach (int number in controllerList[i])
					{
						string s1 = number.ToString();
						if (currentState.Count == 0 || s1.Substring(0, 2) == currentState[currentState.Count - 1].ToString().Substring(2, 2))
						{
							currentState.Add(number);
							checkedLists[i] = true;

							FindSequence(currentState, checkedLists);
							
							checkedLists[i] = false;							
							currentState.RemoveAt(currentState.Count - 1);
						}
					}
				}
			}

			if (currentState.Count == 6)
				if (currentState[0].ToString().Substring(0, 2) != currentState[5].ToString().Substring(2, 2))
					passed = false;

			if (passed)
			{
				int sum = 0;
				for (int j = 0; j < currentState.Count; j++)
				{
					Console.WriteLine(currentState[j]);
					sum += currentState[j];
				}

				Console.WriteLine("Answer is " + sum);
				keepLooking = false;
				
				return currentState;
			}

			return null;
		}
				
		static void Main(string[] args)
		{
			List<bool> tmpList = new List<bool>();
			List<int> result = new List<int>();

			for (int i = 0; i < 6; i++)
			{
				tmpList.Add(false);
				numberTypeIncluded.Add(false);
			}

			FillLists();			
			FindSequence(result, tmpList);			
			
			Console.ReadLine();
		}
	}
}
