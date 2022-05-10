namespace MyMath;
#pragma warning disable
class Quaternion
{
    public Quaternion()
    {
        X = 0;
        Y = 0;
        Z = 0;
        W = 0;
    }
    public Quaternion(Complex complex1, Complex complex2)
    {
        X = complex1.Real;
        Y = complex1.Imargimanary;
        Z = complex2.Real;
        W = complex2.Imargimanary;
    }
    public Quaternion(double x, double y, double z, double w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }
    public override string ToString()
    {
        return $"{X} + {Y}i + {Z}j + {W}k";
    }
    public static implicit operator string(Quaternion quaternion)
    {
        return quaternion.ToString();
    }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public double W { get; set; }
    public Complex Complex1 { get => new(X, Y); }
    public Complex Complex2 { get => new(Z, W); }
    public static Quaternion operator +(Quaternion a, Quaternion b)
    {
        return new(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    }
    public static Quaternion operator -(Quaternion a, Quaternion b)
    {
        return new(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    }
    public static Quaternion operator -(Quaternion value)
    {
        return new(-value.X, -value.Y, -value.Z, -value.W);
    }
    public static Quaternion operator *(Quaternion a, Quaternion b)
    {
        return new(a.Complex1 * b.Complex1 - a.Complex2 * b.Complex2, a.Complex1 * b.Complex2 + a.Complex2 * b.Complex1);
    }
    public static Quaternion operator /(Quaternion a, double b)
    {
        return new(a.X / b, a.Y / b, a.Z / b, a.W / b);
    }
    public static Quaternion operator %(Quaternion a, Quaternion b)
    {
        if (b == "0 + 0i")
        {
            throw new DivideByZeroException();
        }
        var result = a;
        while (a.X > b.X && a.Y > b.Y && a.Z > b.Z && a.Y > b.Y)
        {
            result -= b;
        }
        return result;
    }
    public static Quaternion operator !(Quaternion value)
    {
        return new(value.X, -value.Y, -value.Z, -value.W);
    }
    public static bool operator ==(Quaternion? x, Quaternion? y)
    {
        return x.Complex1 == y.Complex1;
    }
    public static bool operator !=(Quaternion? x, Quaternion? y) => !(x == y);
    public bool Equals(Quaternion? y)
    {
        return (this is null || y is not null) && (this is not null || y is null) && this is not null || y is not null && Complex1 == y.Complex1 && Complex2 == y.Complex2;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z, W, Complex1, Complex2);
    }

    public override bool Equals(object? obj)
    {
        return obj is Quaternion quaternion &&
            quaternion.Complex1 == Complex1 &&
            quaternion.Complex2 == Complex2;
    }
}
