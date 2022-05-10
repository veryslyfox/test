namespace System.Collections.Generic;
class CureValues<T> : IEnumerable<T>
{
    protected List<T> _values;
    public CureValues(List<T> values)
    {
        _values = values;
    }
    public CureValues(IEnumerable<T> collection)
    {
        _values = (List<T>)collection;
    }
    public void Add(T item)
    {
        _values.Add(item);
    }
    public void Delete(int index, out T result)
    {
        result = _values[index];
        _values.Remove(_values[index]);
    }
    public IEnumerator<T> GetEnumerator()
    {
        IEnumerator<T> GetEnumerator2()
        {
            for (int i = 0; i < _values.Count; i++)
            {
                yield return _values[i];
            }
        }
        return GetEnumerator2();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
    public int CureCapacity
    {
        get => _values.Count;
        set
        {
            _values.Capacity = value;
        }
    }
    public T[] ToArray
    {
        get => _values.ToArray();
    }
    public List<T> ToList
    {
        get => _values;
    }
}