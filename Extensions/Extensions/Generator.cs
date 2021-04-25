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
                result += chars[rnd.Next(chars.Length)];
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

        public static string GetUniqCode()
        {
            return GetUniqCodeUpper(4);
        }

        public static string GetUniqCode(byte sections)
        {
            var commonWords = sections * 4;
            var commonCountOfSymbols = commonWords + (sections - 1);
            var stringChars = new char[commonCountOfSymbols];
            var positons = GetHyphenPositions(sections);
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                if (positons.Contains(i))
                {
                    stringChars[i] = '-';
                    continue;
                }
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var result = new String(stringChars);
            return result;
        }

        public static string GetUniqCodeUpper(byte sections)
        {
            return GetUniqCode(sections).ToUpper();
        }

        public static string GetUniqCodeLower(byte sections)
        {
            return GetUniqCode(sections).ToLower();
        }

        private static int[] GetHyphenPositions(int sections)
        {
            var pos = new int[sections - 1];
            var baseIndex = 4;
            for (int i = 0; i < pos.Length; i++)
            {
                pos[i] = baseIndex;
                baseIndex += 4 + 1;
            }
            return pos;
        }




        #region FileChecker
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
        #endregion
    }
}