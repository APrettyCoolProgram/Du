/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuApplication.cs
 * UPDATED: 6-23-2021-9:03 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System.Diagnostics;
using System.Reflection;

namespace Du
{
    public class DuApplication
    {
        /// <summary>Get various details about the entry assembly.</summary>
        /// <param name="detailRequest">The requested detail.</param>
        /// <returns>The requested detail.</returns>
        public static string GetEntryAssemblyDetail(string detailRequest)
        {
            var entryAssemblyDetail = detailRequest switch
            {
                "name"                 => Assembly.GetEntryAssembly().GetName().Name,
                "version"              => Assembly.GetEntryAssembly().GetName().Version.ToString(),
                "fileVersion"          => FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).FileVersion,
                "informationalVersion" => Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion,
                "productVersion"       => FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).ProductVersion,
                _                      => "ERROR: Invalid entry assembly detail request.",
            };

            return entryAssemblyDetail;
        }
    }
}