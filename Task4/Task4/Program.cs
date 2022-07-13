using System;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
        }

        /// <summary>
        /// Задание 1
        /// </summary>
        private static void Task1()
        {
            while (true) //бесконечный цикл, чтобы не перезапускать каждый раз
            {
                Console.WriteLine("Введите количество строк:");
                int rowCount = int.Parse(Console.ReadLine()); //считываем кол-ко строк
                Console.WriteLine("Введите количество столбцов:");
                int colCount = int.Parse(Console.ReadLine()); // считываем кол-во столбцов
                Console.WriteLine(); //отступ

                Random random = new Random(); //генератор псевдослучайных чисел
                int[,] arr = new int[rowCount, colCount]; //двумерный массив
                int sum = 0; //переменная для подсчета суммы

                for (int i = 0; i < rowCount; i++) // цикл по строкам
                {
                    for (int j = 0; j < colCount; j++) //цикл по столбцам
                    {
                        int num = random.Next(1, 10); // генерируем число
                        arr[i, j] = num; //записываем число в массив
                        sum += num; // прибавляем число к сумме
                        Console.Write($"{num} "); //выводим число
                    }
                    Console.WriteLine(); //переход к следующей строке для отображения в консоли
                }

                Console.WriteLine(); //отступ
                Console.WriteLine($"Сумма всех элементов: {sum}"); //вывод суммы

                if (YNQuestion("Перейти к следующему заданию?"))
                    break; //переход к следующему заданию
            }
        }

        /// <summary>
        /// Задание 2
        /// </summary>
        private static void Task2()
        {
            while (true)
            {
                Console.WriteLine("Введите длину последовательности:");
                int count = int.Parse(Console.ReadLine()); //длина последовательности
                int[] arr = new int[count]; //массив для хранения введенных пользователем чисел

                for (int i = 0; i < count; i++) //цикл для записи данных в массив
                {
                    Console.WriteLine($"Введите {i + 1}-e число:");
                    arr[i] = int.Parse(Console.ReadLine());
                }

                int minValue = int.MaxValue; //переменная для записи текущего минимального значения

                for (int i = 0; i < count; i++) //отдельный цикл по заданию, для поиска минимального значения
                {
                    if (arr[i] < minValue)
                        minValue = arr[i];
                }

                Console.WriteLine($"Минимальное значение: {minValue}");

                if (YNQuestion("Перейти к следующему заданию?"))
                    break; //переход к следующему заданию
            }
        }

        /// <summary>
        /// Задание 3
        /// </summary>
        private static void Task3()
        {
            while (true)
            {
                Console.WriteLine("Введите максимальное число диапазона:");
                int maxValue = int.Parse(Console.ReadLine()); //максимум диапазона
                var programNumber = new Random().Next(0, maxValue + 1); //загаданное число

                while (true)
                {
                    Console.WriteLine("Введите число или пустую строку если надоело и хочется выйти:");
                    string inputString = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputString)) //Проверка на ввод пустой строки и выход
                    {
                        Console.WriteLine($"Было загадано число {programNumber}");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }

                    int userNumber = int.Parse(inputString);

                    if (programNumber == userNumber) //проверка на совпадение введенного числа с загаданным
                    {
                        Console.WriteLine("Верно!");
                        break;
                    }

                    if (programNumber > userNumber) //сообщение пользователю о положении загаданного числа
                        Console.WriteLine("Загаданное число больше введенного");
                    else
                        Console.WriteLine("Загаданное число меньше введенного");
                }

                if (!YNQuestion("Попробовать еще раз?"))
                    break;
            }
        }

        /// <summary>
        /// Вопрос пользователю c вариантом отведа да или нет
        /// </summary>
        /// <returns>True если пользователь ответил да False если пользователь ответил нет</returns>
        private static bool YNQuestion(string question)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"===> {question} Y/N");
                var answer = Console.ReadLine();

                switch (answer)
                {
                    case "Y":
                    case "y":
                        Console.WriteLine();
                        return true;

                    case "N":
                    case "n":
                        Console.WriteLine();
                        return false;

                    default:
                        Console.WriteLine("Введен неверный символ");
                        break;
                }
            }
        }
    }
}
