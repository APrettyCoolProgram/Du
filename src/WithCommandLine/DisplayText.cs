using System;

namespace Du.WithCommandLine
{
    public static class DisplayText
    {
        public static void InColor(string bgrnd, string fgrnd, string msg)
        {
            Console.BackgroundColor = Du.Convert.Color.ToConsoleColor(bgrnd);
            Console.ForegroundColor = Du.Convert.Color.ToConsoleColor(fgrnd);
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
