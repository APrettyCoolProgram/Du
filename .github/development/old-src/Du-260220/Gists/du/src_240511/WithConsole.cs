// 240511.1104

namespace Du
{
    /// <summary>Display text in the console.</summary>
    public static class WithConsole
    {
        /// <summary>Display colored text in the console.</summary>
        /// <param name="text">The text to display</param>
        /// <param name="background">The background color of the text</param>
        /// <param name="foreground">The foreground color of the text.</param>
        /// <remarks>
        ///     - The background and foreground colors are the first letter(s) of the color that is being converted.
        ///       ex: "r" for red, "dm" for dark magenta
        /// </remarks>
        /// <example>
        ///     To display black background, white text using Du.WithConsole.DisplayText():
        ///     <code>
        ///         Du.WithConsole.DisplayText("Hello, World!");
        ///     </code>
        ///     To display red background, green text using Du.WithConsole.DisplayText():
        ///     <code>
        ///         Du.WithConsole.DisplayText("Hello, World!", "r", "g");
        ///     </code>
        ///
        /// </example>
        public static void DisplayText(string text, string background = "b", string foreground = "w")
        {
            Console.BackgroundColor = Convert.StringToConsoleColor(background);
            Console.ForegroundColor = Convert.StringToConsoleColor(foreground);
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}