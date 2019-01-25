using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Logic
{
    public class SimpleBotUser
    {
        public string Reply(SimpleMessage message)
        {
            return $"{message.User} disse '{message.Text}";
        }

        UserProfile GetProfile(string id)
        {
            var db = new MongoClient().GetDatabase("BotBase");
            var filter = Builders<UserProfile>.Filter.Eq(u => u.Id, id);
            return db.GetCollection<UserProfile>("user_profiles").Find(filter).SingleOrDefault();
        }
    }
}