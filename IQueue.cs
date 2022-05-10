namespace System.Collections.Generic;
interface IQueue<T>
{
    public void AddFirst();
    public void RemoveLast();
    public T Last();
    public int Capacity { get; set; }
    public int Count { get; }
}