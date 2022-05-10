#pragma warning disable
class Monada<T>
{
    private T _value;
    public Monada(T value)
    {
        _value = value;
    }
    public Monada()
    {
        _value = default(T);
    }
    public static Monada<T> MonadaOperation(Func<T, T, T> func, Monada<T> monada1, Monada<T> monada2)
    {
        return new(func(monada1._value, monada2._value));
    }
}