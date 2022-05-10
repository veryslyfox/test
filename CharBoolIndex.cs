static partial class MemoryAnalysis
{
    public static bool GetBoolAdressValue(char value, uint index)
    {
        if (index > 15)
        {
            throw new BoolIndexException(index, typeof(char));
        }
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
}