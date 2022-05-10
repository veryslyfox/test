class Exceptor
{
    public Exceptor()
    {
        Exceptions = new List<Exception>();
    }
    public Exceptor(int capacity)
    {
        Exceptions = new List<Exception>(capacity);
    }
    public Exceptor(IEnumerable<Exception> exceptions)
    {
        Exceptions = new List<Exception>(exceptions);
    }
    public Exceptor(params Exception[] exceptions)
    {
        Exceptions = new List<Exception>(exceptions);
    }

    public List<Exception> Exceptions { get; }
    public Span<Exception> ToSpan()
    {
        return Exceptions.ToArray();
    }
    public Exception this[int index]
    {
        get => Exceptions[index];
    }
    public Exceptor this[Range range]
    {
        get => (Exceptor)ToSpan()[range];
    }
    public void ChainThrow()
    {
        var count = Exceptions.Count;
        if (count == 0)
        {
            return;
        }
        if (count == 1)
        {
            throw Exceptions[0];
        }
        else
        {
            new Exceptor(ToSpan()[1..].ToArray()).ChainThrow();
        }
    }
    public static explicit operator Exceptor(Span<Exception> exceptions)
    {
        return new(exceptions.ToArray());
    }
}
