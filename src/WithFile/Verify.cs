// 240510.1622

namespace Du.WithFile
{
    public static class Verify
    {
        public static bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}
