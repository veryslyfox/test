struct Numbers
{
    public Numbers(int seed, int operation)
    {
        Seed = seed;
        Operation = operation;
        Generate = 0;
    }
    public int Seed { get; private set; }
    public int Operation { get; }
    public int Generate { get; private set; }
    public int New()
    {
        if (Generate % 2 == 0)
        {
            Seed &= Operation;
        }
        else
        {
            Seed |= Operation;
        }
        return Seed;
    }
}