namespace System.Security.Cryptography;
#pragma warning disable
partial class Tsr : IDisposable, IEquatable<Tsr> //(Time Span Random)
{
    public int Next(int maxValue)
    {
        if (Seed == 0)
        {
            Seed = 255;
        }
        return (NextByte() * 16777216 + NextByte() * 65536 + NextByte() * 256 + NextByte()) % maxValue;
    }
    public int Next(int minValue, int maxValue)
    {
        if (Seed == 0)
        {
            Seed = 255;
        }
        return (int)(NextByte() * 16777216 + NextByte() * 65536 + NextByte() * 256 + NextByte()) % (maxValue - minValue) + minValue;
    }
    public int Next(byte seed1, byte seed2, byte seed3, byte seed4)
    {
        if (Seed == 0)
        {
            Seed = 255;
        }
        return (int)(NextByte(seed1) * 16777216 + NextByte(seed2) * 65536 + NextByte(seed3) * 256 + NextByte(seed4));
    }
    public float NextFloat()
    {
        return (float)NextBigInteger(4) / (float)Math.Pow(256, 4) + 0.5F;
    }
    public double NextDouble()
    {
        return (double)NextBigInteger(8) / (double)Math.Pow(256, 8) + 0.5D;
    }
    public float NextFloat(double d)
    {
        return (float)NextBigInteger(4) / (float)Math.Pow(256, 4) + 0.5F;
    }
    public double NextDouble(double d)
    {
        return (double)NextBigInteger(8) / (double)Math.Pow(256, 8) + 0.5D;
    }
    public void Dispose()
    {
        Seed = 127;
    }
    public bool Equals(Tsr? other)
    {
        return other is null && this is null &&
            !(other is null && this is not null) &&
            !(other is not null && this is null) &&
            (other.Seed == Seed);
    }
    public void NextBytes(IEnumerable<byte> buffer)
    {
        for (int i = 0; i < buffer.Count(); i++)
        {
            buffer.ToArray()[i] = NextByte();
        }
    }
    public void NextBytes(Set<byte> buffer)
    {
        for (int i = 0; i < buffer.Count; i++)
        {
            buffer[i] = NextByte();
        }
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Seed);
    }
    public static explicit operator Tsr(byte b)
    {
        return new(b);
    }
    public Guid NextGuid()
    {
        return new(new byte[] {
        NextByte(), NextByte(),
         NextByte(), NextByte(),
          NextByte(), NextByte(),
           NextByte(), NextByte(),
            NextByte(), NextByte(),
             NextByte(), NextByte(),
              NextByte(), NextByte(),
               NextByte(), NextByte()});
    }
}