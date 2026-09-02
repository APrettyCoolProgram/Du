/* A class for AO.cs that does various things with directories.
 * v00.53.03.161219
 * http://aprettycoolprogram.com/ao
 */

using System.Collections.Generic;
using System.IO;

namespace AO
{
    public class AODirectory
    {
        /// <summary>
        /// Batch creates directories.
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="directoryNames">The directory names.</param>
        /// <param name="addTrailingSlash">if set to <c>true</c> [add trailing slash].</param>
        /// <remarks>
        /// None.
        /// </remarks>
        public static void BatchCreate(string rootPath, List<string> directoryNames, bool addTrailingSlash)
        {
            foreach (var directoryName in directoryNames)
            {
                Create(directoryName, addTrailingSlash);
            }
        }

        /// <summary>
        /// Creates the specified directory name.
        /// </summary>
        /// <param name="directoryName">Name of the directory.</param>
        /// <param name="addTrailingSlash">if set to <c>true</c> [add trailing slash].</param>
        /// <remarks>
        /// None.
        /// </remarks>
        public static void Create(string directoryName, bool addTrailingSlash)
        {
            if (addTrailingSlash)
            {
                directoryName = directoryName + @"\";
            }

            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
        }
    }
}