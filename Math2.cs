using System.Numerics;
static partial class MathHigh
{
    public static BigInteger FastGrowingHierarchy(BigInteger value, uint rank)
    {
        if (rank == 0)
        {
            return value + 1;
        }
        if (rank == 1)
        {
            return value * 2;
        }
        if (rank == 2)
        {
            return Pow(2, value) * value;
        }
        var result = value;
        for (int i = 0; i < value; i++)
        {
            result = FastGrowingHierarchy(result, rank - 1);
        }
        return result;
    }
    public static int DigitCount(BigInteger value)
    {
        var count = 1;
        for (BigInteger i = 1; i < value; i *= 10)
        {
            count++;
        }
        return count;
    }
    public static double Integer(Func<double, double> func,
     double minValue, double maxValue, double interval)
    {
        var result = 0.0;
        for (double i = minValue; i < maxValue; i += interval)
        {
            result += func(i);
        }
        return result;
    }
    public static BigInteger Hyper(BigInteger x, BigInteger y, int rank)
    {
        if (rank == 0)
        {
            return x + 1;
        }
        if (rank == 1)
        {
            return x + y;
        }
        if (rank == 2)
        {
            return x * y;
        }
        if (rank == 3)
        {
            return Pow(x, y);
        }
        var result = x;
        for (int i = 0; i < y - 1; i++)
        {
            result = Hyper(result, y, rank - 1);
        }
        return result;
    }
    /*
    public static BigInteger PowQuick(BigInteger a, BigInteger b)
    {
        if (b == 2)
        {
            return a * a;
        }
        for (int count = 0; count < BigInteger.Log10(b); count++)
        {
            
        }
    }
    */
}