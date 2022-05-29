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
        if (y == 1)
        {
            return x;
        }
        return Hyper(x, Hyper(x, y - 1, rank), rank - 1);
    }
    public static BigInteger KnutArrow(BigInteger a, BigInteger b, int n)
    {
        Hyper(a, b, n + 2);
    }
    public static BigInteger Factorial(BigInteger input)
    {
        BigInteger accumulator = new BigInteger(1);
        for (BigInteger i = 0; i < input; i++)
        {
            accumulator *= i;
        }
        return accumulator;
    }
    public static BigInteger ConwayArrow(params BigInteger[] integers)
    {
        return Conway(integers);
    }
    public static BigInteger Conway(BigInteger[] integers)
    {
        var search = integers.Search(1);
        if (search != -1)
        {
            return Conway(integers.AsSpan(0, search).ToArray());
        }
        if (search == -1)
        {
            return ConwayArrow(integers.ToArray().AsSpan(..1).ToArray());
        }
        else if (integers.Count() == 3)
        {
            return KnutArrow(integers[0], integers[1], ((int)integers[2]));
        }
        else
        {
            return ConwayArrow(new BigInteger[] { integers[0], integers[1] });
        }
    }

}