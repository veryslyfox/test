interface IConverter<T> 
{
    public T Convert(T value);
    public T Value { get; protected set; }
}