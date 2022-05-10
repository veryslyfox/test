static partial class MemoryAnalysis
{
    public static short GetExponent(double d)
    {
        var isInteger = d != (int)d;
        short count = 0;
        if (!isInteger)
        {
            while (!isInteger)
            {
                d *= 2;
                count++;
                isInteger = d != (int)d;
            }
        }
        else
        {
            while ((d / 2.0) !=  (int)(d / 2.0))
            {
                d /= 2.0;
            }
        }
        return count;
    }
    public static long GetMantiss(double d)
    {
        return (long)(d / Math.Pow(2, GetExponent(d)));
    }
}