// 260711_code
// 260711_documentation;

using System.Security.Cryptography;

namespace Du;

/// <summary>Logic to verify file hashes.</summary>
public static class DuHash
{
    // v1.0.0.0
    /// <summary>Verify a file's hash and return a boolean value.</summary>
    /// <param name="filePath">The path to the file to verify.</param>
    /// <param name="hashPath">The path to the file containing the expected hash.</param>
    /// <remarks>
    /// This method returns a boolean value.<br/>
    /// <br/>
    /// If you need to return a string, use the <see cref="IsMatch"/> method instead.
    /// </remarks>
    /// <example>
    /// <code>
    /// bool result = DuHash.IsMatch("path/to/file.txt", "path/to/hash.txt");
    /// </code>
    /// </example>
    /// <returns>True if the file's hash matches the expected hash; otherwise, false.</returns>
    public static bool IsMatch(string filePath, string hashPath)
    {
        if (!File.Exists(filePath) || !File.Exists(hashPath))
        {
            return false;
        }
        else
        {
            var computedHash = GetFileHash(filePath);
            var expectedHash = File.ReadAllText(hashPath).Trim();

            return computedHash.Equals(expectedHash, StringComparison.OrdinalIgnoreCase);
        }
    }

    // v1.0.0.0
    /// <summary>Verify a file's hash and return a string message.</summary>
    /// <param name="filePath">The path to the file to verify.</param>
    /// <param name="hashPath">The path to the file containing the expected hash.</param>
    /// <param name="defaultMsg">The default message to return in the result string.</param>
    /// <remarks>
    /// This method returns a string message.<br/>
    /// <br/>
    /// If you need to return a boolean value, use the <see cref="IsMatch"/> method instead.
    /// </remarks>
    /// <example>
    /// <code>
    /// string result = DuHash.IsMatch("path/to/file.txt", "path/to/hash.txt", "Hash verification");
    /// </code>
    /// </example>
    /// <returns>A string message indicating whether the file's hash matches the expected hash.</returns>
    public static string IsMatch(string filePath, string hashPath, string msg)
    {
        return (!File.Exists(filePath) || !File.Exists(hashPath))
            ? $"{msg} ERROR: Missing required file(s)!"
            : (IsMatch(filePath, hashPath))
                ? $"{msg}successful"
                : $"{msg}failed";
    }

    // v1.0.0.0
    /// <summary>Compute the SHA256 hash of a file.</summary>
    /// <param name="filePath">The path to the file to compute the hash for.</param>
    /// <example>
    /// <code>
    /// string hash = DuHash.GetFileHash("path/to/file.txt");
    /// </code>
    /// </example>
    /// <returns>The SHA256 hash of the file as a lowercase hexadecimal string.</returns>
    public static string GetFileHash(string filePath)
    {
        using var sha256 = SHA256.Create();
        using var stream = File.OpenRead(filePath);
        var hash         = sha256.ComputeHash(stream);

        return Convert.ToHexStringLower(hash);
    }
}