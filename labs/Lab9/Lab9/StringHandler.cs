using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    // Класс пользовательской обработки строки
    static class StringHandler
    {
        // Удаляет точки из строки.
        public static string RemoveDots(string str)
        {
            return str.Replace(".", "");
        }

        // Удаляет пробелы из строки.
        public static string RemoveSpaces(string str)
        {
            return str.Replace(" ", "");
        }

        // Добавляет указанный вторым параметром символ в конец строки.
        public static string AddSymbolToEnd(string str, char sym)
        {
            return str + sym;
        }

        // Удаляет первый символ строки.
        public static string RemoveFirstSymbol(string str)
        {
            return str.Remove(0, 1);
        }

        // Заменяет указанный символ, передаваемый вторым парампетром,
        // если он есть в строке, в верхний регистр.
        public static string UpSymbol(string str, char sym)
        {
            return string.Join("", str.Select(x =>
            {
                return x.Equals(sym) ? char.ToUpper(x) : x;
            }));
        }
    }
}
