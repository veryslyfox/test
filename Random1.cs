#pragma warning disable
static class Random1 
{
    public static int Generate(int iterations, string hash, params int[] seeds)
    {
        var aggregate = seeds.Aggregate((arg0, arg1) => (byte)((int)arg0 + (int)arg1));
        for (int i = 0; i < iterations; i++)
        {
            hash += hash;
        }
        return aggregate * iterations + aggregate + iterations + hash.GetHashCode();
    }
}