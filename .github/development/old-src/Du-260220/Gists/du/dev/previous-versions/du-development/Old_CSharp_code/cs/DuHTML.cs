#region PROJECT_HEADER
//   PROJECT: Du
//  FILENAME: DuHTML.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2018 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

#region CLASS_DESCRIPTION
// Does things with HTML.
#endregion

#region USING
using System.Collections.Generic;
using System.IO;
#endregion

namespace Du
{
    public class DuHTML
    {
        /// <summary>Get the data between <P></P> tags.</summary>
        /// <param name="htmlString">The HTML file to parse.</param>
        /// <returns>A list of data between paragraph tags.</returns>
        /// <build>180227</build>
        /// <remarks>This doesn't actually remove the paragraph tags.</remarks>
        public static List<string> ExtractParagraphs(string htmlString)
        {
            var paragraphs = new List<string>();
            var line       = string.Empty;

            using (var reader = new StringReader(htmlString))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("<p>") && line.EndsWith("</p>")) //DEV-- put this in DuString and allow any braces to be extracted.
                    {
                        paragraphs.Add(line);
                    }
                }
            }

            return paragraphs;
        }

        /// <summary>Remove all HTML tags from an HTML string.</summary>
        /// <param name="htmlString">The HTML string to remove tags from.</param>
        /// <returns>The HTML string without HTML tags.</returns>
        /// <build>180227</build>
        /// <remarks>Probably a much more efficient way of doing this!</remarks>
        public static string RemoveTags(string htmlString)
        {
            var line   = string.Empty;
            var record = true;

            foreach (var character in htmlString)
            {
                if (character == '<')
                {
                    record = false;
                }
                else if (character == '>')
                {
                    record = true;

                    continue;
                }

                if (record)
                {
                    line = line + character;
                }
            }

            return line;
        }
    }
}