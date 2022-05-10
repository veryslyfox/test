#pragma warning disable
class BoolIndexException : Exception, IEquatable<BoolIndexException>
{
    public BoolIndexException() {}
    public BoolIndexException(object? value) { Value = value; }
    public BoolIndexException(Type? exceptionType) { ExceptionType = exceptionType; }
    public BoolIndexException(uint index) { Index = index; }
    public BoolIndexException(uint index, Type? exceptionType) { Index = index; ExceptionType = exceptionType; }
    public BoolIndexException(uint index, object value) { Index = index; Value = value; ExceptionType = value.GetType(); }
    public BoolIndexException(uint index, object value, string message, Exception? innerException) :
    base(message, innerException)
    {
        Index = index; Value = value; ExceptionType = value.GetType();
    }
    public Type? ExceptionType { get; init; }
    public uint Index { get; init; }
    public object Value { get; init; }

    public bool Equals(BoolIndexException? other)
    {

        return (this is null && other is null)
            && !(this is null && other is not null)
            && !(this is not null && other is null)
            || ExceptionType == other.ExceptionType
            && Index == other.Index;
    }
    public override string Message =>
     $"был указан неверный индекс {Index} при адресации {(Value == null ? Value : ExceptionType)}";
}
