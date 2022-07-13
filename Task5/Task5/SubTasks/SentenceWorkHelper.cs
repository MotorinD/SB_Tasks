using System;

namespace Task5.SubTasks
{
    internal static class SentenceWorkHelper
    {
        /// <summary>
        /// Ввод пользователем предложения
        /// </summary>
        /// <returns>Введенное пользователем предложение</returns>
        internal static string EnterSentence()
        {
            var result = string.Empty;

            while (true)
            {
                Console.WriteLine("Введите предложение:");
                result = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine();
                    break;
                }

            }

            return result;
        }

        /// <summary>
        /// Разделить предложение по пробелу
        /// </summary>
        /// <param name="userSentence">Предложение которое нужно разделить</param>
        /// <returns>Массив слов</returns>
        internal static string[] SplitSentence(string userSentence)
        {

            var result = userSentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return result;
        }

        /// <summary>
        /// Расположить слова в предложении в обратном порядке
        /// </summary>
        /// <param name="userSentence">Предложение для которого необходимо расположить слова в обратном порядке</param>
        /// <returns>Предложение с обратным порядком слов</returns>
        internal static string ReverseWords(string userSentence)
        {
            var wordsArray = SplitSentence(userSentence);
            Array.Reverse(wordsArray);
            var result = string.Empty;

            foreach (var word in wordsArray)
                result += $"{word} ";

            return result;
        }

        /// <summary>
        /// Вывести в консоль массив слов построчно
        /// </summary>
        /// <param name="wordsArray">Массив слов который нужно вывести</param>
        public static void PrintWords(string[] wordsArray)
        {
            foreach (var word in wordsArray)
                Console.WriteLine(word);

            Console.WriteLine();
        }

        /// <summary>
        /// Вывести в консоль предложение
        /// </summary>
        /// <param name="sentence">Предложение которое необходимо вывести</param>
        internal static void PrintSentence(string sentence)
        {
            Console.WriteLine(sentence);
            Console.WriteLine();
        }

        /// <summary>
        /// Вопрос пользователю c вариантом отведа да или нет
        /// </summary>
        /// <returns>True если пользователь ответил да False если пользователь ответил нет</returns>
        internal static bool YNQuestion(string question)
        {
            while (true)
            {
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
