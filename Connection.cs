namespace System.Security.Cryptography;
#pragma warning disable
class Connection
{
    public Sender Alice { get; }
    public Sender Bob { get; }
    private byte[] DataStream { get; set; }
    
}
