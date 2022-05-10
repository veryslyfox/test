static partial class MemoryAnalysis
{
    #if false
    public static bool GetBoolAdressValue(long value, uint index)
    {
        if (index > 63)
        {
            throw new BoolIndexException(index, typeof(long));
        }
        if (index == 63)
        {
            return value < 0;
        }
        else
        {
            if (value >= 0)
            {
                return Program.Convert((ulong)Math.Abs(value), 2)[index] == 0;
            }
            else
            {
            }
        }
    }
    #endif
}