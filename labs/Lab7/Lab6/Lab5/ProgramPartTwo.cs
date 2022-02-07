using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    partial class Program
    {
        // Метод для тестирования.
        static void Test()
        {
            // Создадим несколько объектов структуры даты и заполним ее.
            DateStruct date1 = new DateStruct()
            {
                Day = 12,
                Hour = 10,
                Minute = 12,
                Month = Months.December,
                Year = 2020
            };

            DateStruct date2 = new DateStruct()
            {
                Day = 9,
                Hour = 11,
                Minute = 33,
                Month = Months.May,
                Year = 2020
            };
            /**
 * Построим следующую иерархию.
 * Класс ДОКУМЕНТ сделаем абстрактным, который будет описывать
 * свойства присущие документам. Он будет родителем для классов
 * НАКЛАДНАЯ, КВИТАНЦИЯ т.к эти классы являются документами.
 * Класс ЧЕК является запечатанным классом, можем только использовать его.
 * В нем будет хранится общая стоимость услуг/товаров из классов НАКЛАДНАЯ КВИТАНЦИЯ
 * 
 * Класс ДАТА, будет запечатанным классом, который нельзя наследовать,
 * будет хранить в себе время и дату, которое зададим для его объектов.
 * Также перегрузим для него все методы object. Для него создаим интерфейс
 * который будет определелять члены класса для класса ДАТА.
 * 
 * Класс ОРГАНИЗАЦИЯ, сделаем абстрактным.
 * Будем наследовать его для каждого нового класса придуманной организации.
 * 
 */

            /**
             * Можно воспользоваться полиморфизмом, и передавать потомков класса Organization
             * вторым параметром. Создадим две организации, МосГорЭлектро и продуктовый магазин.
             */
            // Создадим тестовые объекты. Квитанции и накладной.
            // Поскольку добавили перегрузку конструктора для работы со структурой
            // передадим в дату структуру.
            Receipt mosGorElRec = new Receipt(new Date(date1),
                new MoscowEnergyEstablishment());
            // Заполним словарь услуга-стоимость
            mosGorElRec.ServicePricePair.Add("Электричество", 1230);
            mosGorElRec.ServicePricePair.Add("Отопление", 3434);
            mosGorElRec.ServicePricePair.Add("Газ", 124);
            mosGorElRec.ServicePricePair.Add("ЖКХ", 534);
            mosGorElRec.CalculateFinalPrice(); // Посчитаем общую стоимость услуг и занесем в чек

            ConsignmentNote mosGorElCN = new ConsignmentNote(new Date(date2),
                new MoscowEnergyEstablishment());
            // Заполним словарь товар-стоимость
            mosGorElCN.GoodsPricePair.Add("Счетчик \"Заря\"", 1543.23);
            mosGorElCN.GoodsPricePair.Add("Счетчик \"M23\"", 2543.23);
            mosGorElCN.GoodsPricePair.Add("Счетчик \"Электрон\"", 543.23);
            mosGorElCN.CalculateFinalPrice();
            Console.WriteLine(new MoscowEnergyEstablishment().GetFullInfo() + "\n\n");
            ///////////////////////////////////////////////////////////////////////////
            // Создадим тестовые объекты. Квитанции и накладной.
            Receipt freshMarketRec = new Receipt(new Date(5, 32, 15, 2020, "December"),
                new FreshMarket());
            // Заполним словарь услуга-стоимость
            freshMarketRec.ServicePricePair.Add("Доставка продуктов", 34230);
            freshMarketRec.ServicePricePair.Add("Накладные расходы", 342334);
            freshMarketRec.ServicePricePair.Add("Логистика", 1234124);
            freshMarketRec.ServicePricePair.Add("Уборка", 53434);
            freshMarketRec.CalculateFinalPrice(); // Посчитаем общую стоимость услуг и занесем в чек

            ConsignmentNote freshMarketCN = new ConsignmentNote(new Date(5, 32, 15, 2020, "December"),
                new FreshMarket());
            // Заполним словарь товар-стоимость
            freshMarketCN.GoodsPricePair.Add("Фрукты", 154334.23);
            freshMarketCN.GoodsPricePair.Add("Вода", 2543343.23);
            freshMarketCN.GoodsPricePair.Add("Овощи", 54433.23);
            freshMarketCN.CalculateFinalPrice();
            Console.WriteLine(new FreshMarket().GetFullInfo() + "\n");
            // Выведем для продуктового магазина список накладной.
            foreach (var good in freshMarketCN.GoodsPricePair)
            {
                Console.WriteLine($"Наименование товара: {good.Key} | Цена: {good.Value}");
            }
            Console.WriteLine("\n\n");

            // Создаем список из документов разных организаций.
            List<Document> documents = new List<Document>()
            {
                mosGorElRec,
                mosGorElCN,
                freshMarketRec,
                freshMarketCN
            };
            // Создаем объект принтер.
            Printer printer = new Printer();

            // Последовательно перебираем все объекты и вызываем их перегрузку tostring
            foreach (var doc in documents)
            {
                printer.IAmPrinting(doc);
            }
        }

        static void Test2()
        {
            // Создадим несколько объектов структуры даты и заполним ее.
            DateStruct date1 = new DateStruct()
            {
                Day = 11,
                Hour = 23,
                Minute = 59,
                Month = Months.December,
                Year = 2020
            };

            DateStruct date2 = new DateStruct()
            {
                Day = 14,
                Hour = 11,
                Minute = 33,
                Month = Months.May,
                Year = 2020
            };

            DateStruct date3 = new DateStruct()
            {
                Day = 23,
                Hour = 6,
                Minute = 44,
                Month = Months.April,
                Year = 2021
            };

            DateStruct date4 = new DateStruct()
            {
                Day = 11,
                Hour = 15,
                Minute = 17,
                Month = Months.March,
                Year = 2021
            };

            // Создадим несколько объектов
            ConsignmentNote mosGorElCN = new ConsignmentNote(new Date(date1),
                new MoscowEnergyEstablishment());
            mosGorElCN.GoodsPricePair.Add("Счетчик \"Заря\"", 1543.23);
            mosGorElCN.GoodsPricePair.Add("Счетчик \"M23\"", 2543.23);
            mosGorElCN.GoodsPricePair.Add("Счетчик \"Электрон\"", 543.23);

            ConsignmentNote mosGorElCN2 = new ConsignmentNote(new Date(date2),
                new MoscowEnergyEstablishment());
            mosGorElCN2.GoodsPricePair.Add("Счетчик \"Вега-123\"", 15233.23);
            mosGorElCN2.GoodsPricePair.Add("Счетчик \"M99\"", 25423.23);
            mosGorElCN2.GoodsPricePair.Add("Счетчик \"NewWave\"", 5143.23);

            ConsignmentNote mosGorElCN3 = new ConsignmentNote(new Date(date3),
                new MoscowEnergyEstablishment());
            mosGorElCN3.GoodsPricePair.Add("Мультиметр \"Тестер-92\"", 133.23);
            mosGorElCN3.GoodsPricePair.Add("Галогенная лампа \"ГЛ-23\"", 423.23);
            mosGorElCN3.GoodsPricePair.Add("Провод 100м \"12-12\"", 5143.23);

            ConsignmentNote mosGorElCN4 = new ConsignmentNote(new Date(date4),
                new MoscowEnergyEstablishment());
            mosGorElCN4.Check = null; // Чека нет.
            mosGorElCN4.GoodsPricePair.Add("Набор инструментов \"Электрик\"", 133.23);
            mosGorElCN4.GoodsPricePair.Add("Щипцы \"ЩС-13\"", 423.23);
            mosGorElCN4.GoodsPricePair.Add("Сварочный аппарат \"12-12\"", 5143.23);

            ConsignmentNote mosGorElCN5 = new ConsignmentNote(new Date(date3),
                new MoscowEnergyEstablishment());
            mosGorElCN5.Check = null; // Чека нет.
            mosGorElCN5.GoodsPricePair.Add("Мультиметр \"Тестер-92\"", 133.23);
            mosGorElCN5.GoodsPricePair.Add("Галогенная лампа \"ГЛ-23\"", 423.23);
            mosGorElCN5.GoodsPricePair.Add("Провод 100м \"12-12\"", 5143.23);

            // Заполним контейнер объектами.
            Accounting accounting = new Accounting();
            accounting.Documents.Add(mosGorElCN);
            accounting.Documents.Add(mosGorElCN2);
            accounting.Documents.Add(mosGorElCN3);
            accounting.Documents.Add(mosGorElCN4);
            accounting.Documents.Add(mosGorElCN5);

            /**
             * Вызовем assert. Подобные вызовы стараться избегать,
             * в рабочем коде подобных вызовов не должно быть вообще.
             * !!!использовать ТОЛЬКО в качестве отладочных целей и тестов!!!
             *
             * Проверяем утверждение, что количество объектов, должно быть больше 0
             * если объектов больше 0 условие верное и срабатывать не будет, сработает только в
             * том случае если утверждение ЛОЖНО, а именно, когда объектов 0,
             * ЧТобы вызвать этот assert, нужно заккоментировать три строки 186, 187, 188
             */
            System.Diagnostics.Debug.Assert(mosGorElCN5.GoodsPricePair.Count > 0,
                "Список товаров в накладной не может быть пуст!");

            // Если условие верное
            if (accounting.Documents.Count == 0)
            {
                // выбрасываем исключение
                throw new EmptyObjectsException();
            }
            // Напечатаем на консоль информацию об объектах
            accounting.PrintDocuments();

            // Передадим классу контроллеру, класс контейнер.
            AccountingController accountingController = new AccountingController(accounting);
            // Протестируем методы по заданию.
            string findName = "Мультиметр \"Тестер-92\"";
            var res = accountingController.CalculateFinallyCost(findName);
            Console.WriteLine($"Суммарная стоимость {findName} = {res}");
            Console.WriteLine($"Количество чеков для накладных = {accountingController.CalculateCheckCount()}");
            // Возьмем интервал год, и напечатаем НЕ меньше ДВУХ дат.
            accountingController.PrintTwoDocs(DateTime.ParseExact("2020-12-12",
                "yyyy-MM-dd", 
                System.Globalization.CultureInfo.InvariantCulture),
                DateTime.ParseExact("2020-01-12",
                "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture));
        }
    }
}
