namespace Animals;
abstract class Carnivorous : Animal
{
    public Carnivorous(string name) : base(name)
    {   
    }
    public abstract void Eat(Animal animal);
    public void Eat(IEnumerable<Animal> animals)
    {
        foreach (var item in animals)
        {
            Eat(item);   
        }
    }
}