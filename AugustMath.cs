namespace MyMath;
static partial class ConstsFunctions
{

    public static double Exponent(double d)
    {
        return Math.Pow(Consts.E, d);
    }
    public static double Circle(double radius)
    {
        return Consts.Pi * radius * radius;
    }
    public static decimal PresicionCircle(decimal radius)
    {
        return Consts.PrecisonPi * radius * radius;
    }
    public static double Stirling(double factorialEnter)
    {
        return Math.Sqrt(2 * Consts.Pi * factorialEnter) * Math.Pow(factorialEnter / Consts.E, factorialEnter);
    }
}
static class Consts
{
    public static double Fi
    {
        get => (1 + Math.Sqrt(5)) / 2;
    }
    public static decimal DecimalPiRow(int r)
    {
        var accumulator = 0M;
        for (int i = 0; i < r; i++)
        {
            if (i % 2 == 0)
            {
                accumulator += 1M / (2 * i + 1);
            }
            else
            {
                accumulator -= 1M / (2 * i + 1);
            }
        }
        return 4 * accumulator;
    }
    public static double PiRow1(int r)
    {
        var accumulator = 0.0;
        for (int i = 0; i < r; i++)
        {
            if (i % 2 == 0)
            {
                accumulator += 1 / (2 * i + 1);
            }
            else
            {
                accumulator -= 1 / (2 * i + 1);
            }
        }
        return 4 * accumulator;
    }
    public static double PiRow2(int precision)
    {
        var accumulator = 0.0;
        for (int i = 1; i < precision; i++)
        {
            accumulator += (1 / (i * i));
        }
        return Math.Sqrt(6 * accumulator);
    }
    public static decimal PresicionERow(int r)
    {
        var accumulator = 0M;
        for (int i = 0; i < r; i++)
        {
            var afactorial = 1M;
            for (decimal k = 1; k < i; k++)
            {
                afactorial /= k;
            }
            accumulator += afactorial;
        }
        return accumulator - 1;
    }
    public static double ERow(int r)
    {
        var accumulator = 0.0;
        for (int i = 0; i < r; i++)
        {
            var afactorial = 1.0;
            for (double k = 1; k < i; k++)
            {
                afactorial /= k;
            }
            accumulator += afactorial;
        }
        return accumulator - 1;
    }

    public static double E
    {
        get => 2.7182818284590;
    }
    public static decimal PrecisonE
    {
        get => 2.71828182845904523536M;
    }
    public static double Pi
    {
        get => 3.1415926535;
    }
    public static decimal PrecisonPi
    {
        get => 3.14159265358979323846M;
    }
}
class MathFunc
{
    public readonly double[] _powConsts;
    public readonly double[]? _expConsts;
    public readonly double[]? _expMultiplication;
    public MathFunc(double[] powConsts, double[]? expConsts, double[]? expMultiplication)
    {
        _powConsts = powConsts;
        _expConsts = expConsts;
        _expMultiplication = expMultiplication;
    }
    public double Result(double d)
    {
        var accumulator = 0.0;
        if (_powConsts is { })
        {
            for (int i = 0; i < _powConsts.Length; i++)
            {
                var sum = _powConsts[i] * Math.Pow(d, _powConsts.Length - i);
                accumulator += sum;
            }
        }
        if (_expConsts is { } && _expMultiplication is { })
        {
            for (int i = 0; i < _expConsts.Length; i++)
            {
                accumulator += Math.Pow(_expConsts[i], d) * _expMultiplication[i];
            }
        }
        return accumulator;
    }
    public int? GetPow
    {
        get
        {
            if (_powConsts is { })
            {
                return _powConsts.Length - 1;
            }
            else
            {
                Console.WriteLine("Error");
                return null;
            }
        }
    }
    public double[]? GetExponent
    {
        get => _expConsts;
    }
}
