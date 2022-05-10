static partial class Program
{
    //Concatenate two files 
    static void Concatenate(string fileName1, string fileName2, string name)
    {
        using var file1 = File.Open(fileName1, FileMode.Open);
        using var file2 = File.Open(fileName2, FileMode.Open);
        using var file = File.Open(name, FileMode.Create);
        var buffer = new byte[1 << 20];
        while (true)
        {
            var bytes = file1.Read(buffer, 0, buffer.Length);
            if (bytes == 0)
            {
                break;
            }
            file.Write(buffer, 0, bytes);
        }
        while (true)
        {
            var bytes = file2.Read(buffer, 0, buffer.Length);
            if (bytes == 0)
            {
                break;
            }
            file.Write(buffer, 0, bytes);
        }
    }
}