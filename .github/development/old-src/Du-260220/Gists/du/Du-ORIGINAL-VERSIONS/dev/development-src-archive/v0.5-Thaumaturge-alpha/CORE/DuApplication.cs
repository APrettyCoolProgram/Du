/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuApplication.cs
 * UPDATED: 1-27-2021-8:22 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System.Diagnostics;
using System.Reflection;

namespace Du
{
    /// <summary>This class does various things with an application.</summary>
    public class DuApplication
    {
        /// <summary>Get the assembly name of the application.</summary>
        /// <returns>The assembly name of the application.</returns>
        public static string GetAssemblyName()
        {
            return Assembly.GetEntryAssembly().GetName().Name;
        }

        /// <summary> Get the AssemblyVersion of the entry application.</summary>
        /// <returns>The AssemblyVersion of the entry application.</returns>
        public static string GetVersionAssembly()
        {
            return Assembly.GetEntryAssembly().GetName().Version.ToString();
        }

        /// <summary> Get the FileVersion of the entry application. </summary>
        /// <returns>The FileVersion of the entry application.</returns>
        public static string GetVersionFile()
        {
            return FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).FileVersion;
        }

        /// <summary> Get the Version of the entry application. </summary>
        /// <returns>The Version of the entry application.</returns>
        public static string GetVersionInformational()
        {
            return Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }

        /// <summary> Get the ProductVersion of the entry application.</summary>
        /// <returns>The ProductVersion of the entry application.</returns>
        public static string GetVersionProduct()
        {
            return FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).ProductVersion;
        }
    }
}
