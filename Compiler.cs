static class Compiler
{
    private static Context Context = new Context(new List<object>());
    public static int Cursor { get; set; }
    public static void Compile(string name)
    {

    }
    // public static void Execute(Expression expression)
    // {
    //     var i = 0;
    //     while (i < expression.Length - 1)
    //     {
    //         var symbol = expression.Code[i];
    //         switch (symbol)
    //         {
    //             case '[':
    //                 Context.Variables.Add(expression.ToNextChar(']').FromVariable());
    //                 i = Cursor;
    //                 break;
    //             case '(':
    //                 expression.ToNextChar(')').FromVariable();
    //                 break;
    //         }

    //     }
    // }
}

class Error
{
    public Error(string errorName, int errorString, int errorSymbol)
    {
        ErrorName = errorName;
        ErrorString = errorString;
        ErrorSymbol = errorSymbol;
    }

    public string ErrorName { get; }
    public int ErrorString { get; }
    public int ErrorSymbol { get; }
    public static List<Error> Errors = new List<Error>();
}

class ParseResult
{
    public IReadOnlyList<Error> Errors { get; } = new List<Error>();
}

class Expression
{
    public Expression(string code)
    {
        Code = code;
    }
    public IEnumerator<char> GetEnumerator()
    {
        return Code.GetEnumerator();
    }
    public string Code { get; }
    public int Length => Code.Length;
    public int Cursor { get; set; }
    public char Symbol { get => Code[Cursor]; }
    // Move cursor to the next specified char and return intermediate symbols and record specified Error to Error.Errors
    public string ToNextChar(char symbol)
    {
        var symbolIndex = Code.IndexOf(symbol, Cursor);
        if (symbolIndex < 0)
        {
            return $"Read error. Please, write character {symbol}";
        }
        var inner = Code.Substring(Cursor, symbolIndex - Cursor - 1);
        Cursor = symbolIndex + 1;
        return new(inner);
    }

}

public class InputLineParseResult
{
    public string Code { get; }
    public bool IsError { get; }
    public InputLineParseResult(string code)
    {
        Code = code;
    }
    public InputLineParseResult(bool error)
    {
        Code = "";
        IsError = error;
    }
    public object FromVariable()
    {
        if (int.TryParse(Code, out int i))
        {
            return i;
        }
        if (Code == "true")
        {
            return true;
        }
        if (Code == "false")
        {
            return false;
        }
        return Code;
    }
    // internal ParserInputLine TryParse()
    // {

    // }
}

class Context
{
    public Context(List<object> variables)
    {
        Variables = variables;
    }

    public List<object> Variables { get; }
}