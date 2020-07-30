using System;
using System.Collections.Generic;
using System.Text;
namespace Extensions
{
    public class Generator
    {
        public static int GetCode(int length)
        {

        }
        public static string GetString(int length, bool IsUpper = false, bool IsLowwer = false)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var result = new String(stringChars);
            return IsUpper ? result.ToUpper() : IsLowwer ? result.ToLower() : result;
        }
    }
}