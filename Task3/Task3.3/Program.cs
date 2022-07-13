using System;

namespace Task3._3
{
    internal class Program
    {
        /// <summary>
        /// Задание 3 определяем является ли введенное число простым
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите целое положительное число больше 1");
                int num = int.Parse(Console.ReadLine());

                if (num <= 0 || num == 1) 
                {
                    Console.WriteLine($"{num} не входит в множество простых чисел по определению");
                    continue;
                }

                int i = 2;
                bool isZeroRemainderFounded = false;

                while (i < num)
                {
                    int remainder = num % i;
                    if (remainder == 0)
                    {
                        isZeroRemainderFounded = true;
                        break;
                    }

                    i++;
                }

                Console.WriteLine(isZeroRemainderFounded ? "Число не является простым" : "Это простое число");
            }
        }
    }
}

