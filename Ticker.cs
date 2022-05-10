static partial class Time
{
    public static byte ByteTicker()
    {
        return (byte)TimeRandom.TimeSpanRandom(10000, 256);
    }
}