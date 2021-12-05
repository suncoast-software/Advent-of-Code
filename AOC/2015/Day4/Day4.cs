using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AOC._2015.Day4
{
    public class Day4: Day
    {
        private string _key = "yzbqklnj";
        public int Part_One()
        {
            for (int i = 0; i < 9999999; i++)
            {
                var newKey = _key + i;
                var testHash = CreateHash(newKey);
                Console.WriteLine(testHash);
                if (testHash.StartsWith("000000"))
                {
                    return i;
                }
                
            }
            
            return 0;
        }

        private string CreateHash(string args)
        {
            using MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(args);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder hashBuilder = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashBuilder.Append(hashBytes[i].ToString("X2"));
            }
            return hashBuilder.ToString();
        }
    }
}
