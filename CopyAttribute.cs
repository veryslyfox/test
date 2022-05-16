[Copy("Copy")]
sealed class CopyAttribute : Attribute
{
    public CopyAttribute()
    {
        FileName = "AttributeCopyFile.cs";
    }
    public CopyAttribute(string fileName)
    {
        FileName = fileName;
    }

    public string FileName { get; }
    public static class ActiveCopy
    {

        public static void OnCopy(Assembly assembly, ReflectData reflectData)
        {
            var types = assembly.GetTypes().Where((Type type) => type.GetCustomAttributes(typeof(CopyAttribute)) is not null);
        }
    }
}