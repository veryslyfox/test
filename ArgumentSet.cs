struct ArgumentSet
{
    public ArgumentSet()
    {
        ArgumentInfos = new List<ArgumentInfo>();
    }
    public ArgumentSet(IEnumerable<ArgumentInfo> argumentInfos)
    {
        ArgumentInfos = argumentInfos.ToList();
    }
    public ArgumentSet(int capacity)
    {
        ArgumentInfos = new List<ArgumentInfo>(capacity);
    }
    public List<ArgumentInfo> ArgumentInfos { get; }
    public IEnumerator<ArgumentInfo> GetEnumerator()
    {
        return ArgumentInfos.GetEnumerator();
    }
}
