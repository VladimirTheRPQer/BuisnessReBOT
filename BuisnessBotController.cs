using BuisnessReBOT.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Newtonsoft.Json;

namespace BuisnessReBOT
{
    
    [ApiController]
    [Route("api/message/update")]
    public class BuisnessBotController : ControllerBase
    {
        private readonly TelegramBotClient _telegramBotClient;
        private readonly DataContext _dataContext;

        public BuisnessBotController(BuisnessBot buisnessBot)
        {
            _telegramBotClient = buisnessBot.GetBot().Result;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody]object update)
        {
            var upd = JsonConvert.DeserializeObject<Update>(update.ToString());
            var chat = upd.Message?.Chat;

            if (chat == null)
            {
                return Ok();
            }

            var appUser = new AppUser
            {
                Name = chat.Username,
                ChatId = chat.Id,
                FirstName = chat.FirstName,
                LastName = chat.LastName

            };

            await _dataContext.Users.AddAsync(appUser);
            await _dataContext.SaveChangesAsync();

            await _telegramBotClient.SendTextMessageAsync(chat.Id, "Welcome в базу данных, бугагагага)))");

            return Ok();
        }

    }
}
