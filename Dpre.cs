using System.Reflection;

class DpreData
{
    public DpreData(TypeSelector inPrivate, TypeSelector outPrivate, byte[] data, bool isDataFileName, IDpreReflector? dpreReflector)
    {
        InPrivate = inPrivate;
        OutPrivate = outPrivate;
        Data = data;
        IsDataFileName = isDataFileName;
    }

    public TypeSelector InPrivate { get; }
    public TypeSelector OutPrivate { get; }
    public byte[] Data { get; }
    public bool IsDataFileName { get; }
}
interface IDpreReflector
{
    public void ReflectionPrivate(byte[] data, Assembly assembly, TypeSelector selector)
    {

    }
}
class TypeSelector
{
    public TypeSelector()
    {

    }
}