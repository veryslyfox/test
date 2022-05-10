static partial class Program
{
    static void MathFocus1Write()
    {
        Console.WriteLine("задумайте число от 0 до 1000");
        Console.WriteLine("число возведите в квадрат(запомните)");
        Console.WriteLine("к исходному числу прибавьте что - то(и введите что)");
        Console.WriteLine("найдите квадрат суммы");
        Console.WriteLine("найдите разность квадратов и введите");
    }
    static void MathFocus1Struct()
    {
        var d = Console.ReadLine();
        var number = Console.ReadLine();
        if (double.TryParse(number, out var parse1) && double.TryParse(d, out var parse2))
        {
            var result = parse1 / (2.0 * parse2) - (parse2 / 2.0);
            Console.WriteLine(result);
        }
        else
        {
            MathFocus1Struct();
        }
    }
    static void MathFocus1()
    {
        MathFocus1Write();
        MathFocus1Struct();
    }   
}