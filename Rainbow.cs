static partial class Program
{
    static void Rainbow()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write('r');
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write('a');
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write('i');
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write('n');
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write('b');
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write('o');
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine('w');
        Console.ForegroundColor = ConsoleColor.White;
    }
}