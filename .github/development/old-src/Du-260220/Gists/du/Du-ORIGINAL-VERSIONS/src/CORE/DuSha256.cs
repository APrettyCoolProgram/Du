// =====================================================================================================================
//    FILE: Du.DuSha256.cs
// PROJECT: Du (https://github.com/aprettycoolprogram/Du)
// UPDATED: 4-1-2021-11:19 AM
// AUTHORS: development@aprettycoolprogram.com
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          © 2021 A Pretty Cool Program. All rights reserved.
// =====================================================================================================================

using System.IO;
using System.Security.Cryptography;

namespace Du
{
    /// <summary>Methods that work with SHA256 hashes.</summary>
    public class DuSha256
    {
        /// <summary>Get the SHA256 value of a file as a byte[].</summary>
        /// <param name="filePath">The file to get the SHA256 value of.</param>
        /// <returns>A SHA256 value as a byte[].</returns>
        private static byte[] GetHashAsBytes(string filePath)
        {
            var workingHashValue = SHA256.Create();
            byte[] hashAsBytes;

            using(FileStream stream = File.OpenRead(filePath))
            {
                hashAsBytes = workingHashValue.ComputeHash(stream);
            }

            return hashAsBytes;
        }

        /// <summary>Get the SHA256 value of a file as a string.</summary>
        /// <param name="filePath">The file to get the SHA256 value of.</param>
        /// <returns>A SHA256 value as a string.</returns>
        public static string GetHashAsString(string filePath)
        {
            var hashAsBytes  = GetHashAsBytes(filePath);
            var hashAsString = ConvertHashToString(hashAsBytes);

            return hashAsString;
        }

        /// <summary>Convert a SHA256 hash as a byte[] to a string</summary>
        /// <param name="hashAsBytes">The byte[] that holds the SHA256 hash.</param>
        /// <returns>A SHA256 hash as a string.</returns>
        public static string ConvertHashToString(byte[] hashAsBytes)
        {
            var hashAsString = "";

            for(var currentBit = 0; currentBit < hashAsBytes.Length; currentBit++)
            {
                hashAsString += $"{hashAsBytes[currentBit]:X2}";

                if((currentBit % 4) == 3)
                {
                    hashAsString += " ";
                }
            }

            return hashAsString;
        }

        /// <summary></summary>
        /// <param name="filePath1"></param>
        /// <param name="filePath2"></param>
        /// <returns></returns>
        public static bool BothFilesMatchSha256(string filePath1, string filePath2)
        {
            return GetHashAsString(filePath1) == GetHashAsString(filePath2);
        }

        /// <summary></summary>
        /// <param name="filePath"></param>
        /// <param name="sha256Value"></param>
        /// <returns></returns>
        public static bool FileMatchesSha256Value(string filePath, string sha256Value)
        {
            return GetHashAsString(filePath) == sha256Value;
        }

        /// <summary></summary>
        /// <param name="fileToCalculate"></param>
        /// <param name="pathToSave"></param>
        public static void WriteHashValueAsContent(string fileToCalculate, string pathToSave)
        {
            File.WriteAllText(pathToSave, GetHashAsString(fileToCalculate));
        }
    }

}
