global using System.Numerics;
class NumberPlatform
{
    public NumberPlatform()
    {
    }
    public NumberPlatform(BigInteger value)
    {
        Value = value;
    }

    public BigInteger Value { get; set; }
    public void FromPower(BigInteger power)
    {
        Value = MathHigh.Pow(Value, power);
    }
    public void FromExponent(BigInteger exponent)
    {
        Value = MathHigh.Pow(exponent, Value);
    }
}
