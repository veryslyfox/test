namespace Animals;
enum AnimalsTypes
{
    Cat,
    Fox,
    Mouse,
    Penguin,
    Owl,
}
class Zoo : INameable
{
    
    private List<Animal> _zoo;
    public Zoo(string name)
    {
        _zoo = new List<Animal>();
        Name = name;
    }
    public Zoo(int capacity, string name)
    {
        _zoo = new List<Animal>(capacity);
        Name = name;
    }
    public Zoo(IEnumerable<Animal> collection, string name)
    {
        _zoo = new List<Animal>(collection);
        Name = name;
    }
    public void Add(Animal animal)
    {
        foreach (var item in _zoo)
        {
            if (item == animal)
            {
                return;
            }
        }
        _zoo.Add(animal);
    }
    public string Name { get; }
}
