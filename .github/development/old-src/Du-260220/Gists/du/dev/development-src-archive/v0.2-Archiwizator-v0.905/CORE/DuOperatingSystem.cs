/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuOperatingSystem.cs
 * UPDATED: 12-31-2020-11:01 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/*  This is a work-in-progress, and some of these methods have not been extensively tested yet.
 */

using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;

namespace Du
{
    /// <summary>Does things with various operating systems, each of which has its own sub-class.</summary>
    public class DuOperatingSystem
    {
        /// <summary>Microsoft Windows</summary>
        public class MSWindows
        {
            /// <summary>Determines if the current operating system is 32Bit or 64Bit.</summary>
            /// <returns>Returns true (64Bit) or false (32Bit).</returns>
            public static bool Is64Bit() /* NOT TESTED */
            {
                return Environment.Is64BitOperatingSystem;
            }

            /// <summary>Executes a Windows command.</summary>
            /// <param name="procedureName">     The procedure name ("ping").</param>
            /// <param name="procedureArguments">Procedure argument(s) ("-t 123.456.789.123").</param>
            /// <returns>The result of the command.</returns>
            /// <remarks>
            /// * The procedureArguments parameter must include all necessary formatting. For example, if the arguments
            /// require specific spacing, that should be passed to this method. This method does not apply any formatting.
            /// * The result is whatever the commands sends to the command line when it executes.
            /// </remarks>
            public static string ExecuteCommand(string procedureName, string procedureArguments) /* NOT TESTED */
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        WindowStyle            = ProcessWindowStyle.Hidden,
                        RedirectStandardOutput = true,
                        UseShellExecute        = false,
                        FileName               = procedureName,
                        Arguments              = procedureArguments
                    }
                };

                _ = process.Start();

                return process.StandardOutput.ReadToEnd();
            }

            /// <summary>Ping an IP address.</summary>
            /// <param name="ipAddress">    The IP address to ping ("google.com", "1.1.1.1").</param>
            /// <param name="numberOfPings">The number of pings to perform [4]</param>
            /// <returns>The number of reachable and unreachable ping attempts.</returns>
            /// <remarks>* This has not been extensively tested!</remarks>
            public static Tuple<int, int> PingIpAddress(string ipAddress, int numberOfPings = 4) /* NOT TESTED */
            {
                var unreachable = new Regex(Regex.Escape("unreachable")).Matches(ExecuteCommand("ping", $" /n {numberOfPings} {ipAddress}")).Count;
                var reachable   = numberOfPings - unreachable;

                return new Tuple<int, int>(reachable, unreachable);
            }

            /// <summary>Pauses execution.</summary>
            /// <param name="milliSeconds">The amount of time to pause, in milliseconds [1000].</param>
            /// <remarks>* This has not been extensively tested!</remarks>
            public static void PauseExecution(int milliSeconds = 1000) /* NOT TESTED */
            {
                Thread.Sleep(milliSeconds);
            }
        }
    }
}