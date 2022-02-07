using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Receipt mosGorElRec = new Receipt(new Date(5, 32, 15, 2020, "December"),
                new MoscowEnergyEstablishment());
            // Заполним словарь услуга-стоимость
            mosGorElRec.ServicePricePair.Add("Электричество", 1230);
            mosGorElRec.ServicePricePair.Add("Отопление", 3434);
            mosGorElRec.ServicePricePair.Add("Газ", 124);
            mosGorElRec.ServicePricePair.Add("ЖКХ", 534);
            mosGorElRec.CalculateFinalPrice(); // Посчитаем общую стоимость услуг и занесем в чек

            ConsignmentNote mosGorElCN = new ConsignmentNote(new Date(5, 32, 15, 2020, "December"),
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
            Console.ReadKey();
        }
    }
}
