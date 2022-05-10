#pragma warning disable 
class Model<T>
{
    private T _value;
    private List<(Predicate<T>, bool)> predicates;

    public List<T> History { get; private set; }
    public List<(Predicate<T>, bool)> Predicates { get => predicates; set => predicates = value; }
}