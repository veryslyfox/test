interface IStringProvider<T>
{
    public string ToString(T value);
    public static IStringProvider<T> Default => new Standard<T>();
    public class Standard<TValue> : IStringProvider<TValue>
    {
        public string ToString(TValue value)
        {
            return value.ToString();
        }
    }
}
interface IStringProvider<T, TFormat>
{
    public string ToString(T value, TFormat format);
}
interface IStringProvider<T, TFormat1, TFormat2>
{
    public string ToString(T value, TFormat1 format1, TFormat2 format2);
}
interface IStringProvider<T, TFormat1, TFormat2, TFormat3>
{
    public string ToString(T value, TFormat1 format1, TFormat2 format2, TFormat3 format3);
}