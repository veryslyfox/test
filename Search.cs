static partial class Program
{
    static int Search(int[] values, int s)
    {
        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] == s)
            {
                return i;
            }
        }
        return -1;
    }
}
