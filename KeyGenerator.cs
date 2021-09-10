using System.Security.Cryptography;

namespace RockPaperScissors
{
    /// <summary>
    /// Represents a secure key generator 
    /// </summary>
    public class KeyGenerator
    {
        private RandomNumberGenerator _generator;
        private byte[] _key;

        public KeyGenerator()
        {
            _generator = RandomNumberGenerator.Create();
            _key = new byte[128];
        }

        /// <summary>
        /// Generates the secure 128-bit key
        /// </summary>
        /// <returns>The key - an array of 128 bytes</returns>
        public byte[] GenerateKey()
        {
            _generator.GetBytes(_key);
            return _key;
        }
        
    }
}