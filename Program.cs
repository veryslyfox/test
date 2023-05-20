class Node
{
    public Node(double a, Node? left, Node? right, Node? parent)
    {
        A = a;
        Left = left;
        Right = right;
        Parent = parent;
    }

    public double A { get; }
    public Node? Left { get; }
    public Node? Right { get; }
    public Node? Parent { get; }
}