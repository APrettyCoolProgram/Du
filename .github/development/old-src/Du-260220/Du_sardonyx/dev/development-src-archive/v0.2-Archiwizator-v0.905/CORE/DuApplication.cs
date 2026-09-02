/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuApplication.cs
 * UPDATED: 12-31-2020-11:36 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/*  This is a work-in-progress, and some of these methods have not been extensively tested yet.
 */

using System.Reflection;

namespace Du
{
    /// <summary>This class does various things with an application.</summary>
    public class DuApplication
    {
        /// <summary>Get the assembly name of the application.</summary>
        /// <returns>The assembly name of the application.</returns>
        public static string GetApplicationAssemblyName()
        {
            /* NOT TESTED */

            return Assembly.GetExecutingAssembly().GetName().Name;
        }

        /// <summary> Get version of the application. </summary> <returns>The version of the application</returns>
        /// <remarks>This data is in the <c><PropertyGroup><Version><c> of the <c>.csproj</c> file.</remarks>
        public static string GetApplicationVersion()
        {
            /* NOT TESTED */

            return Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }
    }
}