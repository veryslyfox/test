using System.Reflection;

class DpreData
{
    public DpreData(TypeSelector inPrivate, TypeSelector outPrivate, byte[] data, bool isDataFileName, IDpreReflector? dpreReflector, object? key = null)
    {
        InPrivate = inPrivate;
        OutPrivate = outPrivate;
        Data = data;
        IsDataFileName = isDataFileName;
        DpreReflector = dpreReflector;
        Key = key;
    }

    TypeSelector InPrivate { get; }
    TypeSelector OutPrivate { get; }
    byte[] Data { get; }
    public bool IsDataFileName { get; }
    public IDpreReflector? DpreReflector { get; }
    object? Key { get; }
}
interface IDpreReflector
{
    public void ReflectionPrivate(byte[] data, Assembly assembly, TypeSelector selector);
}
class TypeSelector
{
    public TypeSelector()
    {

    }
}