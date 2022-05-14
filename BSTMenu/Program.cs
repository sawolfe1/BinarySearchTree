// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Scott Wolfe
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BSTMenu
{
    using System;

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
}
