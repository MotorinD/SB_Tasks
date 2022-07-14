using System;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ShowChooseActionMessage();
                var action = Console.ReadLine().Trim();

                switch (action)
                {
                    case "1":
                        EmployeesBook.ShowData();
                        break;

                    case "2":
                        EmployeesBook.AddData();
                        break;

                    default:
                        Console.WriteLine("\nНекорректный ввод действия, введите 1 или 2\n");
                        break;
                }
            }
        }

        private static void ShowChooseActionMessage()
        {
            Console.WriteLine(
                   "Выберите вариант введя число:\n" +
                   "1 - вывести данные\n" +
                   "2 - добавить запись\n");
        }
    }
}
