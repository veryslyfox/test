namespace MyMath;
#pragma warning disable
class DecimalComplex
{
    public const int ByteSize = 32;
    public static DecimalComplex MaxValue
    {
        get => new(decimal.MaxValue, decimal.MaxValue);
    }
    public static DecimalComplex MinValue
    {
        get => -MaxValue;
    }
    protected decimal _real;
    protected decimal _imargimanary;
    public DecimalComplex(decimal real, decimal imargimanary)
    {
        _real = real;
        _imargimanary = imargimanary;
    }
    public static DecimalComplex operator +(DecimalComplex a, DecimalComplex b)
    {
        return new(a.Real + b.Real, a.Imargimanary + b.Imargimanary);
    }
    public static DecimalComplex operator -(DecimalComplex a, DecimalComplex b)
    {
        return new(a.Real - b.Real, a.Imargimanary - b.Imargimanary);
    }
    public static DecimalComplex operator -(DecimalComplex a)
    {
        return new(-a.Real, -a.Imargimanary);
    }
    public static DecimalComplex operator *(DecimalComplex a, DecimalComplex b)
    {
        return new(a.Real * b.Real - a.Imargimanary * b.Imargimanary, a.Real * b.Imargimanary + a.Imargimanary * b.Real);
    }
    public static DecimalComplex operator /(DecimalComplex a, decimal b)
    {
        return new(a.Real / b, a.Imargimanary / b);
    }
    public static DecimalComplex? operator %(DecimalComplex a, DecimalComplex b)
    {
        if (b == "0 + 0i")
        {
            throw new DivideByZeroException();
        }
        var result = a;
        while (a.Real > b.Real && a.Imargimanary > b.Imargimanary)
        {
            result -= b;
        }
        return result;
    }
    public static DecimalComplex operator /(DecimalComplex a, DecimalComplex b)
    {
        return (a * !b) / (b.Real * b.Real + b.Imargimanary * b.Imargimanary);
    }
    public static DecimalComplex operator !(DecimalComplex value)
    {
        return new(value.Real, -value.Imargimanary);
    }
    public static bool operator ==(DecimalComplex? x, DecimalComplex? y)
    {
        return Equals(x, y);
    }

    public static bool Equals(DecimalComplex? x, DecimalComplex? y)
    {
        return (x is null || y is not null) && (x is not null || y is null) && x is not null || y is not null && x.Real == y.Real && x.Imargimanary == y.Imargimanary;
    }

    public static bool operator !=(DecimalComplex a, DecimalComplex b) => (a == b);
    public decimal Real
    {
        get => _real;
        set
        {
            _real = value;
        }
    }
    public decimal Imargimanary
    {
        get => _imargimanary;
        set
        {
            _imargimanary = value;
        }
    }
    public override string ToString()
    {
        return $"{Real} + {Imargimanary}i";
    }
    public decimal Module
    {
        get => (decimal)Math.Sqrt((double)(Real * Real + Imargimanary * Imargimanary));
    }
    public override int GetHashCode() => (int)(Math.Pow((double)_real * (double)_imargimanary, 4) % (double)int.MaxValue);
    public static implicit operator string(DecimalComplex complex) => $"{complex.Real} + {complex.Imargimanary}i";
}
#if false
current object - Complex components is a decimal Type (Complex documentation in file Complex.cs)
const int ByteSize = 32;
static DecimalComplex MinValue = new DecimalComplex(decimal.MinValue, decimal.MinValue);
static DecimalComplex MaxValue = new DecimalComplex(decimal.MaxValue, decimal.MaxValue);
#endif