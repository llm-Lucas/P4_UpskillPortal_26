using System;
using System.Security.Cryptography;

namespace UpskillPortal.Utils
{
    /// <summary>
    /// A class for hashing and comparing strings (likely passwords) using PBKDF2 with SHA256.
    /// </summary>
    public class HashingService
    {
        private const int SaltSize = 32; // 256 bit
        private const int KeySize = 32;  // 256 bit
        private const int Iterations = 100000;

        public static string Hash(string plaintext)
        {
            using var rng = RandomNumberGenerator.Create();
            var salt = new byte[SaltSize];
            rng.GetBytes(salt);

            var key = new Rfc2898DeriveBytes(plaintext, salt, Iterations, HashAlgorithmName.SHA256);
            var hash = key.GetBytes(KeySize);

            var hashBytes = new byte[SaltSize + KeySize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, KeySize);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool CompareHash(string hashedString, string plaintext)
        {
            var hashBytes = Convert.FromBase64String(hashedString);
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var key = new Rfc2898DeriveBytes(plaintext, salt, Iterations, HashAlgorithmName.SHA256);
            var hash = key.GetBytes(KeySize);

            for (int i = 0; i < KeySize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i]) { return false; }
            }

            return true;
        }
    }
}
