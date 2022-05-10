static partial class Program
{
    public static void CSharpGenerate(string text, string name, char[] s)
    {
        var digitableString = new byte[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            digitableString[i] = ((byte)text[i]);
        }
        var file = File.Open(name + ".cs", FileMode.OpenOrCreate);   
        file.Write(new Span<byte>(digitableString));
    }
}