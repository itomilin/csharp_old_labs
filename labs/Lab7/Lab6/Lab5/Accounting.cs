using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    // Класс контейнер БУXГАЛТЕРИЯ.
    sealed class Accounting
    {
        /**
         * Список с абстрактным типом данных ДОКУМЕНТ
         * определен в виде автоматического свойства для удобства.
         * В это контейнер будем помещать документы (квитанции, накладные)
         * В списке уже реализованы операции удаления/добавления новых элементов,
         * поэтому дополнительные методы не требуются.
         */
        public List<Document> Documents { get; set; } 
            = new List<Document>();


        // Метод печати списка на консоль.
        public void PrintDocuments()
        {
            foreach (var document in Documents)
            {
                Console.WriteLine("=======================");
                Console.WriteLine(document.DocumentType);
                Console.WriteLine(document.Date);
                Console.WriteLine(document.Organization.GetFullInfo());
                foreach (var item in ((ConsignmentNote)document).GoodsPricePair)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
                Console.WriteLine("=======================");
            }
        }
    }
}
