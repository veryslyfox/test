static class IOCreate
{
    public static byte[] ToBytes(FileStream file)
    {
        byte[] buffer = new byte[file.Length];
        file.Read(buffer);
        return buffer;
    }
}