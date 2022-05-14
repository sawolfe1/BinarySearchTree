namespace BSTMenu
{
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
}