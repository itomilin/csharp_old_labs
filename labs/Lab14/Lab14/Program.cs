using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

// Для soap нужно добавить ссылку на сборку в проекте!
using System.Runtime.Serialization.Formatters.Soap;

using System.Xml.Serialization;

// Для json сериализации, нужно загрузить пакет из nuget
// и подключить пространство имен
using System.Runtime.Serialization.Json;
using System.Xml;

// Подключим пространство имен для работы jsontolinq
using Newtonsoft.Json.Linq;

namespace Lab14
{
    // Создадим перечисление для выбора действия
    enum SType
    {
        Serialize,
        Deserialize
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Возьмем два класса с наследованием из 5 задания и создадим несколько объектов
            Lab5.MoscowEnergyEstablishment moscowEnergy = new Lab5.MoscowEnergyEstablishment();
            Lab5.MoscowEnergyEstablishment moscowEnergyF = new Lab5.MoscowEnergyEstablishment()
            {
                Id = 1234,
                Address = "г. Серебряный бор, Улица Якорная 12",
                Name = "МосГорЭнерго \"филиал Серебряный бор\"",
                PhoneNumber = "495-12-12",
                Licence = "№123"
            };

            Lab5Json.MoscowEnergyEstablishment moscowEnergyJ = new Lab5Json.MoscowEnergyEstablishment()
            {
                Id = 1234,
                Address = "г. Сосновый бор, Улица Земляная 31",
                Name = "МосГорЭнерго \"филиал Сосновый бор\"",
                PhoneNumber = "495-32-99",
                Licence = "№1235"
            };

            // Также создадим массив объектов для второго задания,
            // для него выберем способ сериализации - JSON т.к этот
            // способ является наиболее предпочтительным и быстрым

            List<Lab5Json.MoscowEnergyEstablishment> establishments =
                new List<Lab5Json.MoscowEnergyEstablishment>()
                {
                    new Lab5Json.MoscowEnergyEstablishment
                    {
                        Id = 1234,
                        Address = "г. Сосновый бор, Улица Земляная 31",
                        Name = "МосГорЭнерго \"филиал Сосновый бор\"",
                        PhoneNumber = "495-32-99",
                        Licence = "№1235"
                    },
                    new Lab5Json.MoscowEnergyEstablishment
                    {
                        Id = 1234,
                        Address = "г. Серебряный бор, Улица Якорная 12",
                        Name = "МосГорЭнерго \"филиал Серебряный бор\"",
                        PhoneNumber = "495-12-12",
                        Licence = "№123"
                    },
                    new Lab5Json.MoscowEnergyEstablishment
                    {
                        Id = 12331,
                        Address = "г. Красный бор, Улица Морская 99",
                        Name = "МосГорЭнерго \"филиал Красный бор\"",
                        PhoneNumber = "495-32-91",
                        Licence = "№1236"
                    },
                    new Lab5Json.MoscowEnergyEstablishment
                    {
                        Id = 11,
                        Address = "г. Заневский, Улица Ленина 211",
                        Name = "МосГорЭнерго \"филиал Заневский\"",
                        PhoneNumber = "495-55-01",
                        Licence = "№1535"
                    },
                };

            // вызовем поочереди разные виды сериализации/десериализации, по заданию
            try
            {
                Console.WriteLine("==BINARY");
                BinarySerialization(SType.Serialize, moscowEnergyF);
                BinarySerialization(SType.Deserialize);
                Console.WriteLine("==SOAP");
                SoapSerialization(SType.Serialize, moscowEnergy);
                SoapSerialization(SType.Deserialize);
                // Для будущего задания с селекторами xpath, создадим документ xml с несколькими объектами
                Console.WriteLine("==XML");
                XmlSerialization(SType.Serialize, new List<Lab5.MoscowEnergyEstablishment>
                {
                    moscowEnergyF,
                    moscowEnergy,
                });
                XmlSerialization(SType.Deserialize);
                Console.WriteLine("==JSON");
                JsonSerialization(SType.Serialize, moscowEnergyJ);
                JsonSerialization(SType.Deserialize);

                // Пункт 11 Сериализуем методом Json, список объектов
                Console.WriteLine("==JSON_LIST");
                JsonSerializationL(SType.Serialize, establishments);
                JsonSerializationL(SType.Deserialize);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("**ОШИБКА СЕРИАЛИЗАЦИИ**" + ex);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            // пункт12
            P12();
            // пункт 13
            P13();

            Console.WriteLine("Press key to exit");
            Console.ReadKey();
        }

