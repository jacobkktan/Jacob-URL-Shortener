using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace URLShortener.BL
{
    public static class ShortGeneratorHelper
    {
        private static Random random = new Random();

        public static string GenerateCode(int noOfCharacters = 4)
        {
            StringBuilder final = new StringBuilder();
            for (var i = 0; i < noOfCharacters; i++)
            {
                final.Append(GenerateChar());
            }
            return final.ToString();
        }

        private static string GenerateChar()
        {
            //65 - 90 is for A to Z with a potential 1-9 from 91 - 99
            int rand = random.Next(65, 99);
            if(rand > 90) return (rand % 10).ToString();
            return char.ConvertFromUtf32(rand);
        }
    }
}