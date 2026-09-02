// ---------------------------------------------------------------------------------------------------------------------
// Name: DoSystem.cs
// Version: 00.90.01.160731
// Author: Christopher Banwarth (development@aprettycoolprogram.com)
// Description: A class for AO that does various things with system functions.
// More: ao.aprettycoolprogram.com OR aprettycoolprogram.github.com
// ---------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;

namespace AO
{
    public class DoSystem
    {
        /// <summary>Executes a command line process.</summary>
        /// <param name="procName">Name of the process to execute.</param>
        /// <param name="procArgs">Optional process arguments.</param>
        /// <returns>The result of the process.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static string ExecuteCommand(string procName, string procArgs)
        {
            Process processToExectute = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = procName;
            startInfo.Arguments = procArgs;
            processToExectute.StartInfo = startInfo;
            processToExectute.Start();

            return processToExectute.StandardOutput.ReadToEnd();
        }

        /// <summary>Get the bit-level of the operating system.</summary>
        /// <returns>The OS bit-level.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static int GetOSBits()
        {
            if (DoDirectory.CheckExist(@"C:\Program Files (x86)"))
            {
                return 64;
            }
            else
            {
                return 32;
            }
        }

        /// <summary>Get the number of reachable/unreachable ping responses.</summary>
        /// <param name="pingIP">The IP to ping.</param>
        /// <param name="reachable">Flag to return reachable responses, instead of unreachable.</param>
        /// <returns>The number of reachable/unreachable ping responses.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static int GetPingResponse(string PingIP, bool reachable)
        {
            var responseCount = new Regex(Regex.Escape("unreachable")).Matches(ExecuteCommand("cmd.exe", "/c ping " + PingIP)).Count;

            if (reachable)
            {
                responseCount = (4 - responseCount); // Reverse unreachable to reachable
            }

            return responseCount;
        }

        /// <summary>Get the location of the Program Files directory.</summary>
        /// <returns>The Program Files folder location.</returns>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static string GetProgramFilesLocation()
        {
            if (DoDirectory.CheckExist(@"C:\Program Files (x86)"))
            {
                return @"C:\Program Files (x86)\APCP\";
            }
            else
            {
                return @"C:\Program Files\APCP\";
            }
        }

        /// <summary>Pause for a number of milliseconds</summary>
        /// <param name="milliseconds">The number of milliseconds to pause</param>
        /// <remarks>None</remarks>
        /// <build>160713</build>
        public static void PauseMilliseconds(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}

// CHANGELOG
// =========
// 00.90.00.160717: Initial release
// 00.90.01.160731: Code and comment cleanup

// ROADMAP
// =======
// * Proper error handling

// NOTES
// =====