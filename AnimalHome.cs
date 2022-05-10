#pragma warning disable 
namespace Animals;

class AnimalHome
{
    protected Animal? _animal;

    public void Enter(Animal animal)
    {
        _animal = animal;
    }
    public Animal? Animal => _animal;
}
