using System;
using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissors
{
    /// <summary>
    /// Represents a class of Encryptor to encode string messages
    /// </summary>
    public class Encryptor
    {
        private HMAC _encryptor;

        /// <summary>
        /// A constructor for the encryptor
        /// </summary>
        /// <param name="key">The key to generate the encryptor</param>
        public Encryptor(byte[] key)
        {
            _encryptor = new HMACSHA256(key);
        }

        /// <summary>
        /// Generates the hash of the message
        /// </summary>
        /// <param name="message">The message that need to be encrypted</param>
        /// <returns>The computed hash code in string</returns>
        public string GenerateHash(string message)
        {
            return BitConverter.ToString(_encryptor.ComputeHash(GetBytes(message))).Replace("-", string.Empty);
        }
        
        /// <summary>
        /// Gets bytes of the input string
        /// </summary>
        /// <param name="message">The string that needs to convert to bytes</param>
        /// <returns>An array of computed bytes</returns>
        private byte[] GetBytes(string message)
        {
            return Encoding.Default.GetBytes(message);
        }
    }
}