
// global using static System.Math;
// try
// {

//     var text1 = @"
// Ужас!
// ";
//     var text2 = @"
// Я сжёг книгу, фу
// ";

//     var text3 = @"
// Чёрт побери, как такую нехорошую, ужасную книгу мы купили!
// ";

//     var text4 = @"
//     Какая прекрасная книга!
//     Мне и моим родственникам понравилось.
// ";

//     var text5 = @"
//     Очень интересный и тонкий сюжет.  
// ";

//     var text6 = @"
//     Эта книга интересна, хороша собой!
// ";
//     NeuralNetwork recurrent = NeuralNetwork.GetRandomNetwork(0, 10, "8,10,10,4", 0.00001, 10000000, true);
//     var loss = 1000000.0;
//     while(loss > 0.1)
//     {
//         loss = recurrent.CorrectAll(Error);
//         Console.WriteLine(loss);
//         Console.WriteLine("T");
//     }
// #pragma warning disable
//     double Error(NeuralNetwork network)
//     {
//         return
//            Abs(network.PropagateText(text1).Sum())
//          + Abs(network.PropagateText(text2).Sum())
//          + Abs(network.PropagateText(text3).Sum())
//          + Abs(network.PropagateText(text4).Sum() - 1)
//          + Abs(network.PropagateText(text5).Sum() - 1)
//          + Abs(network.PropagateText(text6).Sum() - 1);
//     }
// #pragma warning restore
// }
// catch (Exception exception)
// {
//     Console.Error.WriteLine(exception);
// }
// finally
// {
//     Console.ReadKey();
// }
// NeuralNetwork network = NeuralNetwork.GetRandomNetwork(0, 1, "10, 12, 12, 5", 0.0001, 1000, false);
// var file = File.Open("Text", FileMode.Open);
// BinaryReader reader = new BinaryReader(file);
// double Error(NeuralNetwork network)
// {
//     var err = 0;
//     for (int i = 0; i < 582; i++)
//     {
//         var snippet = reader.ReadBytes(10).Select(x => (double)x);
//         Vector begin = new(snippet.Take(6).ToArray());
//         Vector end = new(snippet.TakeLast(4).ToArray());
//     }
//     reader.BaseStream.Position = 0;
// }
using System.Diagnostics;

var abacus = new Abacus(10, 5);
var array = new bool[10];
var timer = new Stopwatch();
timer.Start();
Console.CursorVisible = false;
while(Console.ReadKey().KeyChar != 's'){}
while (!abacus.Stop)
{
    if ((double)timer.ElapsedTicks / Stopwatch.Frequency < 0.4)
    {
        continue;
    }
    timer.Restart();
    Console.SetCursorPosition(0, 0);
    Console.Write('|');
    var index = 0;
    for (int i = 0; i < 10; i++)
    {
        array[i] = false;
    }
    foreach (var item in abacus.Beads)
    {
        index += item;
        array[index] = true;
        index++;
    }
    foreach (var item in array)
    {
        Console.Write(item ? 'O' : ' ');
    }
    Console.Write('|');
    Console.WriteLine();
    abacus.Next();
}
Console.ReadKey();

sealed class Abacus
{
    public Abacus(int n, int k)
    {
        N = n;
        K = k;
        Beads = new int[k];
    }
    public void Next()
    {
        if (Stop)
        {
            return;
        }
        var sum = 0;
        for (int i = 0; i < K; i++)
        {
            sum += Beads[i];
        }
        if (sum == N - K)
        {
            SpecialMove();
        }
        else
        {
            Beads[K - 1]++;
        }
    }
    public void SpecialMove()
    {
        var index = K - 1;
        while (Beads[index] == 0)
        {
            if (index == 1)
            {
                Stop = true;
                return;
            }
            index--;
        }
        Beads[index - 1]++;
        Beads[index] = 0;
        Index = index;
    }
    public void Write(bool[] array)
    {
        array[Index] = false;
        var sum = 0;
        for (int i = 0; i < K; i++)
        {
            sum += Beads[i];
            array[sum] = true;
            sum++;
        }
    }
    int Index { get; set; }
    public int N { get; }
    public int K { get; }
    public int[] Beads { get; }
    public bool Stop { get; set; }
}