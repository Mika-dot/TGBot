using System.Drawing;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TGBot;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using Microsoft.VisualBasic;


internal class Program
{
    static TelegramBotClient botClient = new TelegramBotClient("7061885880:AAFCJbGhHl08JE30pMifC2lEs6d1OLs4W5w");
    static bool flag = true;
    static bool hasStarted = false;
    static void Main(string[] args)
    {

        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { }, // receive all update types
        };
        botClient.StartReceiving(
            HandleUpdateAsync,
            HandlePollingErrorAsync,
            receiverOptions,
            cancellationToken
        );
        Console.ReadLine();

        ;
    }

    static void MakeScreenshot()
    {
        // получаем размеры окна рабочего стола
        Rectangle bounds = Screen.GetBounds(Point.Empty);

        // создаем пустое изображения размером с экран устройства
        using (var bitmap = new Bitmap(bounds.Width, bounds.Height))
        {
            // создаем объект на котором можно рисовать
            using (var g = Graphics.FromImage(bitmap))
            {
                // перерисовываем экран на наш графический объект
                g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
            }

            // сохраняем в файл с форматом JPG
            bitmap.Save(@"C:\Users\Akim\Desktop\TGBot\TGBot\bin\Debug\net8.0\screenshot.jpg");
        }
    }

    static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message)
            return;
        if (message.Text is not { } messageText)
            return;

        CommunicationMethods methods = new CommunicationMethods(botClient, update, cancellationToken);

        if (flag)
        {
            methods.One_lineKeyboards(new string[] { "Осталось", "Считалась правильно", "Информация" }, "Клавиатура");
            flag = false;
        }

        switch (messageText)
        {
            case "Осталось":
                methods.Text(1.ToString());
                break;
            case "Считалась правильно":
                methods.Text(2.ToString());
                break;
            case "Информация":
                MakeScreenshot();
                methods.TextIMG_URL_HTML_Local(@"C:\Users\Akim\Desktop\TGBot\TGBot\bin\Debug\net8.0\screenshot.jpg",
                    "**Общее количество счетчиков: 10**  \r\n\r\n- Всего опрошено: 11  \r\n- Опрошено с профилем: 12\r\n");
                break;
            default:
                break;
        }
    }

    static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };


        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }


}




