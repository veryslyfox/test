class KeyedCollection<TKey, TElement>
{
    public KeyedCollection(TKey key)
    {
        Elements = new List<TElement>();
        Key = key;
        ConstructorData = new ConstructorData("key");
    }
    public KeyedCollection(TKey key, int capacity)
    {
        Elements = new List<TElement>(capacity);
        Key = key;
        ConstructorData = new ConstructorData("key and capacity");
    }
    public KeyedCollection(TKey key, IEnumerable<TElement> elements)
    {
        Key = key;
        Elements = elements.ToList();
        ConstructorData = new ConstructorData("key and elements");
    }

    private TKey Key { get; }
    public List<TElement> Elements { get; private set; }
    public ConstructorData ConstructorData { get; }
    public void Add(TElement element, TKey key)
    {
        if (EqualityComparer<TKey>.Default.Equals(Key, key))
        {
            Elements.Add(element);
        }
    }
}
