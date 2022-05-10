using System.Diagnostics;
static partial class Time
{
    
}
static class TimeRandom
{
    public static byte Byte()
    {
        return Time.ByteTicker();
    }
    public static sbyte SByte()
    {
        return (sbyte)Time.ByteTicker();
    }
    public static long TimeSpanRandom(int tickValue, long maxValue)
    {
        var rng = new Random();
        var a = 0L;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < tickValue; i++)
        {
            a = rng.NextInt64() * rng.NextInt64();
        }
        return stopwatch.ElapsedTicks % maxValue;
    }
}
#if false
byte generate algorythm
{
    1000000 iterations operation 
    {
        two random 64 - bit integers multiplication
    }
}
#endif