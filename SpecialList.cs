class SpecialList<T>
{
    public SpecialList()
    {
        _list = new List<T>();
    }
    public SpecialList(IEnumerable<T> collection)
    {
        _list = new List<T>(collection);
    }
    public SpecialList(int capacity) 
    {
        _list = new List<T>(capacity);
    }
    private List<T> _list;
    private int _minValue;
    private T this[int index, Flag flag]
    {
        get => List[index - MinValue];
        set => List[index - MinValue] = value;
    }
    public new T this[int index]
    {
        get => this[index + MinValue, new Flag()];
        set => this[index + MinValue, new Flag()] = value;
    }
    public int MinValue { get => _minValue; }
    public List<T> List { get => _list; }
    public void AddFirst(T item)
    {
        _minValue--;
        this[_minValue] = item;
    }
    public void AddLast(T item)
    {
        _list.Add(item);
    }
    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }
    public void IndexOffset(int offset)
    {
        _minValue -= offset;
    }
}
class Flag
{
}