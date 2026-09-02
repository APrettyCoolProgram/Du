// 240510.1622

namespace Du
{
    public static class WithFile
    {
        public static void IfNonexistant(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }

        public static bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}