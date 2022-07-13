using System;

namespace Task3
{
    internal class Program
    {
        /// <summary>
        /// Задание 1, определение четности
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число");
            int num = int.Parse(Console.ReadLine());

            if (num % 2 == 0)
            {
                Console.WriteLine("Четное");
            }
            else
            {
                Console.WriteLine("Нечетное");
            }

            Console.ReadKey();
        }
    }
}
