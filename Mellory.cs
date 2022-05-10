namespace System.Desecurity;
using System.Security.Cryptography;
class Mellory : Eve
{
    public byte[] Attach(Connection connection, byte[] surrogate)
    {
        return Attach(connection, surrogate);
    }
}