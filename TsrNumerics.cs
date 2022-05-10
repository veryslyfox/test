namespace System.Security.Cryptography;
using System.Numerics;
partial class Tsr
{
    public double NextDouble(double minValue, double maxValue)
    {
        return (maxValue - minValue) * NextDouble() + minValue;
    }
    public float NextFloat(float minValue, float maxValue)
    {
        return NextFloat() * (maxValue - minValue) + minValue;
    }
    public Complex NextComplex(double maxRealValue, double maxImargimanaryValue)
    {
        return new(NextDouble(0, maxRealValue), NextDouble(0, maxImargimanaryValue));
    }
    public Complex NextComplex(double minRealValue, double maxRealValue, double minImargimanaryValue, double maxImargimanaryValue)
    {
        return new(NextDouble(minRealValue, maxRealValue), NextDouble(minImargimanaryValue, maxImargimanaryValue));
    }
    public Quaternion NextQuaternion()
    {
        return new(NextFloat(), NextFloat(), NextFloat(), NextFloat());
    }
    public BigInteger NextBigInteger(int length = 4, bool isUnsigned = false)
    {
        var list = new List<byte>();
        for (int i = 0; i < length; i++)
        {
            list.Add(NextByte());
        }
        return new(new ReadOnlySpan<byte>(list.ToArray()), isUnsigned);
    }
}