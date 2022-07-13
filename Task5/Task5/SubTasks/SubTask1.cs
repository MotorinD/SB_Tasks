namespace Task5.SubTasks
{
    /// <summary>
    /// Первое задание
    /// </summary>
    internal class SubTask1
    {
        /// <summary>
        /// Выполнить первое задание
        /// </summary>
        public static void Execute()
        {
            while (true)
            {
                var userSentence = SentenceWorkHelper.EnterSentence();
                var wordsArray = SentenceWorkHelper.SplitSentence(userSentence);
                SentenceWorkHelper.PrintWords(wordsArray);

                if (SentenceWorkHelper.YNQuestion("Перейти к следующему заданию?"))
                    break;
            }
        }
    }
}
