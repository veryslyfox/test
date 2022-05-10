sealed class Stringer
{
    private List<string> _list;
    public Stringer()
    {
        _list = new List<string>();
    }
    public Stringer(int capacity)
    {
        _list = new List<string>(capacity);
    }
    public Stringer(IEnumerable<string> collection)
    {
        _list = collection.ToList();
    }
    public void Input(string input)
    {
        _list.Add(input);
    }
    public void Remove(string input)
    {
        _list.Remove(input);
    }
    public void Output()
    {
        foreach (var item in _list)
        {
            Console.WriteLine(item);
        }
    }
}