#pragma warning disable
class StringHashTable
{
    protected int _length;
    public StringHashTable(int length)
    {
        _length = length;
    }
    protected LinkedList<(string, int)>[] table;
    public void Add(string s)
    {
        var hash = HashFunc(s);
        table[hash % _length].AddLast((s, hash));
    }

    private static int HashFunc(string s)
    {
        var accumulator = 0;
        foreach (var item in s)
        {
            accumulator += (int)item;
        }
        return accumulator;
    }
    public int? Do(string s, bool isThrow)
    {
        if (table[HashFunc(s)] is { })
        {
            return Do(s, table[HashFunc(s)].First, 0, isThrow);
        }
        else
        {
            
            return null;
        }
    }

    private int Do(string s, LinkedListNode<(string, int)> linkedListNode, int recurse, bool isThrow)
    {
        var linked = table[HashFunc(s)];
        for (int i = 0; i < linked.Count; i++)
        {
            if (linkedListNode.Value.Item1 == s)
            {
                return linkedListNode.Value.Item2;
            }
            else
            {
                if (recurse <= table[HashFunc(s)].Count)
                {
                    if (linkedListNode.Next is { })
                    {
                        Do(s, linkedListNode.Next, recurse + 1, isThrow);
                    }
                }
            }
        }
        if (isThrow)
        {
            throw new ArgumentException();
        }
        Console.WriteLine("Error");
        return 0;
    }
}