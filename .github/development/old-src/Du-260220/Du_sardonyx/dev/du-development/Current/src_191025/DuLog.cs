// ===========================================================================================================  12:46 PM
//    FILENAME: DuLog.cs
//       BUILD: 20191023
//     PROJECT: Du (https://github.com/APrettyCoolProgram/Du)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

/* Methods for logging.
 */

using System;

namespace Du
{
    public class DuLog
    {
        /// Appends data to a logfile.
        /// </summary>
        /// <param name="filePath">Ex: "/path/to/file".</param>
        /// <param name="toAppend">The data string to append.</param>
        public static void AppendData(string filePath, string toAppend)
        {
            var logEntry = Environment.NewLine
                         + "================================================================================" + Environment.NewLine
                         + DateTime.Now.ToString("yy-MM-dd-HH:mm:ss")                                         + Environment.NewLine
                         + "================================================================================" + Environment.NewLine
                         + toAppend
                         + Environment.NewLine;

            DuFile.AppendData(filePath, logEntry);
        }
    }
}