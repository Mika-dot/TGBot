using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using Microsoft.VisualBasic;

namespace TGBot
{
    public class CommunicationMethods
    {
        ITelegramBotClient botClient { get; set; }
        long chatId { get; set; }
        Update update { get; set; }
        CancellationToken cancellationToken { get; set; }
        public CommunicationMethods(ITelegramBotClient _botClient, Update _update, CancellationToken _cancellationToken)
        {
            botClient = _botClient;
            chatId = _update.Message.Chat.Id;
            update = _update;
            cancellationToken = _cancellationToken;
        }


        public async void TextButton(
            string text, 
            string textButton,
            string url
            )
        {
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: text,
                parseMode: ParseMode.MarkdownV2,
                disableNotification: true,
                replyToMessageId: update.Message.MessageId,
                replyMarkup: new InlineKeyboardMarkup(
                    InlineKeyboardButton.WithUrl(
                        text: textButton,
                        url: url)),
                cancellationToken: cancellationToken);
        }
        public async void Text( string text )
        {
             await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: text,
                    cancellationToken: cancellationToken);
        }
        public async void Stickers(string url)
        {
            await botClient.SendStickerAsync(
                    chatId: chatId,
                    sticker: InputFile.FromUri(url),
                    cancellationToken: cancellationToken);
        }
        public async void Stickers_Local(string url)
        {
            await botClient.SendStickerAsync(
                    chatId: chatId,
                    sticker: InputFile.FromStream(System.IO.File.OpenRead(url)),
                    cancellationToken: cancellationToken);
        }
        public async void Video(string url)
        {
            await botClient.SendVideoAsync(
                    chatId: chatId,
                    video: InputFile.FromUri(url),
                    cancellationToken: cancellationToken);
        }
        public async void Video_Local(string url)
        {
            await botClient.SendVideoAsync(
                    chatId: chatId,
                    video: InputFile.FromStream(System.IO.File.OpenRead(url)),
                    cancellationToken: cancellationToken);
        }
        public async void TextIMG_URL_HTML(string IMG, string HTML)
        {
            await botClient.SendPhotoAsync(
                    chatId: chatId,
                    photo: InputFile.FromUri(IMG),
                    caption: HTML,
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
        }
        public async void TextIMG_URL_HTML_Local(string IMG, string HTML)
        {
            await using Stream stream = System.IO.File.OpenRead(IMG);
            await botClient.SendPhotoAsync(
                    chatId: update.Message.Chat.Id,
                    photo: InputFile.FromStream(stream),
                    caption: HTML,
                    parseMode: ParseMode.Markdown,
                    cancellationToken: cancellationToken);
        }
        public async void Audio(string mp3)
        {
            await botClient.SendAudioAsync(
                    chatId: chatId,
                    audio: InputFile.FromUri(mp3),
                    cancellationToken: cancellationToken);
        }
        public async void Audio_Local(string mp3)
        {
            await using Stream stream = System.IO.File.OpenRead(mp3);
            await botClient.SendVoiceAsync(
                chatId: chatId,
                voice: InputFile.FromStream(stream),
                duration: 36,
                cancellationToken: cancellationToken);

        }
        public async void Video_Img(string url, string IMG)
        {
            await botClient.SendVideoAsync(
                    chatId: chatId,
                    video: InputFile.FromUri(url),
                    thumbnail: InputFile.FromUri(IMG),
                    supportsStreaming: true,
                    cancellationToken: cancellationToken);
        }
        public async void Video_Img_Local(string url, string IMG)
        {
            await using Stream stream = System.IO.File.OpenRead(url);
            await using Stream thumbnail = System.IO.File.OpenRead(IMG);
            await botClient.SendVideoAsync(
                    chatId: chatId,
                    video: InputFile.FromStream(stream),
                    thumbnail: InputFile.FromStream(thumbnail),
                    supportsStreaming: true,
                    cancellationToken: cancellationToken);
        }
        public async void Video360_Local(string mp4)
        {
            await using Stream stream = System.IO.File.OpenRead(mp4);

            await botClient.SendVideoNoteAsync(
                chatId: chatId,
                videoNote: InputFile.FromStream(stream),
                duration: 47,
                length: 360, // value of width/height
                cancellationToken: cancellationToken);
        }
        public async void PhotoArray(string[] Photo)
        {
            IAlbumInputMedia[] albums = new IAlbumInputMedia[Photo.Length];
            for (int i = 0; i < Photo.Length; i++)
            {
                albums[i] = new InputMediaPhoto(InputFile.FromUri(Photo[i]));
            }

            await botClient.SendMediaGroupAsync(
                chatId: chatId,
                media: albums,
                cancellationToken: cancellationToken);
        }
        public async void PhotoArray_Local(string[] Photo)
        {
            IAlbumInputMedia[] albums = new IAlbumInputMedia[Photo.Length];
            for (int i = 0; i < Photo.Length; i++)
            {
                await using Stream stream = System.IO.File.OpenRead(Photo[i]);
                albums[i] = new InputMediaPhoto(InputFile.FromStream(stream));
            }
            await botClient.SendMediaGroupAsync(
                chatId: chatId,
                media: albums,
                cancellationToken: cancellationToken);
        }
        public async void SurveyOpen(string Test, string[] Questions)
        {
            await botClient.SendPollAsync(
                chatId: chatId,
                question: Test,
                options: Questions,
                cancellationToken: cancellationToken);
        }
        public async void SurveyClose()
        {
             await botClient.StopPollAsync(
                    chatId: chatId,
                    messageId: update.Message.MessageId,
                    cancellationToken: cancellationToken);

        }
        public async void Telephone(
            string tel, 
            string firstName, string lastName,
            string TEXT)
        {
            await botClient.SendContactAsync(
                    chatId: chatId,
                    phoneNumber: tel,
                    firstName: firstName,
                    lastName: lastName,
                    vCard: TEXT,
                    cancellationToken: cancellationToken);
        }
        public async void MapText(string TEXT, string address, double[] Coordinates)
        {
            await botClient.SendVenueAsync(
                    chatId: chatId,
                    latitude: Coordinates[0],
                    longitude: Coordinates[1],
                    title: TEXT,
                    address: address,
                    cancellationToken: cancellationToken);
        }
        public async void Map(double[] Coordinates)
        {
            await botClient.SendLocationAsync(
                    chatId: chatId,
                    latitude: Coordinates[0],
                    longitude: Coordinates[1],
                    cancellationToken: cancellationToken);
        }


        public async void One_lineKeyboards(string[] Keyboard, string text)
        {
            KeyboardButton[] keyboards = new KeyboardButton[Keyboard.Length];
            for (int i = 0; i < Keyboard.Length; i++)
            {
                keyboards[i] = Keyboard[i];
            }

            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                keyboards,
            })
            {
                ResizeKeyboard = true
            };

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: text,
                replyMarkup: replyKeyboardMarkup,
                cancellationToken: cancellationToken);

        }
        public async void Multiple_lineKeyboards(string[] Keyboard, string text)
        {  
            KeyboardButton[][] keyboards = new KeyboardButton[Keyboard.Length][];
            for (int i = 0; i < Keyboard.Length; i++)
            {
                keyboards[i] = [Keyboard[i]];
            }
            ReplyKeyboardMarkup replyKeyboardMarkup = new(keyboards)
            {
                ResizeKeyboard = true
            };

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: text,
                replyMarkup: replyKeyboardMarkup,
                cancellationToken: cancellationToken);
        }
        public async void RequestInformation(string text)
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                KeyboardButton.WithRequestLocation("Share Location"),
                KeyboardButton.WithRequestContact("Share Contact"),
            });

            await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: text,
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
        }
        public async void RemoveKeyboard(string text)
        {
            await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: text,
                    replyMarkup: new ReplyKeyboardRemove(),
                    cancellationToken: cancellationToken);
        }
        public async void URLButtons(string Keyboard, string url, string text)
        {
            InlineKeyboardMarkup inlineKeyboard = new(new[]
            {
                InlineKeyboardButton.WithUrl(
                    text: Keyboard,
                    url: url)
            });

            await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: text,
                    replyMarkup: inlineKeyboard,
                    cancellationToken: cancellationToken);
        }


        public async void UploadingFile(string Way, string Name, string Text)
        {
            await using Stream stream = System.IO.File.OpenRead(Way);
            await botClient.SendDocumentAsync(
                chatId: chatId,
                document: InputFile.FromStream(stream: stream, fileName: Name),
                caption: Text);

        }

    }
}
