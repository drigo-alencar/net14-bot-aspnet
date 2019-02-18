using System.Configuration;
using MongoDB.Driver;

namespace SimpleBot.Repositories
{
    public class UnitOfWork
    {
        private const string MONGO_CONNECTION_STRING_NAME = "Mongo";
        private const string MONGO_DATABASE = "BotBase";

        private readonly IMongoDatabase db;
        private MessageRepository messageRepository;
        private UserRepository userRepository;

        public UnitOfWork()
        {
            db = new MongoClient(GetConnectionString()).GetDatabase(MONGO_DATABASE);
        }

        public MessageRepository MessageRepository
        {
            get
            {
                if (messageRepository == null)
                {
                    messageRepository = new MessageRepository(db);
                }

                return messageRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(db);
                }

                return userRepository;
            }
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[MONGO_CONNECTION_STRING_NAME].ConnectionString;
        }

        //fazer para user
    }
}