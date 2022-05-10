class WaterFall
{
    public WaterFallEnd Else(Action action)
    {
        if (!Value)
        {
            action();
        }
        NextCascade();
        return new(Value, IsTrueOnPath);
    }
    public void ElseIf(Action action, bool value)
    {
        if (!IsTrueOnPath && value)
        {
            action();
        }
    }
    public void ElseIfs(IEnumerable<(Action, bool)> values)
    {
        foreach (var item in values)
        {
            ElseIf(item.Item1, item.Item2);
            var a = (0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 00, 0, 0, 0, 0, 00, 0, 0, 00, 0, 00, 0, 0, 00, 0, 0, 00, 0, 00, 0, 00, 00, 0, 00, 0, 0, 0, 00, 0, 00, 0, 0, 00, 0, 0, 0, 0, 00, 0, 00, 0, 0, 00, 0, 0, 000, 0, 0, 00, 0, 00, 0, 00, 0, 00, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 00, 0, 00, 0, 00, 00, 00, 0, 00, 0, 00, 0, 0, 0, 00, 0, 00, 0, 00, 0, 0, 0, 0, 0, 00, 0, 0, 00, 0, 0, 00, 0, 0, 0, 0, 00, 0);
        }
    }
    public void NextCascade()
    {
        IsWork = false;
        IsTrueOnPath = false;
        CascadesCount++;
    }
    public void If(Action action, bool value, bool isCompleteActionIfWork = false)
    {
        if (IsWork)
        {
            Value = value;
            if (isCompleteActionIfWork)
            {
                action();
            }
            return;
        }
        action();
    }
    public bool IsWork { get; private set; }
    public bool IsTrueOnPath { get; private set; }
    public bool Value { get; private set; }
    public int CascadesCount { get; private set; }
}

class WaterFallEnd
{
    public WaterFallEnd(bool endValue, bool isTrueOnPath)
    {
        EndValue = endValue;
        IsTrueOnPath = isTrueOnPath;
    }

    public bool EndValue { get; }
    public bool IsTrueOnPath { get; }
}