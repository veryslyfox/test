class MinusList<T>
{
    private int _minValue;
    public MinusList()
    {
        List = new List<T>();
    }
    public MinusList(IEnumerable<T> collection)
    {
        List = collection.ToList();
    }
    public void AddFirst(T item)
    {
        _minValue--;
        this[MinValue] = item;
    }

    public override bool Equals(object? obj) => obj is MinusList<T> list &&
            list.Array == Array &&
            list.MinValue == MinValue &&
            list.MaxValue == list.MaxValue;

    public override int GetHashCode() => HashCode.Combine(Array, List, MinValue, MaxValue);

    public T[] Array { get => List.ToArray(); }
    public List<T> List { get; }
    public int MinValue { get; private set; }
    public int MaxValue { get; private set; }
    public T this[int index]
    {
        get => Array[index - MinValue];
        set => Array[index - MinValue] = value;
    }
}