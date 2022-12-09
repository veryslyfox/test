struct Dot
{
    public Dot(int i, int j)
    {
        I = i;
        J = j;
    }

    public int I { get; }
    public int J { get; }
}
struct Line
{
    public Line(int offset, float angle)
    {
        Offset = offset;
        Angle = angle;
    }

    public int Offset { get; }
    public float Angle { get; }
}