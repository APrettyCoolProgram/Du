namespace Du.WithFile
{
    public class Verify
    {
        public static bool Exists(string path)
        {
            return File.Exists(path);
        }


    }
}
