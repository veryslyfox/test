using System.Collections;
interface IObjectSerializable
{
    
}
struct Serialize : IEnumerable<KeyValuePair<string, byte[]>>
{
    public Serialize(IDictionary<string, byte[]> info)
    {
        Info = info;
    }

    public IDictionary<string, byte[]> Info { get; }

    public IEnumerator<KeyValuePair<string, byte[]>> GetEnumerator()
    {
        return null;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}