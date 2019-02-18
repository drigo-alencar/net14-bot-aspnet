using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using SimpleBot.Logic;
using SimpleBot.Repositories;

namespace SimpleBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private static SimpleBotUser g_bot;
        private readonly UnitOfWork unitOfWork;

        public MessagesController()
        {
            // Pattern: singleton
            if (g_bot == null)
            {
                g_bot = new SimpleBotUser();
            }

            unitOfWork = new UnitOfWork();
        }

        [ResponseType(typeof(void))]
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            if (activity != null && activity.Type == ActivityTypes.Message)
            {
                await HandleActivityAsync(activity);
            }

            // HTTP 202
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        // Estabelece comunicacao entre o usuario e o SimpleBotUser
        private async Task HandleActivityAsync(Activity activity)
        {
            string text = activity.Text;
            string userFromId = activity.From.Id;
            string userFromName = activity.From.Name;

            var user = new SimpleBotUser { Id = userFromId, Username = userFromName };

            var message = new SimpleMessage(userFromId, userFromName, text);

            if (message.Text.ToLowerInvariant().Contains("delete my messages"))
            {
                unitOfWork.MessageRepository.DeleteUserMessages(user.Username);
            }
            else
            {
                unitOfWork.MessageRepository.Save(message);

                var simpleBotUser = unitOfWork.UserRepository.GetProfile(user.Id);
                unitOfWork.UserRepository.SetProfile(simpleBotUser);
            }

            string response = g_bot.Reply(message);

            await ReplyUserAsync(activity, response);
        }

        // Responde mensagens usando o Bot Framework Connector
        private async Task ReplyUserAsync(Activity message, string text)
        {
            var connector = new ConnectorClient(new Uri(message.ServiceUrl));
            var reply = message.CreateReply(text);

            await connector.Conversations.ReplyToActivityAsync(reply);
        }
    }
}