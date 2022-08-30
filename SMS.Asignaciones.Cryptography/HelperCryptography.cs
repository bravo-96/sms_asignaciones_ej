using System;

namespace SMS.Asignaciones.Cryptography
{
    public class HelperCryptography
    {
        /// <summary>
        /// Hash a new password for storing in the database.
        /// </summary>
        /// <param name="password"></param>
        /// <returns>The function automatically generates a cryptographically safe salt.</returns>
        public static string EncryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Check if the hash of the entered login password, matches the stored hash.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="existingHashFromDb"></param>
        /// <returns>The salt and the cost factor will be extracted from existingHashFromDb.</returns>
        public static bool CompareEncryptPassword(string password, string existingHashFromDb)
        {
            return BCrypt.Net.BCrypt.Verify(password, existingHashFromDb);
        }
    }
}
