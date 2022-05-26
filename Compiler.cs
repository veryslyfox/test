static class Compiler
{
    public static void Compile(string name)
    {
        var reader = new BinaryReader(File.Open(name, FileMode.Open));
        CompileCode(new(reader.ReadChars((int)reader.BaseStream.Length)));
    }
    public static void CompileCode(string code)
    {
        List<string> expressions = new();
        string currentExpression = "";
        foreach (var item in code)
        {
            if (item == ';')
            {
                expressions.Add(currentExpression);
                currentExpression = "";
            }
            currentExpression += item;
        }
        for (Reference<int> i = 0; i < expressions.Count; i++)
        {
            var expression = expressions[i];
            if (expression.AsSpan(0, 4) == "goto")
            {
                if (int.TryParse(expression.AsSpan(5), out var a))
                {
                    i = a;
                }
            }
            if (expression.AsSpan(0, 5) == "print")
            {
                Console.WriteLine(expression.AsSpan(6).Trim('"').ToArray());
            }
        }
    }
}