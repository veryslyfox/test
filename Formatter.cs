enum Culture
{
    Russian,
    American,
    Espane
}
enum NumericsSystem
{
    Binary,
    Decimal,
    Hexadecimal
}
class Format
{
    public Format(bool zeros, NumericsSystem numericsSystem, int value = int.MaxValue)
    {
        Zeros = zeros;
    }

    public bool Zeros { get; }
}
class Formatter : IFormatProvider
{
    public Formatter(Culture culture)
    {
        Culture = culture;
    }

    public Culture Culture { get; }

    public object? GetFormat(Type? formatType)
    {
        if (formatType == typeof(bool))
        {
            return "истина / ложь";
        }
        if (formatType == typeof(int))
        {
            return "используйте ToString()";
        }
        if (formatType == typeof(float) || formatType == typeof(double) || formatType == typeof(decimal))
        {
            return "отформатируйте с запятой";
        }
        return "не знаю";
    }
}