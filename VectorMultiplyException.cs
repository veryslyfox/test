#pragma warning disable
class VectorMultiplyException : Exception
{
    public VectorMultiplyException() { }
    public VectorMultiplyException(string message) : base(message) { }
    public VectorMultiplyException(string message, Vector multiplyer1, Vector multiplyer2) : base(message)
    {
        Multiplyer1 = multiplyer1;
        Multiplyer2 = multiplyer2;
    }

    public Vector Multiplyer1 { get; }
    public Vector Multiplyer2 { get; }
}
