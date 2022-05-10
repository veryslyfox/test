namespace System.Security.Cryptography;
partial class Tsr
{
    public Tsr() { Seed = TimeRandom.Byte(); }
    public Tsr(byte seed) { Seed = seed; }
    public byte Seed { get; set; }
    public byte NextByte()
    {
        if (Seed == 0)
        {
            
            Seed = 255;
        }
        var result = (byte)TimeRandom.TimeSpanRandom(Seed * 800, 256);
        Seed += result;
        return result;
    }
    public static Tsr Value
    {
        get => new Tsr();
    }
    public byte NextByte(byte seed)
    {
        if (Seed == 0)
        {
            Seed = 255;
        }
        Seed += seed;
        var result = (byte)TimeRandom.TimeSpanRandom(Seed * 800, 256);
        Seed += result;
        return result;
    }
    public uint NextUint()
    {
        if (Seed == 0)
        {
            Seed = 255;
        }
        return (uint)(NextByte() * 16777216 + NextByte() * 65536 + NextByte() * 256 + NextByte());
    }
    public uint NextUint(uint maxValue)
    {
        if (Seed == 0)
        {
            Seed = 255;
        }
        return (uint)(NextByte() * 16777216 + NextByte() * 65536 + NextByte() * 256 + NextByte()) % maxValue;
    }
    public uint NextUint(uint minValue, uint maxValue)
    {
        if (Seed == 0)
        {
            Seed = 255;
        }
        return (uint)(NextByte() * 16777216 + NextByte() * 65536 + NextByte() * 256 + NextByte()) % (maxValue - minValue) + minValue;
    }
    public uint NextUint(byte seed1, byte seed2, byte seed3, byte seed4)
    {
        
        if (Seed == 0)
        {
            Seed = 255;
        }
        return (uint)(NextByte(seed1) * 16777216 + NextByte(seed2) * 65536 + NextByte(seed3) * 256 + NextByte(seed4));
    }
    public int Next()
    {
        if (Seed == 0)
        {
            Seed = 255;
        }
        return (int)(NextByte() * 16777216 + NextByte() * 65536 + NextByte() * 256 + NextByte());
    }
    public Tsr NextTsr()
    {
        return new Tsr(NextByte());
    }
}