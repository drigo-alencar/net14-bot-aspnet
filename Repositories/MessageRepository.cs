using System;
using MongoDB.Driver;
using SimpleBot.Logic;

namespace SimpleBot.Repositories
{
	public class MessageRepository
	{
		private const string COLLECTION_NAME = "Messages";

		private IMongoCollection<SimpleMessage> collection;

		public MessageRepository(IMongoDatabase db)
		{
			this.collection = db.GetCollection<SimpleMessage>(COLLECTION_NAME);
		}

		internal void Save(SimpleMessage message)
		{
			this.collection.InsertOne(message);
		}

		internal void DeleteUserMessages(string username)
		{
			var filter = Builders<SimpleMessage>.Filter.Eq(s => s.User, username);
			this.collection.DeleteMany(filter);
		}
	}
}