// 240509.1117

namespace Du.WithFile
{
    public static class Create
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
