class Null
{
    public Null(object? value)
    {
        Value = value;
    }

    public object? Value { get; }
    public bool HasValue()
    {
        return this is { };
    }
    public int Nullable()
    {
        if (this == null)
        {
            return 2;
        }
        if (Value == null)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    public object? GetValue()
    {
        if (HasValue())
        {
            return Value;
        }
        else
        {
            return null;
        }
    }
}