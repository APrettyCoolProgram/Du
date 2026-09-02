/* A class for AO.cs that does various things with system functions.
 * v00.52.03.161012
 * http://aprettycoolprogram.com/ao
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace AO
{
    public class AOSystem
    {
        /* Executes a command line process.
         * ---
         * processName      - the process to execute (i.e. "ping")
         * processArguments - arguments for the process (i.e. "-r 10"                                                 */
        public static string RunCommand(string processName, string processArguments)                                    // TODO - Document this better.
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="milliseconds"></param>
        public static void Pause(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    


        /* Determines if the OS is 64-bit.
         * You can use two methods to determine if the OS is 64-bit:
         *      1. Environment.Is64BitOperatingSystem
         *      2. Checking for the presence of "c:\Program Files (x86)"
         * The prefered method is #1, but it requires .NET 4.0 or greater. The second method should work with any
         * version of Windows.
         * ---
         * frameworkMethod - flag to determine if the .NET Freamework 4.0 version is to be used (true) or not (false).*/
        public static bool Is64Bit(bool frameworkMethod)
        {
            if (frameworkMethod)
            {
                return Environment.Is64BitOperatingSystem;
            }
            else
            {
                return Directory.Exists(@"C:\Program Files (x86)") ? true : false;
            }
        }

        /* Get the number of reachable or unreachable ping responses.
         * Ping an IP Address a specified number of times, then return either the number of failures or successes.
         * ---
         * ipToPing         - the IP Address to ping (i.e. "192.168.1.1")
         * numPings         - the number of pings to send
         * requestReachable - flag to return the successes (true) or failures (false)                                 */
        public static int GetPingResponses(string ipToPing, int numPings, bool requestReachable)
        {
            var unreachable = new Regex(Regex.Escape("unreachable")).
                Matches(RunCommand("cmd.exe", "/c ping -n " + numPings + " " + ipToPing)).Count;

            return requestReachable
                ? (numPings - unreachable)
                : unreachable;
        }

        /* Get the location a Windows system directory.
         * This will return the location of one of the following special direcotories used by Windows:
         *      AdminTools          Desktop         Fonts           ProgramFiles        Windows
         *      ApplicationData     MyDocuments     MyMusic         Startup             MyVideos
         *      CDBurning           Favorites       MyPictures      UserProfile
         *
         * This method Works on Windows 7, not sure about other versions.
         * ---
         * directoryName - the name of the directory to get (i.e. "MyDocuments", "Favorites".                         */
        public static string GetSystemDirectory(string directoryName)
        {
            /* Convert the passed directory name to all lowercase, so there is a level playing field.                 */
            directoryName = directoryName.ToLower();

            /* Statements may contain multiple cases in an attempt to cover various references to the directory name. */
            switch (directoryName)
            {
                case "admintools":
                    return Environment.GetFolderPath(Environment.SpecialFolder.AdminTools);

                case "applicationdata":
                case "appdata":
                    return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                case "cdburning":
                    return Environment.GetFolderPath(Environment.SpecialFolder.CDBurning);

                case "desktop":
                case "mydesktop":
                    return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                case "documents":
                case "mydocuments":
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                case "favorites":
                case "myfavorites":
                    return Environment.GetFolderPath(Environment.SpecialFolder.Favorites);

                case "fonts":
                    return Environment.GetFolderPath(Environment.SpecialFolder.Fonts);

                case "music":
                case "myMusic":
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

                case "pictures":
                case "photos":
                case "mypictures":
                case "myphotos":
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                case "programfiles":                                                                                    // TODO - Distinguish between 32 and 64 bit locations?
                    return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

                case "startup":
                    return Environment.GetFolderPath(Environment.SpecialFolder.Startup);

                case "user":
                case "userprofile":
                case "myuserprofile":
                    return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                case "Windows":
                    return Environment.GetFolderPath(Environment.SpecialFolder.Windows);

                case "videos":
                case "myvideos":
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

                default:
                    return "ERROR: Directory does not exist.";
            }
        }

        /* Get the Windows version.
         * This will return version of Windows. Only Windows 2000 and later are supported.                            */
        public static string GetWindowsVersion()
        {
            if (Environment.OSVersion.ToString().Contains("5.0"))      // Windows 2000
            {
                return "2000"; // Windows 2000
            }
            else if (Environment.OSVersion.ToString().Contains("5.1")) // Windows XP 32-bit
            {
                return "XP32";
            }
            else if (Environment.OSVersion.ToString().Contains("5.2")) // Windows XP 64-bit, Server 2003, Server 2003 R2
            {
                return "XP64_2003_2003R2";
            }
            else if (Environment.OSVersion.ToString().Contains("6.0")) // Windows Vista, Server 2008
            {
                return "Vista_2008";
            }
            else if (Environment.OSVersion.ToString().Contains("6.1")) // Windows 7, Server 2008 R2
            {
                return "7_2008R2";
            }
            else if (Environment.OSVersion.ToString().Contains("6.2")) // Windows 8, Server 2012
            {
                return "8_2012";
            }
            else if (Environment.OSVersion.ToString().Contains("6.3")) // Windows 8.1, Server 2012 R2
            {
                return "81_2012R2";
            }
            else if (Environment.OSVersion.ToString().Contains("10.0")) // Windows 10, Server 2016
            {
                return "10_2016";
            }
            else
            {
                return "ERROR";
            }
        }
    }
}