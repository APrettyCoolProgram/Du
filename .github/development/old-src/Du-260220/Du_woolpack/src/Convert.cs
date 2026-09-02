// 240511.1104

namespace Du
{
    /// <summary>Convert things.</summary>
    public static class Convert
    {
        /// <summary>Convert a string to a ConsoleColor</summary>
        /// <param name="colorCode">The string to convert.</param>
        /// <remarks>
        ///     - The colorCode is the first letter(s) of the color that is being converted.
        ///       ex: "r" for red, "dm" for dark magenta
        /// </remarks>
        /// <example>
        ///     <code>ConsoleColor textColor = Du.Convert.Color.ToConsoleColor("r");</code>
        /// </example>
        /// <returns>A CosoleColor</returns>
        public static ConsoleColor StringToConsoleColor(string colorCode)
        {
            return colorCode.ToLower() switch
            {
                "b" => ConsoleColor.Black,
                "u" => ConsoleColor.Blue,
                "c" => ConsoleColor.Cyan,
                "du" => ConsoleColor.DarkBlue,
                "dc" => ConsoleColor.DarkCyan,
                "da" => ConsoleColor.DarkGray,
                "dg" => ConsoleColor.DarkGreen,
                "dm" => ConsoleColor.DarkMagenta,
                "dr" => ConsoleColor.DarkRed,
                "dy" => ConsoleColor.DarkYellow,
                "a" => ConsoleColor.Gray,
                "g" => ConsoleColor.Green,
                "m" => ConsoleColor.Magenta,
                "r" => ConsoleColor.Red,
                "w" => ConsoleColor.White,
                "y" => ConsoleColor.Yellow,
                _ => ConsoleColor.White,
            };
        }
    }
}