class Polynom
{
    public Polynom(params int[] factors)
    {
        Factors = factors;
    }

    public int[] Factors { get; }
    public int Pow { get => Factors.Length; }
    public int GetValue(int value)
    {
        var r = 0;
        for (int i = 0; i < Pow; i++)
        {
            r += (int)(Factors[i] * Math.Pow(value, Pow - i));
        }
        return r;
    }
}