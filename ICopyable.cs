interface ICopyable<T>
{
    public void CopyTo(T buffer);
}
interface ICriticalCopyable<T> : ICopyable<T>
{
    public bool TryCopyTo(T buffer);
}
interface ISpanCopyable<T> : ICriticalCopyable<T>
{
    public bool CopyTo(T buffer, int offset, int count);
}