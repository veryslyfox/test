namespace System.Security.Cryptography;
#pragma warning disable
class Connection
{
    public DHSender Alice { get; }
    public DHSender Bob { get; }
    private byte[] DataStream { get; set; }
    
}
