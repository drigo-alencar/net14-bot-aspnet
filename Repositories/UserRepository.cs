using MongoDB.Driver;
using SimpleBot.Logic;
using System.Linq;

namespace SimpleBot.Repositories
{
    public class UserRepository
    {
        private const string COLLECTION_NAME = "users";

        private IMongoCollection<SimpleBotUser> collection;

        public UserRepository(IMongoDatabase db)
        {
            collection = db.GetCollection<SimpleBotUser>(COLLECTION_NAME);
        }

        internal SimpleBotUser GetProfile(string id)
        {
            return collection.Find(Builders<SimpleBotUser>
                .Filter.Eq("Id", id)).FirstOrDefault();
        }

        internal void SetProfile(SimpleBotUser user)
        {
            user.Count += 1;

            collection.ReplaceOne(Builders<SimpleBotUser>.Filter.Eq(s => s.Id, user.Id), user);
        }

        //fazer os métodos 
    }
}