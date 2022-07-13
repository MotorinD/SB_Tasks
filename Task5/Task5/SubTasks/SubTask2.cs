namespace Task5.SubTasks
{
    /// <summary>
    /// Второе задание
    /// </summary>
    internal class SubTask2
    {
        /// <summary>
        /// Выполнить второе задание
        /// </summary>
        public static void Execute()
        {
            while (true)
            {
                var userSentence = SentenceWorkHelper.EnterSentence();
                var reverseSentence = SentenceWorkHelper.ReverseWords(userSentence);
                SentenceWorkHelper.PrintSentence(reverseSentence);

                if (SentenceWorkHelper.YNQuestion("Закончить работу?"))
                    break;
            }
        }
    }
}
