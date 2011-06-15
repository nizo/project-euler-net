using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler_01
{
	class Program
	{
		static int[,] inputNumbers;
		static int treeHeight = 15;
		static Node root = null;
		static Node[] leafsList = new Node[treeHeight + 1];
		static int leafIndex = 0;

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
			
			// Create new node with null sons
			Node currentNode = new Node(inputNumbers[level, index], level, null, null, leftFather, isNodeLeaf, setLeftFather);

			if (!isNodeLeaf)
			{
				if (index == 0) // Were creating the tree in preOrder so we want to create new node only when were on left side of triangle....
				{
					Node l = InitializeNode(level + 1, index, currentNode, false);
					currentNode.LeftNode = l;
				}
				else // otherwise we want to link this left so to already created node our fathers leftsons rightson
				{
					currentNode.LeftNode = leftFather.LeftNode.RightNode;
					currentNode.LeftNode.RightFather = currentNode;
				}

				Node r = InitializeNode(level + 1, index + 1, currentNode, true);
				currentNode.RightNode = r;
			}
			else
			{
				// If node is leaf, add it to leaf list
				leafsList[leafIndex] = currentNode;
				leafIndex++;
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

		static void UpdateCummulatedValue(Node Node, int Value)
		{
			if (Node == null)
				return;

			if (Node == root)
			{
				if (Value > Node.CummulatedValue)
					Node.CummulatedValue = Value;
				return;
			}

			// If maximum cummulated value is higher, update it
			if (Value > Node.CummulatedValue)
				Node.CummulatedValue = Value;

			if (Node.IsLeaf)
			{
				if (Node.LeftFather != null)
					UpdateCummulatedValue(Node.LeftFather, Node.Value);
				if (Node.RightFather != null)
					UpdateCummulatedValue(Node.RightFather, Node.Value);

				Node.CummulatedValue = Node.Value;
			}
			else
			{
				if (Node.LeftFather != null)
					UpdateCummulatedValue(Node.LeftFather, Value + Node.Value);
				if (Node.RightFather != null)
					UpdateCummulatedValue(Node.RightFather, Value + Node.Value);
			}
		}

		static void Main(string[] args)
		{
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

			// Go through the structure from bottom to top
			for (int i = 0; i < 15; i++)
				UpdateCummulatedValue(leafsList[i], 0);
			
			System.Console.WriteLine("Maximum sum is: " + (root.CummulatedValue + root.Value));
			System.Console.ReadKey(true);
		}
	}
}





