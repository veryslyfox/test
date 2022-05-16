class CipherStream
{
    public CipherStream()
    {
        Bytes = new List<IEnumerable<byte>>();
    }
    public CipherStream(IEnumerable<IEnumerable<byte>> bytes)
    {
        Bytes = bytes.ToList();
    }
    public CipherStream(int capacity)
    {
        Bytes = new List<IEnumerable<byte>>(capacity);
    }

    public List<IEnumerable<byte>> Bytes { get; private set; }
    public override int GetHashCode()
    {
        var code = new HashCode();
        foreach (var item in Bytes.SelectMany(i => i))
        {
            code.Add(item);
        }
        return code.ToHashCode();
    }
    public bool Hammation(byte key, int index)
    {
        var result = index < Bytes.Count;
        if (result)
        {
            Bytes[index] = Bytes[index].Select(i => (byte)(i ^ key));
        }
        return result;
    }
    public void Add(byte[] value)
    {
    }
    public bool Add(int index, byte[] value)
    {
        if(index < 0 || index >= Bytes.Count)
        Bytes.Insert(index, value);
    }
}