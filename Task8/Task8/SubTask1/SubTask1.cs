using System;
using System.Collections.Generic;

namespace Task8
{
    internal class SubTask1
    {
        private List<int> numberList;
        private int numCount;
        private int maxValue;
        private int minValue;

        public SubTask1()
        {
            this.numberList = new List<int>();
            this.numCount = 100;
            this.maxValue = 100;
            this.minValue = 0;
        }

        public void Execute()
        {
            Console.WriteLine("=== ЗАДАНИЕ 1 ===\n");

            while (true)
            {
                this.FillList();

                Console.WriteLine("===> Изначальный список");
                this.ShowList();

                this.RemoveNumberBetween(25, 50);

                Console.WriteLine("===> После удаления");
                this.ShowList();

                if (Program.YNQuestion("Перейти к следующему заданию?"))
                    break;

                this.numberList.Clear();
            }
        }

        private void FillList()
        {
            var rnd = new Random();

            for (int i = 0; i < this.numCount; i++)
                this.numberList.Add(rnd.Next(this.minValue, this.maxValue + 1));
        }

        private void RemoveNumberBetween(int left, int right)
        {
            for (int i = 0; i < this.numberList.Count; i++)
            {
                var item = this.numberList[i];

                if (item > left && item < right)
                    this.numberList.Remove(item);
            }
        }

        private void ShowList()
        {
            foreach (var item in this.numberList)
                Console.Write($"{item}, ");

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