        private static void P12()
        {
            // 12.	Используя XPath напишите два селектора для  вашего XMLдокумента.
            // Напишем два селектора для созданного xml
            XmlDocument xDoc = new XmlDocument(); // создадим объект для работы с xml
            xDoc.Load("xmlSerialized.xml"); // загрузим документ
            XmlElement xRoot = xDoc.DocumentElement; // загрузим в xmlelement для работы

            // выполним запрос xpath, который находит элементы с указанным id
            XmlNode childnode = xRoot.SelectSingleNode("MoscowEnergyEstablishment[Id='1234']");
            if (childnode != null) // проверяем если что-то нашли по запросу
            {
                Console.WriteLine("Элемент списка с id = 1234:");
                foreach (XmlNode item in childnode) // выводим на консоль объект с этим id
                {
                    Console.WriteLine(item.OuterXml);
                }
            }


            // Сделаем запрос, который находит все узлы документа с тегами id
            XmlNodeList childnodes = xRoot.SelectNodes("//MoscowEnergyEstablishment//Id");
            if (childnodes != null) // проверяем если что-то нашли по запросу
            {
                Console.WriteLine("Список всех ID:");
                foreach (XmlNode item in childnodes) // выводим на консоль объект с этим id
                {
                    Console.WriteLine(item.OuterXml);
                }
            }
        }

        private static void P13()
        {
            // 13.Используя  LinqtoJSON создать несколько запросов
            // добавим популярную библиотку newtonsoft.json из Nuget

            // Прочтем файл в переменную
            string jsonData = File.ReadAllText("jsonSerializedList.json");
            JArray jsonArray = JArray.Parse(jsonData);
            Console.WriteLine("JSON TO LINQ");
            var root = jsonArray.Root.Children();
            Console.WriteLine("Получим список всех адресов: ");
            root["Address"].Select(t => t)
                .ToList().ForEach(i => Console.WriteLine(i));
            // Найдем количество элементов с указанным id
            int fId = 1234;
            var c = root["Id"]
                .Select(t => t)
                .Where(id => id.Value<int>().Equals(fId)).Count();
            Console.WriteLine($"Найдено {c} элеменов с Id = {fId}");

            ///////////////////////////////////////////////////
        }

        /// <summary>
        /// Метод для бинарной сериализации/десериализации
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">
        /// объект для сериализации, необязательный параметр
        /// т.к для десериализации нам нужен только файл с сохраненными данными
        /// </param>
        /// <param name="type">Опция сериализовать/десериализовать</param>
        private static void BinarySerialization(SType type, Lab5.Organization obj = null)
        {
            // имя файла, для сохранения данных
            const string FILE_NAME = "binarySerialized.bin";

            // Создаем объект для бинарного формата сериализации
            var binaryFormat = new BinaryFormatter();

            // Создадим поток для записи файла.
            // Используем using для безопасной работы с потоками.
            using (var fileStream = new FileStream(FILE_NAME,
                FileMode.OpenOrCreate)) // добавляем опцию на создание/перезапись файла
            {
                // Первый параметр, поток создания файла.
                // Второй параметр объект для сериализации.
                switch (type)
                {
                    case SType.Serialize:
                        if (obj is null)
                        {
                            Console.WriteLine("ERROR. obj is null!!!");
                            return;
                        }
                        Console.WriteLine("**ВЫБРАНА ОПЦИЯ - СЕРИАЛИЗАЦИЯ**\n");
                        // Вызываем метод для сериализации, первый параметр объект файлового
                        // стрима, второй объект, то что хотим сериализовать
                        binaryFormat.Serialize(fileStream, obj);
                        Console.WriteLine("**Бинарная сериализация выполнена!**\n");
                        break;
                    case SType.Deserialize:
                        Console.WriteLine("**ВЫБРАНА ОПЦИЯ - ДЕСЕРИАЛИЗАЦИЯ**\n");
                        // При десериализации возвращается object, поэтому
                        // нужно выполнить преобразование типа
                        var deserializeObject = binaryFormat
                            .Deserialize(fileStream) as Lab5.Organization;
                        if (deserializeObject != null)
                        {
                            // Посколько tostring уже перегружен,
                            // то можно просто вывести десериализованный объект на консоль
                            Console.WriteLine(deserializeObject);
                            Console.WriteLine("**Десериализация выполнена!**\n");
                        }
                        break;
                    default:
                        break;
                }                
            }
        }

