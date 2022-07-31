#pragma warning disable
namespace MyMath;
class Complex : IEquatable<Complex>
{
    public const int ByteSize = 16;
    public static Complex MaxValue
    {
        get => new Complex(double.MaxValue, double.MaxValue);
    }
    public static Complex MinValue
    {
        get => -MaxValue;
    }
    protected double _real;
    protected double _imaginary;
    public Complex()
    {
        _real = 0;
        _imaginary = 0;
    }
    public Complex(double real, double imargimanary)
    {
        _real = real;
        _imaginary = imargimanary;
    }
    public static Complex operator +(Complex a, Complex b)
    {
        return new(a.Real + b.Real, a.Imargimanary + b.Imargimanary);
    }
    public static Complex operator -(Complex a, Complex b)
    {
        return new(a.Real - b.Real, a.Imargimanary - b.Imargimanary);
    }
    public static Complex operator -(Complex a)
    {
        return new(-a.Real, -a.Imargimanary);
    }
    public static Complex operator *(Complex a, Complex b)
    {
        return new(a.Real * b.Real - a.Imargimanary * b.Imargimanary, a.Real * b.Imargimanary + a.Imargimanary * b.Real);
    }
    public static Complex operator /(Complex a, double b)
    {
        return new(a.Real / b, a.Imargimanary / b);
    }
    public static Complex? operator %(Complex a, Complex b)
    {
        if (b == "0 + 0i")
        {
            throw new DivideByZeroException();
        }
        var result = a;
        while (result.Real > b.Real && result.Imargimanary > b.Imargimanary)
        {
            result -= b;
        }
        return result;
    }
    public static Complex operator /(Complex a, Complex b)
    {
        return (a * !b) / (b.Real * b.Real + b.Imargimanary * b.Imargimanary);
    }
    public static Complex operator !(Complex value)
    {
        return new(value.Real, -value.Imargimanary);
    }
    public static bool operator ==(Complex? x, Complex? y)
    {
        return Equals(x, y);
    }

    public static bool Equals(Complex? x, Complex? y)
    {
        return (x is null || y is not null) && (x is not null || y is null) && x is not null || y is not null && x.Real == y.Real && x.Imargimanary == y.Imargimanary;
    }
    public static bool operator !=(Complex a, Complex b) => (a == b);
    public double Real
    {
        get => _real;
        set
        {
            _real = value;
        }
    }
    public double Imargimanary
    {
        get => _imaginary;
        set
        {
            _imaginary = value;
        }
    }
    public override string ToString()
    {
        return $"{Real} + {Imargimanary}i";
    }
    public double Module
    {
        get => Math.Sqrt(Real * Real + Imargimanary * Imargimanary);
    }
    public override int GetHashCode() => (int)(Math.Pow(_real * _imaginary, 4) % (double)int.MaxValue);
    public static implicit operator string(Complex complex) => $"{complex.Real} + {complex.Imargimanary}i";
    public static implicit operator Complex((double, double) value) => new(value.Item1, value.Item2);
    public static implicit operator Complex(string s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (47 < (int)s[i] || (int)s[i] < 58)
            {
            }
        }
        return null;
    }
    public static implicit operator Complex(int i)
    {
        return new(i, 0);
    }
    public double Sum()
    {
        return Real * Math.Abs(Real) + Imargimanary * Math.Abs(Imargimanary);
    }

    public bool Equals(Complex? other)
    {
        return this == other;
    }

    public static bool operator <(Complex complex1, Complex complex2)
    {
        return complex1.Sum() < complex2.Sum();
    }
    public static bool operator >(Complex complex1, Complex complex2)
    {
        return complex1.Sum() < complex2.Sum();
    }
    public static bool operator <=(Complex complex1, Complex complex2)
    {
        return complex1.Sum() <= complex2.Sum();
    }
    public static bool operator >=(Complex complex1, Complex complex2)
    {
        return complex1.Sum() >= complex2.Sum();
    }
}
#pragma warning restore
#if false
class MyMath.Complex
{
    current object - complex value : a + bi
    constructor elements : double real, double imargimanary
    operators :
    ==, !=, +, -, unary - : (- a - bi), *, /, ! : (a - bi) 
    mains :
    override string ToString() :
    return "a + bi"
    override int GetHashCode() :
    return 4 - byte Complex hash
    flags : 
    get and set Real and Imargimanary elements this complex
    const int ByteSize = 16;
    const Complex MinValue = new Complex(double.MinValue, double.MinValue);
    const Complex MaxValue = new Complex(double.MaxValue, double.MaxValue);
}
#endif