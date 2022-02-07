using System;
using System.Runtime.Serialization;

namespace Lab5Json
{
    /**
     * Абстрактный класс, определяет некое поведение для классов, в текущем контексте
     * для класса организация.
     * У любой организации обязательно есть базовые данные,
     * например название, какой-нибудь номер в реестре,
     * контактный телефон, адрес...
     * 
     * Определим свойства отвечающие за эти данные.
     * Также добавим метод, который должен отображать все эти данные сразу.
     * Ключевое слово abstract у членов класса, означает, что они не имеют реализации.
     */
    [DataContract] // Укажим тег, отличается от других способов
    public abstract class Organization
    {
        // Для каждого состояния объекта, нужно указать тег.
        // Контейнеры не отмеченные тегом, не будут сериализоваться!!

        [DataMember]
        public string Licence { get; set; } = null;

        [DataMember] 
        public abstract string Name { get; set; }

        [DataMember]
        public abstract int Id { get; set; }

        [DataMember]
        public abstract string PhoneNumber { get; set; }

        [DataMember]
        public abstract string Address { get; set; }
    }
}
