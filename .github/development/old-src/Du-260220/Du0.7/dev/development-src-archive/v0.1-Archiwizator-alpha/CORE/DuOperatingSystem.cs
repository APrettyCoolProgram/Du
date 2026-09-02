/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuOperatingSystem.cs
 * UPDATED: 12-28-2020-12:30 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System;
using System.Diagnostics;

namespace Du
{
    public class DuOperatingSystem
    {
        /*  Microsoft Windows
         */
        public class MSWindows
        {
            /// <summary>Determines if an operating system is 32Bit or 64Bit.</summary>
            /// <returns>Returns true (is 64Bit) or false (is 32Bit).</returns>
            public static bool Is64Bit()
            {
                return Environment.Is64BitOperatingSystem;
            }

            /// <summary>Executes a command.</summary>
            /// <param name="procName">The procedure name (i.e. "ping").</param>
            /// <param name="procArgs">Procedure arguments (i.e. "-t 123.456.789.123").</param>
            /// <returns></returns>
            public static string ExecuteCommand(string procName, string procArgs)
            {
                var processToExectute = new Process();

                var startInfo = new ProcessStartInfo()
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    FileName = procName,
                    Arguments = procArgs
                };

                processToExectute.StartInfo = startInfo;
                processToExectute.Start();

                return processToExectute.StandardOutput.ReadToEnd();
            }
        }
    }
}