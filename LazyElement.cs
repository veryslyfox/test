struct LazyElement<T>
{
    public LazyElement(T value)
    {
        HasValue = true;
        Value = value;
    }
    public bool HasValue { get; private set; }
    public T Value { get; set; }
    public void OnElement(T value)
    {
        Value = value;
        HasValue = true;
    }
    public void OnDefault()
    {
        Value = default;
        HasValue = false;
    }
}