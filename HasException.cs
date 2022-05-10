static partial class Program
{
    public static bool HasException(Action action)
    {
        try
        {
            action.Invoke();
            return false;   
        }
        catch
        {
            return true;
        }
    }   
}