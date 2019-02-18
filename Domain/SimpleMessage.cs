using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace SimpleBot.Logic
{
    public class SimpleMessage
    {
        public SimpleMessage(string userId, string username, string text)
        {
            UserId = userId;
            User = username;
            Text = text;
        }

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public string Text { get; set; }
    }
}