static partial class Program
{
    static int[] _weights = new int[100];
    static int Weight(string s)
    {
        return s.Sum((char c) => _weights[(int)c]);
    }
    
}
interface IText
{
    string NextLine();
}