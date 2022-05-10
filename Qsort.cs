static partial class Program
{
    //O(n)
    static int[] Pivot(int[] a, int[] b, int[] c)
    {
        var array = new int[a.Length + 1 + c.Length];
        for (int i = 0; i < a.Length; i++)
        {
            array[i] = a[i];
        }
        for (int i = a.Length + 1; i < b.Length; i++)
        {
            array[i] = b[i];
        }
        for (int i = b.Length + 1; i < c.Length; i++)
        {
            array[i] = c[i];
        }
        return array;
    }
    static public void QuickSort(int[] values, int offset, int length)
    {
        if (length < 2)
        {
            return;
        }
        var pivot = values[offset + length - 1];

        int smallest = 0;
        for (int i = offset; i < offset + length; i++)
        {
            if (values[i] < pivot)
            {
                continue;
            }

            if (values[i] > pivot)
            {
                if (smallest <= i)
                {
                    smallest = i;
                }

                while (++smallest < offset + length)
                {
                    if (values[smallest] == pivot)
                    {
                        (values[i], values[smallest]) = (values[smallest], values[i]);
                    }
                }
            }

            if (values[i] == pivot)
            {
                QuickSort(values, offset, i - offset);
                QuickSort(values, i + 1, length - i - 1);
                break;
            }
        }
    }
    
}
