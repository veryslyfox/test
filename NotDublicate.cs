namespace MyMath;
static partial class SetMaterial<T> 
{
    public static List<T> NotDublicate(List<T> value)
    {
        var result = value;
        for (int i = 0; i < value.Count; i++)
        {
            for (int k = 0; k < value.Count; k++)
            {
                if (k == i)
                {
                    continue;
                }
                else
                {
                    
                    if (Equals(i, k))
                    {
                        value.Remove(value[k]);
                    }
                }
            }
        }
        return result;
    }
}
