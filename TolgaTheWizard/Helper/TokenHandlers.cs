using System;

namespace TolgaTheWizard.Helper
{
    /// <summary>
    /// Token Generator Methods
    /// </summary>
    public static class TokenHandlers
    {
        private static readonly Random Random = new Random();
        /// <summary>
        /// Generate only numeric code
        /// </summary>
        /// <param name="size">Size of the Code, Default size is 10</param>
        /// <returns>string like 498521388</returns>
        public static string GenerateRandomUserFriednlyCode(int size = 10)
        {
            var code = "";
            for (var i = 0; i < size; i++)
            {
                code += Random.Next(0, 9).ToString();
            }
            return code;
        }
        /// <summary>
        ///Create from given string characters(repeating characters increase the frequency of use.) 
        /// </summary>
        /// <param name="characters">Source Characters</param>
        /// <param name="size">Size of the Code, Default size is 10</param>
        /// <returns></returns>
        public static string GenerateRandomUserFriednlyCode(string characters, int size = 10)
        {
            var code = "";
            var characterArray = characters.ToCharArray();
            for (var i = 0; i < size; i++)
            {
                code += characterArray[Random.Next(0, characterArray.Length)];
            }
            return code;
        }
    }
}
