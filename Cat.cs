#pragma warning disable 
namespace Animals;
using System;

class Cat : Animal
{
    public Cat(string name)
        : base(name)
    {
    }
    public static explicit operator Fox(Cat cat) => new(cat.Name);

    public override void Vocalize()
    {
        if (!IsAsleep)
        {
            Console.WriteLine($"мяу - мяу I am {Name}");
        }
        else
        {
            Console.WriteLine("ш - ш - ш");
        }
    }
    public void Meow(int meowCount)
    {
        if (!IsAsleep)
        {
            for (int i = 0; i < meowCount; i++)
            {
                Console.WriteLine("мяу");
            }
        }
        else
        {
            Console.WriteLine("ш - ш - ш");
        }
    }
    public Meower GetMeower()
    {
        return new(this);
    }
}
class Meower
{
    public Meower(string name)
    {
        MeowCat = new Cat(name);
    }
    public Meower(Cat cat)
    {
        MeowCat = cat;
    }
    public void Meow()
    {
        MeowCat.Vocalize();
    }
    public void Meow(int meowCount)
    {
        MeowCat.Meow(meowCount);
    }
    public Cat MeowCat { get; }
    public string Name { get => MeowCat.Name; }
}