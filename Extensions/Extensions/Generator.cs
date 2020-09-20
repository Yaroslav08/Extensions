using System;
using System.Collections.Generic;
using System.Text;
namespace Extensions
{
    public class Generator
    {
        static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        static List<string> ukrFirstNames = new List<string> { "Дмитро", "Євгеній", "Іван", "Данило", "Назар", "Віталій", "Богдан", "Денис", "Роман", "Олександр", "Микола", "Микита", "Ярослав", "Юрій", "Андрій", "Артем", "Павло", "Владислав", "Ждан", "Анатолій", "Олексій", "Михайло", "Ігор", "Антон", "Ілья", "Кирило", "Георгій", "Юрій", "Анна", "Юлія", "Анастасія", "Дарья", "Вікторія", "Тамара", "Аделіна", "Аліса", "Алла", "Альбіна", "Валерія", "Василіна", "Вероніка", "Галина", "Дана", "Діана", "Елеонора", "Еріка", "Єва", "Єлизавета", "Жана", "Злата", "Зоряна", "Зоя", "Інна", "Ілона", "Інга", "Карина", "Катерина", "Кіра", "Ксенія", "Оксана", "Лариса", "Леся", "Лідія", "Любов", "Людмила", "Маргарита", "Марта", "Марія", "Марина", "Меланія", "Мирослава", "Надія", "Ніна", "Поліна", "Раїса", "Рина", "Роза", "Руслана", "Світлана", "Тетяна", "Уляна", "Христя", "Яна", "Ярина", "Ярослава" };
        static List<string> ukrLastName = new List<string> { "Шевченко", "Антоненко", "Авраменко", "Бабюк", "Онищенко", "Медко", "Левченко", "Косенко", "Посенко", "Левицький", "Вернадський", "Петрушевський", "Авдієнко", "Басенко", "Шевченко", "Абраменко" };
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
    }
}