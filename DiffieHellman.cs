class DHOpenKey
{
    public DHOpenKey(int g, int p)
    {
        G = g;
        P = p;
    }

    public int G { get; }
    public int P { get; }
    // value => G^value mod P
    public int Encrypt(int value)
    {
        var result = 1;
        for (int i = 0; i < value; i++)
        {
            result *= G;
            result = result % P;
        }
        return result;
    }
}
class DHSender
{
    public DHSender(DHOpenKey key)
    {
    }
    public void GenerateKey()
    {
        Random.Next();  
    }
    static Random Random = new Random();
} 
class ECCurve
{
    public ECCurve(int a, int b, int m)
    {

    }
}