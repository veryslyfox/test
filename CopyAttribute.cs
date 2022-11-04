using System.Reflection;
[Copy("Copy")]
sealed class CopyAttribute : Attribute
{
    public CopyAttribute()
    {
        #pragma warning disable 
        ActiveCopy.OnCopy(Assembly.GetAssembly(typeof(Program)));
        #pragma warning restore
        FileName = "AttributeCopyFile.cs";
    }
    public CopyAttribute(string fileName)
    {
        FileName = fileName;
    }

    public string FileName { get; }
    public static class ActiveCopy
    {

        public static void OnCopy(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                var attribute = type.GetCustomAttribute<CopyAttribute>();
                if (attribute == null)
                {
                    continue;
                }

            }
        }
    }
}