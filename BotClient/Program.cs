using Domain.Models;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("https://localhost:7240/api/User");

            Console.WriteLine(result);
            var test = await result.Content.ReadAsStringAsync();
            Console.WriteLine(test);

            var botClient = new TelegramBotClient("6107848888:AAF5O60QZ0WbRDXW3aybcnfiROR_V6l63FU");

            using CancellationTokenSource cts = new();

            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
                );
            var me = await botClient.GetMeAsync();
            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            cts.Cancel();
        }
        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            /* Only process Massege updates: hhttp://core.telegram.org/bots/api#massage */
            if (update.Message is not { } message)
                return;
            if (message.Text is not { } messageText)
                return;
            var chatId = message.Chat.Id;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
            //Message setMessage = await botClient.SendTextMessageAsync( 
            //    chatId: chatId,
            //    text: "You said: \n" + messageText,
            //    cancellationToken: cancellationToken); 

            if (message.Text == "Проверка")
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "проверка: Ок",
                    cancellationToken: cancellationToken);
            }
            if (message.Text == "Привет" || message.Text == "привет")
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Приветули, красотуля)",
                    cancellationToken: cancellationToken);
            }

            if (message.Text == "ку")
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "ку привет здравствуйте хорошего дня вечера ночи живите богато",
                    cancellationToken: cancellationToken);
            }

            if (message.Text == "Картинка")
            {
                await botClient.SendPhotoAsync(
                    chatId: chatId,
                    photo: "https://cs9.pikabu.ru/post_img/big/2020/06/25/6/159307832513015589.jpg",
                    caption: "<b>хочу черешню</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
            }
            if (message.Text == "Видео")
            {
                message = await botClient.SendVideoAsync(
                chatId: chatId,
                video: @"C:\Users\user\Documents\GitHub\task\BotClient\котик кушает черешню.mp4",
                /*thumb: "https://raw.githubusercontent.com/TelegramBots/book/master/src/2/docs/thumb-clock.jpg",*/
                supportsStreaming: true,
                cancellationToken: cancellationToken);
            }
            if (message.Text == "Стикер")
            {
                message = await botClient.SendStickerAsync(
                chatId: chatId,
                sticker: "CAACAgIAAxkBAAEgq91kVLfuuRgcnXNHlyjKnsPRIvmwmQACXRwAAqvQQUix35BnpHrVzi8E",
                cancellationToken: cancellationToken);
            }
            
            if (message.Text == "купить черешню")
            {
                message = await botClient.SendPhotoAsync(
                chatId: chatId,
                photo: "https://cs10.pikabu.ru/post_img/big/2020/06/25/6/1593078334125699339.jpg",
                caption: "<b>держи, друг</b>. <i>Source</i>: <a href=\"https://pikabu.ru/story/kogda_u_tebya_chereshnezavisimost_7544386\">Pikabu</a>",
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);
            }

        }
        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                => $"Telegramm Api Error: \n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
              _ => exception.ToString()
            };
            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}