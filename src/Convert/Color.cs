// 240509.1117

namespace Du.Convert
{
    public static class Color
    {
        public static ConsoleColor ToConsoleColor(string color)
        {
            return color.ToLower() switch
            {
                "b"  => ConsoleColor.Black,
                "u"  => ConsoleColor.Blue,
                "c"  => ConsoleColor.Cyan,
                "du" => ConsoleColor.DarkBlue,
                "dc" => ConsoleColor.DarkCyan,
                "da" => ConsoleColor.DarkGray,
                "dg" => ConsoleColor.DarkGreen,
                "dm" => ConsoleColor.DarkMagenta,
                "dr" => ConsoleColor.DarkRed,
                "dy" => ConsoleColor.DarkYellow,
                "a"  => ConsoleColor.Gray,
                "g"  => ConsoleColor.Green,
                "m"  => ConsoleColor.Magenta,
                "r"  => ConsoleColor.Red,
                "w"  => ConsoleColor.White,
                "y"  => ConsoleColor.Yellow,
                _    => ConsoleColor.White,
            };
        }
    }
}
