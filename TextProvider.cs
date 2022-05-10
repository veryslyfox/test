class TextProvider : IDisposable, IEquatable<TextProvider>
{
    public TextProvider(string value = "")
    {
        Value = value;
    }

    public string Value { get; private set; }

    public void Write(string write)
    {
        Value += write;
    }
    public void CopySliceFrom(int start, int count, IEnumerable<char> buffer)
    {
        buffer = Value.AsSpan(start, count).ToArray();
    }
    public void Dispose()
    {
        Value = "";
    }
    public string GetString(IEnumerable<char> chars)
    {
        return new(chars.ToArray());
    }

    public bool Equals(TextProvider? other)
    {
        return other.Value == Value;
    }
}