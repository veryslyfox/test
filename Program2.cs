#pragma warning disable 
using System.Dynamic;
using System.Diagnostics;
class PseudoRandom
{
    public int[] Random3(int seed1, int seed2, int seed3, int seed4, int seed5, int maxValue, int length)
    {
        var result = new int[length];
        for (int i = 0; i < length - 1; i++)
        {
            if (seed3 < 3)
            {
                seed1 = (seed2 + seed3) % maxValue;
                seed2 = (seed3 + (int)(Math.Sqrt(seed1 * seed3 * seed5))) % maxValue;
                seed3 = (seed1 + seed2) % maxValue;
                seed4 = (seed1 + seed2 + seed3 + seed4) % maxValue;
                seed5 = ((seed1 * seed2) * (seed3 / 3) + seed4 / seed5);
            }
            else
            {
                seed3 = (seed1 + seed2 + seed4 + seed5) % maxValue;
            }
            result[i] = ((seed1 - seed2 + seed3 - seed4 + seed5) % maxValue);
        }
        return result;
    }
    public int[] Random1(int seed, uint count, int[] generateParameters, int plus, int maxValue)
    {
        var indexator = generateParameters;
        var values = new int[count];
        for (int i = 0; i < values.Length - 1; i++)
        {
            foreach (var item in indexator)
            {
                seed *= item;
                seed += seed % item;
                seed += plus;
                seed %= maxValue;
            }
            values[i] = seed;
        }
        return values;
    }

    public int[] Random2(int seed1, int seed2, uint count, int maxValue)
    {
        var values = new int[count];
        for (int i = 0; i < count - 1; i++)
        {
            (seed1, seed2) = ((seed1 * seed1 + seed1 / seed2 + seed1 + seed2) % maxValue, seed1);
            values[i] = seed1;
        }
        return values;
    }
    public int[] Random4(int[][] g, byte pow, uint length, int maxValue)
    {
        var result = new int[length];
        for (int i = 0; i < g.GetLength(0); i++)
        {
            var accumulator = 0.0;
            for (int j = 0; j < g.GetLength(1); j++)
            {
                accumulator += (Math.Pow(g[i][j], pow)) % maxValue;
                g[i][j] += g[(i + 1) % g[i].Length][(j + 1) % g[j].Length];
            }
            result[i] = (int)accumulator;
        }
        return result;
    }
    public string ToString
    {
        get => "PseudoRandom";
    }
}
static partial class Program
{
    class Glass
    {
        protected double _filledVolume;
        public double TotalVolume { get; }
        public virtual double FilledVolume
        {
            get => _filledVolume;
            set
            {
                var newVolume = value;
                if (newVolume > TotalVolume)
                {
                    newVolume = TotalVolume;
                }

                _filledVolume = newVolume;
            }
        }
        public double Percent
        {
            get => 100.0 * FilledVolume / TotalVolume;
        }
        public Glass(double totalVolume = 250)
        {
            TotalVolume = totalVolume;
        }
        public static Glass operator +(Glass glass1, Glass glass2)
        {
            return new Glass(glass1.FilledVolume + glass2.FilledVolume);
        }
        public void PercentWrite()
        {
            Console.WriteLine($"{Percent} %");
        }
        public virtual bool GlassEquals(Glass obj)
        {
            return TotalVolume == obj.TotalVolume;
        }
        public bool IsFull
        {
            get => FilledVolume == TotalVolume;
        }
    }
    class Float
    {
        public int _mantiss;
        public sbyte _exponent;
        public Float(int mantiss, sbyte exponent)
        {
            _mantiss = mantiss;
            _exponent = exponent;
        }
    }
    class Pechat<T>
    {
        public int _form;
        public Pechat(int form)
        {
            _form = form;
        }
    }

    class Stone<T>
    {
        private T? _info;
    }

    class Tablix
    {
        public int[,] _values;
        public Tablix(int[,] values)
        {
            _values = values;
        }
        public Tablix()
        {
            _values = new int[0, 0];
        }
        public int[,]? Sum(Tablix v2)
        {
            var result = new int[_values.GetLength(0), _values.GetLength(1)];
            if (_values.GetLength(0) == v2._values.GetLength(0) && _values.GetLength(1) == v2._values.GetLength(1))
            {
                for (int column = 0; column < _values.GetLength(0) - 1; column++)
                {
                    for (int row = 0; row < _values.GetLength(1) - 1; row++)
                    {
                        result[column, row] = _values[column, row] + v2._values[column, row];
                    }
                }
                return result;
            }
            else
            {
                Console.WriteLine("Error");
                return null;
            }
        }
    }
    class PriorityList<T>
    {
        protected T[] _values;
        public PriorityList(T[] values)
        {
            _values = values;
        }
        public virtual void Add(T item)
        {
            var result = new T[_values.Length + 1];
            for (int i = 0; i < _values.Length; i++)
            {
                var i1 = _values[i];
                var i2 = _values[i + 1];
                if (Equals(item, i1) || Equals(item, i2))
                {
                    result[i] = item;
                    for (int k = i; k < _values.Length; k++)
                    {
                        result[k + 1] = _values[k];
                    }
                }
            }
        }
        public virtual void Delete(int index)
        {

        }
        public int Count
        {
            get => _values.Length;
        }
    }
}

class HashTable<T>
{
    protected List<T?> _values;
    protected int _length;
    public HashTable(int length)
    {
        _values = new List<T>(length);
        _length = length;
    }
    public void Add(T item, int offset)
    {
        var index = item.GetHashCode() + offset;
        var count = 0;
        if (_values[index] is null)
        {
            _values.Add(item);
        }
        else
        {
            if (count != _length)
            {
                count++;
                Add(item, offset + 1);
            }
            else
            {
                for (int i = 0; i < _length; i++)
                {
                    _values.Add(default(T?));
                }
            }
        }
    }

    public int Length
    {
        get => _length;
    }
}
class CuckooHashTable<T>
{
    protected T?[] _values;
    protected List<CuckooHashTable<T>> _newCuckoos = new List<CuckooHashTable<T>>();
    public CuckooHashTable(int length)
    {
        _values = new T[length];
    }
    public void Add(T item, int cuckuooLength)
    {
        var hash = item.GetHashCode() % _values.Length;
        if (_values[hash] is { })
        {
            _values[hash] = item;
        }
        else
        {
            var cuckuooHashTablix = new CuckooHashTable<T>(cuckuooLength);
            _newCuckoos.Add(cuckuooHashTablix);
            cuckuooHashTablix.Add(item, cuckuooLength);
        }
    }
    public List<CuckooHashTable<T>> NewCuckoos
    {
        get => _newCuckoos;
    }
    public T?[] HashValues
    {
        get => _values;
    }
}