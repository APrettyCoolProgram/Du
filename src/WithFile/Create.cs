namespace Du.WithFile
{
    public class Create
    {
        public static void IfNonexistant(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }
    }
}
