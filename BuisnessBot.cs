using Telegram.Bot;

namespace BuisnessReBOT
{
    public class BuisnessBot
    {
        private readonly IConfiguration _configuration;
        private TelegramBotClient _botClient;

        public BuisnessBot(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TelegramBotClient> GetBot()
        {
            if(_botClient != null)
            { 
                return _botClient;
            }
            _botClient = new TelegramBotClient(_configuration["Token"]);

            var hook = $"{_configuration["url"]}api/message/update";
            await _botClient.SetWebhookAsync(hook);

            return _botClient;
        }
    }
}
