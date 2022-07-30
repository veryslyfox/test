using MyMath;
static class Fractals
{
    public static DotArray JuliaSetCoordinates(Complex c, int x, int y)
    {
        var coordinates = new DotArray();
        for (int j = 0; j < y - 1; j++)
        {
            for (int i = 0; i < x - 1; i++)
            {
                Complex SquareIter(int value, Complex start)
                {
                    if (value > 0)
                    {
                        return SquareIter(value - 1, start) * SquareIter(value - 1, start) + c;
                    }
                    else
                    {
                        return start;
                    }
                }
                var maxCount = 0;
                for (int k = 0; k < 10; i++)
                {
                    Complex start = new Complex(i, j);
                    if (SquareIter(k + 1, start) <= SquareIter(k, start))
                    {
                        maxCount++;
                    }
                }
                if (maxCount < 5)
                {
                    coordinates.Add((i * x / 3, i * y / 3));
                }
            }
        }
        return coordinates;
    }
    public static void FractalVisualize(DotArray mains, (int, int) main)
    {
        var rng = new Random();
        var dotArray = mains;
        var current = main;
        while (true)
        {
            dotArray.Add(current);
            var randomMain = dotArray[]
        }
    }
}
class DotArray
{
    public DotArray() : this(new List<(int, int)>())
    {

    }
    public DotArray(List<(int, int)> dotCoordinates)
    {
        DotCoordinates = dotCoordinates;
    }
    public DotArray(params (int, int)[] dotCoordinates) : this(dotCoordinates.ToList())
    {

    }
    public bool[,] AsFlags()
    {
        var maxX = int.MinValue;
        for (int i = 0; i < DotCoordinates.Count; i++)
        {
            maxX = Math.Min(maxX, DotCoordinates[i].Item1);
        }
        var maxY = int.MinValue;
        for (int i = 0; i < DotCoordinates.Count; i++)
        {
            maxY = Math.Min(maxY, DotCoordinates[i].Item2);
        }
        bool[,] result = new bool[maxX + 1, maxY + 1];
        for (int row = 0; row < maxY + 1; row++)
        {
            for (int column = 0; column < maxX + 1; column++)
            {
                result[column, row] = DotCoordinates.Contains((row, column));
            }
        }
        return result;
    }
    public void Visualize(char full, char empty)
    {
        var flags = AsFlags();
        for (int row = 0; row < flags.GetLength(1); row++)
        {
            for (int column = 0; column < flags.GetLength(0); column++)
            {
                var writeSymbol = flags[column, row] ? full : empty;
                Console.Write(writeSymbol);
            }
            Console.WriteLine();
        }
    }
    public List<(int, int)> DotCoordinates { get; set; }
    public bool[,] Flags
    {
        get => AsFlags();
    }
    public bool this[int column, int row]
    {
        get => Flags[column, row];
        set => Flags[column, row] = value;
    }
    public (int, int) this[int index]
    {
        get => DotCoordinates[index];
        set => DotCoordinates[index] = value;
    }
    public void Add((int, int) complex)
    {
        DotCoordinates.Add(complex);
    }
}