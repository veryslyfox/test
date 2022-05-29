using System.Reflection;
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

        public static void OnCopy(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                Pocket pocket = new Pocket();
            }
        }
    }
}