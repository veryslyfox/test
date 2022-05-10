#pragma warning disable
class MyMemory<T>
{
     public MyMemory(int count)
     {
          BoxMemories = new MyMemoryBox<T>[count];
          Count = count;
     }

     public MyMemoryBox<T>?[]? BoxMemories { get; private set; }
     public int Count { get; }

     public (bool, int) TryWrite(T data)
     {
          if (BoxMemories is null)
          {
               BoxMemories = new MyMemoryBox<T>[Count];
          }
          for (int i = 0; i < BoxMemories.Length; i++)
          {
               var item = BoxMemories[i];
               if (item is null)
               {
                    item = new(data);
                    return (true, i);
               }
          }
          return (false, -1);
     }
     public bool TryWrite(int index, T data)
     {
          if (BoxMemories is not null)
          {
               bool b = BoxMemories[index] is null;
               return b;
          }
          else
          {
               BoxMemories = new MyMemoryBox<T>[Count];
               BoxMemories[index] = new(data);
               return true;
          }
     }
     public MyMemoryBox<T> this[int index]
     {
          get
          {
               if (BoxMemories != null)
               {
                    var box = BoxMemories[index];
                    if (box != null)
                    {
                         return box;
                    }
                    else
                    {
                         return default;
                    }
               }
               else
               {
                    return default;
               }
          }
          set { }
     }
}
class MyMemoryBox<T>
{
     public MyMemoryBox(T value)
     {
          Value = value;
     }

     public T Value { get; private set; }

     public override bool Equals(object? obj)
     {
          return obj is MyMemoryBox<T> box &&
                 Equals(Value, box.Value);
     }

     public override int GetHashCode()
     {
          return HashCode.Combine(Value);
     }
}