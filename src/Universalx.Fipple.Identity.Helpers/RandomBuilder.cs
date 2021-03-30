using System;
using System.Security.Cryptography;

namespace Universalx.Fipple.Identity.Helpers
{
    public static class RandomBuilder
    {
        public static string GenerateRandomNumber(int min, int max)
        {
            RNGCryptoServiceProvider rngProvider = new RNGCryptoServiceProvider();

            byte[] buffer = new byte[4];
            rngProvider.GetBytes(buffer);
            int seed = BitConverter.ToInt32(buffer, 0);

            Random random = new Random(seed);
            return random.Next(min, ++max).ToString();
        }

        public static string GenerateRefreshToken()
        {
            byte[] buffer = new byte[32];
            using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }
    }
}
