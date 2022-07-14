using System;

namespace Task7
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public struct Employee
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Дата добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// Рост
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string DateBirth { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        public string BirthLocation { get; set; }
    }
}
