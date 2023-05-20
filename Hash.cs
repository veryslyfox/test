static partial class Program
{
    
#pragma warning disable // Задам, когда нужно
    public static CubeHashData CubeHashData;
#pragma warning restore
    public static readonly string HexString = "0123456789ABCDEF";

    public static byte[] Hash256(string value)
    {
        if (value.Length % 4 != 0)
        {
            return new byte[]{};
            
        }
        var data = ToByteArray(value);
        CubeHashData = new CubeHashData(data);
        var result = new byte[256];
        for (int i = 0; i < 256; i++)
        {
            result[i] = Hash256Byte(value, i);
        }
        return result;
    }
    public static byte Hash256Byte(string value, int index)
    {
        var p = index % 2;
        var q = index << 2 % 2;
        var r = index << 4 % 2;
        var t = index << 6 % 2;
        var array = new int[] { p, q, r, t };
        var length = CubeHashData.Value.Length;
        var result = 0;
        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < length; y++)
            {
                for (int z = 0; z < length; z++)
                {
                    result += CubeHashData[x, y, z] * array[(x + y + z) % 4];
                }
            }
        }
        return (byte)(result % 256);
    }
    public static string To16String(byte[] bytes)
    {
        return new string(bytes.Select(c => HexString[c / 16]).ToArray()) + new string(bytes.Select(c => HexString[c % 16]).ToArray());
    }
    public static byte[] ToByteArray(string s)
    {
        return s.Select(c => HexString.IndexOf(c)).Chunk(2).Select(v => (byte)(16 * v[0] + v[1])).ToArray();
    }
    public static int[] ToIntArray(byte[] array)
    {
        return array.Chunk(4).Select(c => c[0] * 16777216 + c[1] * 65536 + c[2] * 256 + c[3]).ToArray();
    }
}
public struct TernaryOperator
{
    public TernaryOperator(byte operation)
    {
        Operation = operation;
    }

    public byte Operation { get; }
    public byte Combine(byte a, byte b, byte c)
    {
        var result = 0;
        var pow = 1;
        for (int i = 0; i < 8; i++)
        {
            result += pow * (Combine(a << i % 2 == 1, b << i % 2 == 1, c << i % 2 == 1) ? 0 : 1);
            pow *= 2;
        }
        return (byte)result;
    }
    public bool Combine(bool a, bool b, bool c)
    {
        var A = a ? 0 : 1;
        var B = b ? 0 : 1;
        var C = c ? 0 : 1;
        return (Operation >> (4 * A + 2 * B + C)) % 2 == 1;
    }
}
public class CubeHashData
{
    public CubeHashData(byte[] value)
    {
        Value = value;
    }
    public byte this[int x, int y, int z]
    {
        get => new TernaryOperator((byte)(x ^ y ^ z)).Combine(Value[x], Value[y], Value[z]);
    }
    public byte[] Value { get; }
}