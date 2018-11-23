// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Scott Wolfe
//   CS3130
//   Programming Assignment 3
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BSTMenu
{
    using System;
    using System.Linq;

    public class Program
    {  
        public static int[] ArrayOfIntegers { get; set; }

        public static void Main(string[] args)
        {
            ArrayOfIntegers = new[] { 30, 10, 45, 38, 20, 50, 25, 33, 8, 12 };
            Console.WriteLine("Array = { 30, 10, 45, 38, 20, 50, 25, 33, 8, 12 }");
            Console.WriteLine("Convert to Binary Search Tree using TREE-INSERT on each element:\n");
            var bst = new BinarySearchTree(ArrayOfIntegers);

            RunTheShow(bst);
        }

        private static void RunTheShow(BinarySearchTree bst)
        {
            var input = new[] {string.Empty};
            while (input[0] != "0")
            {
                input = ShowMenu().Trim().Split();

                switch (input[0])
                {
                    case "1":
                        Console.WriteLine("\nIn Order Traversal:");
                        bst.InOrderTreeWalk(bst.Root);
                        break;
                    case "2":
                        Console.WriteLine("\nPre Order Traversal:");
                        bst.PreOrderTreeWalk(bst.Root);
                        break;
                    case "3":
                        Console.WriteLine("\nPost Order Traversal:");
                        bst.PostOrderTreeWalk(bst.Root);
                        break;
                    case "4":
                        Console.WriteLine($"\nTree Search for {input[1]}:");
                        bst.TreeSearch(bst.Root, int.Parse(input[1]));
                        break;
                    default:
                        Console.WriteLine("\n---That's not an option---");
                        break;
                }
            }
        }

        private static string ShowMenu()
        {
            Console.WriteLine("\nBinary Search Tree Menu:");
            Console.WriteLine("=======================================");
            Console.WriteLine("1. Perform Inorder Traversal.");
            Console.WriteLine("2. Perform Preorder Traversal.");
            Console.WriteLine("3. Perform Postorder Traversal.");
            Console.WriteLine("4. Perform TREE-SEARCH.");
            Console.WriteLine("5. Perform TREE-DELETE.");
            Console.WriteLine("=======================================");
            Console.Write("Enter Menu Item: ");

            return Console.ReadLine();
        }

    }

    public class Node
    {
        public Node(int value)
        {
            Key = value;
            Left = null;
            Right = null;
        }

        public int Key { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }
    }

    public class BinarySearchTree
    {
        public Node Root { get; set; }

        public BinarySearchTree(int[] arr)
        {
            Root = new Node(arr[0]);
            Console.WriteLine($"Inserted {arr[0]} as root!");
            foreach (var num in arr.Skip(1))
            {
                Console.WriteLine($"Inserting {num}!");
                Insert(Root, num);
            }
        }

        public Node TreeMaximum(Node node)
        {
            while (node.Right != null)
                node = node.Right;

            return node;
        }

        public Node TreeMinimum(Node node)
        {
            while (node.Left != null)
                node = node.Left;

            return node;
        }

        public void InOrderTreeWalk(Node node)
        {
            if (node != null)
            {
                InOrderTreeWalk(node.Left);
                Console.WriteLine(node.Key);
                InOrderTreeWalk(node.Right);
            }
        }

        public void PostOrderTreeWalk(Node node)
        {
            if (node != null)
            {
                PostOrderTreeWalk(node.Left);
                PostOrderTreeWalk(node.Right);
                Console.WriteLine(node.Key);
            }
        }

        public void PreOrderTreeWalk(Node node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Key);
                PreOrderTreeWalk(node.Left);
                PreOrderTreeWalk(node.Right);
            }
        }

        public void TreeSearch(Node node, int key)
        {
            if (node == null)
            {
                Console.WriteLine("\nKey Not Found!");
                return;
            }

            if (key == node.Key)
            {
                Console.WriteLine("\nKey Found!");
                return;
            }

            if (key < node.Key)
            {
                Console.WriteLine("To the left...");
                TreeSearch(node.Left, key);
            }
            else if (key > node.Key)

            {
                Console.WriteLine("To the right...");
                TreeSearch(node.Right, key);
            }
        }

        public Node Insert(Node root, int value)
        {
            if (root == null)
            {
                root = new Node(value);
                Console.WriteLine($"New Node with key:{value} inserted!");
            }
            else if (value < root.Key)
            {
                Console.WriteLine("To the left...");
                root.Left = Insert(root.Left, value);
            }
            else
            {
                Console.WriteLine("To the right...");
                root.Right = Insert(root.Right, value);
            }

            return root;
        }

    }
}
