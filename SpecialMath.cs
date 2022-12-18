struct Dot
{
    public Dot(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }
}
struct Vector
{
    public Vector(int offset, double angle, bool direct)
    {
        Offset = offset;
        Angle = angle;
        Direct = direct;
    }
    public Vector(Dot begin, Dot end)
    {
        
        var a = begin.X;
        var b = begin.Y;
        var c = end.X;
        var d = end.Y;
        Angle = Math.Atan2(d - b, c - a);
        Offset = (double)d / (b - d);
        Direct = b < d;

    }
    public double Offset { get; }
    public double Angle { get; }
    public bool Direct; // true - up. false - down.
}