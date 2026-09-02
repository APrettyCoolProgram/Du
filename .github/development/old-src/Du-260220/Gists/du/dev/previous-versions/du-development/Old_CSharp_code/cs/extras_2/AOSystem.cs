/* A class for AO.cs that does various things with system functions.
 * v00.51.160926
 * http://aprettycoolprogram.com/ao
 */

using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace AO
{
    public class AOSystem
    {
        /// <summary>Executes a command line process.</summary>
        /// <param name="processName">Name of the process to execute.</param>
        /// <param name="processArguments">Optional process arguments.</param>
        /// <returns>The result of the process.</returns>
        public static string RunCommand(string processName, string processArguments)
        {
            Process processToExectute = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = processName;
            startInfo.Arguments = processArguments;
            processToExectute.StartInfo = startInfo;
            processToExectute.Start();

            return processToExectute.StandardOutput.ReadToEnd();
        }

        /// <summary>Get the bit-level of the operating system.</summary>
        /// <returns>The OS bit-level.</returns>
        public static int GetOSBits()
        {
            return Directory.Exists(@"C:\Program Files (x86)") ? 64 : 32;
        }

        /// <summary>Get the number of reachable/unreachable ping responses.</summary>
        /// <param name="pingIP">The IP to ping.</param>
        /// <param name="numPings">The number of pings to try.</param>
        /// <param name="reachable">Flag to return reachable/unreachable responses.</param>
        /// <returns>The number of reachable/unreachable ping responses.</returns>
        public static int GetPingResponses(string ipToPing, int numPings, bool wantReachable)
        {
            var unreachable = new Regex(Regex.Escape("unreachable")).Matches(RunCommand("cmd.exe", "/c ping " + ipToPing)).Count;

            return wantReachable ? (numPings - unreachable) : unreachable;
        }

        /// <summary>Get the location of the Program Files directory.</summary>
        /// <returns>The Program Files folder location.</returns>
        public static string GetProgramFilesLocation()
        {
            return Directory.Exists(@"C:\Program Files (x86)") ? @"C:\Program Files (x86)" : @"C:\Program Files";
        }

        /// <summary>Pause for a number of milliseconds</summary>
        /// <param name="milliSeconds">The number of milliseconds to pause</param>
        public static void PauseMilliseconds(int milliSeconds)
        {
            Thread.Sleep(milliSeconds);
        }
    }
}