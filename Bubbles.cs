static class Bubbles
{
    static Cell[,] _field = new Cell[5, 40];
    static GameMode _gameMode = GameMode.Process;
    public static void Draw(this Cell cell)
    {
        void Print(char value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.White;
        }
        switch (cell)
        {
            case Cell.Empty:
                Print('+', ConsoleColor.White);
                break;
            case Cell.Blue:
                Print('+', ConsoleColor.Blue);
                break;
            case Cell.Green:
                Print('+', ConsoleColor.Green);
                break;
            case Cell.Red:
                Print('+', ConsoleColor.Red);
                break;
            case Cell.Yellow:
                Print('+', ConsoleColor.Yellow);
                break;
            case Cell.BlueProjectile:
                Print('^', ConsoleColor.Blue);
                break;
            case Cell.GreenProjectile:
                Print('^', ConsoleColor.Green);
                break;
            case Cell.RedProjectile:
                Print('^', ConsoleColor.Red);
                break;
            case Cell.YellowProjectile:
                Print('^', ConsoleColor.Yellow);
                break;
        }
    }
    public enum Cell
    {
        Empty,
        Blue,
        Green,
        Red,
        Yellow,
        BlueProjectile,
        GreenProjectile,
        RedProjectile,
        YellowProjectile,
    }
    enum GameMode
    {
        GameOver,
        Victory,
        Process
    }
    public static void Game()
    {
        for (int column = 0; column < _field.GetLength(1); column++)
        {
            for (int row = 0; row < _field.GetLength(0); row++)
            {
                _field[row, row] = Cell.Empty;
            }
        }
        while (_gameMode != GameMode.Process)
        {
            DrawField();
        }
    }
    static void ProcessInput()
    {
        //switch (Console.ReadKey().Key)
        //{

        //}
    }
    static void ProcessLogic()
    {

    }
    static void DrawField()
    {
        Console.SetCursorPosition(0, 0);
        foreach (var item in _field)
        {
            item.Draw();
        }
    }
    static void GenLevel()
    {

    }
}