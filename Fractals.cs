using MyMath;
static class Fractals
{
    public static DotArray JuliaSetCoordinates(Complex c, int x, int y)
    {
        var coordinates = new DotArray(x, y);
        for (int j = 0; j < y - 1; j++)
        {
            for (int i = 0; i < x - 1; i++)
            {
                var start = new Complex(i, j);
                var maxCount = 0;
                for (int k = 31; k > 0; k--)
                {
                    var a = SquareIter(k + 1, start);
                    var b = SquareIter(k, start);
                    if (a <= b)
                    {
                        break;
                    }

                    maxCount++;
                }

                //Console.WriteLine(maxCount);

                if (maxCount < 26)
                {
                    coordinates.Add(i, j);
                }
            }
        }
        return coordinates;

        Complex SquareIter(int value, Complex start)
        {
            if (value > 0)
            {
                var a = SquareIter(value - 1, start);
                return a * a * 2 + c;
            }
            else
            {
                return start;
            }
        }
    }
    public static void FractalVisualize(List<(int, int)> mains, int mainX, int mainY, char symbol)
    {
        var rng = new Random();
        var dotArray = mains;
        var currentX = mainX;
        var currentY = mainY;
        while (true)
        {
            dotArray.Add((currentX, currentY));
            var number = rng.Next(mains.Count);
            var randomMain = mains[number];
            mains[number] = (mainX / 2 + randomMain.Item1 / 2, mainY / 2 + randomMain.Item2/ 2);
            Console.SetCursorPosition(currentX, currentY);
            Console.WriteLine(symbol);
        }
    }
}
class DotArray
{
    public DotArray(int sizeX, int sizeY)
    {
        DotCoordinates = new bool[sizeX, sizeY];
    }
    public DotArray(bool[,] dotCoordinates)
    {
        DotCoordinates = dotCoordinates;
    }
    public void Visualize(char full, char empty)
    {
        var coordinates = DotCoordinates;
        for (int row = 0; row < coordinates.GetLength(1); row++)
        {
            for (int column = 0; column < coordinates.GetLength(0); column++)
            {
                var writeSymbol = coordinates[column, row] ? full : empty;
                Console.Write(writeSymbol);
            }
            Console.WriteLine();
        }
    }
    public bool[,] DotCoordinates { get; set; }
    public bool this[int column, int row]
    {
        get => DotCoordinates[column, row];
        set => DotCoordinates[column, row] = value;
    }
    public void Add(int x, int y)
    {
        DotCoordinates[x, y] = true;
    }
}