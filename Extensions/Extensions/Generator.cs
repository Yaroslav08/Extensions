using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace Extensions
{
    public class Generator
    {
        static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public static string GetCode(int length)
        {
            var chars = "0123456789";
            string result = null;
            var rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                result += chars[rnd.Next(10)];
            }
            return result;
        }

        public static string GetString(int length, bool IsUpper = false, bool IsLowwer = false)
        {
            var stringChars = new char[length];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var result = new String(stringChars);
            return IsUpper ? result.ToUpper() : IsLowwer ? result.ToLower() : result;
        }

        public static string GetUniqCodeUpper()
        {
            var stringChars = new char[19];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                if(i == 4 || i == 9 || i == 14)
                {
                    stringChars[i] = '-';
                    continue;
                }
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var res = new String(stringChars);
            return res.ToUpper();
        }

        public static byte[] GetArrayMD5CheckSum(string pathToFile)
        {
            using var md5 = MD5.Create();
            using var stream = File.OpenRead(pathToFile);
            return md5.ComputeHash(stream);
        }

        public static byte[] GetArrayMD5CheckSum(Stream stream)
        {
            using var md5 = MD5.Create();
            return md5.ComputeHash(stream);
        }

        public static string GetStringMD5CheckSum(string pathToFile)
        {
            using var md5 = MD5.Create();
            using var stream = File.OpenRead(pathToFile);
            var hash = md5.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }

        public static string GetStringMD5CheckSum(Stream stream)
        {
            using var md5 = MD5.Create();
            var hash = md5.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}