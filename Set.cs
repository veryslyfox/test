#pragma warning disable
using MyMath;
class Set<T> : IEquatable<Set<T>>
{
    protected List<T> _list;
    public Set()
    {
        Constructor = "empty";
        _list = new List<T>();
    }
    public Set(IEnumerable<T> collection)
    {
        _list = SetMaterial<T>.NotDublicate(collection.ToList());
    }
    public Set(params T[] collection)
    {
        _list = SetMaterial<T>.NotDublicate(collection.ToList());
    }
    public Set(int capacity)
    {

        _list = new List<T>(capacity);
    }
    public Set(Set<T> cloneable)
    {
        _list = cloneable.List;
    }
    public string Constructor { get; }
    public string InnerConstructor { get; }
    public Set(T seed, Func<T, T> iterator, int length)
    {
        var list = new List<T>();
        var add = seed;
        for (int i = 0; i < length - 1; i++)
        {
            add = iterator(add);
            list.Add(add);
        }
        _list = SetMaterial<T>.NotDublicate(list);
    }
    public static explicit operator Set<T>(List<T> list)
    {
        return new(SetMaterial<T>.NotDublicate(list));
    }
    public static Set<T> operator &(Set<T> set1, Set<T> set2)
    {
        var result = new List<T>();
        for (int i = 0; i < set1.Capacity; i++)
        {
            for (int k = 0; k < set2.Capacity; k++)
            {
                if (Equals(set1[i], set2[k]))
                {
                    result.Add(set1[i]);
                }
            }
        }
        return new(result);
    }
    public static Set<T> operator |(Set<T> set1, Set<T> set2)
    {
        var result = new List<T>();
        for (int i = 0; i < set1.Count; i++)
        {
            for (int k = 0; k < set2.Count; k++)
            {
                result.Add(set2[k]);
            }
        }
        return new(result);
    }
    public static Set<T> operator -(Set<T> set1, Set<T> set2)
    {
        var result = Set<T>.Empty;
        for (int k = 0; k < set1.Count; k++)
        {
            result.List.Add(set1[k]);
        }
        for (int k = 0; k < set2.Count; k++)
        {
            result.List.Remove(set2[k]);
        }
        return result;
    }
    public static bool operator ==(Set<T> set, object obj) => obj.ToString() == set.ToString();
    public static bool operator !=(Set<T> set, object obj) => !(set == obj);

    public T[] Array
    {
        get => _list.ToArray();
    }
    public List<T> List
    {
        get => _list;
    }
    public int Count
    {
        get
        {
            if (_list is null)
            {
                return 0;
            }
            return _list.Count;
        }
    }
    public int Capacity
    {
        get => _list.Capacity;
        set
        {
            _list.Capacity = value;
        }
    }
    public T this[int index]
    {
        get => _list[index];
        set => _list[index] = value;
    }
    public bool Add(T item)
    {
        var result = true;
        foreach (var i in _list)
        {
            result = !i.Equals(item);
        }
        if (result)
        {
            _list.Add(item);
        }
        return result;
    }
    public override string ToString()
    {
        var accumulator = "";
        foreach (var item in _list)
        {
            accumulator += item.ToString();
        }
        return $"Set<{typeof(T)}>" + accumulator;
    }

    public override bool Equals(object? other)
    {
        if (other is null)
        {
            return false;
        }
        return other.ToString() == ToString();
    }

    public bool Equals(Set<T> other)
    {
        return this == other;
    }
    public override int GetHashCode()
    {
        var accumulator = 0;
        foreach (var item in _list)
        {
            accumulator += item.GetHashCode();
        }
        return accumulator;
    }
    public bool HasValue(T value)
    {
        for (int i = 0; i < Count; i++)
        {
            if (Equals(this[i], value))
            {
                return true;
            }
        }
        return false;
    }
    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }
    public static Set<T> Empty
    {
        get => new();
    }
    public int RemoveAll(Predicate<T> match)
    {
        return _list.RemoveAll(match);
    }
    public void RemoveLast()
    {
        _list.RemoveAt(_list.Count - 1);
    }
}
