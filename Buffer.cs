#pragma warning disable 
class Buffer<T> : IDisposable
{
    protected T?[] _buffer;
    protected bool[] _nulls;
    public Buffer(int count)
    {
        var buffer = new T?[count];
        var nulls = new bool[count];
        for (int i = 0; i < count; i++)
        {
            buffer[i] = default(T?);
            nulls[i] = true;
        }
        _buffer = buffer;
        _nulls = nulls;
    }
    public void Dispose()
    {
        for (int i = 0; i < _buffer.Length; i++)
        {
            _buffer[i] = default(T?);
            _nulls[i] = true;
        }
    }
    public bool HasValue(int index)
    {
        return _nulls[index];
    }
    public int NullCount
    {
        get
        {
            var count = 0;
            for (int i = 0; i < _buffer.Length; i++)
            {
                if (_buffer[i] is null)
                {
                    count++;
                }
            }
            return count;
        }
    }
    public int NotNullCount
    {
        get => _buffer.Length - NullCount;
    }
    public int Count
    {
        get => _buffer.Length;
    }
    public void Defaulting()
    {
        for (int i = 0; i < _buffer.Length; i++)
        {
            _buffer[i] = default(T);
        }
    }
    public T? this[int index]
    {
        get => _buffer[index];
        set
        {
            _nulls[index] = value is null;
            _buffer[index] = value;
        }
    }
}
