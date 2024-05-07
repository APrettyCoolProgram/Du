using System.Diagnostics;

namespace Du.WithSystem
{
    public class Command
    {
        public static void Execute(string cmd, string arg, bool terminate = true)
        {
            if (terminate)
            {
                Process.Start(cmd, $"/c {arg}");
            }
            else
            {
                Process.Start(cmd, arg);
            }
        }
    }
}
