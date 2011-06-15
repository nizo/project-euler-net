using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ProjectEuler_01
{
	class Program
	{
		static int[,] inputNumbers;
		static int treeHeight = 100;
		static Node root = null;
		static Node traversingNode = null;		

		public class Node
		{
			public Node(int myValue, int myLevel, Node left, Node right, Node Father, bool leaf, bool setLeftFather)
			{
				Value = myValue;
				LeftNode = left;
				RightNode = right;
				if (setLeftFather)
				{
					LeftFather = Father;
					RightFather = null;
				}
				else
				{
					LeftFather = null;
					RightFather = Father;
				}				
				IsLeaf = leaf;
				Level = myLevel;
			}

			public int Value = 0;
			public int Level = 0;
			public int CummulatedValue = 0;
			public bool IsLeaf = false;
			public Node LeftNode = null;
			public Node RightNode = null;
			public Node LeftFather = null;
			public Node RightFather = null;
		}

		static Node InitializeNode(int level, int index, Node leftFather, bool setLeftFather)
		{
			bool isNodeLeaf = (level == treeHeight - 1);
			Node currentNode = new Node(inputNumbers[level, index], level, null, null, leftFather, isNodeLeaf, setLeftFather);

			if (!isNodeLeaf)
			{
				if (index == 0)
				{
					Node l = InitializeNode(level + 1, index, currentNode, false);
					currentNode.LeftNode = l;
				}
				else
				{
					currentNode.LeftNode = leftFather.LeftNode.RightNode;
					currentNode.LeftNode.RightFather = currentNode;
				}

				Node r = InitializeNode(level + 1, index + 1, currentNode, true);
				currentNode.RightNode = r;
			}
			else
			{
				currentNode.CummulatedValue = currentNode.Value;

				// If node is leaf, add it to leaf list
				if (traversingNode == null)
					traversingNode = currentNode;
			}

			return currentNode;
		}

		static Node InitializeRootNode()
		{			
			Node currentNode = InitializeNode(0, 0, null, false);
			return currentNode;
		}

		static void FillArrayRowWithData(string s, int line)
		{
			int currentIndex = 0;
			int overallIndex = 0;

			while (currentIndex < s.Length)
			{
				inputNumbers[line, overallIndex] = int.Parse(s.Substring(currentIndex, 2));
				overallIndex++;
				currentIndex += 3;
			}
		}

		static void Update(Node node)
		{
			Node holderNode = node;

			// We adusted our algorythm a bit, instead of backtracing solution used in problem 18, we simply sum both nodes and assign the bigger value to their father. Repeat till root
			while (node != root)
			{
				if (node.RightFather == null)
				{
					node = holderNode.RightFather;
					holderNode = node;
				}
				else
				{
					node.RightFather.CummulatedValue = Math.Max(node.CummulatedValue, node.RightFather.RightNode.CummulatedValue) + node.RightFather.Value;
					node = node.RightFather.RightNode;
				}
			}
		}

		static void Main(string[] args)
		{

			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			// Load data from txt file and convert them to two array

			#region LoadInputIntoArray

			inputNumbers = new int[treeHeight, treeHeight];
			for (int i = 0; i < treeHeight; i++)
			{
				for (int j = 0; j <= i; j++)
					inputNumbers[i, j] = 0;
			}

			const string inputFile = "input.txt";
			using (StreamReader streamReader = new StreamReader(inputFile))
			{
				string line;
				int counter = 0;
				while ((line = streamReader.ReadLine()) != null)
				{
					FillArrayRowWithData(line, counter);
					counter++;
				}
				streamReader.Close();
			}

			#endregion
			
			// Create our data structure, basically a variation of binary tree, but node may have two fathers
			root = InitializeRootNode();

			Update(traversingNode);

			stopwatch.Stop();
			System.Console.WriteLine("Maximum sum is: " + (root.CummulatedValue));
			System.Console.WriteLine("Calculation took: " + stopwatch.Elapsed);
			System.Console.ReadKey(true);
		}
	}
}





