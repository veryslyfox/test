namespace System.Security.Cryptography;
abstract class TsrConverter
{
    public TsrConverter() { TsrSeed = Tsr.Value; }
    public TsrConverter(byte seed) { TsrSeed = (Tsr)seed; }
    public Tsr TsrSeed { get; protected set; }

    public override bool Equals(object? obj)
    {
        return obj is TsrConvertDigit digit &&
            digit.TsrSeed == TsrSeed;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(TsrSeed);
    }
}