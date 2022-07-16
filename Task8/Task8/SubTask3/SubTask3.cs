using System;
using System.Collections.Generic;

namespace Task8
{
    internal class SubTask3
    {
        HashSet<int> numberHashSet;

        public SubTask3()
        {
            this.numberHashSet = new HashSet<int>();
        }

        internal void Execute()
        {
            Console.WriteLine("=== ЗАДАНИЕ 3 ===\n");

            while (true)
            {
                var nullableInt = this.GetNumber(); //если null, то пользователь ввел пустую строку
                if (nullableInt is null)
                {
                    if (!Program.YNQuestion("Перейти к следующему заданию?"))
                    {
                        this.numberHashSet.Clear();
                        Console.WriteLine("===> Продолжаем, таблица значений очищена");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                this.TryAddValue(nullableInt.Value);
            }
        }

        private void TryAddValue(int value)
        {
            if (this.numberHashSet.Contains(value))
            {
                Console.WriteLine("===> Число уже вводилось ранее");
            }
            else
            {
                this.numberHashSet.Add(value);
                Console.WriteLine("===> Число успешно сохранено");
            }
        }

        private int? GetNumber()
        {
            var inputString = string.Empty;
            int value;

            do
            {
                Console.WriteLine("===> Введите целое число, чтобы прервать задание введите пустую строку");
                inputString = Console.ReadLine();

                if (string.IsNullOrEmpty(inputString.Trim()))
                    return null;
            }
            while (!int.TryParse(inputString, out value));

            return value;
        }
    }
}
