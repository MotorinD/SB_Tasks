using System;
using System.Collections.Generic;

namespace Task8
{
    internal class SubTask2
    {
        private Dictionary<string, string> phoneBookDict;

        public SubTask2()
        {
            this.phoneBookDict = new Dictionary<string, string>();
        }

        public void Execute()
        {
            Console.WriteLine("=== ЗАДАНИЕ 2 ===\n");

            this.FillPhoneBook();
            this.FindUser();
        }

        private void FindUser()
        {
            while (true)
            {
                Console.WriteLine("===> Для прекращения введите пустую строку. Поиск пользователя по номеру телефона. Введите номер:");
                var phone = Console.ReadLine();

                if (string.IsNullOrEmpty(phone))
                    break;

                if (!this.phoneBookDict.TryGetValue(phone, out var value))
                {
                    Console.WriteLine("===> Такой номер не обнаружен");
                    continue;
                }

                Console.WriteLine($"===> Фио:{value}");
            }
        }

        private void FillPhoneBook()
        {
            Console.WriteLine("===> Для прекращения ввода отправьте пустую строку\n");

            while (true)
            {
                Console.WriteLine("===> Введите номер телефона");
                var phone = Console.ReadLine();

                if (string.IsNullOrEmpty(phone))
                    break;

                if (this.phoneBookDict.ContainsKey(phone))
                {
                    Console.WriteLine("Такой номер уже есть\n");
                    continue;
                }

                Console.WriteLine("===> Введите ФИО");
                var fullName = Console.ReadLine();

                if (string.IsNullOrEmpty(fullName))
                    break;

                this.phoneBookDict.Add(phone, fullName);
            }
        }
    }
}
