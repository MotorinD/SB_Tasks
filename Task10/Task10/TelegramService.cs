using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.IO;
using File = System.IO.File;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Task10
{
    internal class TelegramService
    {
        MainWindow mainWindow;
        TelegramBotClient telegramBotClient;
        public TelegramService(MainWindow window)
        {
            this.mainWindow = window;

            var token = File.ReadAllText(@"C:\Users\Memento\Desktop\telegrToken.txt");
            this.telegramBotClient = new TelegramBotClient(token);

            using (var cts = new CancellationTokenSource())
            {
                var receiverOptions = new ReceiverOptions();
                receiverOptions.AllowedUpdates = Array.Empty<UpdateType>();

                this.telegramBotClient.StartReceiving(
                    updateHandler: this.HandleUpdateAsync,
                    pollingErrorHandler: this.HandlePollingErrorAsync,
                    receiverOptions: receiverOptions,
                    cancellationToken: cts.Token);
            }
        }

        /// <summary>
        /// Метод вызываемый при получении сообщения
        /// </summary>
        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is null
                || update.Message.From is null
                || update.Message.Text is null)
                return;

            var message = update.Message;

            if (message.Type != MessageType.Text)
                return;

            this.mainWindow.Dispatcher.Invoke(() =>
            {
                this.mainWindow.messageModelList.Add(
                    new MessageModel(
                        message.From.Id,
                        message.Text,
                        message.Date,
                        $"{message.From.FirstName} {message.From.LastName} {message.From.Username}"));
            });

            this.WriteMessageToLog(message);
        }

        string jsonPath = "jsonMessages.txt";
        private void WriteMessageToLog(Message msg)
        {
            List<Message> messageList;
            if (File.Exists(this.jsonPath))
            {
                var jsonRead = File.ReadAllText(this.jsonPath);
                messageList = JsonConvert.DeserializeObject<List<Message>>(jsonRead);
                messageList.Add(msg);
            }
            else
            {
                messageList = new List<Message>() { msg };
            }

            var jsonGenered = JsonConvert.SerializeObject(messageList);
            File.WriteAllText(this.jsonPath, jsonGenered);
        }

        /// <summary>
        /// отправка сообщения
        /// </summary>
        public void SendText(long userId, string text)
        {
            this.telegramBotClient.SendTextMessageAsync(
                chatId: userId,
                text: text);
        }

        /// <summary>
        /// Вывод ошибок
        /// </summary>
        Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Debug.WriteLine(exception.ToString());
            return Task.CompletedTask;
        }
    }
}
