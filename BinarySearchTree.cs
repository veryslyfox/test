class BinarySearchTree<TKey, TData>
{
    private BinarySearchTree(IComparer<TKey> comparer, TKey rootKey, TData rootData, BinarySearchTree<TKey, TData> left, BinarySearchTree<TKey, TData> right)
    {
        Comparer = comparer;
        RootKey = rootKey;
        RootData = rootData;
        Left = left;
        Right = right;
    }
    public BinarySearchTree(IComparer<TKey> comparer, IEnumerable<(TKey, TData)> values)
    {
        Comparer = comparer;
    }
    public IComparer<TKey> Comparer { get; }
    public TKey RootKey { get; }
    public TData RootData { get; }
    public BinarySearchTree<TKey, TData> Left { get; }
    public BinarySearchTree<TKey, TData> Right { get; }
    public void Add(TKey key, TData data)
    {
        
    }
}