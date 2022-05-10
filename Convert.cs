static partial class Program
{
    public static ushort[] Convert(ulong value, ushort systemBase)
    {
        var count = 0;
        for (ulong i = 1; i <= value; i *= systemBase)
        {
            count++;
        }
        var result = new ushort[count];
        for (int i = 0; i < result.Length; i++)
        {
            result[result.Length - 1 - i] = (ushort)((value / (ulong)Math.Pow(systemBase, i)) % systemBase);
        }
        return result;
    }
    public static byte[] Convert(ulong value)
    {
        var count = 0;
        for (ulong i = 1; i <= value; i *= 256)
        {
            count++;
        }
        var result = new byte[count];
        for (int i = 0; i < result.Length; i++)
        {
            result[result.Length - 1 - i] = (byte)((value / (ulong)Math.Pow(256, i)) % 256);
        }
        return result;
    }
    public static byte[] Convert(uint value)
    {
        var count = 0;
        for (ulong i = 1; i <= value; i *= 256)
        {
            count++;
        }
        var result = new byte[count];
        for (int i = 0; i < result.Length; i++)
        {
            result[result.Length - 1 - i] = (byte)((value / (uint)Math.Pow(256, i)) % 256);
        }
        return result;
    }
}
