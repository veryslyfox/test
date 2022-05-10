interface IFlag<T>
{
    public bool Predicate(T item);
    public bool GetPredicate { get => Predicate(Value); }
    public T Value { get; set; }
    public bool GetFlag { get => Predicate(Value); }
}