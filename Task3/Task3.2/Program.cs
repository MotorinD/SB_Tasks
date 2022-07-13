using System;

namespace Task3._2
{
    internal class Program
    {
        /// <summary>
        /// Задание 2 подсчет суммы значений карт в игре 21
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Привет. Сколько карт на руках?");
            int count = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите номинал карты");
                string cardValue = Console.ReadLine();

                switch (cardValue)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                        sum += int.Parse(cardValue);
                        break;
                    case "J":
                    case "Q":
                    case "K":
                    case "T":
                        sum += 10;
                        break;

                    default:
                        Console.WriteLine("Введенное значение карты некорректно попробуйте еще раз");
                        i--; //т.к. введено неверное значение, отнимем от счетчика, чтобы была дополнительная попытка для этой карты
                        break;
                }
            }

            Console.WriteLine($"Сумма карт: {sum}");
            Console.ReadKey();
        }
    }
}
