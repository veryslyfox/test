class FixedLibrary<T>
{
    public bool[] _isFull;
    public T[] _library;
    public FixedLibrary(int count)
    {
        _library = new T[count];
        _isFull = new bool[count];
        for (int i = 0; i < count; i++)
        {
            _isFull[i] = false;
        }
    }
    public T this[int index]
    {
        get
        {
            if (!_isFull[index])
            {
                throw new NotValueException();
            }
            else
            {
                return _library[index];
            }
        }
        set
        {
            if(_isFull[index])
            {
                _isFull[index] = true;
                value = _library[index];
            }   
        }
    }
}

class NotValueException : Exception { }