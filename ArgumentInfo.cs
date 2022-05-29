#pragma warning disable
class ArgumentInfo : IEquatable<ArgumentInfo>
{
    public ArgumentInfo(Type type, string name, bool isParams = false, bool isOut = false, bool isIn = false)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"имя параметра не может быть неопределенным или пустым.", nameof(name));
        }
        isIn = (isIn && !isParams) && !isOut;
        isOut = isOut && !isParams;
        Type = type;
        Name = name;
        IsParams = isParams && TypeOperations.InheritanceChain(type)[1] == typeof(Array);
        IsOut = isOut;
        IsIn = isIn;
    }
    public ArgumentInfo(object? defaultValue, string name, bool isIn = false)
    {
        var type = defaultValue.GetType();
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("имя параметра не может быть неопределенным или пустым.");
        }
        Type = type;
        DefaultValue = defaultValue;
        Name = name;
        IsParams = false;
        IsIn = isIn;
    }
    public Type Type { get; }
    public object? DefaultValue { get; }
    public string Name { get; }
    public bool IsParams { get; }
    public bool IsOut { get; }
    public bool IsIn { get; }

    public override bool Equals(object? other)
    {
        return other is ArgumentInfo info
            && Name == info.Name
            && IsOut == info.IsOut
            && IsIn == info.IsIn;
    }

    public bool Equals(ArgumentInfo? other)
    {
        return Equals((object)other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(DefaultValue, FullName, IsIn, IsOut, IsParams, Type);
    }
    public override string ToString()
    {
        if (IsParams)
        {
            return $"params {FullName}";
        }
        if (IsOut)
        {
            return $"out {FullName}";
        }
        if (IsIn)
        {
            return  $"in {FullName}";
        }
        return FullName;
    }
    public string FullName
    {
        get => $"{Type} {Name}";
    }
    public ArgumentInfo? TryParse(string s) 
    {
        return null;
    }
}