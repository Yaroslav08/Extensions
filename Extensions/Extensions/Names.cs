using System;
using System.Collections.Generic;
using System.Text;
namespace Extensions
{
    public class Names
    {
        static string[] ukrFirstNames = new string[] { "Дмитро", "Євгеній", "Іван", "Данило", "Назар", "Віталій", "Богдан", "Денис", "Роман", "Олександр", "Микола", "Микита", "Ярослав", "Юрій", "Андрій", "Артем", "Павло", "Владислав", "Ждан", "Анатолій", "Олексій", "Михайло", "Ігор", "Антон", "Ілья", "Кирило", "Георгій", "Юрій", "Анна", "Юлія", "Анастасія", "Дарья", "Вікторія", "Тамара", "Аделіна", "Аліса", "Алла", "Альбіна", "Валерія", "Василіна", "Вероніка", "Галина", "Дана", "Діана", "Елеонора", "Еріка", "Єва", "Єлизавета", "Жана", "Злата", "Зоряна", "Зоя", "Інна", "Ілона", "Інга", "Карина", "Катерина", "Кіра", "Ксенія", "Оксана", "Лариса", "Леся", "Лідія", "Любов", "Людмила", "Маргарита", "Марта", "Марія", "Марина", "Меланія", "Мирослава", "Надія", "Ніна", "Поліна", "Раїса", "Рина", "Роза", "Руслана", "Світлана", "Тетяна", "Уляна", "Христя", "Яна", "Ярина", "Ярослава" };
        static string[] ukrLastName = new string[] { "Шевченко", "Антоненко", "Авраменко", "Бабюк", "Онищенко", "Медко", "Мудрик", "Левченко", "Косенко", "Посенко", "Левицький", "Вернадський", "Петрушевський", "Авдієнко", "Басенко", "Шевченко", "Абраменко" };
        public static string GetFirstnameRandom()
        {
            var rnd = new Random();
            return ukrFirstNames[rnd.Next(0, ukrFirstNames.Length)];
        }

        public static List<string> GetFirstnamesRandom(int count)
        {
            var rnd = new Random();
            List<string> names = new List<string>();
            for (int i = 0; i < count; i++)
            {
                names.Add(ukrFirstNames[rnd.Next(0, ukrFirstNames.Length)]);
            }
            return names;
        }

        public static string GetLastnameRandom()
        {
            var rnd = new Random();
            return ukrLastName[rnd.Next(0, ukrLastName.Length)];
        }

        public static List<string> GetLastnamesRandom(int count)
        {
            var rnd = new Random();
            List<string> names = new List<string>();
            for (int i = 0; i < count; i++)
            {
                names.Add(ukrLastName[rnd.Next(0, ukrLastName.Length)]);
            }
            return names;
        }

        public static string GetFullnameRandom()
        {
            var rnd = new Random();
            return $"{ukrFirstNames[rnd.Next(0, ukrFirstNames.Length)]} {ukrLastName[rnd.Next(0, ukrLastName.Length)]}";
        }

        public static List<string> GetFullnamesRandom(int count)
        {
            var rnd = new Random();
            List<string> names = new List<string>();
            for (int i = 0; i < count; i++)
            {
                names.Add($"{ukrFirstNames[rnd.Next(0, ukrFirstNames.Length)]} {ukrLastName[rnd.Next(0, ukrLastName.Length)]}");
            }
            return names;
        }
    }
}