        // Поскольку у класса soapformatter общий интерфейс с Binaryformatter
        // то отличий в плане кода сериализации/десериализации, кроме содержимого файла, нету.

        // просто скопируем предыдущий метод и заменим название метода и название файла.
        private static void SoapSerialization(SType type, Lab5.Organization obj = null)
        {
            const string FILE_NAME = "soapSerialized.soap";

            // Создаем объект для soap формата сериализации
            var soapFormat = new SoapFormatter();

            // Создадим поток для записи файла.
            // Используем using для безопасной работы с потоками.
            using (var fileStream = new FileStream(FILE_NAME,
                FileMode.OpenOrCreate)) // добавляем опцию на создание/перезапись файла
            {
                // Первый параметр, поток создания файла.
                // Второй параметр объект для сериализации.
                switch (type)
                {
                    case SType.Serialize:
                        if (obj is null)
                        {
                            Console.WriteLine("ERROR. obj is null!!!");
                            return;
                        }
                        Console.WriteLine("**ВЫБРАНА ОПЦИЯ - СЕРИАЛИЗАЦИЯ**\n");
                        // Вызываем метод для сериализации, первый параметр объект файлового
                        // стрима, второй объект, то что хотим сериализовать
                        soapFormat.Serialize(fileStream, obj);
                        Console.WriteLine("**SOAP сериализация выполнена!**\n");
                        break;
                    case SType.Deserialize:
                        Console.WriteLine("**ВЫБРАНА ОПЦИЯ - ДЕСЕРИАЛИЗАЦИЯ**\n");
                        // При десериализации возвращается object, поэтому
                        // нужно выполнить преобразование типа
                        var deserializeObject = soapFormat
                            .Deserialize(fileStream) as Lab5.Organization;
                        if (deserializeObject != null)
                        {
                            // Посколько tostring уже перегружен,
                            // то можно просто вывести десериализованный объект на консоль
                            Console.WriteLine(deserializeObject);
                            Console.WriteLine("**Десериализация выполнена!**\n");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        // у xml уже другая реализация, поэтому код немного отличается
        private static void XmlSerialization(SType type, List<Lab5.MoscowEnergyEstablishment> obj = null)
        {
            const string FILE_NAME = "xmlSerialized.xml";

            // Создаем объект для xml сериализации
            // необходимо указать тип сериализуемого объекта
            var soapFormat = new XmlSerializer(typeof(List<Lab5.MoscowEnergyEstablishment>));

            // Создадим поток для записи файла.
            // Используем using для безопасной работы с потоками.
            using (var fileStream = new FileStream(FILE_NAME,
                FileMode.OpenOrCreate)) // добавляем опцию на создание/перезапись файла
            {
                // Первый параметр, поток создания файла.
                // Второй параметр объект для сериализации.
                switch (type)
                {
                    case SType.Serialize:
                        if (obj is null)
                        {
                            Console.WriteLine("ERROR. obj is null!!!");
                            return;
                        }
                        Console.WriteLine("**ВЫБРАНА ОПЦИЯ - СЕРИАЛИЗАЦИЯ**\n");
                        // Вызываем метод для сериализации, первый параметр объект файлового
                        // стрима, второй объект, то что хотим сериализовать
                        soapFormat.Serialize(fileStream, obj);
                        Console.WriteLine("**XML сериализация выполнена!**\n");
                        break;
                    case SType.Deserialize:
                        Console.WriteLine("**ВЫБРАНА ОПЦИЯ - ДЕСЕРИАЛИЗАЦИЯ**\n");
                        // При десериализации возвращается object, поэтому
                        // нужно выполнить преобразование типа
                        var deserializeObject = soapFormat
                            .Deserialize(fileStream) as List<Lab5.Organization>;
                        if (deserializeObject != null)
                        {
                            // Посколько tostring уже перегружен,
                            // то можно просто вывести десериализованный объект на консоль
                            Console.WriteLine(deserializeObject);
                            Console.WriteLine("**Десериализация выполнена!**\n");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        // Для json используется другой способ тегирования, поэтому чтобы работали
        // другие демонстрационные методы,необходимо было добавить другое пространство имен с такими же классами
        // но теги отличаются, можно посмотреть в директории lab5Json
        // реализация по коду отличается другими именами методов для сериализации/десериализации
        private static void JsonSerialization(SType type, Lab5Json.Organization obj = null)
        {
            const string FILE_NAME = "jsonSerialized.json";

            // Создаем объект для json сериализации
            // необходимо указать тип сериализуемого объекта, как в случае с XML
            var soapFormat = new DataContractJsonSerializer(typeof(Lab5Json.MoscowEnergyEstablishment));

            // Создадим поток для записи файла.
            // Используем using для безопасной работы с потоками.
            using (var fileStream = new FileStream(FILE_NAME,
                FileMode.OpenOrCreate)) // добавляем опцию на создание/перезапись файла
            {
                // Первый параметр, поток создания файла.
                // Второй параметр объект для сериализации.
                switch (type)
                {
                    case SType.Serialize:
                        if (obj is null)
                        {
                            Console.WriteLine("ERROR. obj is null!!!");
                            return;
                        }
                        Console.WriteLine("**ВЫБРАНА ОПЦИЯ - СЕРИАЛИЗАЦИЯ**\n");
                        // Вызываем метод для сериализации, первый параметр объект файлового
                        // стрима, второй объект, то что хотим сериализовать
                        soapFormat.WriteObject(fileStream, obj);
                        Console.WriteLine("**JSON сериализация выполнена!**\n");
                        break;
                    case SType.Deserialize:
                        Console.WriteLine("**ВЫБРАНА ОПЦИЯ - ДЕСЕРИАЛИЗАЦИЯ**\n");
                        // При десериализации возвращается object, поэтому
                        // нужно выполнить преобразование типа
                        var deserializeObject = soapFormat
                            .ReadObject(fileStream) as Lab5Json.Organization;
                        if (deserializeObject != null)
                        {
                            // Посколько tostring уже перегружен,
                            // то можно просто вывести десериализованный объект на консоль
                            Console.WriteLine(deserializeObject);
                            Console.WriteLine("**Десериализация выполнена!**\n");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        // Метод для десериализации списка объектов
        private static void JsonSerializationL(SType type, List<Lab5Json.MoscowEnergyEstablishment> obj = null)
        {
            const string FILE_NAME = "jsonSerializedList.json";

            // Создаем объект для json сериализации
            // необходимо указать тип сериализуемого объекта, как в случае с XML
            var soapFormat =
                new DataContractJsonSerializer(typeof(List<Lab5Json.MoscowEnergyEstablishment>));

            // Создадим поток для записи файла.
            // Используем using для безопасной работы с потоками.
            using (var fileStream = new FileStream(FILE_NAME,
                FileMode.OpenOrCreate)) // добавляем опцию на создание/перезапись файла
            {
                // Первый параметр, поток создания файла.
                // Второй параметр объект для сериализации.
                switch (type)
                {
                    case SType.Serialize:
                        if (obj is null)
                        {
                            Console.WriteLine("ERROR. obj is null!!!");
                            return;
                        }
                        Console.WriteLine("**ВЫБРАНА ОПЦИЯ - СЕРИАЛИЗАЦИЯ**\n");
                        // Вызываем метод для сериализации, первый параметр объект файлового
                        // стрима, второй объект, то что хотим сериализовать
                        soapFormat.WriteObject(fileStream, obj);
                        Console.WriteLine("**JSON сериализация выполнена!**" +
                            $"\nИнформация записана в файл {FILE_NAME}");
                        break;
                    case SType.Deserialize:
                        Console.WriteLine("**ВЫБРАНА ОПЦИЯ - ДЕСЕРИАЛИЗАЦИЯ**\n");
                        // При десериализации возвращается object, поэтому
                        // нужно выполнить преобразование типа
                        var deserializeObject = soapFormat
                            .ReadObject(fileStream) as List<Lab5Json.MoscowEnergyEstablishment>;
                        if (deserializeObject != null)
                        {
                            // Посколько tostring уже перегружен,
                            // то можно просто вывести десериализованный список на консоль
                            Console.WriteLine("===Десериализованный список объектов===");
                            foreach (var item in deserializeObject)
                            {
                                Console.WriteLine(item + "\n");
                            }    
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
