static partial class Program
{
    static List<int> GetPrimes(int maxValue)
    {
        var values = new List<int> { };
        for (int i = 2; i < maxValue; i++)
        {
            var ip = true;
            for (int k = 2; k <= values.Count; k++)
            {
                if (i % values[k] == 0)
                {
                    ip = false;
                }
            }
            if (ip)
            {
                values.Add(i);
            }
        }
        return values;
    }
    static void VoidGetPrimes(int maxValue)
    {
        var values = new List<int> { };
        for (int i = 2; i < maxValue; i++)
        {
            var ip = true;
            for (int k = 2; k <= values.Count; k++)
            {
                if (i % values[k] == 0)
                {
                    ip = false;
                }
            }
            if (ip)
            {
                Console.WriteLine(i);
                values.Add(i);
            }
        }
    }

}
