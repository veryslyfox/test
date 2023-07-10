class Person
{
    public Person(string name, uint age)
    {
        Name = name;
        Age = age;
    }
    public override bool Equals(object? obj)
    {
        return obj is Person person &&
            person.Age == Age &&
            person.Name == Name;
    }
    public override int GetHashCode()
    {
        return Name.AsSpan(0, Math.Min(5, Name.Length)).ToArray().Sum((char value) =>
         {
             return (value * value * value) ^ (value * value);
         });
    }
    public string Name { get; }
    public uint Age { get; set; }
}