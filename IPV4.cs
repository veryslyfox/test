class IPV4
{
    public IPV4()
    {
        Prefix = new byte[] { };
    }
    public IPV4(int address, byte[] prefix)
    {
        if (prefix.Length > 3)
        {
            Prefix = new byte[] { prefix[0], prefix[1], prefix[2], prefix[3] };
        }
        else
        {
            Prefix = prefix;
        }
        Address = address;
    }

    public byte[] Prefix { get; init; }
    public int Address { get; init; }
}
