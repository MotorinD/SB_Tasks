using System;

namespace Task2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fullName = "Иванов Иван Иванович";
            byte age = 25;
            string email = "iii@gmail.com";
            double progScore = 75.35;
            double mathScore = 66.21;
            double phisScore = 59.70;

            string pattern = "ФИО: {0},\nВозраст: {1},\nEmail: {2},\nБаллы по программированию: {3},\n" +
                "Баллы по математике: {4},\nБаллы по физике: {5}";

            Console.WriteLine(string.Format(pattern, fullName, age, email, progScore, mathScore, phisScore));
            Console.ReadKey();

            double sumScore = progScore + mathScore + phisScore;
            double coeffScore = sumScore / 3;

            Console.WriteLine($"Сумма баллов: {sumScore},\nСреднее арифметическое: {coeffScore:0.00}");
            Console.ReadKey();
        }
    }
}
