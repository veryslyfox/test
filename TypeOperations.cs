static partial class TypeOperations
{
    public static List<Type> InheritanceChain(Type type)
    {
        var types = new List<Type>();
        for (Type? t = type; t is not null; t = t.BaseType)
        {
            types.Add(t);
        }
        types.Reverse();
        return types;
    }

    public static int ObjectDistance(Type type)
    {
        return InheritanceChain(type).Count;
    }
    public static void TypeAttributeActive(Type? type)
    {
    }
}