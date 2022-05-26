#pragma warning disable
static class Serializator
{
    public static byte[] ToBytes(char value)
    {
        return ToBytes((ushort)value);
    }
    public static byte[] ToBytes(ushort value)
    {
        return new byte[] { (byte)(value / 256), (byte)(value % 256) };
    }
    public static byte[] ToBytes(uint value)
    {
        return Program.Convert(value);
    }
    public static byte[] ToBytes(int value)
    {
        return Program.Convert((uint)value);
    }
    public static byte[] ToBytes(ulong value)
    {
        return Program.Convert(value);
    }
    public static byte[] ToBytes(long value)
    {
        return Program.Convert((ulong)value);
    }
    public static byte[] ToBytes(string? value)
    {
        byte[] result = new byte[] { };
        if (value == null)
        {
            return result;
        }
        foreach (var item in value)
        {
            result = (byte[])result.Union(ToBytes(item));
        }
        return result;
    }
    // public static void TryDeserialize(byte[] value, Type? type, out object? result)
    // {
    //     try
    //     {
    //         if (type == typeof(int))
    //         {
    //             result = value[3] * 16777216 + value[2] * 65536 + value[1] * 256 + value[0];
    //             //return true;
    //         }
    //     }
    //     catch (Exception exception)
    //     {
    //         throw new SerializeException($"{exception.Message}, deserialize exception", exception, value);
    //     }
    // }
}
class SerializeException : Exception
{
    public SerializeException(byte[] value) : base() { }
    public SerializeException(string message, byte[] value) : base(message)
    {
        Value = value;
    }
    public SerializeException(string message, Exception innerException, byte[] value) : base(message, innerException)
    {
        Value = value;
    }
    public SerializeException(string message, Exception innerException, object value)
    : base(message, innerException)
    {
        new SerializeException("abc", new Exception(), 8);
        IsSerialize = true;
        Value = value;
    }
    public bool IsSerialize { get; }
    public object Value { get; }
}