static partial class Program
{
    static void BinarySearchWrite(int minValue, int maxValue)
    {
        var count = 0;
        for (int i = 1; i <= maxValue - minValue; i *= 2)
        {
            count++;
        }
        Console.WriteLine($"обещаю угадать число не более чем за {count} шагов");
        Console.WriteLine("введите 1 если ваше число меньше, введите 2 если ваше число больше");
    }
    static void BinarySearch(int minValue, int maxValue, int recurse)
    {
        BinarySearchWrite(minValue, maxValue);
        BinarySearchStruct(minValue, maxValue, recurse);
    }


    static void BinarySearchStruct(int minValue, int maxValue, int recurse)
    {
        int c = (minValue + maxValue) / 2;
        int searchEtaps = 0;
        for (int i = 1; i <= maxValue - minValue; i *= 2)
        {
            searchEtaps++;
        }
        if (searchEtaps > recurse)
        {
            Console.WriteLine(c);
            var readCorrect = Console.ReadLine();
            if (readCorrect == "1")
            {
                BinarySearchStruct(minValue, c, recurse + 1);
            }
            else
            {
                if (readCorrect == "2")
                {
                    BinarySearchStruct(c, maxValue, recurse + 1);
                }
                else
                {
                    Console.WriteLine("введите ещё раз");
                    BinarySearchStruct(minValue, maxValue, recurse);
                }
            }
        }
        else
        {
            Console.WriteLine($"{maxValue} - ваше число");
            return;
        }
    }

}