class Pocket
{
    public Pocket()
    {
        Pockets = new List<Pocket>();
    }
    public Pocket(int capacity)
    {
        Pockets = new List<Pocket>(capacity);
    }
    public Pocket(IEnumerable<Node> nodes)
    {
        Pockets = nodes.ToArray().Select((node) => { return node.Pocket; }).ToList();
    }
    public Pocket(params Node[] nodes)
    {
        Pockets = nodes.ToArray().Select((node) => { return node.Pocket; }).ToList();
    }

    public List<Pocket> Pockets { get; }
}
class Node
{
    public Node(Pocket pocket, int index, IEnumerable<Pocket> links)
    {
        Pocket = pocket;
        Index = index;
        Links = links;
    }

    public Pocket Pocket { get; }
    public int Index { get; }
    public IEnumerable<Pocket> Links { get; }
}