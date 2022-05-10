static partial class MemoryAnalysis
{
    public static bool GetBoolAdressValue(int value, uint index)
    {
        if (index > 31)
        {
            throw new BoolIndexException(index, typeof(int));
        }
        if (index != 31)
        {
            if (value != int.MinValue)
            {
                var bits = Program.Convert((ulong)value, 2);
                if (index < bits.Length)
                {
                    return bits[index] == 1;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return value < 0;
        }
    }
}
