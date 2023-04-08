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

    public TypeSelector InPrivate { get; }
    public TypeSelector OutPrivate { get; }
    public byte[] Data { get; }
    public bool IsDataFileName { get; }
    public IDpreReflector? DpreReflector { get; }
    public object? Key { get; }
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