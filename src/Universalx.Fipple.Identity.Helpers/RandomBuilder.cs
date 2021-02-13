using System;
using System.Security.Cryptography;

namespace Universalx.Fipple.Identity.Helpers
{
    public static class RandomBuilder
    {
        public static string GetRandomNumber(int min, int max)
        {
            RNGCryptoServiceProvider rngProvider = new RNGCryptoServiceProvider();

            var buffer = new byte[4];
            rngProvider.GetBytes(buffer);
            var seed = BitConverter.ToInt32(buffer, 0);

            Random random = new Random(seed);
            return random.Next(min, ++max).ToString();
        }
    }
}
