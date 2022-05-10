namespace System.Desecurity;
using System.Security.Cryptography;
class Eve
{
    public static PropertyInfo[] Properties { get => typeof(Connection).GetProperties(BindingFlags.NonPublic); }
    public List<Connection>? Connections { get; private set; }
    //public byte[] GetConncetionData()
    //{

    //}
}
