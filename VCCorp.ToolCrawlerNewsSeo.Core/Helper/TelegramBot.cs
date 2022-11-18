using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace VCCorp.ToolCrawlerNewsSeo.Core.Helper
{
    public class TelegramBot
    {
        //public static string BOT_ID = "5660708625:AAHtB8OTJQaB9xhqVpgHnmftx95ci67-C2k";
        //public static long ID_GROUP_TELEGRAM = 1;

        private readonly TelegramBotClient _telegramBot;

        public TelegramBot(string keyBot )
        {
            _telegramBot = new TelegramBotClient(keyBot);
        }

        public async Task SendMessageToGroup(string message, long groupId, bool isHtmlParseMode = false, bool isWebPreview = false)
        {
            try
            {
                var parseMode = ParseMode.Html;
                await _telegramBot.SendTextMessageAsync(groupId, message, parseMode, disableWebPagePreview: !isWebPreview).ConfigureAwait(false);
            }
            catch (Exception)
            {
            }
        }
    }
}
