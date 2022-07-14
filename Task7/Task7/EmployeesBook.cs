using System;
using System.IO;
using System.Text;

namespace Task7
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

        static Employee[] employeesCache = new Employee[1]; // хранилище для структур Сотрудник

        static int index; // текущий элемент для добавления в Employees

        //размеры колонок для отображения таблицы в консоли
        static int colIdWidth = 3;
        static int colDateAddWidth = 20;
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
        /// Загрузить данные из файла
        /// </summary>
        static public void LoadData()
        {
            var dataArray = GetAllData();

            foreach (var data in dataArray)
            {
                var employee = ConvertStringToModel(data);
                AddToCache(employee);
            }
        }

        /// <summary>
        /// Метод добавления сотрудника в хранилище
        /// </summary>
        /// <param name="ConcreteEmployee">Сотрудник</param>
        public static void AddToCache(Employee ConcreteEmployee)
        {
            Resize(index >= employeesCache.Length);
            employeesCache[index] = ConcreteEmployee;
            index++;
        }

        /// <summary>
        /// Преобразовать строку с разделителями из файла в модель Employee
        /// </summary>
        /// <param name="data">Строка с данными</param>
        /// <returns>модель Employee</returns>
        private static Employee ConvertStringToModel(string data)
        {
            var temp = data.Split('#');
            var employee = new Employee
            {
                Id = temp[0],
                DateAdd = Convert.ToDateTime(temp[1]),
                FullName = temp[2],
                Age = temp[3],
                Height = temp[4],
                DateBirth = temp[5],
                BirthLocation = temp[6]
            };

            return employee;
        }

        /// <summary>
        /// Добавить новую запись в справочник
        /// </summary>
        internal static void AddData()
        {
            var dataRow = GetDataRow();

            if (string.IsNullOrEmpty(dataRow))
                return;

            using (var sw = File.AppendText(fileName))
                sw.WriteLine(dataRow);

            var employee = ConvertStringToModel(dataRow);
            AddToCache(employee);
        }

        /// <summary>
        /// Отредактировать запись в справочнике
        /// </summary>
        internal static void EditData()
        {
            if (employeesCache.Length == 0)
            {
                Console.WriteLine("===> Нет записей в справочнике\n");
                return;
            }

            var dataRow = GetDataRow(isAdd: false);

            if (string.IsNullOrEmpty(dataRow))
                return;

            var employee = ConvertStringToModel(dataRow);
            var position = FindPositionById(employee.Id);

            employee.DateAdd = employeesCache[position].DateAdd;
            employeesCache[position] = employee;
            ReSaveAll();
        }

        /// <summary>
        /// Удалить запись из справочника
        /// </summary>
        internal static void DeleteData()
        {
            if (employeesCache.Length == 0)
            {
                Console.WriteLine("===> Нет записей в справочнике\n");
                return;
            }

            var id = GetIdForDelete();
            var position = FindPositionById(id);

            if (position == -1) // не нашли ничего по Id
                return;

            var temp = new Employee[index - 1];
            var tempIndex = 0;
            for (int i = 0; i < index; i++)
            {
                if (i != position)
                {
                    temp[tempIndex] = employeesCache[i];
                    tempIndex++;
                }
            }

            employeesCache = temp;
            index = tempIndex;
            ReSaveAll();
        }

        /// <summary>
        /// Пересохраняет данные из кэша в файл
        /// </summary>
        /// <param name="Path">Путь к файлу сохранения</param>
        private static void ReSaveAll()
        {
            File.Delete(fileName);
            for (int i = 0; i < index; i++)
            {
                var temp = String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}",
                                        employeesCache[i].Id,
                                        employeesCache[i].DateAdd,
                                        employeesCache[i].FullName,
                                        employeesCache[i].Age,
                                        employeesCache[i].Height,
                                        employeesCache[i].DateBirth,
                                        employeesCache[i].BirthLocation);
                File.AppendAllText(fileName, $"{temp}\n");
            }
        }

        /// <summary>
        /// Найти в массиве - кэше элемент по Id и вернуть его индекс в массиве
        /// </summary>
        private static int FindPositionById(string id)
        {
            for (int i = 0; i < index; i++)
            {
                if (employeesCache[i].Id == id)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Запросить у пользователя Id для удаления
        /// </summary>
        /// <returns></returns>
        private static string GetIdForDelete()
        {
            Console.WriteLine("Введите Id записи которую хотите удалить");
            var id = Console.ReadLine();

            if (FindPositionById(id) == -1)
                Console.WriteLine("===> Такой Id не найден\n");

            return id;
        }

        /// <summary>
        /// Запросить у пользователя строку для добавления/редактирования
        /// </summary>
        /// <returns></returns>
        private static string GetDataRow(bool isAdd = true)
        {
            var stringBuilder = new StringBuilder();

            AddDataToEmployeeString(stringBuilder, "Введите идентификатор Id:");
            if (!isAdd && FindPositionById(stringBuilder.ToString().Split('#')[0]) == -1)
            {
                Console.WriteLine("===> Запись с таким Id не найдена\n");
                return "";
            }

            stringBuilder.Append(DateTime.Now.ToString() + '#');
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
        /// <summary>
        /// Метод увеличения текущего хранилища
        /// </summary>
        /// <param name="Flag">Условие увеличения</param>
        private static void Resize(bool Flag)
        {
            if (Flag)
            {
                var cacheSize = employeesCache.Length;
                var newSize = cacheSize == 0 ? 2 : cacheSize * 2;
                Array.Resize(ref employeesCache, newSize);
            }
        }
    }
}
