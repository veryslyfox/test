class SymbolTree
{
    public SymbolTree(char root, List<SymbolTree>? trees)
    {
        Root = root;
        Trees = trees;
        TreesPtr = (Set<char>)trees.Select((SymbolTree tree) => tree.Root);

    }

    public char Root { get; }
    public Set<char> TreesPtr { get; }
    public List<SymbolTree>? Trees { get; }
    public SymbolTree? this[char index]
    {
        get
        {
            for (int i = 0; i < TreesPtr.Count - 1; i++)
            {
                if (Trees == null)
                {
                    return null;
                }
                if (TreesPtr[i] == index)
                {
                    return Trees[i];
                }
            }
            return null;
        }
    }
    public SymbolTree? this[string index]
    {
        get
        {
            var result = this;
            if (result == null)
            {
                return null;
            }
            for (int i = 0; i < index.Length - 1; i++)
            {
                result = result[index[i]];
            }
            return result;
        }
    }
}