/* PROJECT: Du (https://github.com/aprettycoolprogram/Du)
 *    FILE: Du.DuSha.cs
 * UPDATED: 12-30-2020-5:01 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/*  EXPERIMENTAL!  This is being developed for Thaumaturge. Use at your own risk!
 */

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Du
{
    public class DuSha
    {
        /// <summary>Get the SHA256 value of a file.</summary>
        /// <param name="filePath">The file to get the SHA256 value of.</param>
        /// <returns>A SHA256 value.</returns>
        public static string GetSha256Value(string filePath)
        {
            var test = File.ReadAllText(filePath);

            using(var sha256 = SHA256.Create())
            {

                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(test));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }

        /// <summary></summary>
        /// <param name="directory"></param>
        public static void Getdir(string directory)
        {
            // Create a DirectoryInfo object representing the specified directory.
            var dir = new DirectoryInfo(directory);
            // Get the FileInfo objects for every file in the directory.
            FileInfo[] files = dir.GetFiles();
            // Initialize a SHA256 hash object.
            using(var mySHA256 = SHA256.Create())
            {
                // Compute and print the hash values for each file in directory.
                foreach(FileInfo fInfo in files)
                {
                    try
                    {
                        // Create a fileStream for the file.
                        FileStream fileStream = fInfo.Open(FileMode.Open);
                        // Be sure it's positioned to the beginning of the stream.
                        fileStream.Position = 0;
                        // Compute the hash of the fileStream.
                        var hashValue = mySHA256.ComputeHash(fileStream);
                        // Write the name and hash value of the file to the console.
                        Console.Write($"{fInfo.Name}: ");
                        var final = PrintByteArray(hashValue);
                        // Close the file.
                        fileStream.Close();
                    }
                    catch(IOException e)
                    {
                        Console.WriteLine($"I/O Exception: {e.Message}");
                    }
                    catch(UnauthorizedAccessException e)
                    {
                        Console.WriteLine($"Access Exception: {e.Message}");
                    }
                }
            }
        }

        /// <summary></summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string PrintByteArray(byte[] array)
        {
            var sha256Value = "";

            for(var i = 0; i < array.Length; i++)
            {
                sha256Value += ($"{array[i]:X2}");

                if((i % 4) == 3)
                {
                    sha256Value += " ";
                }

            }

            return sha256Value;
        }

        /// <summary></summary>
        /// <param name="firstFilePath"></param>
        /// <param name="secondFilePath"></param>
        /// <returns></returns>
        public static bool BothFilesMatchSha256(string firstFilePath, string secondFilePath)
        {
            var firstFileSha256Value = GetSha256Value(firstFilePath);
            var secondFileSha256Value = GetSha256Value(secondFilePath);

            return firstFileSha256Value == secondFileSha256Value;
        }

        /// <summary></summary>
        /// <param name="firstFilePath"></param>
        /// <param name="secondFilePath"></param>
        /// <returns></returns>
        public static bool FileMatchesSha256Value(string filePath, string sha256Value)
        {
            var fileSha256Value = GetSha256Value(filePath);

            return fileSha256Value == sha256Value;
        }

        /// <summary></summary>
        /// <param name="fileToCalculate"></param>
        /// <param name="pathToSave"></param>
        public static void WriteSha256ValueToFile(string fileToCalculate, string pathToSave)
        {
            var sha256Value = DuSha.GetSha256Value(fileToCalculate);
            File.WriteAllText(pathToSave, sha256Value);
        }
    }
}
