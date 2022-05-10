namespace Graphic;
// w(x)= 
// n=0
// ∑
// ∞
// ​
//  b 
// n
//  cos(a 
// n
//  πππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππππx
static partial class Color
{
    public static void BigRainbow()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        RainbowWrite();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        RainbowWrite();
        Console.ForegroundColor = ConsoleColor.Yellow;
        RainbowWrite();
        Console.ForegroundColor = ConsoleColor.Green;
        RainbowWrite();
        Console.ForegroundColor = ConsoleColor.Blue;
        RainbowWrite();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        RainbowWrite();
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        RainbowWrite();
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void RainbowWrite()
    {
        for (int i = 0; i < 119; i++)
        {
            Console.Write('o');
        }
        Console.WriteLine();
    }
}
