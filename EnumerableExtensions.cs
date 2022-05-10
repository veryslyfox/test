static class EnumerableExtensions
{
    public static void VocalizeAll(this IEnumerable<Animals.Animal> animals)
    {
        foreach (var animal in animals)
        {
            animal.Vocalize();
        }
    }
    public static void VocalizeAll(this Set<Animals.Animal> animals)
    {
        foreach (var animal in animals)
        {
            animal.Vocalize();
        }
    }
    public static IEnumerable<T> Compress<T>(this IEnumerable<IEnumerable<T>> values)
    {
        return values.SelectMany(i => i);
    }
    public static string UnicodeRotation(this string s, int rotation)
    {
        var result = "";
        foreach (var item in s)
        {
            result += (char)((int)item + rotation);
        }
        return result;
    }
    public static string UnicodeRotation(this string s, int rotation, int start, int count)
    {
        var result = "";
        foreach (var item in s)
        {
            result += (char)((int)item + rotation % count + start);
        }
        return result;
    }
    public static string UnicodeRotationEncrypt(this string s, int rotation, AlphabetValue alphabetValue)
    {
        switch (alphabetValue)
        {
            case AlphabetValue.Russian:
                return s.UnicodeRotation(rotation, 1072, 33);
            case AlphabetValue.English:
                return s.UnicodeRotation(rotation, 97, 26);
            default:
                return s;
        }
    }
    public static string UnicodeRotationDecrypt(this string s, int rotation, AlphabetValue alphabetValue)
    {
        switch (alphabetValue)
        {
            case AlphabetValue.Russian:
                return s.UnicodeRotation(-rotation, 1072, 33);
            case AlphabetValue.English:
                return s.UnicodeRotation(-rotation, 97, 26);
            default:
                return s;
        }
    }
}
enum AlphabetValue
{
    Russian,
    English
}