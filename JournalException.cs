#pragma warning disable
class Journal
{
    private List<string> surrogateCode;

    public Journal()
    {
        Code = new List<string>();
    }
    public Journal(IEnumerable<string> code)
    {
        Code = new List<string>(code);
    }
    public Journal(params string[] code)
    {
        Code = code.ToList();
    }
    public void Journaling(string message)
    {
        Code.Add(message);
    }

    public string Sum()
    {
        var accumulator = "";
        foreach (var item in Code)
        {
            accumulator += item + " ";
        }
        return accumulator;
    }
    public List<string> Code { get; private set; }
    public List<string> SurrogateCode { get => surrogateCode; private set => surrogateCode = value; }
    public static Journal Empty { get => new(); }
    public override int GetHashCode()
    {
        return Sum().GetHashCode();
    }
}
class JournalException : Exception
{
    protected Exception? _innerException;

    public JournalException()
    {
        Journal = new Journal();
    }
    public JournalException(Journal journal)
    {
        Journal = journal;
    }
    public JournalException(Journal journal, Exception innerException)
    {
        Journal = journal;
        _innerException = innerException;
    }
    public override string Message { get => Journal.Sum(); }
    public virtual Journal Journal { get; set; }
    public new Exception? InnerException => _innerException;
}