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
struct Node
{
    public Pocket Pocket { get; set; }
    public IEnumerable<Pocket> Links { get; set; }
}