#region HEADER
//   PROJECT: Du
//  FILENAME: DuSystem.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2017 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

#region CLASS_DESCRIPTION
// Does things with system functions.
#endregion

using System.Diagnostics;
using System.Threading;

namespace Du
{
    public class DuSystem
    {
        /// <summary>
        /// Executes a Windows CLI command.
        /// </summary>
        /// <param name="command">   The command to execute (i.e. "ping").</param>
        /// <param name="arguments"> Optional command arguments (i.e. "-n4 192.168.1.1").</param>
        /// <returns>The results of the command.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static string ExecuteCommand(string command, string arguments)
        {
            var commandProcess = new Process();

            var processInfo = new ProcessStartInfo
            {
                WindowStyle            = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                UseShellExecute        = false,
                CreateNoWindow         = false,
                FileName               = command,
                Arguments              = arguments
            };

            commandProcess.StartInfo = processInfo;
            commandProcess.Start();

            return commandProcess.StandardOutput.ReadToEnd();
        }

        /// <summary>
        /// Inserts a pause.
        /// </summary>
        /// <param name="milliseconds"> Number of milliseconds to pause.</param>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static void Pause(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}