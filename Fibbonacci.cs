#pragma warning disable
class Fibonacci : IClaimer
{
    public long _base1;
    public long _base2;
    public uint _rows = 0;
    private List<(long, long)> _bases;
    public long _longHash;
    public Fibonacci()
    {
            _base2 = 1;
    }
    public long[] FibonachiRow(uint length)
    {
          _base2 = 1;
          var result = new long[length];
        for (int i = 0; i < length - 2; i++)
        {
               _base1 = 0;
               result[i] = _base1;
               result[i + 1] = _base2;
            result[i + 2] = _base1 + _base2;
            (_base1, _base2) = (_base2, _base1 + _base2);
            // _bases[(int)_rows].Item1 = _base1;
            // _bases[(int)_rows].Item2 = _base2;
            _rows++;
        }
        _bases.Add((0, 1));
        return result;
    }
    public long[] FibonachiRow(uint length, long base1, long base2)
    {
        _base1 = base1;
        _base2 = base2;
        var result = new long[length];
        var accumulator = 0L;
        for (int i = 0; i < length - 2; i++)
        {
            result[i] = _base1;
            result[i + 1] = _base2;
            result[i + 2] = _base1 + _base2;
            (_base1, _base2) = (_base2, _base1 + _base2);
            _rows++;
            accumulator += base2;
        }
        _bases.Add((base1, base2));
        _longHash += accumulator;
        return result;
    }
    public uint GetRowsCount
    {
        get => _rows;
    }
    public (long, long)[] BasesArray
    {
        get => _bases.ToArray();
    }
    public override string ToString()
    {
        return "Fibonacci";
    }
    public override int GetHashCode()
    {
        return (int)_longHash;
    }
}
#if false
current object Do FibonachiRow
constructor elements : never;
operators :
never
mains :
override string ToString() :
return "Fibonacci";
override int GetHashCode() :
return sum rows values;
FibonachiRow(uint length) :
return specific length FibonachiRow
FibonachiRow(uint length, long base1, long base2) :
return specific length FibonachiRow and specific two first values 
flags 
{
    GetRowsCount : 
    get - count is a create rows
    BasesArray :
    get - array is a rows bases
}
#endif