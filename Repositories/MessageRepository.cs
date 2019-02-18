using MongoDB.Driver;
using SimpleBot.Logic;

namespace SimpleBot.Repositories
{
    public class MessageRepository
    {
        private const string COLLECTION_NAME = "Messages";

        private readonly IMongoCollection<SimpleMessage> collection;

        public MessageRepository(IMongoDatabase db)
        {
            collection = db.GetCollection<SimpleMessage>(COLLECTION_NAME);
        }

        internal void Save(SimpleMessage message)
        {
            collection.InsertOne(message);
        }

        internal void DeleteUserMessages(string username)
        {
            var filter = Builders<SimpleMessage>.Filter.Eq(s => s.User, username);
            collection.DeleteMany(filter);
        }
    }
}