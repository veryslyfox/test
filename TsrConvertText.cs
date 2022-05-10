namespace System.Security.Cryptography;
class TsrConvertText : TsrConverter
{
    public TsrConvertText()
    {
        TsrSeed = Tsr.Value;
    }
    public TsrConvertText(byte seed)
    {
        TsrSeed = (Tsr)seed;
    }

    public override bool Equals(object? obj)
    {
        return obj is TsrConvertText convert &&
               TsrSeed == convert.TsrSeed;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(TsrSeed);
    }
    public char ToChar()
    {
        return (char)Tsr.Value.NextByte();
    }
    public char ToChar(byte convert)
    {
        return (char)Tsr.Value.NextByte(convert);
    }
    public string ToString(byte convert)
    {
        var s = "";
        for (int i = 0; i < Tsr.Value.NextByte() % 20; i++)
        {
            s += ToChar(convert);
        }
        return s;
    }
    public override string ToString()
    {
        var s = "";
        for (int i = 0; i < Tsr.Value.NextByte(); i++)
        {
            s += ToChar();
        }
        return s;
    }
}