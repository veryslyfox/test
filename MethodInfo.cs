class Method
{
    public Method(Type type, ArgumentSet argumentInfos, string name, string currentNamespace)
    {
        ArgumentInfos = argumentInfos;
        Name = name;
        CurrentNamespace = currentNamespace;
    }

    public ArgumentSet ArgumentInfos { get; }
    public string Name { get; }
    public string CurrentNamespace { get; }
}