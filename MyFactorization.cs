static partial class Program
{
    public static List<int> Factorization1(int value)
    {
        var result = new List<int> { };
        if (value != 1)
        {
            while (!IsPrime(value))
            {
                for (int i = 2; i < value / 2; i++)
                {
                    if (IsPrime(i) && value % i == 0)
                    {
                        result.Add(i);
                        value /= i;
                    }
                }
            }
        }
        return result;
    }
    public static List<int> Factorization2(int value)
    {
        var result = new List<int>();
        if (value != 1)
        {
            for (int i = 2; i < value; i++)
            {
                if (value % i == 0)
                {
                    var list = Factorization2(value / i);
                    var result2 = new List<int>(list.Count);
                    list.Add(i);
                    for (int k = 1; k < list.Count; k++)
                    {
                        list[i] = result[i];
                    }
                    break;
                }
            }
        }
        return result;
    }
    static bool IsPrime(int value)
    {
        if (value != 1)
        {
            var divisors = Math.Floor(Math.Sqrt(value));
            var ip = true;
            for (int i = 2; i <= divisors; i++)
            {
                if (value % i == 0)
                {
                    ip = false;
                }
            }
            return ip;
        }
        else
        {
            return false;
        }
    }

}