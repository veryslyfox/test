#pragma warning disable 
namespace Animals;

class Fox : Carnivorous
{
    public Fox(string name)
        : base(name)
    {
    }

    public static explicit operator Cat(Fox fox) => new(fox.Name);
    public override void Vocalize()
    {
        if (!IsAsleep)
        {
            Console.WriteLine("фыр - фыр");
        }
    }

    public void Bite()
    {
        if (!IsAsleep)
        {
            Console.WriteLine("клац! клац!");
        }
    }

    public override void Eat(Animal animal)
    {
        animal.Vocalize();
        Console.WriteLine("а - а - а - а - а - а!");
    }
}
