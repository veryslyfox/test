#pragma warning disable 
namespace Animals;

abstract class Animal : INameable, ISizable, IEquatable<Animal>
{
    public Animal(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
    public int Size
    {
        get => Name.Length * 2;
    }
    public string Name { get; }
    public bool IsAsleep { get; private set; }
    public void Wake()
    {
        IsAsleep = false;
    }
    public void Sleep()
    {
        IsAsleep = true;
    }

    public abstract void Vocalize();

    public override bool Equals(object? obj)
    {
        return obj is Animal animal &&
               Size == animal.Size &&
               Name == animal.Name &&
               IsAsleep == animal.IsAsleep;
    }

    public override int GetHashCode() => HashCode.Combine(Size, Name, IsAsleep);

    public static bool operator ==(Animal? x, Animal? y)
    {
        if (x is null && y is null)
        {
            return true;
        }
        if (x is { } && y is null)
        {
            return false;
        }
        if (x is null && y is { })
        {
            return false;
        }
        if (x.GetType() != y.GetType())
        {
            return false;
        }
        if (x.Name == y.Name)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public virtual bool Equals(Animal? animal)
    {
        return this == animal;
    }
    public static bool operator !=(Animal? x, Animal? y) => (!(x == y));
}
