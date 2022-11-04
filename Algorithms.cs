static class Algorithms
{
    // static public int DSelect(int[] array)
    // {
    //     if (array.Length == 1)
    //     {
    //         return array[0];
    //     }
    //     if (array.Length == 2)
    //     {
    //         var rng = new Random();
    //         return array[rng.Next(2)];
    //     }
    //     var newArrayCount = (int)Math.Ceiling(((double)array.Length / 3.0));
    //     var newArray = new int[newArrayCount];
    //     (int, int, int) a = (0, 0, 0);
    //     while (true)
    //     {
    //         newArray = 
    //     }
    // }
    static void QuickSort(List<int> array)
    {
        var rng = new Random();
        if (array.Count is 0 or 1)
        {
            return;
        }
        if (array.Count == 2 && array[0] > array[1])
        {
            (array[0], array[1]) = (array[1], array[0]);
        }
        else
        {
            return;
        }
        var choosePivot = array[rng.Next(array.Count)];
        List<int> leftArray = new List<int>();
        List<int> rightArray = new List<int>();
        List<int> centralArray = new List<int>();
        for (int i = 0; i < array.Count; i++)
        {
            if (array[i] < choosePivot)
            {
                leftArray.Add(array[i]);
            }
            if (array[i] > choosePivot)
            {
                rightArray.Add(array[i]);
            }
            if (array[i] == choosePivot)
            {
                centralArray.Add(array[i]);
            }
        }
        QuickSort(leftArray);
        QuickSort(rightArray);
        array = leftArray.Concat(centralArray.Concat(rightArray)).ToList();
    }
    public static void QuickSort(int[] array)
    {
        QuickSort(array.ToList());
    }
    public static int Caratcube(int a, int b)
    {

    }
}