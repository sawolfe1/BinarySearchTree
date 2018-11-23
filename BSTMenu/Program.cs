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
        public static void Main(string[] args)
        {
            var bst = InitializeBst();

            RunTheShow(bst);
        }

        private static BinarySearchTree InitializeBst()
        {
            var arrayOfIntegers = new[] { 30, 10, 45, 38, 20, 50, 25, 33, 8, 12 };
            Console.WriteLine("Array = { 30, 10, 45, 38, 20, 50, 25, 33, 8, 12 }");
            Console.WriteLine("Convert to Binary Search Tree using TREE-INSERT on each array element:\n");
            return new BinarySearchTree(arrayOfIntegers);
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
                        if (int.TryParse(input[1], out var num))
                        {
                            Console.WriteLine($"\nTree Search for {num}:");
                            bst.TreeSearch(bst.Root, num);
                        }
                        break;
                    case "5":
                        if (int.TryParse(input[1], out var num2))
                        {
                            Console.WriteLine($"\nTree Delete for {num2}:");
                            var node = bst.TreeSearch(bst.Root, num2);
                            if (node != null)
                            {
                                bst.TreeDelete(node);
                                Console.WriteLine("...And Deleted!");
                            }
                        }
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
            Console.WriteLine("4. Perform TREE-SEARCH. (2 arguments)");
            Console.WriteLine("5. Perform TREE-DELETE. (2 arguments)");
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
            Parent = null;
        }

        public Node(int value, Node parent)
        {
            Key = value;
            Left = null;
            Right = null;
            Parent = parent;
        }

        public int Key { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node Parent { get; set; }
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
                TreeInsert(Root, num, null);
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

        public Node TreeSearch(Node node, int key)
        {
            if (node == null)
            {
                Console.WriteLine("\nKey Not Found!");
                return null;
            }

            if (key == node.Key)
            {
                Console.WriteLine("\nKey Found!");
                return node;
            }

            if (key < node.Key)
            {
                Console.WriteLine("To the left...");
                return TreeSearch(node.Left, key);
            }

            Console.WriteLine("To the right...");
            return TreeSearch(node.Right, key);

        }

        public Node TreeInsert(Node root, int value, Node parent)
        {
            if (root == null)
            {
                root = new Node(value, parent);
                Console.WriteLine($"New Node with key:{value} inserted!");
            }
            else if (value < root.Key)
            {
                Console.WriteLine("To the left...");
                root.Left = TreeInsert(root.Left, value, root);
            }
            else
            {
                Console.WriteLine("To the right...");
                root.Right = TreeInsert(root.Right, value, root);
            }

            return root;
        }

        public void TreeDelete(Node z)
        {
            if (z.Left == null)
                Transplant(z, z.Right);
            else if (z.Right == null)
                Transplant(z, z.Left);
            else
            {
                Node y;
                y = TreeMinimum(z.Right);
                if (y.Parent != z)
                {
                    Transplant(y, y.Right);
                    y.Right = z.Right;
                    y.Right.Parent = y;
                }
                Transplant(z, y);
                y.Left = z.Left;
                y.Left.Parent = y;
            }
        }

        public void Transplant(Node u, Node v)
        {
            if (u.Parent == null)
                Root = v;
            else if (u == u.Parent.Left)
                u.Parent.Left = v;
            else
                u.Parent.Right = v;

            if (v != null)
                v.Parent = u.Parent;

        }

    }
}
