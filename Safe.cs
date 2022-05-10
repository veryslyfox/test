#pragma warning disable
class Safe<TData, TPassword>
{
    public Safe(TData data, TPassword password)
    {
        Password = password;
    }
    TPassword Password { get; set; }
    TData Data { get; set; }
    public TData? GetData(TPassword password, TData defaultData = default)
    {
        if (Equals(password, Password))
        {
            return Data;
        }
        else
        {
            return defaultData;
        }
    }
}
class IntSafe : Safe<int, string>
{
    public IntSafe(int data, string password) : base(data, password) { }
}
internal class PasswordException<TPassword> : Exception
{
    public PasswordException()
    {
    }
    public PasswordException(TPassword password)
    {
        Password = password;
    }

    public TPassword Password { get; }
}
