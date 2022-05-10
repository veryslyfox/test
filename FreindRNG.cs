#pragma warning disable
global using System.Diagnostics.CodeAnalysis;

enum Pow
{
    Two,
    TwoAndHalf,
    Three,
    ThreeAndHalf,
    Random
}


class FreindRNG : ISizable
{

    public FreindRNG(int seed, FreindRNG[]? freinds)
    {
        Freinds = new(freinds);
        Seed = seed;
    }
    // public int Next(Pow[] pows)
    // {
        
    // }
    public HashSet<FreindRNG> Freinds { get; private set; }
    private int Seed { get; }

    public int Size
    {
        get
        {
            var count = 4;
            if (!(Freinds == new HashSet<FreindRNG>() || Freinds is null))
            {
                foreach (var freind in Freinds)
                {
                    count += freind.Size;
                }
            }
            return count;
        }
    }

    public void Calling(FreindCall call)
    {
        Freinds.Add(call.FreindRNG);
    }
    public FreindRNG this[int index]
    {
        get => Freinds.ToArray()[index];
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Freinds);
    }

    public override bool Equals(object? obj)
    {
        return obj is FreindRNG freindRNG &&
            freindRNG.Freinds == Freinds &&
            freindRNG.Seed == Seed;
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}

class FreindCall 
{
    public FreindCall(FreindRNG freindRNG, int seed)
    {
        FreindRNG = freindRNG;
        Seed = seed;
    }

    public FreindRNG FreindRNG { get; }
    public int Seed { get; }
}
