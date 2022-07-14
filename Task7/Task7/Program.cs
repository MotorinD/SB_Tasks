using System;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeesBook.LoadData();

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

                    case "3":
                        EmployeesBook.EditData();
                        break;

                    case "4":
                        EmployeesBook.DeleteData();
                        break;

                    default:
                        Console.WriteLine("\nНекорректный ввод действия, введите число от 1 до 4\n");
                        break;
                }
            }
        }

        private static void ShowChooseActionMessage()
        {
            Console.WriteLine(
                   "Выберите вариант введя число:\n" +
                   "1 - вывести данные\n" +
                   "2 - добавить запись\n" +
                   "3 - редактировать запись\n" +
                   "4 - удалить запись");
        }
    }
}