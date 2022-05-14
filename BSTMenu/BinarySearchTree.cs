using System;
using System.Linq;

namespace BSTMenu
{
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