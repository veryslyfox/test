using System.Numerics;
static partial class MathHigh
{

    public static BigInteger GetMega()
    {
        return CircleNotation(2);
    }
    public static BigInteger GetMegiston()
    {
        return CircleNotation(10);
    }
    public static BigInteger Pow(BigInteger a, BigInteger b)
    {
        BigInteger result = 1;
        for (BigInteger i = 0; i < b; i++)
        {
            result *= a;
        }
        return result;
    }
    // public static BigInteger PowQuick(BigInteger a, BigInteger b)
    // {
    //     var result = a;
    //     var count = b;
    // }
    public static BigInteger TraingleNotation(BigInteger integer)
    {
        return Pow(integer, integer);
    }
    public static BigInteger SquareNotation(BigInteger integer)
    {
        var result = integer;
        for (BigInteger i = 0; i < integer; i++)
        {
            result = TraingleNotation(result);
        }
        return result;
    }
    public static BigInteger CircleNotation(BigInteger integer)
    {
        var result = integer;
        for (BigInteger i = 0; i < integer; i++)
        {
            result = SquareNotation(result);
        }
        return result;
    }
    public static uint EilerFunc(uint value)
    {
        var count = 0U;
        for (int i = 0; i < value; i++)
        {
        }
        return count;
    }
    public static T Iterate<T>(T seed, Func<T, T> selector, int iterations)
    {
        T result = seed;
        for (int i = 0; i < iterations; i++)
        {
            result = selector(result);
        }
        return result;
    } 
}