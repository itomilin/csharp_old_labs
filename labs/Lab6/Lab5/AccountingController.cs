using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    // Класс контроллер БУХГАЛТЕРИЯ
    sealed class AccountingController
    {
        private Accounting _accounting;

        public AccountingController(Accounting accounting)
        {
            _accounting = accounting;
        }

        // суммарную стоимость продукции заданного наименования по всем накладным
        // В качестве параметра передаем искомое наименование.
        public double CalculateFinallyCost(string goodsName)
        {
            double accumulator = 0;
            // Проходим по всему абстрактному списку
            foreach (var document in _accounting.Documents)
            {
                // Теперь нужно преобразовать абстрактный тип, в конкретный
                // проверяем с помощью as. Нас интересуют только накладные.
                if (document as ConsignmentNote != null)
                {
                    // Теперь считаем сумму по заданным наименованиям.
                    accumulator += ((ConsignmentNote)document)
                        .GoodsPricePair
                        .Where(i => i.Key.Equals(goodsName)).Sum(z => z.Value); 
                }
            }
          
            return accumulator;
        }

        public int CalculateCheckCount()
        {
            int countOfChecks = 0;
            foreach (var document in _accounting.Documents)
            {
                // Теперь нужно преобразовать абстрактный тип, в конкретный
                // проверяем с помощью as. Нас интересуют только накладные.
                if (document as ConsignmentNote != null)
                {
                    // Теперь считаем количество чеков, если поле == null, считаем,
                    // что чека не существует для данной накладной.
                    if (((ConsignmentNote)document).Check != null)
                    {
                        ++countOfChecks;
                    }      
                }
            }
            return countOfChecks;
        }

        public void PrintTwoDocs(DateTime date1, DateTime date2)
        {
            int counter = 0;
            Console.WriteLine("Печатаем не меньше двух документов подходящих под условие" +
                $"**\n{date2} <= дата_документа <= {date1}**");
            foreach (var document in _accounting.Documents)
            {
                // Выводим не больше двух.
                if (counter >= 2)
                {
                    break;
                }
                // Получим дату.
                var date = document.Date;
                // Спарсим дату
                DateTime dt = DateTime.ParseExact($"{date.Year}-{date.Month}-{date.Day}",
                "yyyy-MMMM-dd",
                System.Globalization.CultureInfo.InvariantCulture);
                // Проверим, на вхождение в заданный интервал.
                if (date2 <= dt && dt <= date1)
                {
                    ++counter;
                    Console.WriteLine(document.DocumentType +
                        document.Organization.Name +
                        document.Date);
                }
            }
        }
    }
}
