// 240509.1117

namespace Du.WithDirectory
{
    public static class Verify
    {
        public static void ListOf(List<string> directories)
        {
            foreach (var directory in directories)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }
        }
    }
}
