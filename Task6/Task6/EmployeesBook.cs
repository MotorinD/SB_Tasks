using System;
using System.IO;
using System.Text;

namespace Task6
{
    /// <summary>
    /// Класс для работы со справочником сотрудников
    /// </summary>
    internal static class EmployeesBook
    {
        /// <summary>
        /// Наименование файла для хранения данных по сотрудникам
        /// </summary>
        static string fileName = "EmployeesBookData.txt";

        //размеры колонок для отображения таблицы в консоли
        static int colIdWidth = 3;
        static int colDateAddWidth = 17;
        static int colFullNameWidth = 30;
        static int colAgeWidth = 8;
        static int colHightWidth = 5;
        static int colDateBirthWidth = 15;
        static int colBirthLocationWidth = 15;

        /// <summary>
        /// Шаблон строки для талицы в консоли с индексом и указанной шириной каждой соответствующей колонки
        /// </summary>
        static string pattern =
                $"{"{0, " + $"{colIdWidth}" + "}"} | " +        //Id
                $"{"{1, " + $"{colDateAddWidth}" + "}"} | " +   //Дата добавления
                $"{"{2, " + $"{colFullNameWidth}" + "}"} | " +  //ФИО
                $"{"{3, " + $"{colAgeWidth}" + "}"} | " +       //Возраст
                $"{"{4, " + $"{colHightWidth}" + "}"} | " +     //Рост
                $"{"{5, " + $"{colDateBirthWidth}" + "}"} | " + //Дата рождения
                $"{"{6, " + $"{colBirthLocationWidth}" + "}"}"; //Место рождения

        /// <summary>
        /// Заголовок таблицы для отображения в консоли с наименованиями колонок
        /// </summary>
        static string header = string.Format(
            pattern,
            "Id",
            "Дата добавления",
            "Фамилия Имя Отчество",
            "Возраст",
            "Рост",
            "Дата рождения",
            "Место рождения");

        /// <summary>
        /// Вывести на экран данные из справочника
        /// </summary>
        internal static void ShowData()
        {
            Console.WriteLine();
            Console.WriteLine(header);

            var dataArray = GetAllData();

            foreach (var data in dataArray)
                Console.WriteLine(pattern, data.Split('#'));

            Console.WriteLine();
        }

        /// <summary>
        /// Добавить новую запись в справочник
        /// </summary>
        internal static void AddData()
        {
            var dataRow = GetDataRow();

            using (var sw = File.AppendText(fileName))
                sw.WriteLine(dataRow);
        }

        private static string GetDataRow()
        {
            var stringBuilder = new StringBuilder();

            AddDataToEmployeeString(stringBuilder, "Введите идентификатор Id:");
            stringBuilder.Append(DateTime.Now.ToString("g") + '#');
            AddDataToEmployeeString(stringBuilder, "Введите ФИО:");
            AddDataToEmployeeString(stringBuilder, "Введите возраст:");
            AddDataToEmployeeString(stringBuilder, "Введите рост:");
            AddDataToEmployeeString(stringBuilder, "Введите дату рождения:");
            AddDataToEmployeeString(stringBuilder, "Введите место рождения:", false);
            Console.WriteLine();

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Добавить данные от пользователя к строке с данными
        /// </summary>
        /// <param name="stringBuilder">Экземпляр StringBuilder</param>
        /// <param name="consoleMessage">Сообщение пользователю, что нужно ввести</param>
        /// <param name="isAppendSeparator">Нужно ли добавить разделитель после ввода данных</param>

        private static void AddDataToEmployeeString(StringBuilder stringBuilder, string consoleMessage, bool isAppendSeparator = true)
        {
            Console.WriteLine(consoleMessage);
            stringBuilder.Append(Console.ReadLine());

            if (isAppendSeparator)
                stringBuilder.Append('#');
        }

        /// <summary>
        /// Получение данных из файла
        /// </summary>
        /// <returns>Данные из файла в виде массива строк</returns>
        private static string[] GetAllData()
        {
            CreateDataFileIfNeed();
            return File.ReadAllLines(fileName);
        }

        /// <summary>
        /// Создает файл для хранения данных по сотрудникам если его не существует
        /// </summary>
        private static void CreateDataFileIfNeed()
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
        }
    }
}
