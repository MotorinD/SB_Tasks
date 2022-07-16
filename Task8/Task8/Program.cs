using System;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var st1 = new SubTask1();
            st1.Execute();

            var st2 = new SubTask2();
            st2.Execute();

            var st3 = new SubTask3();
            st3.Execute();

            var st4 = new SubTask4();
            st4.Execute();
        }

        /// <summary>
        /// Вопрос пользователю c вариантом ответа да или нет
        /// </summary>
        /// <returns>True если пользователь ответил да False если пользователь ответил нет</returns>
        public static bool YNQuestion(string question)
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
